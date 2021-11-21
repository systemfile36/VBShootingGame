'스코어를 관리하는 클래스
'스코어는 가산이 아닌 할때마다 갱신
Public Class ScoreManager
	Private Score As Integer = 0
	Private KillCount As Integer = 0

	Private BossKillCount As Integer = 0

	'격추 여부를 확인하는 변수, MainTimer와 이 객체에서만 참조
	Public IsKilled As Boolean = False
	Public IsBossKilled As Boolean = False

	'점수 계산후 저장
	'게임 진행시간을 초 단위로 받아서 점수 계산
	Public Sub SetScore(gameSec As Long)

		If gameSec = 0 Then
			Exit Sub
		End If

		Score = (gameSec * 100) + (KillCount * 200) + (BossKillCount * 2000)
	End Sub

	Public Sub ResetScore()
		Score = 0
	End Sub

	Public Function GetScore()
		Return Score
	End Function

	Public Sub IncKillCount()
		KillCount += 1
		IsKilled = True
	End Sub

	Public Sub IncBossKillCount()
		BossKillCount += 1
		IsBossKilled = True
	End Sub
End Class
