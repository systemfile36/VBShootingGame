Public Class Player
	Inherits GameObject

	'이동 키를 정의한 Enum
	Public Enum InputKeys
		Left
		Right
		Up
		Down
		None
	End Enum

	'이동을 위한 플레이어 고유의 플래그
	Public p_control As InputKeys

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

	Public Overrides Sub Move()
		Select Case p_control
			Case InputKeys.Left
				UPos = New Point(UPos.X - USpeed, UPos.Y)
			Case InputKeys.Right
				UPos = New Point(UPos.X + USpeed, UPos.Y)
			Case InputKeys.Up
				UPos = New Point(UPos.X, UPos.Y - USpeed)
			Case InputKeys.Down
				UPos = New Point(UPos.X, UPos.Y + USpeed)
		End Select

		'화면 범위 벗어날 것 같으면 화면 안으로 좌표 변경
		If UPos.X < 0 Then
			UPos = New Point(0, UPos.Y)
		End If
		If UPos.Y < 0 Then
			UPos = New Point(UPos.X, 0)
		End If
		If UPos.X + UWidth > Form1.BoardWidth Then
			'UPos.X = Form1.BoardWidth - WIDTH
			UPos = New Point(Form1.BoardWidth - UWidth, UPos.Y)
		End If
		If UPos.Y + UHeight > Form1.BoardHeight Then
			'UPos.Y = Form1.BoardHeight - HEIGHT
			UPos = New Point(UPos.X, Form1.BoardHeight - UHeight)
		End If

		'충돌 판정 갱신
		SetCollider(UPos, UWidth, UHeight)
	End Sub

	'키 코드를 받아서 그에 맞게 p_control과 IsFIre 플래그를 설정함
	Public Sub SetControl(key As Keys)
		Select Case key
			Case Keys.W
				p_control = InputKeys.Up
			Case Keys.A
				p_control = InputKeys.Left
			Case Keys.S
				p_control = InputKeys.Down
			Case Keys.D
				p_control = InputKeys.Right
			Case Keys.F
				p_control = InputKeys.None
			Case Keys.Space
				IsFire = True
		End Select
	End Sub

End Class
