'적 타입 객체
'만약 새로운 적을 추가한다면 이 객체를 상속받을 것이다.

Public Class Enemy
	Inherits GameObject

	Private IsUp As Boolean = False

	Private FireTerm As Long = 20000000L
	Private FireTick As Long = 0

	Public Sub New(id As String)
		SetSprite("E_Default")
		SetDestroySprite()

		objType = Type.Enemy

		USpeed = 5
		UWidth = 122
		UHeight = 32
		SetObjID("E" & id)
		UPos = New Point(Form1.BoardWidth - UWidth - 100, 100)

		'충돌 범위 설정
		SetCollider(UPos, UWidth, UHeight + 10)

		'발사 간격을 위한 시간 설정
		FireTick = Now.Ticks

		'등장할 때부터 사격 하기 위해
		IsFire = True

	End Sub

	Public Overrides Sub Move()
		If UPos.Y < 0 Then
			IsUp = False
		ElseIf UPos.Y + UHeight > Form1.BoardHeight Then
			IsUp = True
		End If

		If IsUp Then
			UPos = New Point(UPos.X, UPos.Y - USpeed)
		Else
			UPos = New Point(UPos.X, UPos.Y + USpeed)
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

		If Now.Ticks - FireTick > FireTerm Or IsFire = True Then
			IsFire = True
			FireTick = Now.Ticks
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
