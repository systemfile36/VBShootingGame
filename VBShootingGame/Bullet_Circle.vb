Imports System.Numerics

Public Class Bullet_Circle
	Inherits Bullet

	'방향을 저장하는 변수
	Private Direction As SizeF

	'일반 탄환과 달리 벡터를 받아서 그 값으로 진행방향을 정함
	'id중복을 막기위해 벡터의 X값도 추가
	Public Sub New(sender As GameObject, IsP As Boolean, NormalVector As Vector2, id As String)
		UWidth = 15
		UHeight = 15
		SetDestroySprite()

		USpeed = 20

		If IsP Then
			SetObjID("P_B_C" & NormalVector.X & id)
			objType = Type.PBullet

			SetSprite(My.Resources.P_Bullet_TypeCircle)

			UPos = New PointF(sender.UPos.X + sender.UWidth - 10, sender.UPos.Y + 20)
		Else
			SetObjID("E_B_C" & NormalVector.X & id)
			objType = Type.EBullet
			SetSprite(My.Resources.E_Bullet_TypeCircle)

			USpeed = 11

			UPos = New PointF(sender.UPos.X, sender.UPos.Y + 20)
		End If

		'단위 벡터에 스칼라배 해서 저장
		Dim tempVector As Vector2 = NormalVector * USpeed
		Direction = New SizeF(tempVector.X, tempVector.Y)
		'Debug.WriteLine(Direction)

		SetCollider(UPos, UWidth, UHeight)

	End Sub

	'벡터 방향으로 나아감
	Public Overrides Sub Move()
		UPos = UPos + Direction
		SetCollider(UPos)
	End Sub

End Class
