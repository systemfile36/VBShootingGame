Imports System.Threading
Public Class Form1
	Private player As GameObject
	Private p_direction As InputKeys = InputKeys.None

	Private trd_input As Thread

	Public Enum InputKeys
		Left
		Right
		Up
		Down
		None
	End Enum

	Public Const BoardWidth As Integer = 1200, BoardHeight As Integer = 600

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		player = New Player()

		'입력 스레드 생성 후 실행
		trd_input = New Thread(AddressOf ThreadInput)
		trd_input.IsBackground = True
		trd_input.Start()

		Me.KeyPreview = True
	End Sub

	Private Sub MainTimer_Tick(sender As Object, e As EventArgs) Handles MainTimer.Tick
		Invalidate()
	End Sub

	'키 입력이 들어오면 거기에 맞춰 방향을 설정만 함 갱신은 스레드에서
	Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

		If e.KeyCode = Keys.W Then
			p_direction = InputKeys.Up
		ElseIf e.KeyCode = Keys.A Then
			p_direction = InputKeys.Left
		ElseIf e.KeyCode = Keys.S Then
			p_direction = InputKeys.Down
		ElseIf e.KeyCode = Keys.D Then
			p_direction = InputKeys.Right
		ElseIf e.KeyCode = Keys.Space Then

		End If

	End Sub

	'키 입력이 해제되면 방향을 None으로 설정해서 멈추게 함
	Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
		p_direction = InputKeys.None
	End Sub

	Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
		e.Graphics.DrawImage(player.USprite, New Rectangle(player.UPos.X, player.UPos.Y, 122, 32))
		'lbDebug.Text = player.GetPos().X & " " & player.GetPos().Y
	End Sub

	'부드러운 움직임을 위해 스레드 사용
	'방향 변수를 감시하면서 일정하게 이동시킴
	Private Sub ThreadInput()
		Do
			Select Case p_direction
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
End Class
