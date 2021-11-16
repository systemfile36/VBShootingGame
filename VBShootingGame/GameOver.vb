Public Class GameOver
	Private gameover_text As Image

	'스코어 정보를 가져오기 위한 변수
	Public score As ScoreManager

	Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
		Form1.Show()
		Me.Close()
	End Sub

	Private Sub btnTitle_Click(sender As Object, e As EventArgs) Handles btnTitle.Click
		StartUp.Show()
		Me.Close()
	End Sub

	Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
		Me.Close()
	End Sub

	Private Sub GameOver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'버튼 디자인 설정
		btnTitle.BackgroundImage = My.Resources.GoTitle_Default
		btnTitle.Text = ""
		btnReset.BackgroundImage = My.Resources.Restart_Default
		btnReset.Text = ""
		btnExit.BackgroundImage = My.Resources.GameQuit_Default
		btnExit.Text = ""

		gameover_text = My.Resources.GameOver

		Me.BackgroundImage = My.Resources.BackGround_0

		lbScore.Text = "Your Score : " & score.GetScore()

	End Sub

	'Reset 버튼---------------------------------------------------

	Private Sub btnReset_MouseMove(sender As Object, e As MouseEventArgs) Handles btnReset.MouseMove
		btnReset.BackgroundImage = My.Resources.Restart_Hover
	End Sub

	Private Sub btnReset_MouseLeave(sender As Object, e As EventArgs) Handles btnReset.MouseLeave
		btnReset.BackgroundImage = My.Resources.Restart_Default
	End Sub

	Private Sub btnReset_MouseDown(sender As Object, e As MouseEventArgs) Handles btnReset.MouseDown
		btnReset.BackgroundImage = My.Resources.Restart_Click
	End Sub

	Private Sub btnReset_MouseUp(sender As Object, e As MouseEventArgs) Handles btnReset.MouseUp
		btnReset.BackgroundImage = My.Resources.Restart_Default
	End Sub

	Private Sub btnReset_Enter(sender As Object, e As EventArgs) Handles btnReset.Enter
		btnReset.BackgroundImage = My.Resources.Restart_Hover
	End Sub

	Private Sub btnReset_Leave(sender As Object, e As EventArgs) Handles btnReset.Leave
		btnReset.BackgroundImage = My.Resources.Restart_Default
	End Sub

	'GoTitle버튼 -------------------------------------------------

	Private Sub btnTitle_MouseMove(sender As Object, e As MouseEventArgs) Handles btnTitle.MouseMove
		btnTitle.BackgroundImage = My.Resources.GoTitle_Hover
	End Sub

	Private Sub btnTitle_MouseLeave(sender As Object, e As EventArgs) Handles btnTitle.MouseLeave
		btnTitle.BackgroundImage = My.Resources.GoTitle_Default
	End Sub

	Private Sub btnTitle_MouseDown(sender As Object, e As MouseEventArgs) Handles btnTitle.MouseDown
		btnTitle.BackgroundImage = My.Resources.GoTitle_Click
	End Sub

	Private Sub btnTitle_MouseUp(sender As Object, e As MouseEventArgs) Handles btnTitle.MouseUp
		btnTitle.BackgroundImage = My.Resources.GoTitle_Default
	End Sub

	Private Sub btnTitle_Enter(sender As Object, e As EventArgs) Handles btnTitle.Enter
		btnTitle.BackgroundImage = My.Resources.GoTitle_Hover
	End Sub

	Private Sub btnTitle_Leave(sender As Object, e As EventArgs) Handles btnTitle.Leave
		btnTitle.BackgroundImage = My.Resources.GoTitle_Default
	End Sub

	Private Sub btnExit_MouseMove(sender As Object, e As MouseEventArgs) Handles btnExit.MouseMove
		btnExit.BackgroundImage = My.Resources.GameQuit_Hover
	End Sub

	Private Sub btnExit_MouseLeave(sender As Object, e As EventArgs) Handles btnExit.MouseLeave
		btnExit.BackgroundImage = My.Resources.GameQuit_Default
	End Sub

	Private Sub btnExit_MouseDown(sender As Object, e As MouseEventArgs) Handles btnExit.MouseDown
		btnExit.BackgroundImage = My.Resources.GameQuit_Click
	End Sub

	Private Sub btnExit_MouseUp(sender As Object, e As MouseEventArgs) Handles btnExit.MouseUp
		btnExit.BackgroundImage = My.Resources.GameQuit_Default
	End Sub

	Private Sub btnExit_Enter(sender As Object, e As EventArgs) Handles btnExit.Enter
		btnExit.BackgroundImage = My.Resources.GameQuit_Hover
	End Sub

	Private Sub btnExit_Leave(sender As Object, e As EventArgs) Handles btnExit.Leave
		btnExit.BackgroundImage = My.Resources.GameQuit_Default
	End Sub

	Private Sub GameOver_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
		e.Graphics.DrawImage(gameover_text, New Point(-20, -20))
	End Sub
End Class