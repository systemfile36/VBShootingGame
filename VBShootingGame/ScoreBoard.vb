Imports System.IO
'스코어를 암호화 파일에 읽어와서 보여주고, 저장하는 폼
Public Class ScoreBoard

	Public score As ScoreManager

	'저장 모드인지 확인 모드인지 확인, 기본은 저장 모드
	Public IsSaveMode As Boolean = True

	'보안을 위해 따로 저장(컨트롤 텍스트는 변조될 위험)
	Private lbValues As New List(Of String)

	'해독한 평문 스코어 텍스트
	Private S_Text As String

	'저장되었는지 여부
	Private IsSaved As Boolean = False

	Private Enum MoveForm
		Form1
		StartUp
		None
	End Enum

	'이동할 폼을 FormClosing에서 참조
	Private Toform As MoveForm = MoveForm.None

	Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
		Toform = MoveForm.Form1
		Me.Close()
	End Sub

	Private Sub btnTitle_Click(sender As Object, e As EventArgs) Handles btnTitle.Click
		Toform = MoveForm.StartUp
		Me.Close()
	End Sub

	Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
		Toform = MoveForm.None
		Me.Close()
	End Sub

	Private Sub ScoreBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		btnTitle.BackgroundImage = My.Resources.GoTitle_Default
		btnTitle.Text = ""
		btnReset.BackgroundImage = My.Resources.Restart_Default
		btnReset.Text = ""
		btnExit.BackgroundImage = My.Resources.GameQuit_Default
		btnExit.Text = ""

		'만약 저장모드가 아니면 스코어 등록 인터페이스 비활성화함
		'게임 재시작 버튼도 비활성화, 초기화 버튼 중앙으로 옮김
		If Not IsSaveMode Then
			grpScoreAppend.Enabled = False
			grpScoreAppend.Visible = False
			btnReset.Enabled = False
			btnReset.Visible = False
			btnClear.Location = New Point(360, btnClear.Location.Y)
			LoadScoreBoard()
			Exit Sub
		End If

		With lbValues
			.Add(Format(Now, "yy/MM/dd"))
			.Add(String.Format("{0,-5}", ""))
			.Add(String.Format("{0,-9}", Form1.SelectedPlane))
			.Add(String.Format("{0:0000000}", score.GetScore()))
			If My.Settings.IsDebug Then
				.Add(String.Format("{0,-5}", "Debug"))
			Else
				.Add(String.Format("{0,-5}", "None"))
			End If
		End With

		SetLabels()

		LoadScoreBoard()

		tbScoreBoard.DeselectAll()

		tbName.Focus()

	End Sub

	Private Sub tbName_TextChanged(sender As Object, e As EventArgs) Handles tbName.TextChanged
		If tbName.Text.Length > 5 Then
			MsgBox("5자 이하로 입력하세요!", vbOKOnly)
			tbName.Text = ""
			Exit Sub
		End If

		lbValues(1) = String.Format("{0,-5}", tbName.Text)
		SetLabels()
	End Sub

	Private Sub SetLabels()
		lbDate.Text = lbValues(0)
		lbPname.Text = lbValues(1)
		lbPType.Text = lbValues(2)
		lbScore.Text = lbValues(3)
		lbIsDebug.Text = lbValues(4)
	End Sub

	Private Sub LoadScoreBoard()
		Try
			'파일이 존재하면 바이트값을 읽어와서 스트링으로 저장
			'없으면 파일을 만들고 저장된 스코어 없음 출력
			Dim encrypted As Byte()
			If File.Exists("Score.bin") Then
				encrypted = File.ReadAllBytes("Score.bin")
				S_Text = AesEncrypt.DecryptStringFromBytes_Aes(encrypted, My.Resources.MyKey, My.Resources.MyIV)
				tbScoreBoard.Text = S_Text
			Else
				Dim fs As FileStream = File.Create("Score.bin")
				tbScoreBoard.Text = "저장된 스코어가 없습니다."
				S_Text = ""
				fs.Close()
			End If
		Catch ex As Exception
			tbScoreBoard.Text = "저장된 스코어가 없습니다."
		End Try
	End Sub

	Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
		If tbName.Text.Length < 3 OrElse tbName.Text.Length > 5 Then
			MsgBox("3자 이상, 5자 이하로 입력하세요!")
			tbName.Text = ""
			tbName.Focus()
			Exit Sub
		End If

		'한번 저장하면 저장 버튼 비활성화
		btnSave.Text = "저장중.."
		btnSave.Enabled = False

		'추가할 문자열
		Dim str_add As String = ""

		For Each temp As String In lbValues
			str_add &= temp
			str_add &= "    "
		Next

		str_add &= vbCrLf
		str_add &= vbCrLf

		'추가할 텍스트를 원래 있던 스코어 문자열에 붙이고 암호화 후 저장
		S_Text &= str_add
		File.WriteAllBytes("Score.bin", AesEncrypt.EncryptStringToBytes_Aes(S_Text, My.Resources.MyKey, My.Resources.MyIV))
		LoadScoreBoard()

		IsSaved = True
		btnSave.Text = "완료"
	End Sub

	Private Sub ScoreBoard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
		'저장 모드일때만 나갈 때 저장 확인
		If IsSaveMode Then
			'만약 저장되지 않았다면 메시지 박스 호출하고 종료 캔슬 후 Sub 탈출
			If Not IsSaved Then
				If Not MsgBox("아직 저장되지 않았습니다, 정말 나가시겠습니까?", vbYesNo) = MsgBoxResult.Yes Then
					e.Cancel = True
					Exit Sub
				End If
			End If
		End If

		'Toform을 참조해서 이동할 폼을 열고 종료
		Select Case Toform
			Case MoveForm.Form1
				Form1.Show()
			Case MoveForm.StartUp
				StartUp.Show()
		End Select
	End Sub

	Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
		If MsgBox("정말 초기화 하시겠습니까?", vbYesNo) = MsgBoxResult.Yes Then
			If File.Exists("Score.bin") Then
				File.Delete("Score.bin")
				IsSaved = False
				'저장 버튼 다시 활성화
				btnSave.Text = "저장"
				btnSave.Enabled = True
				LoadScoreBoard()
			End If
		End If
	End Sub

	'Private Function CheckSaveExit() As Boolean
	'	'True면 나감, False면 안 나감
	'	'저장 모드일때만 나갈 때 저장 확인
	'	If Not IsSaved AndAlso IsSaveMode Then
	'		If Not MsgBox("아직 저장되지 않았습니다, 정말 나가시겠습니까?", vbYesNo) = MsgBoxResult.Yes Then
	'			Return False
	'		Else
	'			Return True
	'		End If
	'		'저장 모드가 아니면 그냥 나감
	'	ElseIf Not IsSaveMode Then
	'		Return True
	'	Else
	'		Return False
	'	End If

	'End Function

	Private Sub btnReset_MouseEnter(sender As Object, e As EventArgs) Handles btnReset.MouseEnter
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
	End Sub
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
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
		btnReset.BackgroundImage = My.Resources.Restart_Hover
	End Sub

	Private Sub btnReset_Leave(sender As Object, e As EventArgs) Handles btnReset.Leave
		btnReset.BackgroundImage = My.Resources.Restart_Default
	End Sub

	'GoTitle버튼 -------------------------------------------------

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

	'Quit Game 버튼-----------------------------------

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


End Class