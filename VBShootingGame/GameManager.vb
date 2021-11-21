'게임의 진행을 관리하는 클래스
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

	'보스 정보 저장 큐
	Private BossInfo As New Queue(Of Boss)

	'보스 존재 여부
	'보스가 존재하면 난이도 상승과 적 스폰을 멈춘다.
	Private IsBossExist As Boolean = False
	Public ReadOnly Property UIsBossExist
		Get
			Return IsBossExist
		End Get
	End Property


	Public Sub New()
		'첫번째 보스 추가
		BossInfo.Enqueue(New Boss_S1())
	End Sub


	Public Sub IncDifficulty()
		'함수가 호출된 시점에서 마지막으로 DifTick이
		'초기화된 시점을 뺀 것이 난이도 상승 간격보다
		'크다면(=갱신주기에 도달했다면) 난이도를 갱신하고 DifTick도 갱신한다.
		If Now.Ticks - DifTick > DifTerm And IsBossExist = False Then
			Difficulty += 1
			'0.5초씩 짧아짐
			ESpawnTerm -= 5000000L

			'스폰 주기의 최소값(500ms)
			If ESpawnTerm < 5000000L Then
				ESpawnTerm = 5000000L
			End If
			DifTick = Now.Ticks
		End If
	End Sub

	Public Sub SetSTime(tick As Long)
		StartedTime = tick
		DifTick = tick
		DelayTickEnemy = tick
	End Sub

	'보스가 존재하지 않을때만 소환
	Public Function CheckSpawnEnemy() As Boolean
		If Now.Ticks - DelayTickEnemy > ESpawnTerm And IsBossExist = False Then
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

	Public Sub SetSpawnTerm(spterm As Long)
		ESpawnTerm = spterm

		'최소값 1sec, 최대값 10sec
		If ESpawnTerm < 10000000 Then
			ESpawnTerm = 10000000
		ElseIf ESpawnTerm > 100000000 Then
			ESpawnTerm = 100000000
		End If
	End Sub

	Public Sub SetDifTerm(dterm As Long)
		DifTerm = dterm

		'최소값 3sec, 최대값 30sec
		If DifTerm < 30000000 Then
			DifTerm = 30000000
		ElseIf DifTerm > 300000000 Then
			DifTerm = 300000000
		End If
	End Sub

	Public Sub SetIsBossExistFalse()
		IsBossExist = False
	End Sub

	'보스 출현 난이도 체크 후 보스 객체 반환
	Public Function ControlBossAppear()
		'만약 제일 먼저 들어온 보스의 출현 난이도가 현재 난이도와 같다면 뽑아서 반환
		If BossInfo.Count <> 0 AndAlso BossInfo.Peek().AppearDif = Difficulty Then
			IsBossExist = True
			Return BossInfo.Dequeue()
		Else
			Return Nothing
		End If
	End Function
End Class
