<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameOver
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
		Me.btnReset = New System.Windows.Forms.Button()
		Me.btnExit = New System.Windows.Forms.Button()
		Me.btnTitle = New System.Windows.Forms.Button()
		Me.lbScore = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'btnReset
		'
		Me.btnReset.BackColor = System.Drawing.Color.Transparent
		Me.btnReset.FlatAppearance.BorderSize = 0
		Me.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
		Me.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnReset.Location = New System.Drawing.Point(12, 373)
		Me.btnReset.Name = "btnReset"
		Me.btnReset.Size = New System.Drawing.Size(173, 79)
		Me.btnReset.TabIndex = 0
		Me.btnReset.Text = "Restart Game"
		Me.btnReset.UseVisualStyleBackColor = False
		'
		'btnExit
		'
		Me.btnExit.BackColor = System.Drawing.Color.Transparent
		Me.btnExit.FlatAppearance.BorderSize = 0
		Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
		Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnExit.Location = New System.Drawing.Point(634, 373)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(173, 79)
		Me.btnExit.TabIndex = 2
		Me.btnExit.Text = "Quit Game"
		Me.btnExit.UseVisualStyleBackColor = False
		'
		'btnTitle
		'
		Me.btnTitle.BackColor = System.Drawing.Color.Transparent
		Me.btnTitle.FlatAppearance.BorderSize = 0
		Me.btnTitle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
		Me.btnTitle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnTitle.Location = New System.Drawing.Point(313, 373)
		Me.btnTitle.Name = "btnTitle"
		Me.btnTitle.Size = New System.Drawing.Size(173, 79)
		Me.btnTitle.TabIndex = 3
		Me.btnTitle.Text = "Go Title"
		Me.btnTitle.UseVisualStyleBackColor = False
		'
		'lbScore
		'
		Me.lbScore.AutoSize = True
		Me.lbScore.BackColor = System.Drawing.Color.Transparent
		Me.lbScore.Font = New System.Drawing.Font("HY견고딕", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.lbScore.Location = New System.Drawing.Point(73, 213)
		Me.lbScore.Name = "lbScore"
		Me.lbScore.Size = New System.Drawing.Size(217, 29)
		Me.lbScore.TabIndex = 4
		Me.lbScore.Text = "Your Score : "
		'
		'GameOver
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ClientSize = New System.Drawing.Size(819, 464)
		Me.Controls.Add(Me.lbScore)
		Me.Controls.Add(Me.btnTitle)
		Me.Controls.Add(Me.btnExit)
		Me.Controls.Add(Me.btnReset)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "GameOver"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "GameOver"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents btnReset As Button
	Friend WithEvents btnExit As Button
	Friend WithEvents btnTitle As Button
	Friend WithEvents lbScore As Label
End Class
