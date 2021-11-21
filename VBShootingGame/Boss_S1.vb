Public Class Boss_S1
	Inherits Boss

	Public Sub New()
		MyBase.New(1, 8)
		UHeight = 142
		UWidth = 512
		SetSprite("Boss_1_Default")
		SetSpriteByHealth("Boss_1_Harf", "Boss_1_Quarter", "Boss_1_Destroy")

		'체력 설정
		SetMaxHealthByCount(30)

		SetCollider(New Point(UPos.X, UPos.Y + 78), 256, UHeight - 78)
	End Sub

	Public Overrides Sub Move()
		If UPos.X > Form1.BoardWidth - UWidth - 50 Then
			UPos = New Point(UPos.X - 2, UPos.Y)
			SetCollider(New Point(UPos.X, UPos.Y + 78))
		End If
	End Sub


End Class
