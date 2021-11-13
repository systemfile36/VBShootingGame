<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartUp
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
		Me.btnStart = New System.Windows.Forms.Button()
		Me.btnExit = New System.Windows.Forms.Button()
		Me.btnSetting = New System.Windows.Forms.Button()
		Me.btnInfo = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("HY견고딕", 50.0!)
		Me.Label1.Location = New System.Drawing.Point(161, 55)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(453, 67)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Temp Game"
		'
		'btnStart
		'
		Me.btnStart.Location = New System.Drawing.Point(300, 145)
		Me.btnStart.Name = "btnStart"
		Me.btnStart.Size = New System.Drawing.Size(175, 80)
		Me.btnStart.TabIndex = 1
		Me.btnStart.Text = "Game Start!"
		Me.btnStart.UseVisualStyleBackColor = True
		'
		'btnExit
		'
		Me.btnExit.Location = New System.Drawing.Point(300, 346)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(175, 80)
		Me.btnExit.TabIndex = 2
		Me.btnExit.Text = "Quit Game!"
		Me.btnExit.UseVisualStyleBackColor = True
		'
		'btnSetting
		'
		Me.btnSetting.Location = New System.Drawing.Point(173, 247)
		Me.btnSetting.Name = "btnSetting"
		Me.btnSetting.Size = New System.Drawing.Size(175, 80)
		Me.btnSetting.TabIndex = 3
		Me.btnSetting.Text = "Game Setting"
		Me.btnSetting.UseVisualStyleBackColor = True
		'
		'btnInfo
		'
		Me.btnInfo.Location = New System.Drawing.Point(439, 247)
		Me.btnInfo.Name = "btnInfo"
		Me.btnInfo.Size = New System.Drawing.Size(175, 80)
		Me.btnInfo.TabIndex = 4
		Me.btnInfo.Text = "Game Info"
		Me.btnInfo.UseVisualStyleBackColor = True
		'
		'StartUp
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ClientSize = New System.Drawing.Size(800, 450)
		Me.Controls.Add(Me.btnInfo)
		Me.Controls.Add(Me.btnSetting)
		Me.Controls.Add(Me.btnExit)
		Me.Controls.Add(Me.btnStart)
		Me.Controls.Add(Me.Label1)
		Me.MaximizeBox = False
		Me.Name = "StartUp"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "StartUp"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Label1 As Label
	Friend WithEvents btnStart As Button
	Friend WithEvents btnExit As Button
	Friend WithEvents btnSetting As Button
	Friend WithEvents btnInfo As Button
End Class
