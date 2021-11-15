<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameInfo
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
		Me.tbInfo = New System.Windows.Forms.TextBox()
		Me.btnTitle = New System.Windows.Forms.Button()
		Me.SuspendLayout()
		'
		'tbInfo
		'
		Me.tbInfo.Location = New System.Drawing.Point(13, 13)
		Me.tbInfo.Multiline = True
		Me.tbInfo.Name = "tbInfo"
		Me.tbInfo.ReadOnly = True
		Me.tbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.tbInfo.Size = New System.Drawing.Size(779, 350)
		Me.tbInfo.TabIndex = 0
		'
		'btnTitle
		'
		Me.btnTitle.BackColor = System.Drawing.Color.Transparent
		Me.btnTitle.FlatAppearance.BorderSize = 0
		Me.btnTitle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
		Me.btnTitle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnTitle.Location = New System.Drawing.Point(312, 369)
		Me.btnTitle.Name = "btnTitle"
		Me.btnTitle.Size = New System.Drawing.Size(175, 80)
		Me.btnTitle.TabIndex = 1
		Me.btnTitle.Text = "Button1"
		Me.btnTitle.UseVisualStyleBackColor = False
		'
		'GameInfo
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ClientSize = New System.Drawing.Size(804, 461)
		Me.Controls.Add(Me.btnTitle)
		Me.Controls.Add(Me.tbInfo)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "GameInfo"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "GameInfo"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents tbInfo As TextBox
	Friend WithEvents btnTitle As Button
End Class
