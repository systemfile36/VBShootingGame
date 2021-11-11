﻿Public Class Bullet
	Inherits GameObject

	Private IsPlayer As Boolean = True

	Private IsDestroyed As Boolean = False

	Public Sub New(sender As GameObject, IsP As Boolean, id As Integer)
		USpeed = 20
		UWidth = 42
		UHeight = 13
		SetObjID(id)
		If IsP Then
			IsPlayer = True
			SetSprite("P_Bullet.png")
			UPos = New Point(sender.UPos.X + sender.UWidth - 10, sender.UPos.Y + 20)
		Else
			IsPlayer = False
			SetSprite("E_Bullet.png")
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

	Protected Overrides Sub Finalize()
		USprite.Dispose()
	End Sub


End Class