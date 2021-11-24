Imports System.Numerics

'Boss 타입 적 정의 객체
'모든 Boss타입 객체는 이 객체 상속
Public MustInherit Class Boss
	Inherits GameObject

	Public ReadOnly Stage_N As Integer
	Public ReadOnly IsExist As Boolean
	Public ReadOnly AppearDif As Integer
	Private HealthByCount As Integer
	Public ReadOnly Property UHealth
		Get
			Return HealthByCount
		End Get
	End Property

	Private MaxHealthByCount As Integer

	'체력에 따른 스프라이트 변화
	Private SpriteByHealth(3) As Image

	'점수 중복 상승 방지용 플래그
	Public IsDeath As Boolean = False

	'보스의 죽음 딜레이 (단위 : 프레임)
	Public Const BossDeathDelay As Integer = 70

	'보스 객체 내의 배열에서 따로 관리되는 종속형 적의 기본 타입
	'콜라이더가 없고 보스와 출현과 파괴를 같이함
	'따라서 따로 디스트로이 체크를 하지 않음
	'또한 보스가 있을 때만 그려짐, 각행동은 각 보스 객체에서 상속받아 재정의해서 사용
	Public MustInherit Class Drone
		Inherits GameObject

		Public Sub New()
			SetCollider(New PointF(0, 0), 0, 0)
		End Sub

		'Move()는 반드시 오버라이딩

		'보스가 직접 호출
		Public Overrides Function Destroy() As Boolean
			SetSprite(My.Resources.Destroy_0)
			SetIsDest(True)
			IncDestroyedCounter()
			Return True
		End Function

		Public Overridable Function CheckFireTerm() As Boolean
			Return False
		End Function
	End Class

	'이 보스 고유의 탄 객체, 후에 구분을 위해 이너 클래스로 정의
	'일반적인 탄과 같은 움직임을 보임
	Public Class B_Bullet
		Inherits Bullet

		Public Sub New(sender As GameObject, id As String)
			UWidth = 15
			UHeight = 15
			SetDestroySprite()

			SetObjID("B_B" & id)

			objType = Type.EBullet
			USpeed = 10

			SetSprite("B_Bullet_S1_1")

			UPos = New PointF(sender.UPos.X, sender.UPos.Y + 20)

			SetCollider(UPos, UWidth, UHeight)
		End Sub

		Public Overrides Sub Move()
			SetIsPlayer(False)
			MyBase.Move()
		End Sub

	End Class

	'보스가 발사하는 유도 탄환
	Public Class B_Bullet_S1
		Inherits Bullet

		'타겟을 향한 단위 벡터 저장
		Private targetVector As SizeF

		Public Sub New(sender As GameObject, target As Player, id As String)
			UWidth = 30
			UHeight = 30
			SetDestroySprite()

			SetObjID("B_B_S1" & id)

			objType = Type.EBullet
			USpeed = 8

			'초기 위치 = 생성자로 넘어온 오브젝트의 앞
			UPos = New PointF(sender.UPos.X, sender.UPos.Y + 50)

			'타겟을 향한 벡터를 구한 뒤 Normalize하고 속도만큼 스칼라배
			Dim tempVector As Vector2
			tempVector = Vector2.Normalize(New Vector2(target.UPos.X - UPos.X, target.UPos.Y - UPos.Y))
			tempVector *= USpeed
			targetVector = New SizeF(tempVector.X, tempVector.Y)

			SetSprite("B_Bullet_S1_1")

			SetCollider(UPos, UWidth, UHeight)
		End Sub

		Public Overrides Sub Move()
			'발사 시점의 타겟으로 이동
			UPos = UPos + targetVector

			'범위 밖이면 삭제
			If UPos.X + UWidth + 100 < 0 OrElse UPos.X - UWidth > Form1.BoardWidth _
				OrElse UPos.Y - 100 > Form1.BoardHeight OrElse UPos.Y + 100 < 0 Then

				SetIsDest(True)
				Destroy()

			End If

			SetCollider(UPos)
		End Sub

	End Class


	'종속된 객체 보관
	'메인 루프와 Paint이벤트에서 직접 순회하며 참조할 것
	Public Drones As New List(Of Drone)

	'부모 생성자가 먼저 호출
	Public Sub New(stage_n As Integer, appeardif As Integer)
		'UHeight = 71
		'UWidth = 256
		'SetSprite("Boss_1_Default")

		'보스는 맵 밖에서 안으로 들어오는 형태
		UPos = New PointF(Form1.BoardWidth, 100)

		'SetCollider(New Point(UPos.X, UPos.Y + 39), 256, UHeight - 39)

		'Stage_N = 1
		IsExist = True
		'AppearDif = 8

		Me.Stage_N = stage_n
		Me.AppearDif = appeardif

	End Sub

	Public Overrides Function CollisionCheck(obj As GameObject) As Object
		If obj.UType = Type.PBullet Then
			Return MyBase.CollisionCheck(obj)
		Else
			Return False
		End If
	End Function

	'파괴 여부 체크
	'충돌했을 때 IsDestroyed가 True가 된다. 그때 체력을 1 줄이고 다시 False로 바꾼다.
	'그 다음 체력이 0인지 여부를 판단해서 0이라면 다시 파괴 여부 플래그를 True로 바꾸고 ㅆ
	'True를 반환, 그 외에는 False 반환
	Public Overrides Function Destroy() As Boolean
		'만약 IsDestroyed = True이면(=PBullet 타입과 충돌했다면)
		If GetIsDest() Then
			'체력을 1 줄인다.
			HealthByCount -= 1
			Debug.WriteLine("BossHelath = " & HealthByCount)
			SetIsDest(False)
			'체력이 0 이하인지 체크하고 0이하라면 콜라이더 제거 후 True를 반환한다.
			'0이 아니라면 체력의 양을 측정해서 그에 맞게 스프라이트 교체
			If HealthByCount <= 0 Then
				SetIsDest(True)
				SetCollider(New PointF(0, 0), 0, 0)
				SetSprite(SpriteByHealth(2))
				'딜레이 적용을 위한 DestroyCounter 증가(나중에 체크)
				IncDestroyedCounter()
				Return True
			ElseIf HealthByCount < (MaxHealthByCount / 4) Then
				SetSprite(SpriteByHealth(1))
			ElseIf HealthByCount < (MaxHealthByCount / 2) Then
				SetSprite(SpriteByHealth(0))
			End If
		End If
		Return False
	End Function

	'체력에 따른 스프라이트 변화 설정
	Public Sub SetSpriteByHealth(h As String, q As String, d As String)
		SpriteByHealth(0) = My.Resources.ResourceManager.GetObject(h)
		SpriteByHealth(1) = My.Resources.ResourceManager.GetObject(q)
		SpriteByHealth(2) = My.Resources.ResourceManager.GetObject(d)
	End Sub

	Public Sub SetMaxHealthByCount(mHealth As Integer)
		MaxHealthByCount = mHealth
		HealthByCount = mHealth
	End Sub

	'drone들 전부 파괴함
	Public Sub DestroyAllDrone()
		For Each drone As Drone In Drones
			drone.Destroy()
		Next
	End Sub

	'드론 배열을 비움
	Public Sub ClearDrones()
		Drones.Clear()
	End Sub

	'발사 간격 함수
	Public MustOverride Function CheckFireTerm()

End Class
