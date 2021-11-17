'게임이 실행되는 메인 폼
'객체 지향을 통해 다형성 구현 + 후일 확장성 확보
'그 객체에 관한 변경은 그 객체에서 담당하게 만듬
'유니티랑 비슷한 방식으로 만듬, 게임 엔진이 해주던걸 직접 할 뿐...
'Resource를 사용하여 모든 리소스 파일이 실행파일에 합쳐집니다!
'총탄과 적 처리에서 삭제용 배열과 추가용 배열을 따로 만듬 (열거 오류 예방)
'	이때 삭제용과 추가용 배열은 반영하고 나면 다시 비워야 함(안그러면 중복)
'	enum loop안에서 리스트를 수정하면 오류가 나기 때문
'20211111 21:57 이동방식을 F로 수동으로 멈추는 것으로 변환
'충돌 구현
'	충돌 범위(콜라이더)를 오브젝트 크기와 위치를 이용해 Rentangle형태로 설정한다.
'	그리고 Move함수 호출 시 마다 갱신한다.
'	충돌 함수에서 obj를 받아서 각 사각형의 점이 자신의 충돌 범위에 포함되면
'	자신과 obj를 파괴한다.
'	충돌 함수는 GameObject의 것을 오버라이딩해서 쓴다.
'GameObject에 타입 변수 추가

'플레이어 객체를 변경하는 함수를 전부 메소드 내부로 이동, 캡슐화 강화

'객체는 참조형 변수이므로 For Each 내부에서 수정하면 원본 객체에 반영됨
'하지만 내부에서 obj에 Nothing 같은 걸 넣는다 해서 리스트 내부가 변경 되진 않음

'연사 속도 추가 (기본 0.4초) (Set/GetFireDelay추가, ReleaseControl추가)

'파괴 시 콜라이더의 크기 0으로 변경, 파괴되어도 딜레이에 도달하기 전까진
'배열에 남아서 그려짐(파괴 모션을 위함), 즉 실제 반영에 딜레이를 줌

'GameSounds 객체의 Play는 오버헤드가 심해 발사음 같이 반복되는 곳에 사용하면 느려짐
'따라서 My.Computer.Audio.Play 사용

Imports System.Threading
Public Class Form1
	Private player As Player

	'스코어 관리
	Private scoreBoard As New ScoreManager()

	'게임 진행 관리
	Private game As New GameManager()

	'게임 소리 관리
	Private sound As New GameSounds

	'게임의 메인 루프
	Private MainLoop As System.Timers.Timer

	'파괴된 시점부터 삭제될 때까지의 딜레이, 프레임 단위
	Private DestroyDelay As Integer = 20

	'기타 오브젝트 List<T>
	Private OtherObjects As New List(Of GameObject)

	'파괴 오브젝트 임시 보관용 List<T>
	Private removeObj As New List(Of GameObject)

	'생성된 오브젝트 임시 보관용 List<T>
	Private addObj As New List(Of GameObject)

	'난수 생성기
	Private rand As New Random()

	'게임 시간을 밀리세컨드로 변환해서 오브젝트 아이디로 사용(삭제 시 Equal()구현 위함)

	'캔버스 크기 상수
	Public Const BoardWidth As Integer = 1200, BoardHeight As Integer = 600

	'배경 변화를 위한 변수
	Private bg0 As Image, bg1 As Image
	Private bg0_x As Integer = 0, bg1_x As Integer = BoardWidth

	'게임 종료 여부
	Private IsGameEnd As Boolean = False

	'호출 시간 (ms단위)
	Private MainLoopInterval As Integer = 14
	Private MainTimerInterval As Integer = 20


	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		player = New Player()

		'게임 관리에 시작시간 등록
		game.SetSTime(player.SpawnedTime)

		'My.Settings 내용 반영
		ApplySetting()

		'배경 셋팅
		bg0 = My.Resources.BackGround_0
		bg1 = My.Resources.BackGround_0

		'메인 타이머
		'UI Thread에서 작동 해야하는 것만 담당
		MainTimer.Interval = 20
		MainTimer.Enabled = True

		'리스트 사이즈를 미리 넓혀 놓는다.
		OtherObjects.Capacity = 500
		removeObj.Capacity = 200
		addObj.Capacity = 200

		'배경 음악 세팅
		sound.AddSound("BGM", "Sound/bgm.mp3")
		sound.Play("BGM", True)
		sound.SetVolume("BGM", 300)

		'메인 루프를 담당하는 System.Timers.Timer
		'모든 오브젝트 갱신 담당
		'다른 스레드에서 돌아가는 일정한 타이머임
		MainLoop = New System.Timers.Timer(MainLoopInterval)
		AddHandler MainLoop.Elapsed, AddressOf TimerEvent
		MainLoop.AutoReset = True
		MainLoop.Enabled = True

		Me.KeyPreview = True
	End Sub

	Private Sub TimerEvent()
		'플레이어 이동 갱신
		player.Move()

		'오브젝트 갱신
		RefreshOtherObjects()

		'배경 움직임을 위한 로직
		bg0_x -= 1
		bg1_x -= 1
		If bg0_x <= -BoardWidth Then
			bg0_x = BoardWidth - 2
		End If

		If bg1_x <= -BoardWidth Then
			bg1_x = BoardWidth - 2
		End If

		'화면 갱신
		Invalidate()
	End Sub

	Private Sub MainTimer_Tick(sender As Object, e As EventArgs) Handles MainTimer.Tick
		If IsGameEnd Then
			EndGame()
		End If

		lbDebug.Text = game.GetGameSec() & " " & game.GetDifficulty() & " " & MainLoopInterval
	End Sub

	'키 입력이 들어오면 Player객체의 SetControl() 메소드에 키 코드를 넘김
	'플래그 갱신은 객체 내부에서 이루어짐
	'실제 좌표 변경은 MainTimer에서 Move()메소드를 통해이루어짐
	'이렇게 하면 컨트롤 요소가 추가 되어도 플레이어 객체만 수정하면 됨
	Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
		player.SetControl(e.KeyCode)

		'일시정지 키와 종료 연결
		If e.KeyCode = Keys.Back Then
			PauseGameToggle()
		ElseIf e.KeyCode = Keys.C Then
			EndGame()
		End If

	End Sub
	'버튼에서 손을 뗏음을 알려주는 변수
	Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
		player.ReleaseControl(e.KeyCode)
	End Sub

	Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint

		'배경 움직임 구현
		e.Graphics.DrawImage(bg0, New Rectangle(bg0_x, 0, BoardWidth, BoardHeight))
		e.Graphics.DrawImage(bg1, New Rectangle(bg1_x, 0, BoardWidth, BoardHeight))

		'플레이어를 그림
		e.Graphics.DrawImage(player.USprite, New Rectangle(player.UPos.X, player.UPos.Y, player.UWidth, player.UHeight - 40))

		'충돌 범위 가시화용
		'e.Graphics.DrawRectangle(New Pen(Color.Red), player.UCollider)

		'열거 오류 예방
		Try
			For Each obj As GameObject In OtherObjects
				'파괴 되었으면 파괴 이펙트 표시
				If obj.GetIsDest() Then
					e.Graphics.DrawImage(obj.UDSprite, New Rectangle(obj.UPos.X, obj.UPos.Y, obj.DWidth, obj.DHeight))
				Else
					e.Graphics.DrawImage(obj.USprite, New Rectangle(obj.UPos.X, obj.UPos.Y, obj.UWidth, obj.UHeight))

					'충돌 범위 가시화용
					'e.Graphics.DrawRectangle(New Pen(Color.Red), obj.UCollider)
				End If
			Next
		Catch ex As Exception

		End Try
		'lbDebug.Text = game.GetGameSec() & " " & game.GetDifficulty() & " "
	End Sub

	Delegate Sub SoundEventDelegate()

	'플레이어 외 오브젝트 갱신
	'사실상 메인 루프
	Private Sub RefreshOtherObjects()

		'디버깅용 Try문
		Try
			'적 생성
			If game.CheckSpawnEnemy() Then

				'적 스폰 위치 랜덤
				'난이도를 전달해서 발사 간격 조정
				OtherObjects.Add(New Enemy(game.GetGameMil(), rand.Next(40, 500), game.GetDifficulty()))

				game.ResetDelayTickEnemy()

			End If

			'총탄 생성
			'CheckFireDelay()가 True를 반환하면 총탄 생성
			If player.CheckFireDelay() Then
				OtherObjects.Add(New Bullet(player, True, game.GetGameMil()))

				'발사음 재생
				My.Computer.Audio.Play(My.Resources.Laser_one, AudioPlayMode.Background)
			End If

			'오브젝트들 갱신
			For Each obj As GameObject In OtherObjects
				'파괴되지 않았을때만 이동 함수 호출
				If Not obj.GetIsDest() Then
					obj.Move()
				End If

				'enemy인지 판단하고 enemy타입으로 하향 형변환한다.
				'enemy 발사 시퀀스 확인
				If obj.UType = GameObject.Type.Enemy Then
					Dim temp = TryCast(obj, Enemy)
					'enemy타입이 맞다면 시간비교함수 호출해서 플래그 셋팅
					If Not (temp Is Nothing) Then
						If temp.CheckFireTerm() Then
							'다형성으로 부모자리에 자식을 넣을 수 있다.
							'추가할 물건 저장
							addObj.Add(New Bullet(temp, False, game.GetGameMil()))
							temp.IsFire = False
						End If
					End If
				End If

				'충돌 판정을 위해 한번 더 루프를 돌며 충돌판정 함수 호출
				'오브젝트가 아직 파괴되지 않았다면
				If Not obj.GetIsDest() Then
					'총탄의 CollisionCheck는 아무것도 하지 않는다
					'탄의 타입체크는 각 충돌 판정에서 행한다.

					'적들의 충돌 판정 함수 실행
					For Each obj_c As GameObject In OtherObjects
						'만약 적의 충돌함수가 True를 반환했다면( = 격추되었다면)
						If obj_c.CollisionCheck(obj) Then
							'격추 수를 올린다.
							scoreBoard.IncKillCount()
						End If
					Next
					'플레이어의 충돌 판정 함수 실행
					player.CollisionCheck(obj)
				End If

				'파괴 확인
				If obj.Destroy() Then
					'파괴할 물건을 저장 (열거 오류를 막기위해)

					removeObj.Add(obj)
				End If
			Next

			'Player가 파괴되면 게임을 끝낸다.
			'System.Timers.Timer 사용을 위해 플래그 사용(크로스 스레드)
			If player.Destroy() Then
				IsGameEnd = True
			End If

			'실제 삭제 반영
			'파괴 딜레이에 도달한 물건만 삭제(파괴 모션을 위함)
			'DestroyCount는 Destroy()가 호출 될때마다(한 프레임마다) 1씩 증가
			For Each obj As GameObject In removeObj
				If obj.GetDestroyCounter() > DestroyDelay Then
					'removeObj에 있는 것과 같은 아이디를 가진 물건 삭제
					OtherObjects.Remove(obj)

				End If
			Next

			'실제 추가 반영
			For Each obj As GameObject In addObj

				OtherObjects.Add(obj)
			Next

			'삭제를 위한 배열 비우기
			removeObj.Clear()
			'추가를 위한 배열 비우기
			addObj.Clear()

			'게임 시간 체크 후 난이도 상승
			game.IncDifficulty()

		Catch ex As Exception
			'이렇게 출력하면 게임은 멈추지 않음
			Task.Run(Sub()
						 MsgBox(ex.ToString())
					 End Sub)
		End Try
	End Sub

	'일시 정지 메뉴
	'화면 갱신 타이머도 멈춘다. 음악도 멈춘다.
	'게임 시간도 반영해준다.
	Private Sub PauseGameToggle()
		'일시정지 한다.
		game.PauseTime()
		MainTimer.Stop()
		MainLoop.Stop()
		sound.Pause("BGM")

		'넘겨줄 스코어를 설정하고 일시 정지 메뉴 폼의 인스턴스를 만든다.
		scoreBoard.SetScore(game.GetGameSec)

		Dim pauseForm As New PauseMenu()
		pauseForm.Score = scoreBoard.GetScore()
		pauseForm.GameTime = game.GetGameSec()

		'ShowDialog()로 연다.
		pauseForm.ShowDialog()

		'만약 Resume버튼이 눌렸다면(=DialogResult.OK) 게임을 재개하고 아니면 종료한다.
		If pauseForm.DialogResult = DialogResult.OK Then
			game.ResumeTime()
			MainTimer.Start()
			MainLoop.Start()
			sound.Resume("BGM")
			pauseForm.Dispose()
		Else
			pauseForm.Dispose()
			Me.Close()
		End If


	End Sub

	'게임 종료 함수 
	'모든 스레드와 타이머를 끄고 게임 오버창을 연 뒤 현재 폼을 닫는다.
	'음악도 꺼주어야 함
	Private Sub EndGame()
		'점수 설정
		scoreBoard.SetScore(game.GetGameSec())
		Dim gameover As New GameOver()
		gameover.score = scoreBoard
		gameover.Show()
		MainTimer.Stop()
		MainLoop.Enabled = False
		sound.Stop("BGM")
		Thread.Sleep(10)
		Me.Close()
	End Sub

	Private Sub ApplySetting()

		MainLoopInterval = My.Settings.ML_Interval
		If MainLoopInterval < 10 Then
			MainLoopInterval = 10
		ElseIf MainLoopInterval > 30 Then
			MainLoopInterval = 30
		End If

		MainTimerInterval = My.Settings.MLT_Interval
		If MainTimerInterval < 10 Then
			MainTimerInterval = 10
		ElseIf MainTimerInterval > 30 Then
			MainLoopInterval = 30
		End If

		'범위 제한은 메소드에서
		game.SetSpawnTerm(My.Settings.ESpawnTerm)
		game.SetDifTerm(My.Settings.DifTerm)

		player.USpeed = My.Settings.PSpeed
		'최소값 1, 최대값 25
		If player.USpeed < 1 Then
			player.USpeed = 1
		ElseIf player.USpeed > 25 Then
			player.USpeed = 25
		End If

		'범위 제한은 메소드에서
		player.SetFireDelay(My.Settings.PFireDelay)

		My.Settings.Save()

	End Sub

End Class