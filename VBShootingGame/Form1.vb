'게임이 실행되는 메인 폼
'객체 지향을 통해 다형성 구현 + 후일 확장성 확보
'처리 함수는 일관되게 하고 수정은 각 오브젝트 클래스에서 행함
'ex)각 객체에 자신의 좌표를 변경하는 Move함수가 오버로딩 되어 있음
'	갱신 할때 Move함수를 호출만 하면 됨, 오류가 생기면 그 객체만 고치면 됨
'삭제 과정에서 오버헤드 가능성 있음
'Resource를 사용하여 모든 리소스 파일이 실행파일에 합쳐집니다!
'총탄과 적 처리에서 삭제용 배열과 추가용 배열을 따로 만듬 (열거 오류 예방)
'enum loop안에서 리스트를 수정하면 오류가 나기 때문
'20211111 21:57 이동방식을 F로 수동으로 멈추는 것으로 변환
'	움직임이 더욱 부드러워짐


Imports System.Threading
Imports System.Collections.Concurrent
Public Class Form1
	Private player As GameObject

	'적 생성 간격 변수
	Private TermTickEnemy As Long = 50000000L
	Private DelayTickEnemy As Long = 0

	'ThreadOther에서 조작하는 기타 오브젝트 List<T>
	Private OtherObjects As New List(Of GameObject)

	'고유 아이디 부여를 위한 변수
	Private NumberofObj As Integer = 0

	'플레이어 컨트롤 변수
	Private p_control As InputKeys = InputKeys.None

	'입력 갱신 스레드
	Private trd_input As Thread

	'기타 오브젝트 갱신 스레드
	Private trd_other As Thread

	'난수 생성기
	Private rand As New Random()

	Public Enum InputKeys
		Left
		Right
		Up
		Down
		Space
		None
	End Enum

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

	'키 입력이 들어오면 거기에 맞춰 방향을 설정만 함 갱신은 스레드에서
	'F를 입력하면 p_control을 None으로 만들어서 멈추게 함
	'스페이스(발사)입력이 들어오면 IsFire플래그를 True로 바꾸고 스레드에서 참조
	Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

		If e.KeyCode = Keys.W Then
			p_control = InputKeys.Up
		ElseIf e.KeyCode = Keys.A Then
			p_control = InputKeys.Left
		ElseIf e.KeyCode = Keys.S Then
			p_control = InputKeys.Down
		ElseIf e.KeyCode = Keys.D Then
			p_control = InputKeys.Right
		ElseIf e.KeyCode = Keys.F Then
			p_control = InputKeys.None
		ElseIf e.KeyCode = Keys.Space Then
			player.IsFire = True
		End If

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
	'방향 변수를 감시하면서 버튼 이벤트에서 반영된 값을 참조함
	Private Sub ThreadInput()
		Do
			Select Case p_control
				Case InputKeys.Up
					player.Move(InputKeys.Up)
				Case InputKeys.Left
					player.Move(InputKeys.Left)
				Case InputKeys.Down
					player.Move(InputKeys.Down)
				Case InputKeys.Right
					player.Move(InputKeys.Right)
			End Select
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
				If Now.Ticks - DelayTickEnemy > TermTickEnemy Then
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
					obj.Move(-1)
					'파괴 확인
					If obj.CheckDestroyed() Then
						'파괴할 물건을 저장 (열거 오류를 막기위해)
						removeObj.Add(obj)
					End If

					'enemy인지 판단하고 enemy타입으로 하향 형변환한다.

					If obj.IsEnemy Then
						Dim temp = TryCast(obj, Enemy)
						'enemy타입이 맞다면 시간비교함수 호출해서 플래그 셋팅
						If Not (temp Is Nothing) Then
							temp.EnemyCanShot()

							If temp.IsFire Then
								'다형성으로 부모자리에 자식을 넣을 수 있다.
								'추가할 물건 저장
								addObj.Add(New Bullet(temp, False, NumberofObj))
								temp.IsFire = False
							End If
						End If
					End If


				Next

				'실제 삭제 반영
				For Each obj As GameObject In removeObj
					'removeObj에 있는 것과 같은 아이디를 가진 물건 삭제
					If OtherObjects.Remove(obj) Then
						NumberofObj -= 1
					End If
				Next

				'실제 추가 반영
				For Each obj As GameObject In addObj
					OtherObjects.Add(obj)
					NumberofObj += 1
				Next

				'삭제를 위한 배열 비우기
				removeObj.Clear()
				'추가를 위한 배열 비우기
				addObj.Clear()

			Catch ex As Exception
				Task.Run(Sub()
							 MsgBox(ex.ToString())
						 End Sub)
			End Try
			Thread.Sleep(20)
		Loop
	End Sub

End Class
