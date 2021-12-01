'적 타입 객체
'만약 새로운 적을 추가한다면 이 객체를 상속받을 것이다.

Public Class Enemy
	Inherits GameObject

	Private IsUp As Boolean = False

	Private FireTerm As Long = 20000000L
	Private FireTick As Long = 0

	Public Sub New(id As String)
		SetSprite(Type.Enemy)
		SetDestroySprite()

		objType = Type.Enemy

		USpeed = 5
		UWidth = 122
		UHeight = 32
		SetObjID("E" & id)
		UPos = New PointF(Form1.BoardWidth - UWidth - 100, 100)

		'충돌 범위 설정
		SetCollider(UPos, UWidth, UHeight + 10)

		'발사 간격을 위한 시간 설정
		FireTick = Form1.GNowTick - FireTerm

		'등장할 때부터 사격 하기 위해
		IsFire = True

	End Sub

	'랜덤한 숫자를 받아서 생성 위치를 정하는 생성자
	'추가로 난이도도 받아서 발사 간격을 조정
	Public Sub New(id As String, rNum As Integer, dif As Integer)
		'위의 생성자 호출
		Me.New(id)

		'여기서 바뀐부분만 실행
		UPos = New PointF(Form1.BoardWidth - UWidth - 100, rNum)
		SetCollider(UPos, UWidth, UHeight + 10)

		'랜덤한 숫자에 따라 속도 변경
		USpeed = 3 + (rNum Mod 4 + 1)

		'난이도가 상승할때마다 0.3초씩 빠르게 발사한다.
		'최소값 = 600ms = 0.6초
		SetFireTerm(Math.Max((FireTerm / 10000) - ((dif - 1) * 300), 600))

		'Debug.WriteLine(FireTerm)

	End Sub

	Public Overrides Sub Move()
		If UPos.Y < 0 Then
			IsUp = False
		ElseIf UPos.Y + UHeight > Form1.BoardHeight Then
			IsUp = True
		End If

		If IsUp Then
			UPos = New PointF(UPos.X, UPos.Y - USpeed)
		Else
			UPos = New PointF(UPos.X, UPos.Y + USpeed)
		End If

		'콜라이더 갱신
		SetCollider(UPos)
	End Sub

	'기록한 시간을 비교해서 발사간격 시간에 도달하면
	'IsFire를 True로 바꾸고 FIreTick 조정
	Public Function CheckFireTerm()
		'파괴되었을 때는 무조건 False
		If GetIsDest() Then
			Return False
		End If

		If Form1.GNowTick - FireTick > FireTerm Then
			FireTick = Form1.GNowTick
			Return True
		Else
			Return False
		End If
	End Function

	'발사간격 설정 함수
	'하한선 80ms, 상한선 3000ms
	Public Sub SetFireTerm(milsec As Integer)
		If milsec < 80 Then
			FireTerm = 80 * 10000
		ElseIf milsec > 3000 Then
			FireTerm = 3000 * 10000
		Else
			FireTerm = milsec * 10000
		End If
	End Sub

	'충돌한 것이 플레이어 탄일때만 서로 파괴, 그외엔 무시
	Public Overrides Function CollisionCheck(obj As GameObject) As Object
		If obj.UType = Type.PBullet Then
			Return MyBase.CollisionCheck(obj)
		Else
			Return False
		End If
	End Function

End Class
