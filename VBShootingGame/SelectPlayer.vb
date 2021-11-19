Public Class SelectPlayer
	Private SelectType As String = "P_Default"
	Private Sub SelectPlayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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