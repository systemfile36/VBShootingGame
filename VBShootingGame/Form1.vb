﻿'게임이 실행되는 메인 폼
'객체 지향을 통해 다형성 구현
'처리 함수는 일관되게 하고 수정은 각 오브젝트 클래스에서 행함
'ex)각 객체에 자신의 좌표를 변경하는 Move함수가 오버로딩 되어 있음
'갱신 할때 Move함수를 호출만 하면 됨, 오류가 생기면 그 객체만 고치면 됨
'삭제 과정에서 오버헤드 가능성 있음
'Resource를 사용하여 모든 리소스 파일이 실행파일에 합쳐집니다!


Imports System.Threading
Imports System.Collections.Concurrent
Public Class Form1
	Private player As GameObject

	'적 생성 간격 변수
	Private TermTickEnemy As Long = 50000000L
	Private DelayTickEnemy As Long = 0

	'ThreadOther에서 조작하는 기타 오브젝트 List<T>
	Private OtherObjects As New List(Of GameObject)
	Private NumberofObj As Integer = 0

	'플레이어 컨트롤 변수
	Private p_control As InputKeys = InputKeys.None

	'발사 여부 함수
	Private launch_control As Boolean = False

	'입력 갱신 스레드
	Private trd_input As Thread

	'기타 오브젝트 갱신 스레드
	Private trd_other As Thread

	'난수 생성기
	Private rand As New Random()

	Public Enum InputKeys
		Left
		Right
		Up
		Down
		Space
		None
	End Enum

	'캔버스 크기 상수
	Public Const BoardWidth As Integer = 1200, BoardHeight As Integer = 600

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		player = New Player()

		'입력 스레드 생성 후 실행
		trd_input = New Thread(AddressOf ThreadInput)
		trd_input.IsBackground = True
		trd_input.Start()

		'다른 오브젝트 갱신용 스레드 생성 후 실행
		trd_other = New Thread(AddressOf ThreadOther)
		trd_other.IsBackground = True
		trd_other.Start()

		'적 생성 간격용
		DelayTickEnemy = Now.Ticks


		Me.KeyPreview = True
	End Sub

	Private Sub MainTimer_Tick(sender As Object, e As EventArgs) Handles MainTimer.Tick
		Invalidate()
	End Sub

	'키 입력이 들어오면 거기에 맞춰 방향을 설정만 함 갱신은 스레드에서
	Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

		If e.KeyCode = Keys.W Then
			p_control = InputKeys.Up
		ElseIf e.KeyCode = Keys.A Then
			p_control = InputKeys.Left
		ElseIf e.KeyCode = Keys.S Then
			p_control = InputKeys.Down
		ElseIf e.KeyCode = Keys.D Then
			p_control = InputKeys.Right
		ElseIf e.KeyCode = Keys.Space Then
			launch_control = True
		End If

	End Sub

	'키 입력이 해제되면 방향을 None으로 설정해서 멈추게 함
	Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
		p_control = InputKeys.None

	End Sub

	Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
		'플레이어를 그림
		e.Graphics.DrawImage(player.USprite, New Rectangle(player.UPos.X, player.UPos.Y, 122, 32))

		'열거 오류 예외 처리
		Try
			For Each obj As GameObject In OtherObjects
				e.Graphics.DrawImage(obj.USprite, New Rectangle(obj.UPos.X, obj.UPos.Y, obj.UWidth, obj.UHeight))
			Next
		Catch ex As Exception
			lbDebug.Text = "Exception Iter"
		End Try
		lbDebug.Text = NumberofObj
	End Sub

	'부드러운 움직임을 위해 스레드 사용
	'방향 변수를 감시하면서 일정하게 이동시킴
	Private Sub ThreadInput()
		Do
			Select Case p_control
				Case InputKeys.Up
					player.Move(InputKeys.Up)
				Case InputKeys.Left
					player.Move(InputKeys.Left)
				Case InputKeys.Down
					player.Move(InputKeys.Down)
				Case InputKeys.Right
					player.Move(InputKeys.Right)
			End Select
			Thread.Sleep(20)
		Loop
	End Sub

	'플레이어 외 오브젝트 갱신
	Private Sub ThreadOther()
		'삭제할 물건 저장용 리스트
		Dim removeObj As New List(Of GameObject)
		Do
			Try
				'적 생성
				If Now.Ticks - DelayTickEnemy > TermTickEnemy Then
					NumberofObj += 1
					OtherObjects.Add(New Enemy(NumberofObj))

					DelayTickEnemy = Now.Ticks
				End If

				'총탄 생성
				If launch_control Then
					NumberofObj += 1
					OtherObjects.Add(New Bullet(player, True, NumberofObj))

					launch_control = False
				End If

				'오브젝트들 갱신
				For Each obj As GameObject In OtherObjects
					obj.Move(-1)
					'파괴 확인
					If obj.CheckDestroyed() Then
						'파괴할 물건을 저장 (열거 오류를 막기위해)
						removeObj.Add(obj)
					End If


				Next

				'실제 삭제 반영
				For Each obj As GameObject In removeObj
					'removeObj에 있는 것과 같은 아이디를 가진 물건 삭제
					If OtherObjects.Remove(obj) Then
						NumberofObj -= 1
					End If

				Next

				'삭제를 위한 배열 비우기
				removeObj.Clear()

				Thread.Sleep(20)
			Catch ex As Exception
				'열거가 잘못되는 오류가 발생할 수 있지만 무시함
				Task.Run(Sub()
							 MsgBox(ex.ToString())
						 End Sub)
				Thread.Sleep(0)
				Continue Do
			End Try

		Loop
	End Sub

End Class
