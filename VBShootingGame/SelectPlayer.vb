Public Class SelectPlayer
	Private SelectType As String = "P_Default"
	Private Sub SelectPlayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		lbDefaultInfo.Text = "기체 타입 : Default" & vbCrLf & vbCrLf & "연사력 : " & My.Settings.PFireDelay _
			& "ms 당 1발" & vbCrLf & vbCrLf & "장탄수 : Infinity" & vbCrLf & vbCrLf & vbCrLf & "기본적인 형태의 기체입니다." _
			& vbCrLf & "보통 연사속도로 총알을 지속적으로 발사합니다."

		lbType1Info.Text = "기체 타입 : Type_1" & vbCrLf & vbCrLf & "연사력 : " & My.Settings.PFireDelay / 2 _
			& "ms 당 1발" & vbCrLf & vbCrLf & "장탄수 : 5발" & vbCrLf & vbCrLf & vbCrLf & "순간 연사 계열의 기체입니다." _
			& vbCrLf & "보통 기체보다 두 배 빠른 속도로 발사하는 대신 장탄수를 전부 소비하면 " & (My.Settings.PFireDelay / 2) * 5 & "ms의 재장전 시간이 필요합니다."
	End Sub

	Private Sub SelectComplete()
		Form1.SelectedPlane = SelectType
		Form1.Show()
		Me.Close()
	End Sub

	Private Sub btnDefault_Click(sender As Object, e As EventArgs) Handles btnDefault.Click
		SelectType = "P_Default"
		SelectComplete()
	End Sub

	Private Sub btnType1_Click(sender As Object, e As EventArgs) Handles btnType1.Click
		SelectType = "P_Type_1"
		SelectComplete()
	End Sub

	Private Sub btnType2_Click(sender As Object, e As EventArgs) Handles btnType2.Click
		SelectType = "P_Type_2"
		SelectComplete()
	End Sub
End Class