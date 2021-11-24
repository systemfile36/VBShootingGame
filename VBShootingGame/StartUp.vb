'게임의 시작 메뉴
'프로젝트 속성의 종료 모드를 마지막 폼을 닫을때로 변경
Public Class StartUp
	Private title As Image
	Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
		'Form1.Show()
		'Me.Close()

		SelectPlayer.Show()
		Me.Close()
	End Sub

	Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
		Me.Close()
	End Sub

	Private Sub StartUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		btnExit.Select()

		'배경과 타이틀 이미지 설정
		BackgroundImage = My.Resources.BackGround_0
		title = My.Resources.Title

		'버튼 초기 이미지 설정
		btnStart.BackgroundImage = My.Resources.GameStart_Default
		btnStart.Text = ""
		btnSetting.BackgroundImage = My.Resources.GameSetting_Default
		btnSetting.Text = ""
		btnInfo.BackgroundImage = My.Resources.GameInfo_Default
		btnInfo.Text = ""
		btnExit.BackgroundImage = My.Resources.GameQuit_Default
		btnExit.Text = ""

		Me.KeyPreview = True

	End Sub

	Private Sub StartUp_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
		'방향키와 엔터키 이외에는 무시한다.(오입력 방지)
		If Not (e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down) Then
			e.Handled = True
		End If
	End Sub

	Private Sub StartUp_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
		e.Graphics.DrawImage(title, New Point(-20, -20))
	End Sub

	Private Sub btnInfo_Click(sender As Object, e As EventArgs) Handles btnInfo.Click
		GameInfo.Show()
		Me.Close()
	End Sub

	Private Sub btnSetting_Click(sender As Object, e As EventArgs) Handles btnSetting.Click
		GameSetting.Show()
		Me.Close()
	End Sub

	'-------------------------------버튼 디자인용 이벤트들-----------------------------------

	'GameStart 버튼 -----------------------------------
	Private Sub btnStart_MouseEnter(sender As Object, e As EventArgs) Handles btnStart.MouseEnter
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
	End Sub
	Private Sub btnStart_MouseMove(sender As Object, e As MouseEventArgs) Handles btnStart.MouseMove
		btnStart.BackgroundImage = My.Resources.GameStart_Hover
	End Sub

	Private Sub btnStart_MouseLeave(sender As Object, e As EventArgs) Handles btnStart.MouseLeave
		btnStart.BackgroundImage = My.Resources.GameStart_Default
	End Sub

	Private Sub btnStart_MouseDown(sender As Object, e As MouseEventArgs) Handles btnStart.MouseDown
		btnStart.BackgroundImage = My.Resources.GameStart_Click
	End Sub

	Private Sub btnStart_MouseUp(sender As Object, e As MouseEventArgs) Handles btnStart.MouseUp
		btnStart.BackgroundImage = My.Resources.GameStart_Default
	End Sub

	Private Sub btnStart_Enter(sender As Object, e As EventArgs) Handles btnStart.Enter
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
		btnStart.BackgroundImage = My.Resources.GameStart_Hover
	End Sub

	Private Sub btnStart_Leave(sender As Object, e As EventArgs) Handles btnStart.Leave
		btnStart.BackgroundImage = My.Resources.GameStart_Default
	End Sub

	'GameSetting 버튼 -----------------------------------

	Private Sub btnSetting_MouseEnter(sender As Object, e As EventArgs) Handles btnSetting.MouseEnter
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
	End Sub

	Private Sub btnSetting_MouseMove(sender As Object, e As MouseEventArgs) Handles btnSetting.MouseMove
		btnSetting.BackgroundImage = My.Resources.GameSetting_Hover
	End Sub

	Private Sub btnSetting_MouseLeave(sender As Object, e As EventArgs) Handles btnSetting.MouseLeave
		btnSetting.BackgroundImage = My.Resources.GameSetting_Default
	End Sub

	Private Sub btnSetting_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSetting.MouseDown
		btnSetting.BackgroundImage = My.Resources.GameSetting_Click
	End Sub

	Private Sub btnSetting_MouseUp(sender As Object, e As MouseEventArgs) Handles btnSetting.MouseUp
		btnSetting.BackgroundImage = My.Resources.GameSetting_Default
	End Sub

	Private Sub btnSetting_Enter(sender As Object, e As EventArgs) Handles btnSetting.Enter
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
		btnSetting.BackgroundImage = My.Resources.GameSetting_Hover
	End Sub

	Private Sub btnSetting_Leave(sender As Object, e As EventArgs) Handles btnSetting.Leave
		btnSetting.BackgroundImage = My.Resources.GameSetting_Default
	End Sub

	'GameInfo 버튼-----------------------------------------

	Private Sub btnInfo_MouseEnter(sender As Object, e As EventArgs) Handles btnInfo.MouseEnter
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
	End Sub
	Private Sub btnInfo_MouseMove(sender As Object, e As MouseEventArgs) Handles btnInfo.MouseMove
		btnInfo.BackgroundImage = My.Resources.GameInfo_Hover
	End Sub

	Private Sub btnInfo_MouseLeave(sender As Object, e As EventArgs) Handles btnInfo.MouseLeave
		btnInfo.BackgroundImage = My.Resources.GameInfo_Default
	End Sub

	Private Sub btnInfo_MouseDown(sender As Object, e As MouseEventArgs) Handles btnInfo.MouseDown
		btnInfo.BackgroundImage = My.Resources.GameInfo_Click
	End Sub

	Private Sub btnInfo_MouseUp(sender As Object, e As MouseEventArgs) Handles btnInfo.MouseUp
		btnInfo.BackgroundImage = My.Resources.GameInfo_Default
	End Sub

	Private Sub btnInfo_Enter(sender As Object, e As EventArgs) Handles btnInfo.Enter
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
		btnInfo.BackgroundImage = My.Resources.GameInfo_Hover
	End Sub

	Private Sub btnInfo_Leave(sender As Object, e As EventArgs) Handles btnInfo.Leave
		btnInfo.BackgroundImage = My.Resources.GameInfo_Default
	End Sub

	'Quit Game 버튼 --------------------------------------

	Private Sub btnExit_MouseEnter(sender As Object, e As EventArgs) Handles btnExit.MouseEnter
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
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
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
		btnExit.BackgroundImage = My.Resources.GameQuit_Hover
	End Sub

	Private Sub btnExit_Leave(sender As Object, e As EventArgs) Handles btnExit.Leave
		btnExit.BackgroundImage = My.Resources.GameQuit_Default
	End Sub
End Class