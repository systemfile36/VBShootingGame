'적 타입 객체
'만약 새로운 적을 추가한다면 이 객체를 상속받을 것이다.

Public Class Enemy
	Inherits GameObject

	Private IsUp As Boolean = False

	Private FireTerm As Long = 30000000L
	Private FireTick As Long = 0

	Public Sub New(id As String)
		SetSprite("E_Default")
		IsEnemy = True
		USpeed = 5
		UWidth = 122
		UHeight = 32
		SetObjID("E" & id)
		UPos = New Point(Form1.BoardWidth - UWidth - 100, 100)

		'발사 간격을 위한 시간 설정
		FireTick = Now.Ticks


	End Sub

	Public Overrides Sub Move(dire As Form1.InputKeys)
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
	End Sub

	'기록한 시간을 비교해서 발사간격 시간에 도달하면
	'IsFire를 True로 바꾸고 FIreTick 조정
	Public Sub EnemyCanShot()
		If Now.Ticks - FireTick > FireTerm Then
			IsFire = True
			FireTick = Now.Ticks
		End If
	End Sub

End Class
