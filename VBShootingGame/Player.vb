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

	'이동을 위한 플레이어 고유의 플래그 (초기값 = 정지)
	Public p_control As InputKeys = InputKeys.None

	'기본 발사 간격 0.4초
	Private FireDelay As Long = 4000000L
	Private FireTick As Long = 0L

	'발사 입력이 들어왔는지 여부를 판단
	'SetControl(), ReleaseControl()이 설정함
	Private IsInputFire As Boolean

	Public Sub New()
		SetSprite("P_Default")
		SetDestroySprite()

		UPos = New Point(100, 100)
		USpeed = 10
		UWidth = 122
		UHeight = 72

		objType = Type.Player

		FireTick = Now.Ticks

		'충돌 범위 설정
		SetCollider(UPos, UWidth, UHeight - 40)

	End Sub

	'충돌한것이 적탄일때만 서로 파괴, 그외엔 무시
	Public Overrides Function CollisionCheck(obj As GameObject) As Object
		If obj.UType = Type.EBullet Then
			Return MyBase.CollisionCheck(obj)
		Else
			Return False
		End If
	End Function

	'이렇게 Move()에서 컨트롤을 반영하면 나중에 컨트롤을 확장하기 쉬움
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
		SetCollider(UPos)
	End Sub

	Public Overrides Function Destroy() As Boolean
		Return MyBase.Destroy()
	End Function


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
				IsInputFire = True
		End Select
	End Sub

	'발사 간격을 조정하기 위함
	'입력이 들어온 상태이고 이전 발사와의 시간차가 딜레이보다 크면
	'시간 갱신 후 True 반환 아니면 False반환
	'스페이스에서 손을 때면 False로 바뀌므로 외부에서 변경할 필요 없음
	Public Function CheckFireDelay() As Boolean
		If IsInputFire = True And Now.Ticks - FireTick > FireDelay Then
			FireTick = Now.Ticks
			Return True
		Else
			Return False
		End If
	End Function

	'스페이스에서 손을 때면 인풋 여부를 False로 바꿈
	Public Sub ReleaseControl(key As Keys)
		If key = Keys.Space Then
			IsInputFire = False
		End If
	End Sub

	'시간을 milsec로 받아 FireDelay를 설정함
	'하한선 = 100ms, 상한선은 1000ms
	Public Sub SetFireDelay(msec As Integer)
		If msec < 100 Then
			FireDelay = 100 * 10000
		ElseIf msec > 1000 Then
			FireDelay = 1000 * 10000
		Else
			FireDelay = msec * 10000
		End If
	End Sub

	'발사 간격을 밀리세컨드 단위로 반환
	Public Function GetFireDelay() As Integer
		Return FireDelay / 10000
	End Function

End Class
