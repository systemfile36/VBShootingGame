Public Class GameSetting

	'기본값 상수
	Public Const D_MLI As Integer = 14, D_MLTI As Integer = 20
	Public Const D_EspT As Long = 50000000, D_DifT As Long = 70000000
	Public Const D_PSpeed As Integer = 10, D_PFireD As Integer = 400

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