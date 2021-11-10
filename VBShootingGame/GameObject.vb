'게임 오브젝트의 기본 틀
'모든 오브젝트는 이 클래스를 상속 받음
Public Class GameObject
	Private sprite As Image
	Private pos As Point
	Private SPEED As Integer
	'private 접근을 위해 property 사용
	Public Property USpeed As Integer
		Get
			Return SPEED
		End Get
		Set(value As Integer)
			If value < 0 Then
				SPEED = 10
			Else
				SPEED = value
			End If
		End Set
	End Property

	Private WIDTH As Integer, HEIGHT As Integer

	Public Property UWidth As Integer
		Get
			Return WIDTH
		End Get
		Set(value As Integer)
			If value < 0 Then
				WIDTH = 10
			Else
				WIDTH = value
			End If
		End Set
	End Property

	Public Property UHeight As Integer
		Get
			Return HEIGHT
		End Get
		Set(value As Integer)
			If value < 0 Then
				HEIGHT = 10
			Else
				HEIGHT = value
			End If
		End Set
	End Property

	Public Property UPos As Point
		Get
			Return pos
		End Get
		Set(value As Point)
			pos = value
		End Set
	End Property

	Public ReadOnly Property USprite As Image
		Get
			Return sprite
		End Get
	End Property
	Public Sub New()

	End Sub

	Public Overridable Sub Move(dire As Form1.InputKeys)
		Select Case dire
			Case Form1.InputKeys.Left
				pos.X -= USpeed
			Case Form1.InputKeys.Right
				pos.X += USpeed
			Case Form1.InputKeys.Up
				pos.Y -= USpeed
			Case Form1.InputKeys.Down
				pos.Y += USpeed
		End Select

		'화면 범위 벗어날 것 같으면 화면 안으로 좌표 변경
		If pos.X < 0 Then
			pos.X = 0
		End If
		If pos.Y < 0 Then
			pos.Y = 0
		End If
		If pos.X + WIDTH > Form1.BoardWidth Then
			pos.X = Form1.BoardWidth - WIDTH
		End If
		If pos.Y + HEIGHT > Form1.BoardHeight Then
			pos.Y = Form1.BoardHeight - HEIGHT
		End If
	End Sub

	Public Sub SetSprite(f_name As String)
		sprite = Image.FromFile(f_name)
	End Sub

	Public Overridable Function CheckDestroyed() As Boolean

	End Function

End Class
