'게임 오브젝트의 기본 틀
'모든 오브젝트는 이 클래스를 상속 받음
'반드시 상속 받아야 사용 가능
'아이디 비교를 위한 IEquatable 인터페이스 상속
Public MustInherit Class GameObject
	Implements IEquatable(Of GameObject)

	'타입 정의 열거형
	Public Enum Type
		None
		Player
		Enemy
		PBullet
		EBullet
	End Enum

	'Equals구현을 위한 고유 아이디
	Private ObjID As String = ""

	'생성될때의 시간을 틱으로 저장
	Public ReadOnly SpawnedTime As Long = 0

	'타입 멤버
	Protected objType As Type

	Public ReadOnly Property UType
		Get
			Return objType
		End Get
	End Property

	'발사 여부를 판단, 발사 간격 유지를 위함
	Public IsFire As Boolean = False

	'파괴 여부를 판단
	Private IsDestroyed As Boolean = False

	'스프라이트 이미지
	Private sprite As Image

	Public ReadOnly Property USprite As Image
		Get
			Return sprite
		End Get
	End Property

	'파괴 스프라이트
	Private DestroySprite As Image

	Public ReadOnly Property UDSprite As Image
		Get
			Return DestroySprite
		End Get
	End Property

	Public ReadOnly DWidth As Integer = 100, DHeight As Integer = 80

	'위치 정보
	Private pos As Point

	Public Property UPos As Point
		Get
			Return pos
		End Get
		Set(value As Point)
			pos = value
		End Set
	End Property

	'충돌판정을 위한 범위
	Private Collider As Rectangle

	Public ReadOnly Property UCollider As Rectangle
		Get
			Return Collider
		End Get
	End Property

	'속도(프레임당 이동 좌표값)
	Private SPEED As Integer

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

	'파괴된 시점부터 상승하는 카운터
	Private DestroyedCount As Integer = 0

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

	Public ReadOnly Property UObjID As String
		Get
			Return ObjID
		End Get
	End Property

	Public Sub New()
		SpawnedTime = Now.Ticks
	End Sub

	'오버라이딩 해야하는 이동 함수
	Public MustOverride Sub Move()


	Public Sub SetSprite(f_name As String)
		'sprite = Image.FromFile(f_name)
		'리소스에서 이름에 맞는 파일을 불러옴
		sprite = My.Resources.ResourceManager.GetObject(f_name)
	End Sub



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

	Public Function GetIsDest() As Boolean
		Return IsDestroyed
	End Function

	Public Sub SetIsDest(value As Boolean)
		IsDestroyed = value
	End Sub

	'충돌 범위 설정 함수
	'왠만하면 생성자에서만 호출
	Public Overloads Sub SetCollider(point As Point, width As Integer, height As Integer)
		Collider = New Rectangle(point.X, point.Y, width, height)
	End Sub

	'높이와 넓이는 그대로 둔 채 위치만 옮김
	Public Overloads Sub SetCollider(point As Point)
		Collider.Location = point
	End Sub

	'충돌 판정 후 Boolean 값 반환
	'매개변수의 네개의 꼭짓점이 자신의 충돌 범위에 하나라도 포함되면 충돌인걸로 판정
	'전달 받은 객체와 자신의 파괴 여부를 True로 만들고 destroy 호출
	Public Overridable Function CollisionCheck(obj As GameObject)
		'충돌한 물체 중 하나라도 콜라이더가 0이라면, 즉 콜라이더가 제거된 상태일 때
		If Me.Collider.Width = 0 OrElse obj.UCollider.Width = 0 Then
			Return False
		End If

		If Me.Collider.Contains(obj.UCollider.Left, obj.UCollider.Top) OrElse
			Me.Collider.Contains(obj.UCollider.Left, obj.UCollider.Bottom) OrElse
			Me.Collider.Contains(obj.UCollider.Right, obj.UCollider.Top) OrElse
			Me.Collider.Contains(obj.UCollider.Right, obj.UCollider.Bottom) Then
			Me.IsDestroyed = True
			obj.SetIsDest(True)
			Me.Destroy()
			obj.Destroy()
			Return True
		Else
			Return False
		End If
	End Function

	'파괴 여부를 확인한 뒤 True이면 충돌 범위를 0으로 만듬
	'그리고 파괴하면 True, 아니면 False를 반환
	Public Overridable Function Destroy() As Boolean
		If IsDestroyed = True Then
			DestroyedCount += 1
			'콜라이더 제거 작업
			SetCollider(New Point(0, 0), 0, 0)
			Return True
		Else
			Return False
		End If
	End Function

	'소멸 될때 스프라이트도 해제
	Protected Overrides Sub Finalize()
		MyBase.Finalize()
		sprite.Dispose()
	End Sub

	'파괴된 시점부터 증가하는 변수를 반환
	Public Function GetDestroyCounter() As Long
		Return DestroyedCount
	End Function

	'파괴 모션 세팅 함수
	Public Sub SetDestroySprite()
		DestroySprite = My.Resources.ResourceManager.GetObject("Destroy_0")
	End Sub

End Class
