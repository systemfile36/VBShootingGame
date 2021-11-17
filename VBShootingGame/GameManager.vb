﻿'게임의 진행을 관리하는 클래스
Public Class GameManager
	'적 스폰 주기
	Private ESpawnTerm As Long = 50000000L
	Private DelayTickEnemy As Long = 0

	'난이도 변화 주기
	Private DifTerm As Long = 70000000L
	Private DifTick As Long = 0

	Private Difficulty As Integer = 1
	Private StartedTime As Long = 0

	'일시 정지한 시간동안 게임 시간 측정을 멈추기 위해
	Private PausedTime As Long = 0
	Private PausedTick As Long = 0

	Public Sub IncDifficulty()
		'함수가 호출된 시점에서 마지막으로 DifTick이
		'초기화된 시점을 뺀 것이 난이도 상승 간격보다
		'크다면 난이도를 갱신하고 DifTick도 갱신한다.
		If Now.Ticks - DifTick > DifTerm Then
			Difficulty += 1
			'0.5초씩 짧아짐
			ESpawnTerm -= 5000000L

			'스폰 주기의 최소값
			If ESpawnTerm < 10000000L Then
				ESpawnTerm = 10000000L
			End If
			DifTick = Now.Ticks
		End If
	End Sub

	Public Sub SetSTime(tick As Long)
		StartedTime = tick
		DifTick = tick
		DelayTickEnemy = tick
	End Sub

	Public Function CheckSpawnEnemy() As Boolean
		If Now.Ticks - DelayTickEnemy > ESpawnTerm Then
			Return True
		Else
			Return False
		End If
	End Function

	Public Sub ResetDelayTickEnemy()
		DelayTickEnemy = Now.Ticks
	End Sub

	'게임 시간 반환
	Public Function GetGameSec() As Integer
		Return CInt((Now.Ticks - StartedTime) / 10000000)
	End Function

	Public Function GetDifficulty()
		Return Difficulty
	End Function

	'일시 정지한 시간을 점수 계산에 반영하지 않기 위해
	Public Sub PauseTime()
		PausedTick = Now.Ticks
	End Sub

	Public Sub ResumeTime()
		PausedTime = Now.Ticks - PausedTick

		StartedTime += PausedTime

	End Sub

	Public Function GetGameMil() As Integer
		Return CInt((Now.Ticks - StartedTime) / 10000)
	End Function

End Class
