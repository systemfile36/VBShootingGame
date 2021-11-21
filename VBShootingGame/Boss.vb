'Boss 타입 적 정의 객체
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

	Public Sub New(stage_n As Integer, appeardif As Integer)
		'UHeight = 71
		'UWidth = 256
		'SetSprite("Boss_1_Default")
		UPos = New Point(Form1.BoardWidth, 100)

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
				SetCollider(New Point(0, 0), 0, 0)
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

End Class
