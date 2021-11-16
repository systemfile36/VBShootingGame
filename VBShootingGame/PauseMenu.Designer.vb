<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PauseMenu
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
		Me.btnResume = New System.Windows.Forms.Button()
		Me.btnExit = New System.Windows.Forms.Button()
		Me.lbScore = New System.Windows.Forms.Label()
		Me.lbTime = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'btnResume
		'
		Me.btnResume.BackColor = System.Drawing.Color.Transparent
		Me.btnResume.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnResume.FlatAppearance.BorderSize = 0
		Me.btnResume.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
		Me.btnResume.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnResume.Location = New System.Drawing.Point(12, 226)
		Me.btnResume.Name = "btnResume"
		Me.btnResume.Size = New System.Drawing.Size(175, 80)
		Me.btnResume.TabIndex = 0
		Me.btnResume.Text = "Resume"
		Me.btnResume.UseVisualStyleBackColor = False
		'
		'btnExit
		'
		Me.btnExit.BackColor = System.Drawing.Color.Transparent
		Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnExit.FlatAppearance.BorderSize = 0
		Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
		Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnExit.Location = New System.Drawing.Point(367, 226)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(175, 80)
		Me.btnExit.TabIndex = 1
		Me.btnExit.Text = "Exit"
		Me.btnExit.UseVisualStyleBackColor = False
		'
		'lbScore
		'
		Me.lbScore.AutoSize = True
		Me.lbScore.Font = New System.Drawing.Font("HY견고딕", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.lbScore.Location = New System.Drawing.Point(59, 170)
		Me.lbScore.Name = "lbScore"
		Me.lbScore.Size = New System.Drawing.Size(130, 28)
		Me.lbScore.TabIndex = 2
		Me.lbScore.Text = "Score : "
		'
		'lbTime
		'
		Me.lbTime.AutoSize = True
		Me.lbTime.Font = New System.Drawing.Font("HY견고딕", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.lbTime.Location = New System.Drawing.Point(72, 62)
		Me.lbTime.Name = "lbTime"
		Me.lbTime.Size = New System.Drawing.Size(117, 28)
		Me.lbTime.TabIndex = 3
		Me.lbTime.Text = "Time : "
		'
		'PauseMenu
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ClientSize = New System.Drawing.Size(554, 318)
		Me.Controls.Add(Me.lbTime)
		Me.Controls.Add(Me.lbScore)
		Me.Controls.Add(Me.btnExit)
		Me.Controls.Add(Me.btnResume)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "PauseMenu"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "PauseMenu"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents btnResume As Button
	Friend WithEvents btnExit As Button
	Friend WithEvents lbScore As Label
	Friend WithEvents lbTime As Label
End Class
