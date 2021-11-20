'Boss 타입 적 정의 객체
Public MustInherit Class Boss
	Inherits GameObject

	Public ReadOnly Stage_N As Integer
	Public ReadOnly IsExist As Boolean
	Public ReadOnly AppearDif As Integer
	Protected HealthByCount As Integer

	Public Sub New(stage_n As Integer, appeardif As Integer)
		'UHeight = 71
		'UWidth = 256
		'SetSprite("Boss_1_Default")
		UPos = New Point(Form1.BoardWidth, 100)

		'SetCollider(New Point(UPos.X, UPos.Y + 39), 256, UHeight - 39)

		'Stage_N = 1
		IsExist = True
		'AppearDif = 8

		Me.Stage_N = stage_n
		Me.AppearDif = appeardif

	End Sub

	Public Overrides Sub Move()
		If UPos.X < Form1.BoardWidth - (UWidth / 2) Then
			UPos = New Point(UPos.X - 2, UPos.Y)
		End If
	End Sub



End Class
