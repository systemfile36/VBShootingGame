Public Class Enemy
	Inherits GameObject

	Public Sub New()
		SetSprite("E_Default.png")
		USpeed = 10
		UWidth = 122
		UHeight = 72
		UPos = New Point(Form1.BoardWidth - UWidth - 100, 100)
	End Sub

End Class
