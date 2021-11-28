Public Class SelectPlayer
	Private SelectType As String = "P_Default"
	Private Sub SelectPlayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		lbDefaultInfo.Text = "기체 타입 : Default" & vbCrLf & vbCrLf & "연사력 : " & My.Settings.PFireDelay _
			& "ms 당 1발" & vbCrLf & vbCrLf & "장탄수 : Infinity" & vbCrLf & vbCrLf & vbCrLf & "기본적인 형태의 기체입니다." _
			& vbCrLf & "보통 연사속도로 총알을 지속적으로 발사합니다."

		lbType1Info.Text = "기체 타입 : Type_1" & vbCrLf & vbCrLf & "연사력 : " & My.Settings.PFireDelay / 2 _
			& "ms 당 1발" & vbCrLf & vbCrLf & "장탄수 : 5발" & vbCrLf & vbCrLf & vbCrLf & "순간 연사 계열의 기체입니다." _
			& vbCrLf & "보통 기체보다 두 배 빠른 속도로 발사하는 대신 장탄수를 전부 소비하면 " & (My.Settings.PFireDelay / 2) * 5 & "ms의 재장전 시간이 필요합니다."

		lbType2Info.Text = "기체 타입 : Type_1" & vbCrLf & vbCrLf & "연사력 : " & My.Settings.PFireDelay * 3.5 _
			& "ms 당 1회" & vbCrLf & vbTab & "1회 5발, 분산도 : 20도" & vbCrLf & vbCrLf & "장탄수 : Infinity" & vbCrLf & vbCrLf & vbCrLf & "한번에 다섯발을 넓게 퍼뜨리며 발사하는 타입입니다." _
			& vbCrLf & "연사력이 상대적으로 느린 대신 멀리 떨어진 적도 공격할 수 있습니다."

	End Sub

	Private Sub SelectComplete()
		Form1.SelectedPlane = SelectType
		Form1.Show()
		Me.Close()
	End Sub

	'라벨을 클릭해도 선택되도록
	Private Sub Default_Click(sender As Object, e As EventArgs) Handles btnDefault.Click, lbDefaultInfo.Click
		SelectType = "P_Default"
		SelectComplete()
	End Sub

	Private Sub Type1_Click(sender As Object, e As EventArgs) Handles btnType1.Click, lbType1Info.Click
		SelectType = "P_Type_1"
		SelectComplete()
	End Sub

	Private Sub Type2_Click(sender As Object, e As EventArgs) Handles btnType2.Click, lbType2Info.Click
		SelectType = "P_Type_2"
		SelectComplete()
	End Sub


	'버튼 이벤트 일괄 적용
	'모든 버튼에 이벤트 연결, sender를 하향형변환해서 사용
	Private Sub Button_MouseMove(sender As Object, e As MouseEventArgs) Handles btnDefault.MouseMove, btnType1.MouseMove, btnType2.MouseMove
		TryCast(sender, Button).BackgroundImage = My.Resources.ButtonBase_Hover
	End Sub

	'라벨들 위에 마우스 진입했을때도 소리 재생되도록
	Private Sub Button_MouseEnter(sender As Object, e As EventArgs) Handles btnDefault.MouseEnter, btnType1.MouseEnter, btnType2.MouseEnter _
		, lbDefaultInfo.MouseEnter, lbType1Info.MouseEnter, lbType2Info.MouseEnter
		My.Computer.Audio.Play(My.Resources.Button_hover, AudioPlayMode.Background)
	End Sub

	Private Sub Button_MouseLeave(sender As Object, e As EventArgs) Handles btnDefault.MouseLeave, btnType1.MouseLeave, btnType2.MouseLeave
		TryCast(sender, Button).BackgroundImage = My.Resources.ButtonBase_Default
	End Sub

	Private Sub Button_MouseUp(sender As Object, e As MouseEventArgs) Handles btnDefault.MouseUp, btnType1.MouseUp, btnType2.MouseUp
		TryCast(sender, Button).BackgroundImage = My.Resources.ButtonBase_Default
	End Sub

	Private Sub Button_Enter(sender As Object, e As EventArgs) Handles btnDefault.Enter, btnType1.Enter, btnType2.Enter
		TryCast(sender, Button).BackgroundImage = My.Resources.ButtonBase_Hover
	End Sub

	Private Sub Button_Leave(sender As Object, e As EventArgs) Handles btnDefault.Leave, btnType1.Leave, btnType2.Leave
		TryCast(sender, Button).BackgroundImage = My.Resources.ButtonBase_Default
	End Sub

	Private Sub Button_MouseDown(sender As Object, e As EventArgs) Handles btnDefault.MouseDown, btnType1.MouseDown, btnType2.MouseDown
		TryCast(sender, Button).BackgroundImage = My.Resources.ButtonBase_Click
	End Sub

	Private Sub Button_MouseUp(sender As Object, e As EventArgs) Handles btnDefault.MouseUp, btnType1.MouseUp, btnType2.MouseUp
		TryCast(sender, Button).BackgroundImage = My.Resources.ButtonBase_Default
	End Sub

	'버튼이 포커스 되어있지 않으면 Focus()를 실행해서 각 버튼의 .Enter이벤트 발생시킴
	Private Sub InfoDefault_MouseEnter(sender As Object, e As EventArgs) Handles lbDefaultInfo.MouseEnter
		If Not btnDefault.Focused Then
			btnDefault.Focus()
		End If
	End Sub

	Private Sub InfoType1_MouseEnter(sender As Object, e As EventArgs) Handles lbType1Info.MouseEnter
		If Not btnType1.Focused Then
			btnType1.Focus()
		End If
	End Sub

	Private Sub InfoType2_MouseEnter(sender As Object, e As EventArgs) Handles lbType2Info.MouseEnter
		If Not btnType2.Focused Then
			btnType2.Focus()
		End If
	End Sub

	'라벨에서 마우스가 떠나면 Button_Leave도 발생시킴
	Private Sub InfoDefault_MouseLeave(sender As Object, e As EventArgs) Handles lbDefaultInfo.MouseLeave
		If btnDefault.Focused Then
			lbSTitle.Focus()
			Button_Leave(btnDefault, e)
		End If
	End Sub

	Private Sub InfoType1_MouseLeave(sender As Object, e As EventArgs) Handles lbType1Info.MouseLeave
		If btnType1.Focused Then
			lbSTitle.Focus()
			Button_Leave(btnType1, e)
		End If
	End Sub

	Private Sub InfoType2_MouseLeave(sender As Object, e As EventArgs) Handles lbType2Info.MouseLeave
		If btnType2.Focused Then
			lbSTitle.Focus()
			Button_Leave(btnType2, e)
		End If
	End Sub
End Class