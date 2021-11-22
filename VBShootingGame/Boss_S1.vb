'첫번째 타입 보스
Public Class Boss_S1
	Inherits Boss

	Private IsUp As Boolean = False

	'이 보스 고유의 드론 클래스
	Public Class Drone_S1
		Inherits Drone

		Private IsMoving As Boolean = False

		Private IsUp As Boolean = False

		Private IsCheckedTick As Boolean = False

		Private CheckUpDownTick As Long = 0

		'위아래 변환 주기 3s
		Private UpDownDelay As Long = 30000000L

		'생성될 때의 Y 좌표
		Private StartedPosY As Integer

		'발사 간격 600ms
		Private FireTerm As Long = 6000000L
		Private FireTick As Long = 0

		'초기 Y좌표 설정
		Public Sub New(posY As Integer)
			UHeight = 35
			UWidth = 53
			SetSprite("B_Drone_S1")
			UPos = New Point(Form1.BoardWidth, posY)
			StartedPosY = posY
		End Sub

		Public Overrides Sub Move()
			'맵 중앙 조금 덜간 위치에서 멈춤
			If UPos.X > Form1.BoardWidth - 512 + 50 Then
				UPos = New Point(UPos.X - 2, UPos.Y)
				Exit Sub
			End If

			'초기 위치에 도달한 시점에 시간 체크 시작(계속 갱신되는 것을 막기 위해 플래그 사용)
			'즉 한번만 실행됨
			If IsCheckedTick = False Then
				CheckUpDownTick = Now.Ticks
				FireTick = Now.Ticks
				IsCheckedTick = True
			End If

			'딜레이 측정해서 시간에 도달했다면 위아래에 맞게 움직임
			If Now.Ticks - CheckUpDownTick > UpDownDelay Then
				If IsUp Then
					UPos = New Point(UPos.X, UPos.Y - 1)
				Else
					UPos = New Point(UPos.X, UPos.Y + 1)
				End If
				IsMoving = True
			End If

			'위아래로 일정 이상 움직이면 위아래 방향을 바꾸고 다시 시간을 잼
			'이때 딜레이만큼 멈추게 됨
			If UPos.Y <= StartedPosY - 20 OrElse UPos.Y >= StartedPosY + 20 Then
				IsUp = Not IsUp
				CheckUpDownTick = Now.Ticks
				IsMoving = False
			End If
		End Sub

		Public Overrides Function CheckFireTerm() As Boolean
			If GetIsDest() Then
				Return False
			End If

			'이동중이지 않고 일정 딜레이에 도달하였다면 발사 True로
			If IsMoving = False AndAlso Now.Ticks - FireTick > FireTerm Then
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

		SetCollider(New Point(UPos.X, UPos.Y + 58), 256, UHeight - 58)
	End Sub

	'일단은 위 아래 왕복 운동
	Public Overrides Sub Move()
		If UPos.X > Form1.BoardWidth - UWidth - 50 Then
			UPos = New Point(UPos.X - 2, UPos.Y)
		End If

		If UPos.Y < 0 Then
			IsUp = False
		ElseIf UPos.Y + UHeight > Form1.BoardHeight Then
			IsUp = True
		End If

		If IsUp Then
			UPos = New Point(UPos.X, UPos.Y - 1)
		Else
			UPos = New Point(UPos.X, UPos.Y + 1)
		End If

		SetCollider(New Point(UPos.X, UPos.Y + 58))
	End Sub


End Class
