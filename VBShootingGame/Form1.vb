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

Imports System.Threading
Public Class Form1
	Private player As Player

	'스코어 관리
	Private scoreBoard As New ScoreManager()

	'게임 진행 관리
	Private game As New GameManager()

	'파괴된 시점부터 삭제될 때까지의 딜레이, 프레임 단위
	Private DestroyDelay As Integer = 20

	'ThreadOther에서 조작하는 기타 오브젝트 List<T>
	Private OtherObjects As New List(Of GameObject)

	'입력 갱신 스레드
	Private trd_input As Thread

	'기타 오브젝트 갱신 스레드
	Private trd_other As Thread

	'난수 생성기
	Private rand As New Random()

	'게임 시간을 밀리세컨드로 변환해서 오브젝트 아이디로 사용(삭제 시 Equal()구현 위함)

	'스레드 일시 정지를 위한 변수
	'AutoResetEvent = 하나의 스레드를 멈추면 자동으로 Reset(False로 바뀜)
	'MenualResetEvent = 수동으로 Reset호출해야 함
	Private PauseThread_Input As New AutoResetEvent(False)
	Private PauseThread_Other As New AutoResetEvent(False)

	'스레드의 종료를 위한 변수
	'폼이 닫혀도 스레드는 프로그램이 꺼질 때까지 남으므로 종료 해주어야함
	Private CloseThread As New ManualResetEvent(False)

	'일시 정지 여부 변수(토글을 위해 참조)
	Private IsPause As Boolean = False

	'타이머에서 참조, 스레드에서 종료 함수를 부를 수 없기에
	Private IsGameEnd As Boolean = False

	'캔버스 크기 상수
	Public Const BoardWidth As Integer = 1200, BoardHeight As Integer = 600

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		player = New Player()

		'게임 관리에 시작시간 등록
		game.SetSTime(player.SpawnedTime)

		BackgroundImage = My.Resources.ResourceManager.GetObject("BackGround_0")

		MainTimer.Interval = 15

		'입력 스레드 생성 후 실행
		trd_input = New Thread(AddressOf ThreadInput)
		trd_input.IsBackground = True
		trd_input.Start()

		'오브젝트 갱신용 스레드 생성 후 실행
		trd_other = New Thread(AddressOf ThreadOther)
		trd_other.IsBackground = True
		trd_other.Start()

		Me.KeyPreview = True
	End Sub

	Private Sub MainTimer_Tick(sender As Object, e As EventArgs) Handles MainTimer.Tick
		'화면 갱신
		Invalidate()

		If IsGameEnd Then
			EndGame()
		End If
	End Sub

	'키 입력이 들어오면 Player객체의 SetControl() 메소드에 키 코드를 넘김
	'플래그 갱신은 객체 내부에서 이루어짐
	'실제 좌표 변경은 ThreadInput()에서 Move()메소드를 통해이루어짐
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

		'플레이어를 그림
		e.Graphics.DrawImage(player.USprite, New Rectangle(player.UPos.X, player.UPos.Y, player.UWidth, player.UHeight - 40))

		'충돌 범위 가시화용
		'e.Graphics.DrawRectangle(New Pen(Color.Red), player.UCollider)

		'열거 오류 예외 처리
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
		lbDebug.Text = game.GetGameSec() & " " & game.GetDifficulty()
	End Sub

	'부드러운 움직임을 위해 스레드 사용
	'플레이어의 Move()메소드를 호출할 뿐
	'방향에 따른 좌표 변환은 메소드에서 이루어짐
	Private Sub ThreadInput()
		Do
			player.Move()

			'AutoResetEvent 신호를 보내면(True로 바뀌면) if 문 실행
			If PauseThread_Input.WaitOne(0) Then
				'이 시점에서 자동으로 다시 False로 바뀐다.

				'다시 True로 바뀔 때까지 대기한다.
				PauseThread_Input.WaitOne()
				'여기서 다시 False로 리셋되므로 다음 루프때 다시 멈추는 일 없음
			End If

			If CloseThread.WaitOne(0) Then
				Exit Sub
			End If

			Thread.Sleep(20)
		Loop

	End Sub

	'플레이어 외 오브젝트 갱신
	Private Sub ThreadOther()
		'삭제할 물건 저장용 리스트
		Dim removeObj As New List(Of GameObject)

		'추가할 적탄 리스트
		Dim addObj As New List(Of GameObject)
		Do
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

				'Player가 파괴되면 게임 종료 플래그를 True로 바꾼다
				'이 플래그는 타이머에서 참조한다.(게임 종료함수에 폼 열기가 포함되어 있기에)
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

			Catch ex As Exception
				'이렇게 출력하면 게임은 멈추지 않음
				Task.Run(Sub()
							 MsgBox(ex.ToString())
						 End Sub)
			End Try

			'게임 시간 체크 후 난이도 상승
			game.IncDifficulty()

			'AutoResetEvent 신호를 보내면(True로 바뀌면) if 문 실행
			If PauseThread_Other.WaitOne(0) Then
				'이 시점에서 자동으로 다시 False로 바뀐다.

				'다시 True로 바뀔 때까지 대기한다.
				PauseThread_Other.WaitOne()
				'여기서 다시 False로 리셋되므로 다음 루프때 다시 멈추는 일 없음
			End If

			If CloseThread.WaitOne(0) Then
				Exit Sub
			End If

			Thread.Sleep(20)
		Loop

	End Sub

	'일시 정지 메뉴
	'각 스레드의 AutoResetEvent를 True로 바꾼다.
	'그러면 Thread내부에서 False로 바뀌고 다시 True로 바뀌는 것을 대기한다.(일시정지)
	'화면 갱신 타이머도 멈춘다.
	'게임 시간도 반영해준다.
	Private Sub PauseGameToggle()
		'일시정지 한다.
		game.PauseTime()
		PauseThread_Input.Set()
		PauseThread_Other.Set()
		MainTimer.Stop()

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
			PauseThread_Input.Set()
			PauseThread_Other.Set()
			MainTimer.Start()
			pauseForm.Dispose()
		Else
			pauseForm.Dispose()
			Me.Close()
		End If


	End Sub

	'게임 종료 함수 
	'모든 스레드와 타이머를 끄고 게임 오버창을 연 뒤 현재 폼을 닫는다.
	Private Sub EndGame()
		'점수 설정
		scoreBoard.SetScore(game.GetGameSec())
		Dim gameover As New GameOver()
		gameover.score = scoreBoard
		gameover.Show()
		CloseThread.Set()
		MainTimer.Stop()
		Thread.Sleep(10)
		Me.Close()
	End Sub

End Class