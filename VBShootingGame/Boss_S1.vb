Public Class Boss_S1
	Inherits Boss

	Public Sub New()
		MyBase.New(1, 8)
		UHeight = 71
		UWidth = 256
		SetSprite("Boss_1_Default")

		SetCollider(New Point(UPos.X, UPos.Y + 39), 256, UHeight - 39)
	End Sub

End Class
