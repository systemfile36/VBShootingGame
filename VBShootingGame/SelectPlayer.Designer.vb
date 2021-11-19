<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectPlayer
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
		Me.btnDefault = New System.Windows.Forms.Button()
		Me.btnType1 = New System.Windows.Forms.Button()
		Me.btnType2 = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'btnDefault
		'
		Me.btnDefault.BackgroundImage = Global.VBShootingGame.My.Resources.Resources.P_Default
		Me.btnDefault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnDefault.Location = New System.Drawing.Point(7, 116)
		Me.btnDefault.Name = "btnDefault"
		Me.btnDefault.Size = New System.Drawing.Size(244, 64)
		Me.btnDefault.TabIndex = 0
		Me.btnDefault.UseVisualStyleBackColor = True
		'
		'btnType1
		'
		Me.btnType1.BackgroundImage = Global.VBShootingGame.My.Resources.Resources.P_Type_1
		Me.btnType1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnType1.Location = New System.Drawing.Point(251, 116)
		Me.btnType1.Name = "btnType1"
		Me.btnType1.Size = New System.Drawing.Size(244, 64)
		Me.btnType1.TabIndex = 1
		Me.btnType1.UseVisualStyleBackColor = True
		'
		'btnType2
		'
		Me.btnType2.BackgroundImage = Global.VBShootingGame.My.Resources.Resources.P_Type_2
		Me.btnType2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnType2.Location = New System.Drawing.Point(501, 116)
		Me.btnType2.Name = "btnType2"
		Me.btnType2.Size = New System.Drawing.Size(244, 64)
		Me.btnType2.TabIndex = 2
		Me.btnType2.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("HY견고딕", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.Label1.Location = New System.Drawing.Point(205, 36)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(336, 32)
		Me.Label1.TabIndex = 3
		Me.Label1.Text = "Select Your Plane!"
		'
		'SelectPlayer
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ClientSize = New System.Drawing.Size(749, 204)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.btnType2)
		Me.Controls.Add(Me.btnType1)
		Me.Controls.Add(Me.btnDefault)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "SelectPlayer"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "SelectPlayer"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents btnDefault As Button
	Friend WithEvents btnType1 As Button
	Friend WithEvents btnType2 As Button
	Friend WithEvents Label1 As Label
End Class
