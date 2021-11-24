'Type_1 player 객체

Public Class Player_Type1
	Inherits Player

	Private IsReroading As Boolean = False

	Private ReloadingTick As Long = 0
	Private ReloadingDelay As Long

	Private Ammo As Integer = 5

	Public Sub New()
		'재장전 요소를 제외한 것들은 부모생성자에서 초기화됨
		MyBase.New("P_Type_1")

		'두배 속도로 5발 쏘는 만큼의 재장전 시간
		ReloadingDelay = (FireDelay / 2) * 5

	End Sub

	'오버라이딩 해서 재장전 구현
	Public Overrides Function CheckFireDelay() As Boolean
		'만약 총알이 0일때 
		If Ammo <= 0 Then
			'재장전 중이 아니라면
			If IsReroading = False Then
				'재장전을 시작한 시간을 기록하고 플래그를 True로
				ReloadingTick = Now.Ticks
				IsReroading = True
			Else
				'재장전 중이라면 시간 체크
				'만약 재장전이 끝난 시간이면 총알을 채우고 플래그를 내림
				If Now.Ticks - ReloadingTick > ReloadingDelay Then
					Ammo = 5
					IsReroading = False
				End If
			End If
		End If

		'연사 시간에 도달했고 재장전 중이 아닐때만 발사 후 총알 감소
		If IsInputFire = True AndAlso Now.Ticks - FireTick > (FireDelay / 2) _
			AndAlso IsReroading = False Then
			FireTick = Now.Ticks
			Ammo -= 1
			Return True
		Else
			Return False
		End If
	End Function

	Public Overrides Function GetAmmo() As Integer
		Return Ammo
	End Function

End Class
