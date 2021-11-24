'첫번째 타입 보스
Public Class Boss_S1
	Inherits Boss

	Private IsUp As Boolean = False

	'이 보스 고유의 드론 클래스
	Public Class Drone_S1
		Inherits Drone

		Private IsUp As Boolean = False

		'생성될 때의 Y 좌표
		Private StartedPosY As Integer

		'발사 간격 1000ms
		Private FireTerm As Long = 10000000L
		Private FireTick As Long = 0

		'초기 Y좌표 설정
		Public Sub New(posY As Integer)
			UHeight = 35
			UWidth = 53
			SetSprite("B_Drone_S1")
			UPos = New PointF(Form1.BoardWidth, posY)
			StartedPosY = posY

			FireTick = Now.Ticks
		End Sub

		Public Overrides Sub Move()
			'맵 중앙 조금 덜간 위치에서 멈춤
			If UPos.X > Form1.BoardWidth - 512 + 50 Then
				UPos = New PointF(UPos.X - 2, UPos.Y)
				Exit Sub
			End If

			'처음 위치에서 위아래로 일정 이상 움직이면 위아래 방향을 바꿈
			If UPos.Y <= StartedPosY - 50 Then
				IsUp = False
			ElseIf UPos.Y >= StartedPosY + 50 Then
				IsUp = True
			End If

			If IsUp Then
				UPos = New PointF(UPos.X, UPos.Y - 1)
			Else
				UPos = New PointF(UPos.X, UPos.Y + 1)
			End If


		End Sub

		Public Overrides Function CheckFireTerm() As Boolean
			If GetIsDest() Then
				Return False
			End If

			'이동중이지 않고 일정 딜레이에 도달하였다면 발사 True로
			If Now.Ticks - FireTick > FireTerm Then
				FireTick = Now.Ticks
				Return True
			Else
				Return False
			End If

		End Function
	End Class

	Public Sub New()
		MyBase.New(1, 8)
		UHeight = 142
		UWidth = 512
		SetSprite("Boss_1_Default")
		SetSpriteByHealth("Boss_1_Harf", "Boss_1_Quarter", "Boss_1_Destroy")

		'드론 4개 소환
		For i As Integer = 0 To 4
			Drones.Add(New Drone_S1(50 + (100 * i)))
		Next

		'체력 설정
		SetMaxHealthByCount(30)

		SetCollider(New PointF(UPos.X, UPos.Y + 58), 256, UHeight - 58)
	End Sub

	'일단은 위 아래 왕복 운동
	Public Overrides Sub Move()
		If UPos.X > Form1.BoardWidth - UWidth - 50 Then
			UPos = New PointF(UPos.X - 2, UPos.Y)
		End If

		If UPos.Y < 0 Then
			IsUp = False
		ElseIf UPos.Y + UHeight > Form1.BoardHeight Then
			IsUp = True
		End If

		If IsUp Then
			UPos = New PointF(UPos.X, UPos.Y - 1)
		Else
			UPos = New PointF(UPos.X, UPos.Y + 1)
		End If

		SetCollider(New PointF(UPos.X, UPos.Y + 58))
	End Sub


End Class
