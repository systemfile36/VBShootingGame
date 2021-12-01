Imports System.Numerics
Public Class Enemy_Type2
	Inherits Enemy

	Public Sub New(id As String, rNum As Integer, dif As Integer)
		'기본적인 건 대부분 부모 생성자가 해줌
		MyBase.New(id)


		SetSprite(My.Resources.Enemy_Type1)
		UPos = New PointF(Form1.BoardWidth, rNum)
		SetCollider(UPos, UWidth, UHeight)


		'벡터 1, 0 을 각각 20도 간격으로 3개 배치
		'방향을 맞추기 위해 위로 올라가는 탄환은 - 기호를 붙여야 함!
		VectorList.Add(New Vector2(-Math.Cos(30 * Math.PI / 180.0), -Math.Sin(30 * Math.PI / 180.0)))
		VectorList.Add(New Vector2(-1, 0))
		VectorList.Add(New Vector2(-Math.Cos(30 * Math.PI / 180.0), Math.Sin(30 * Math.PI / 180.0)))

		NumOfBullets = 3

		'최소값 2000ms
		'0.3초씩 짧아짐
		SetFireTerm(Math.Max(2000, 3000 - ((dif - 8) * 300)))

	End Sub

	Public Overrides Sub Move()
		'맵 뒤에서 앞으로 나옴
		If UPos.X > Form1.BoardWidth - UWidth - 20 Then
			UPos = New PointF(UPos.X - 2, UPos.Y)
			SetCollider(UPos)
		End If
	End Sub

End Class
