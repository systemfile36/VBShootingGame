Public Class GameSetting

	'기본값 상수
	Public Const D_MLI As Integer = 14, D_MLTI As Integer = 20
	Public Const D_EspT As Long = 50000000, D_DifT As Long = 70000000
	Public Const D_PSpeed As Integer = 10, D_PFireD As Integer = 400

	Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

		If Val(tbMLInterval.Text) < 10 Or Val(tbMLInterval.Text) > 30 Then
			MsgBox("MainLoop의 Interval은 10 이상 30이하로 설정하세요!", vbOKOnly)
			tbMLInterval.Focus()
			tbMLInterval.SelectAll()
		ElseIf Val(tbMLTInterval.Text) < 10 Or Val(tbMLTInterval.Text) > 30 Then
			MsgBox("MainTimer의 Interval은 10 이상 30이하로 설정하세요!", vbOKOnly)
			tbMLTInterval.Focus()
			tbMLTInterval.SelectAll()
		ElseIf Val(tbESpawn.Text) < 10000000 Or Val(tbESpawn.Text) > 100000000 Then
			MsgBox("초기 적 스폰 주기는 1000만Tick(1sec)이상 1억Tick(10sec)이하로 설정하세요!", vbOKOnly)
			tbESpawn.Focus()
			tbESpawn.SelectAll()
		ElseIf Val(tbDifTerm.Text) < 30000000 Or Val(tbDifTerm.Text) > 300000000 Then
			MsgBox("난이도 갱신 주기는 3000만Tick(3sec)이상 3억Tick(30초)이하로 설정하세요!", vbOKOnly)
			tbDifTerm.Focus()
			tbDifTerm.SelectAll()
		ElseIf Val(tbPSpeed.Text) < 1 Or Val(tbPSpeed.Text) > 30 Then
			MsgBox("플레이어 기체 속도는 10 이상 30 이하로 설정해주세요!", vbOKOnly)
			tbPSpeed.Focus()
			tbPSpeed.SelectAll()
		ElseIf Val(tbPFireDelay.Text) < 100 Or Val(tbPFireDelay.Text) > 1000 Then
			MsgBox("플레이어 기체 연사 속도는 100 이상 1000 이하로 설정해주세요!", vbOKOnly)
			tbPFireDelay.Focus()
			tbPFireDelay.SelectAll()
		Else
			With My.Settings
				.ML_Interval = Val(tbMLInterval.Text)
				.MLT_Interval = Val(tbMLTInterval.Text)
				.ESpawnTerm = Val(tbESpawn.Text)
				.DifTerm = Val(tbDifTerm.Text)
				.PSpeed = Val(tbPSpeed.Text)
				.PFireDelay = Val(tbPFireDelay.Text)
				.Save()
			End With
			StartUp.Show()
			Me.Close()
		End If
	End Sub

	'모든 텍스트 박스에 숫자만 입력받게 하는 이벤트 핸들러
	Private Sub TextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbMLInterval.KeyPress,
			tbMLTInterval.KeyPress, tbESpawn.KeyPress, tbDifTerm.KeyPress, tbPSpeed.KeyPress, tbPFireDelay.KeyPress
		If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
			e.Handled = True '검사 결과 숫자도 아니고 기능키도 아니면 씹는다
		End If
	End Sub

	'텍스트 박스의 내용을 초기 값으로 바꿈
	Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
		tbMLInterval.Text = D_MLI
		tbMLTInterval.Text = D_MLTI
		tbESpawn.Text = D_EspT
		tbDifTerm.Text = D_DifT
		tbPSpeed.Text = D_PSpeed
		tbPFireDelay.Text = D_PFireD
	End Sub

	Private Sub GameSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'텍스트 박스의 텍스트를 현재 설정값으로 설정
		tbMLInterval.Text = My.Settings.ML_Interval
		tbMLTInterval.Text = My.Settings.MLT_Interval
		tbESpawn.Text = My.Settings.ESpawnTerm
		tbDifTerm.Text = My.Settings.DifTerm
		tbPSpeed.Text = My.Settings.PSpeed
		tbPFireDelay.Text = My.Settings.PFireDelay
	End Sub

	'갱신용 주석
End Class