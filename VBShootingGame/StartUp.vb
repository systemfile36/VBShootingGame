'게임의 시작 메뉴
'프로젝트 속성의 종료 모드를 마지막 폼을 닫을때로 변경
Public Class StartUp
	Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
		Form1.Show()
		Me.Close()
	End Sub

	Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
		Me.Close()
	End Sub
End Class