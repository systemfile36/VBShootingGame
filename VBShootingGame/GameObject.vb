'게임 오브젝트의 기본 틀
'모든 오브젝트는 이 클래스를 상속 받음
'아이디 비교를 위한 IEquatable 인터페이스 상속
Public Class GameObject
	Implements IEquatable(Of GameObject)

	'Equals구현을 위한 고유 아이디
	'ReadOnly프로퍼티로 읽기만 함, 초기화는 생성자에서만
	Private ObjID As String = ""

	'생성될때의 시간을 틱으로 저장
	Public ReadOnly SpawnedTime As Long = 0

	'적인지 여부를 판단
	Public IsEnemy As Boolean = False

	'발사 여부를 판단, 발사 간격 유지를 위함
	Public IsFire As Boolean = False

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

	Public ReadOnly Property UObjID As String
		Get
			Return ObjID
		End Get
	End Property


	Public Sub New()
		SpawnedTime = Now.Ticks
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
		'sprite = Image.FromFile(f_name)
		'리소스에서 이름에 맞는 파일을 불러옴
		sprite = My.Resources.ResourceManager.GetObject(f_name)
	End Sub

	Public Overridable Function CheckDestroyed() As Boolean
		Return False
	End Function

	'일치 연산을 위한 Equals 오버로딩과정
	'microsoft dotnet 문서 List<T> 문서 참조함
	Public Overrides Function Equals(obj As Object) As Boolean
		If obj Is Nothing Then
			Return False
		End If
		Dim other As GameObject = TryCast(obj, GameObject)
		If other Is Nothing Then
			Return False
		Else
			Return Equals(other)
		End If

	End Function

	Public Overloads Function Equals(other As GameObject) As Boolean _
		Implements IEquatable(Of GameObject).Equals
		If other Is Nothing Then
			Return False
		End If
		Return Me.ObjID.Equals(other.ObjID)
	End Function

	Protected Sub SetObjID(value As String)
		ObjID = value
	End Sub



End Class
