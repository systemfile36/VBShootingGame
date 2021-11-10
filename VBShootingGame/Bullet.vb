Public Class Bullet
	Inherits GameObject

	Public IsPlayer As Boolean = True

	Public Sub New(sender As GameObject, IsP As Boolean)
		USpeed = 20
		UWidth = 42
		UHeight = 13
		If IsP Then
			IsPlayer = True
			SetSprite("P_Bullet.png")
			UPos = New Point(sender.UPos.X + sender.UWidth - 10, sender.UPos.Y + 20)
		Else
			IsPlayer = False
			SetSprite("E_Bullet.png")
			UPos = New Point(sender.UPos.X, sender.UPos.Y + 20)
		End If

	End Sub

	Public Overrides Sub Move(dire As Form1.InputKeys)
		If IsPlayer Then

		End If
	End Sub

End Class
