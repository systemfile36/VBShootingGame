'이 폼은 Form1에서 ShowDialog()로 열어서 참조함
Public Class PauseMenu
	Public Score As Long = 0
	Public GameTime As Integer = 0
	Private Sub PauseMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		lbScore.Text = "Score : " & Score
		lbTime.Text = "Time : " & GameTime & "s"

		btnResume.BackgroundImage = My.Resources.Resume_Default
		btnResume.Text = ""

		btnExit.BackgroundImage = My.Resources.GameQuit_Default
		btnExit.Text = ""

		btnTitle.BackgroundImage = My.Resources.GoTitle_Default
		btnTitle.Text = ""

		'DialogResult로 Form1에서 참조
		btnResume.DialogResult = DialogResult.OK
		btnExit.DialogResult = DialogResult.Cancel
		btnTitle.DialogResult = DialogResult.No

		Me.KeyPreview = True

	End Sub

	Private Sub PauseMenu_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
		'방향키와 엔터키 이외에는 무시한다.(오입력 방지)
		If Not (e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down) Then
			e.Handled = True
		End If
	End Sub

	'Quit Game버튼-----------------------------------------------------
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
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
		btnExit.BackgroundImage = My.Resources.GameQuit_Hover
	End Sub

	Private Sub btnExit_Leave(sender As Object, e As EventArgs) Handles btnExit.Leave
		btnExit.BackgroundImage = My.Resources.GameQuit_Default
	End Sub

	Private Sub btnExit_MouseEnter(sender As Object, e As EventArgs) Handles btnExit.MouseEnter
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
	End Sub

	'Resume 버튼 -----------------------------------------------
	Private Sub btnResume_MouseDown(sender As Object, e As MouseEventArgs) Handles btnResume.MouseDown
		btnResume.BackgroundImage = My.Resources.Resume_Click
	End Sub

	Private Sub btnResume_MouseUp(sender As Object, e As MouseEventArgs) Handles btnResume.MouseUp
		btnResume.BackgroundImage = My.Resources.Resume_Default
	End Sub

	Private Sub btnResume_MouseLeave(sender As Object, e As EventArgs) Handles btnResume.MouseLeave
		btnResume.BackgroundImage = My.Resources.Resume_Default
	End Sub

	Private Sub btnResume_MouseMove(sender As Object, e As MouseEventArgs) Handles btnResume.MouseMove
		btnResume.BackgroundImage = My.Resources.Resume_Hover
	End Sub

	Private Sub btnResume_Enter(sender As Object, e As EventArgs) Handles btnResume.Enter
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
		btnResume.BackgroundImage = My.Resources.Resume_Hover
	End Sub

	Private Sub btnResume_Leave(sender As Object, e As EventArgs) Handles btnResume.Leave
		btnResume.BackgroundImage = My.Resources.Resume_Default
	End Sub

	Private Sub btnResume_MouseEnter(sender As Object, e As EventArgs) Handles btnResume.MouseEnter
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
	End Sub

	'btnTitle 버튼 ------------------------------------------------------------------

	Private Sub btnTitle_MouseEnter(sender As Object, e As EventArgs) Handles btnTitle.MouseEnter
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
	End Sub

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
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
		btnTitle.BackgroundImage = My.Resources.GoTitle_Hover
	End Sub

	Private Sub btnTitle_Leave(sender As Object, e As EventArgs) Handles btnTitle.Leave
		btnTitle.BackgroundImage = My.Resources.GoTitle_Default
	End Sub


End Class