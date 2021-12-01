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
		Me.btnScoreBoard = New System.Windows.Forms.Button()
		Me.lbScore = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'btnScoreBoard
		'
		Me.btnScoreBoard.BackColor = System.Drawing.Color.Transparent
		Me.btnScoreBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnScoreBoard.FlatAppearance.BorderSize = 0
		Me.btnScoreBoard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
		Me.btnScoreBoard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnScoreBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnScoreBoard.Location = New System.Drawing.Point(337, 373)
		Me.btnScoreBoard.Name = "btnScoreBoard"
		Me.btnScoreBoard.Size = New System.Drawing.Size(173, 79)
		Me.btnScoreBoard.TabIndex = 2
		Me.btnScoreBoard.Text = "ScoreBoard"
		Me.btnScoreBoard.UseVisualStyleBackColor = False
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
		Me.Controls.Add(Me.btnScoreBoard)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "GameOver"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "GameOver"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents btnScoreBoard As Button
	Friend WithEvents lbScore As Label
End Class
