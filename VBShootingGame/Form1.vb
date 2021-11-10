'게임이 실행되는 메인 폼
'객체 지향을 통해 다형성 구현
'처리 함수는 일관되게 하고 수정은 각 오브젝트 클래스에서 행함

Imports System.Threading
Imports System.Collections.Concurrent
Public Class Form1
	Private player As GameObject
	'Private OtherObjects As New List(Of GameObject)
	'Private OtherObjects As New ConcurrentQueue(Of GameObject)
	Private OtherObjects As New BlockingCollection(Of GameObject)
	Private p_control As InputKeys = InputKeys.None

	Private launch_control As Boolean = False

	'입력 갱신 스레드
	Private trd_input As Thread

	'기타 오브젝트 갱신 스레드
	Private trd_other As Thread

	Public Enum InputKeys
		Left
		Right
		Up
		Down
		Space
		None
	End Enum

	Public Const BoardWidth As Integer = 1200, BoardHeight As Integer = 600

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		player = New Player()

		'입력 스레드 생성 후 실행
		trd_input = New Thread(AddressOf ThreadInput)
		trd_input.IsBackground = True
		trd_input.Start()


		trd_other = New Thread(AddressOf ThreadOther)
		trd_other.IsBackground = True
		trd_other.Start()

		Me.KeyPreview = True
	End Sub

	Private Sub MainTimer_Tick(sender As Object, e As EventArgs) Handles MainTimer.Tick
		Invalidate()
	End Sub

	'키 입력이 들어오면 거기에 맞춰 방향을 설정만 함 갱신은 스레드에서
	Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

		If e.KeyCode = Keys.W Then
			p_control = InputKeys.Up
		ElseIf e.KeyCode = Keys.A Then
			p_control = InputKeys.Left
		ElseIf e.KeyCode = Keys.S Then
			p_control = InputKeys.Down
		ElseIf e.KeyCode = Keys.D Then
			p_control = InputKeys.Right
		ElseIf e.KeyCode = Keys.Space Then
			launch_control = True
		End If

	End Sub

	'키 입력이 해제되면 방향을 None으로 설정해서 멈추게 함
	Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
		p_control = InputKeys.None

	End Sub

	Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
		'플레이어를 그림
		e.Graphics.DrawImage(player.USprite, New Rectangle(player.UPos.X, player.UPos.Y, 122, 32))

		'다른 오브젝트를 그림
		For i As Integer = 0 To OtherObjects.Count - 1
			e.Graphics.DrawImage(OtherObjects(i).USprite, New Rectangle(OtherObjects(i).UPos.X, OtherObjects(i).UPos.Y, OtherObjects(i).UWidth, OtherObjects(i).UHeight))
		Next
		'lbDebug.Text = player.GetPos().X & " " & player.GetPos().Y
	End Sub

	'부드러운 움직임을 위해 스레드 사용
	'방향 변수를 감시하면서 일정하게 이동시킴
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

	Private Sub ThreadOther()
		Do
			If launch_control Then
				If OtherObjects.TryAdd(New Bullet(player, True), 10) Then
					Continue Do
				End If
				launch_control = False
			End If

			For i As Integer = 0 To OtherObjects.Count - 1
				Dim j = i
				With OtherObjects(i)
					.Move(-1)
					If .CheckDestroyed() Then
						If OtherObjects.TryTake(OtherObjects(j), 10) Then
							Continue Do
						End If
					End If
				End With
			Next
			Thread.Sleep(20)
		Loop
	End Sub

End Class
