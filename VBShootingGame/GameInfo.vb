Public Class GameInfo
	Private infoText As String
	Private Sub GameInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Try
			Using st As New System.IO.StreamReader("ReadMe.txt")
				infoText = st.ReadToEnd()
			End Using
		Catch ex As Exception
			infoText = My.Resources.ReadMe
		Finally
			tbInfo.Text = infoText
		End Try

		btnTitle.BackgroundImage = My.Resources.GoTitle_Default
		btnTitle.Text = ""

		btnTitle.Select()

	End Sub

	'GoTitle버튼 -------------------------------------------------

	Private Sub btnTitle_Click(sender As Object, e As EventArgs) Handles btnTitle.Click
		StartUp.Show()
		Me.Close()
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
		btnTitle.BackgroundImage = My.Resources.GoTitle_Hover
	End Sub

	Private Sub btnTitle_Leave(sender As Object, e As EventArgs) Handles btnTitle.Leave
		btnTitle.BackgroundImage = My.Resources.GoTitle_Default
	End Sub


End Class