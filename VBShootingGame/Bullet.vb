Public Class Bullet
	Inherits GameObject

	Private IsPlayer As Boolean = True

	Private IsDestroyed As Boolean = False

	Public Sub New(sender As GameObject, IsP As Boolean, id As String)
		USpeed = 20
		UWidth = 42
		UHeight = 13

		'플레이어의 탄인지 아닌지 비교해서 다르게 초기화
		If IsP Then
			IsPlayer = True
			SetObjID("P_B" & id)
			SetSprite("P_Bullet")
			UPos = New Point(sender.UPos.X + sender.UWidth - 10, sender.UPos.Y + 20)
		Else
			IsPlayer = False
			SetObjID("E_B" & id)
			SetSprite("E_Bullet")
			UPos = New Point(sender.UPos.X, sender.UPos.Y + 20)
		End If

	End Sub

	Public Overrides Sub Move(dire As Form1.InputKeys)
		If IsPlayer Then
			UPos = New Point(UPos.X + USpeed, UPos.Y)
		Else
			UPos = New Point(UPos.X - USpeed, UPos.Y)
		End If
	End Sub

	'파괴 여부
	Public Overrides Function CheckDestroyed() As Boolean
		If IsDestroyed = True Then
			Return True
		ElseIf UPos.X < 0 Or UPos.X > Form1.BoardWidth Then
			IsDestroyed = True
			Return True
		Else
			Return False
		End If
	End Function

	'소멸자
	Protected Overrides Sub Finalize()
		USprite.Dispose()
	End Sub


End Class
