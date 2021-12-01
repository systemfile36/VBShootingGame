Public Class GameOver
	Private gameover_text As Image

	'스코어 정보를 가져오기 위한 변수
	Public score As ScoreManager

	Private Sub GameOver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'버튼 디자인 설정

		btnScoreBoard.Text = ""
		btnScoreBoard.BackgroundImage = My.Resources.ScoreBoard_Default

		gameover_text = My.Resources.GameOver

		Me.BackgroundImage = My.Resources.BackGround_0

		lbScore.Text = "Your Score : " & score.GetScore()

		Me.KeyPreview = True
		Task.Run(Sub()
					 System.Threading.Thread.Sleep(100)
					 My.Computer.Audio.Play(My.Resources.GameOverSE, AudioPlayMode.Background)
				 End Sub)

	End Sub


	Private Sub GameOver_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
		'방향키와 엔터키 이외에는 무시한다.(오입력 방지)
		If Not (e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down) Then
			e.Handled = True
		End If
	End Sub

	Private Sub GameOver_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
		e.Graphics.DrawImage(gameover_text, New Point(-20, -20))
	End Sub


	'버튼 디자인
	Private Sub btnSB_MouseEnter(sender As Object, e As EventArgs) Handles btnScoreBoard.MouseEnter
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
	End Sub

	Private Sub btnSB_MouseMove(sender As Object, e As MouseEventArgs) Handles btnScoreBoard.MouseMove
		btnScoreBoard.BackgroundImage = My.Resources.ScoreBoard_Hover
	End Sub

	Private Sub btnSB_MouseLeave(sender As Object, e As EventArgs) Handles btnScoreBoard.MouseLeave
		btnScoreBoard.BackgroundImage = My.Resources.ScoreBoard_Default
	End Sub

	Private Sub btnSB_MouseDown(sender As Object, e As MouseEventArgs) Handles btnScoreBoard.MouseDown
		btnScoreBoard.BackgroundImage = My.Resources.ScoreBoard_Click
	End Sub

	Private Sub btnSB_MouseUp(sender As Object, e As MouseEventArgs) Handles btnScoreBoard.MouseUp
		btnScoreBoard.BackgroundImage = My.Resources.ScoreBoard_Default
	End Sub

	Private Sub btnSB_Enter(sender As Object, e As EventArgs) Handles btnScoreBoard.Enter
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
		btnScoreBoard.BackgroundImage = My.Resources.ScoreBoard_Hover
	End Sub

	Private Sub btnSB_Leave(sender As Object, e As EventArgs) Handles btnScoreBoard.Leave
		btnScoreBoard.BackgroundImage = My.Resources.ScoreBoard_Default
	End Sub

	Private Sub btnScoreBoard_Click(sender As Object, e As EventArgs) Handles btnScoreBoard.Click
		Me.Close()
	End Sub

	Private Sub GameOver_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
		Dim result As MsgBoxResult = MsgBox("스코어를 저장하시겠습니까?", vbYesNo)
		If result = MsgBoxResult.Yes Then
			Dim sb As New ScoreBoard()
			sb.score = score
			sb.Show()
		ElseIf result = MsgBoxResult.No Then
			StartUp.Show()
		End If
	End Sub
End Class