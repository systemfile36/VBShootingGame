Imports System.Numerics


'한번에 여러발을 발사하는 삿견 계열 기체
'연사 딜레이 3.5배, 한번에 5발 퍼뜨림

Public Class Player_Type2
	Inherits Player

	'벡터 리스트는 부모 클래스에 있음

	Public Sub New()
		MyBase.New("P_Type_2")

		'한번에 다섯발 쏜다고 선언
		SetNoB(5)

		'시작부터 쏠 수 있게 하기 위하여
		FireTick = Form1.GNowTick - FireDelay * 3

		'벡터 1, 0 을 각각 20도 간격으로 5개 배치
		'방향을 맞추기 위해 위로 올라가는 탄환은 - 기호를 붙여야 함!
		VectorList.Add(New Vector2(Math.Cos(30 * Math.PI / 180.0), -Math.Sin(30 * Math.PI / 180.0)))
		VectorList.Add(New Vector2(Math.Cos(15 * Math.PI / 180.0), -Math.Sin(15 * Math.PI / 180.0)))
		VectorList.Add(New Vector2(1, 0))
		VectorList.Add(New Vector2(Math.Cos(15 * Math.PI / 180.0), Math.Sin(15 * Math.PI / 180.0)))
		VectorList.Add(New Vector2(Math.Cos(30 * Math.PI / 180.0), Math.Sin(30 * Math.PI / 180.0)))

	End Sub

	Public Overrides Function CheckFireDelay() As Boolean
		If IsInputFire = True And Form1.GNowTick - FireTick > FireDelay * 3.5 Then
			FireTick = Form1.GNowTick
			Return True
		Else
			Return False
		End If
	End Function
End Class
