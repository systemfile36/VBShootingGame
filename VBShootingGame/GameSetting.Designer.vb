<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameSetting
	Inherits System.Windows.Forms.Form

	'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Windows Form 디자이너에 필요합니다.
	Private components As System.ComponentModel.IContainer

	'참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
	'수정하려면 Windows Form 디자이너를 사용하십시오.  
	'코드 편집기에서는 수정하지 마세요.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.tbMLInterval = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.tbMLTInterval = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.tbESpawn = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.tbDifTerm = New System.Windows.Forms.TextBox()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.tbPSpeed = New System.Windows.Forms.TextBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.tbPFireDelay = New System.Windows.Forms.TextBox()
		Me.btnReset = New System.Windows.Forms.Button()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("맑은 고딕", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.Label1.Location = New System.Drawing.Point(13, 13)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(395, 25)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "일정 범위를 벗어난 값은 저장되지 않습니다!"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(12, 119)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(173, 12)
		Me.Label2.TabIndex = 1
		Me.Label2.Text = "MainLoop의 Interval(ms 단위)"
		'
		'tbMLInterval
		'
		Me.tbMLInterval.Location = New System.Drawing.Point(196, 116)
		Me.tbMLInterval.Name = "tbMLInterval"
		Me.tbMLInterval.Size = New System.Drawing.Size(100, 21)
		Me.tbMLInterval.TabIndex = 2
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(12, 191)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(178, 12)
		Me.Label3.TabIndex = 3
		Me.Label3.Text = "MainTimer의 Interval(ms 단위)"
		'
		'tbMLTInterval
		'
		Me.tbMLTInterval.Location = New System.Drawing.Point(196, 188)
		Me.tbMLTInterval.Name = "tbMLTInterval"
		Me.tbMLTInterval.Size = New System.Drawing.Size(100, 21)
		Me.tbMLTInterval.TabIndex = 4
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(14, 263)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(163, 12)
		Me.Label4.TabIndex = 5
		Me.Label4.Text = "초기 적 스폰 주기(Tick 단위)"
		'
		'tbESpawn
		'
		Me.tbESpawn.Location = New System.Drawing.Point(196, 260)
		Me.tbESpawn.Name = "tbESpawn"
		Me.tbESpawn.Size = New System.Drawing.Size(100, 21)
		Me.tbESpawn.TabIndex = 6
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(16, 335)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(159, 12)
		Me.Label5.TabIndex = 7
		Me.Label5.Text = "난이도 갱신 주기(Tick 단위)"
		'
		'tbDifTerm
		'
		Me.tbDifTerm.Location = New System.Drawing.Point(196, 332)
		Me.tbDifTerm.Name = "tbDifTerm"
		Me.tbDifTerm.Size = New System.Drawing.Size(100, 21)
		Me.tbDifTerm.TabIndex = 8
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(352, 119)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(237, 12)
		Me.Label6.TabIndex = 9
		Me.Label6.Text = "플레이어 기체 속도(1루프 당 좌표 이동 값)"
		'
		'tbPSpeed
		'
		Me.tbPSpeed.Location = New System.Drawing.Point(595, 116)
		Me.tbPSpeed.Name = "tbPSpeed"
		Me.tbPSpeed.Size = New System.Drawing.Size(100, 21)
		Me.tbPSpeed.TabIndex = 10
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Location = New System.Drawing.Point(352, 191)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(193, 12)
		Me.Label7.TabIndex = 11
		Me.Label7.Text = "플레이어 기체 연사 속도(ms 단위)"
		'
		'tbPFireDelay
		'
		Me.tbPFireDelay.Location = New System.Drawing.Point(595, 188)
		Me.tbPFireDelay.Name = "tbPFireDelay"
		Me.tbPFireDelay.Size = New System.Drawing.Size(100, 21)
		Me.tbPFireDelay.TabIndex = 12
		'
		'btnReset
		'
		Me.btnReset.Location = New System.Drawing.Point(14, 390)
		Me.btnReset.Name = "btnReset"
		Me.btnReset.Size = New System.Drawing.Size(119, 48)
		Me.btnReset.TabIndex = 13
		Me.btnReset.Text = "초기값으로 돌리기"
		Me.btnReset.UseVisualStyleBackColor = True
		'
		'btnSave
		'
		Me.btnSave.Location = New System.Drawing.Point(354, 390)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(119, 48)
		Me.btnSave.TabIndex = 14
		Me.btnSave.Text = "저장하고 타이틀로"
		Me.btnSave.UseVisualStyleBackColor = True
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Location = New System.Drawing.Point(16, 66)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(109, 12)
		Me.Label8.TabIndex = 15
		Me.Label8.Text = "숫자만 입력됩니다."
		'
		'GameSetting
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ClientSize = New System.Drawing.Size(800, 450)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.btnSave)
		Me.Controls.Add(Me.btnReset)
		Me.Controls.Add(Me.tbPFireDelay)
		Me.Controls.Add(Me.Label7)
		Me.Controls.Add(Me.tbPSpeed)
		Me.Controls.Add(Me.Label6)
		Me.Controls.Add(Me.tbDifTerm)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.tbESpawn)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.tbMLTInterval)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.tbMLInterval)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "GameSetting"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "GameSetting"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Label1 As Label
	Friend WithEvents Label2 As Label
	Friend WithEvents tbMLInterval As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents tbMLTInterval As TextBox
	Friend WithEvents Label4 As Label
	Friend WithEvents tbESpawn As TextBox
	Friend WithEvents Label5 As Label
	Friend WithEvents tbDifTerm As TextBox
	Friend WithEvents Label6 As Label
	Friend WithEvents tbPSpeed As TextBox
	Friend WithEvents Label7 As Label
	Friend WithEvents tbPFireDelay As TextBox
	Friend WithEvents btnReset As Button
	Friend WithEvents btnSave As Button
	Friend WithEvents Label8 As Label
End Class
