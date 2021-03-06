'탄환 타입 객체
Public Class Bullet
	Inherits GameObject

	Private IsPlayer As Boolean = True


	Public Sub New(sender As GameObject, IsP As Boolean, id As String)
		'USpeed = 20
		UWidth = 42
		UHeight = 13
		SetDestroySprite()

		'플레이어의 탄인지 아닌지 비교해서 다르게 초기화
		If IsP Then
			IsPlayer = True
			SetObjID("P_B" & id)

			objType = Type.PBullet
			USpeed = 25

			SetSprite(Type.PBullet)
			'생성자에 들어온 객체(=발사 주체)의 위치가 초기 위치
			UPos = New PointF(sender.UPos.X + sender.UWidth - 10, sender.UPos.Y + 20)
		Else
			IsPlayer = False
			SetObjID("E_B" & id)

			objType = Type.EBullet
			USpeed = 10

			SetSprite(Type.EBullet)
			'생성자에 들어온 객체(=발사 주체)의 위치가 초기 위치
			UPos = New PointF(sender.UPos.X, sender.UPos.Y + 20)
		End If

		'pos설정 후 충돌 범위 설정
		SetCollider(UPos, UWidth, UHeight)

	End Sub

	'상속을 대비한 기본 생성자
	Public Sub New()

	End Sub

	Public Overrides Sub Move()
		If IsPlayer Then
			UPos = New PointF(UPos.X + USpeed, UPos.Y)
		Else
			UPos = New PointF(UPos.X - USpeed, UPos.Y)
		End If

		'범위 밖이면 삭제
		If UPos.X + UWidth + 100 < 0 Or UPos.X - UWidth > Form1.BoardWidth Then
			SetIsDest(True)
			Destroy()
		End If

		'콜라이더 갱신
		SetCollider(UPos)

	End Sub

	Public Overrides Function CollisionCheck(obj As GameObject) As Object
		Return False
	End Function

	Public Overrides Function Destroy() As Boolean
		Return MyBase.Destroy()
	End Function

	Public Sub SetIsPlayer(isP As Boolean)
		IsPlayer = isP
	End Sub

End Class
