'스코어를 관리하는 클래스
'스코어는 가산이 아닌 할때마다 갱신
Public Class ScoreManager
	Private Score As Integer = 0
	Private KillCount As Integer = 0

	'점수 계산후 저장
	'게임 진행시간을 초 단위로 받아서 점수 계산
	Public Sub SetScore(gameSec As Long)

		If gameSec = 0 Then
			Exit Sub
		End If

		Score = (gameSec * 100) + (KillCount * 200)
	End Sub

	Public Sub ResetScore()
		Score = 0
	End Sub

	Public Function GetScore()
		Return Score
	End Function

	Public Sub IncKillCount()
		KillCount += 1
	End Sub



End Class
