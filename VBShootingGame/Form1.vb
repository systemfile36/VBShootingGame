'게임이 실행되는 메인 폼
'객체 지향을 통해 다형성 구현 + 후일 확장성 확보
'그 객체에 관한 변경은 그 객체에서 담당하게 만듬(디자인 패턴)
'삭제 과정에서 오버헤드 가능성 있음
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
'GameObject 타입 변수 추가

'플레이어 객체를 변경하는 함수를 전부 메소드 내부로 이동, 캡슐화 강화

Imports System.Threading
Public Class Form1
	Private player As Player

	'적 생성 간격 변수
	Private SpawnTerm As Long = 50000000L
	Private DelayTickEnemy As Long = 0

	'ThreadOther에서 조작하는 기타 오브젝트 List<T>
	Private OtherObjects As New List(Of GameObject)

	'고유 아이디 부여를 위한 변수
	Private NumberofObj As Integer = 0

	'입력 갱신 스레드
	Private trd_input As Thread

	'기타 오브젝트 갱신 스레드
	Private trd_other As Thread

	'난수 생성기
	Private rand As New Random()

	'입력 키 열거형


	'캔버스 크기 상수
	Public Const BoardWidth As Integer = 1200, BoardHeight As Integer = 600

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		player = New Player()

		'입력 스레드 생성 후 실행
		trd_input = New Thread(AddressOf ThreadInput)
		trd_input.IsBackground = True
		trd_input.Start()

		'다른 오브젝트 갱신용 스레드 생성 후 실행
		trd_other = New Thread(AddressOf ThreadOther)
		trd_other.IsBackground = True
		trd_other.Start()

		'적 생성 간격용
		DelayTickEnemy = Now.Ticks


		Me.KeyPreview = True
	End Sub

	Private Sub MainTimer_Tick(sender As Object, e As EventArgs) Handles MainTimer.Tick
		'화면 갱신
		Invalidate()
	End Sub

	'키 입력이 들어오면 Player객체의 SetControl() 메소드에 키 코드를 넘김
	'플래그 갱신은 객체 내부에서 이루어짐
	'실제 좌표 변경은 ThreadInput()에서 Move()메소드를 통해이루어짐 
	Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
		player.SetControl(e.KeyCode)
	End Sub

	Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
		'플레이어를 그림
		e.Graphics.DrawImage(player.USprite, New Rectangle(player.UPos.X, player.UPos.Y, 122, 32))

		'열거 오류 예외 처리
		Try
			For Each obj As GameObject In OtherObjects
				e.Graphics.DrawImage(obj.USprite, New Rectangle(obj.UPos.X, obj.UPos.Y, obj.UWidth, obj.UHeight))
			Next
		Catch ex As Exception
			lbDebug.Text = "Exception Iter"
		End Try
		lbDebug.Text = NumberofObj
	End Sub

	'부드러운 움직임을 위해 스레드 사용
	'플레이어의 Move()메소드를 호출할 뿐
	'방향에 따른 좌표 변환은 메소드에서 이루어짐
	Private Sub ThreadInput()
		Do
			player.Move()
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
				If Now.Ticks - DelayTickEnemy > SpawnTerm Then
					NumberofObj += 1
					OtherObjects.Add(New Enemy(NumberofObj))

					DelayTickEnemy = Now.Ticks
				End If

				'총탄 생성
				'IsFire 플래그가 True면 총탄을 생성 후 플래그 False로 변경
				'한번 발사 할때마다 플래그를 False로 변경하므로 한번의 입력으론 한번만 발사
				'지속 입력의 경우엔 예외
				If player.IsFire Then
					NumberofObj += 1
					OtherObjects.Add(New Bullet(player, True, NumberofObj))

					player.IsFire = False
				End If

				'오브젝트들 갱신
				For Each obj As GameObject In OtherObjects
					obj.Move()

					'enemy인지 판단하고 enemy타입으로 하향 형변환한다.
					'enemy 발사 시퀸스 확인
					If obj.UType = GameObject.Type.Enemy Then
						Dim temp = TryCast(obj, Enemy)
						'enemy타입이 맞다면 시간비교함수 호출해서 플래그 셋팅
						If Not (temp Is Nothing) Then
							temp.EnemyCanShot()

							If temp.IsFire Then
								'다형성으로 부모자리에 자식을 넣을 수 있다.
								'추가할 물건 저장
								NumberofObj += 1
								addObj.Add(New Bullet(temp, False, NumberofObj))
								temp.IsFire = False
							End If
						End If
					End If

					'충돌 판정을 위해 한번 더 루프를 돌며 충돌판정 함수 호출
					'오브젝트가 아직 파괴되지 않은 탄이라면
					If obj.UType = GameObject.Type.PBullet And Not obj.Destroy() Then
						'적들의 충돌 판정 함수 실행
						'총탄의 CollisionCheck는 아무것도 하지 않으므로
						'적들의 것만이 작동한다.
						For Each obj_c As GameObject In OtherObjects
							obj_c.CollisionCheck(obj)
						Next
					End If

					'파괴 확인
					If obj.Destroy() Then
						'파괴할 물건을 저장 (열거 오류를 막기위해)
						NumberofObj -= 1
						removeObj.Add(obj)
					End If


				Next

				'실제 삭제 반영
				For Each obj As GameObject In removeObj
					'removeObj에 있는 것과 같은 아이디를 가진 물건 삭제
					OtherObjects.Remove(obj)

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
			Thread.Sleep(20)
		Loop
	End Sub

	Private Sub SetSpawnTerm(second As Integer)
		SpawnTerm = second * 10000000
	End Sub

End Class
