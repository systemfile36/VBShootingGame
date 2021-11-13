Public Class GameOver
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
End Class