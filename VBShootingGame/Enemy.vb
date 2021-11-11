Public Class Enemy
	Inherits GameObject

	Private IsUp As Boolean = False

	Public Sub New(id As Integer)
		SetSprite("E_Default")
		USpeed = 5
		UWidth = 122
		UHeight = 32
		SetObjID(id)
		UPos = New Point(Form1.BoardWidth - UWidth - 100, 100)
	End Sub

	Public Overrides Sub Move(dire As Form1.InputKeys)
		If UPos.Y < 0 Then
			IsUp = False
		ElseIf UPos.Y + UHeight > Form1.BoardHeight Then
			IsUp = True
		End If

		If IsUp Then
			UPos = New Point(UPos.X, UPos.Y - USpeed)
		Else
			UPos = New Point(UPos.X, UPos.Y + USpeed)
		End If
	End Sub

End Class
