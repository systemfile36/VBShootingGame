Public Class Player
	Inherits GameObject
	'Private sprite As Image
	'Private pos As Point
	'Public Const WIDTH = 122, HEIGHT = 72
	'Public Const SPEED As Integer = 10


	Public Sub New()
		SetSprite("P_Default")
		UPos = New Point(100, 100)
		USpeed = 10
		UWidth = 122
		UHeight = 72

		objType = Type.Player

		'충돌 범위 설정
		SetCollider(UPos, UWidth, UHeight)

	End Sub

	'충돌한것이 적탄일때만 서로 파괴, 그외엔 무시
	Public Overrides Function CollisionCheck(obj As GameObject) As Object
		If obj.UType = Type.EBullet Then
			Return MyBase.CollisionCheck(obj)
		Else
			Return False
		End If
	End Function


End Class
