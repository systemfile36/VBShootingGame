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
		Me.btnStart = New System.Windows.Forms.Button()
		Me.btnExit = New System.Windows.Forms.Button()
		Me.btnSetting = New System.Windows.Forms.Button()
		Me.btnInfo = New System.Windows.Forms.Button()
		Me.btnScoreBoard = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'btnStart
		'
		Me.btnStart.BackColor = System.Drawing.Color.Transparent
		Me.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnStart.FlatAppearance.BorderSize = 0
		Me.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
		Me.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnStart.Location = New System.Drawing.Point(357, 264)
		Me.btnStart.Name = "btnStart"
		Me.btnStart.Size = New System.Drawing.Size(175, 80)
		Me.btnStart.TabIndex = 1
		Me.btnStart.Text = "Game Start!"
		Me.btnStart.UseVisualStyleBackColor = False
		'
		'btnExit
		'
		Me.btnExit.BackColor = System.Drawing.Color.Transparent
		Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnExit.FlatAppearance.BorderSize = 0
		Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
		Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnExit.Location = New System.Drawing.Point(357, 436)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(175, 80)
		Me.btnExit.TabIndex = 2
		Me.btnExit.Text = "Quit Game!"
		Me.btnExit.UseVisualStyleBackColor = False
		'
		'btnSetting
		'
		Me.btnSetting.BackColor = System.Drawing.Color.Transparent
		Me.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnSetting.FlatAppearance.BorderSize = 0
		Me.btnSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
		Me.btnSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnSetting.Location = New System.Drawing.Point(228, 350)
		Me.btnSetting.Name = "btnSetting"
		Me.btnSetting.Size = New System.Drawing.Size(175, 80)
		Me.btnSetting.TabIndex = 3
		Me.btnSetting.Text = "Game Setting"
		Me.btnSetting.UseVisualStyleBackColor = False
		'
		'btnInfo
		'
		Me.btnInfo.BackColor = System.Drawing.Color.Transparent
		Me.btnInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnInfo.FlatAppearance.BorderSize = 0
		Me.btnInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
		Me.btnInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnInfo.Location = New System.Drawing.Point(481, 350)
		Me.btnInfo.Name = "btnInfo"
		Me.btnInfo.Size = New System.Drawing.Size(175, 80)
		Me.btnInfo.TabIndex = 4
		Me.btnInfo.Text = "Game Info"
		Me.btnInfo.UseVisualStyleBackColor = False
		'
		'btnScoreBoard
		'
		Me.btnScoreBoard.BackColor = System.Drawing.Color.Transparent
		Me.btnScoreBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnScoreBoard.FlatAppearance.BorderSize = 0
		Me.btnScoreBoard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
		Me.btnScoreBoard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnScoreBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnScoreBoard.Location = New System.Drawing.Point(709, 436)
		Me.btnScoreBoard.Name = "btnScoreBoard"
		Me.btnScoreBoard.Size = New System.Drawing.Size(173, 79)
		Me.btnScoreBoard.TabIndex = 5
		Me.btnScoreBoard.Text = "ScoreBoard"
		Me.btnScoreBoard.UseVisualStyleBackColor = False
		'
		'StartUp
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ClientSize = New System.Drawing.Size(894, 551)
		Me.Controls.Add(Me.btnScoreBoard)
		Me.Controls.Add(Me.btnInfo)
		Me.Controls.Add(Me.btnSetting)
		Me.Controls.Add(Me.btnExit)
		Me.Controls.Add(Me.btnStart)
		Me.DoubleBuffered = True
		Me.MaximizeBox = False
		Me.Name = "StartUp"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Title"
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents btnStart As Button
	Friend WithEvents btnExit As Button
	Friend WithEvents btnSetting As Button
	Friend WithEvents btnInfo As Button
	Friend WithEvents btnScoreBoard As Button
End Class
