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
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.lbDefaultInfo = New System.Windows.Forms.Label()
		Me.lbType1Info = New System.Windows.Forms.Label()
		Me.Panel1.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.Panel3.SuspendLayout()
		Me.SuspendLayout()
		'
		'btnDefault
		'
		Me.btnDefault.BackgroundImage = Global.VBShootingGame.My.Resources.Resources.P_Default
		Me.btnDefault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnDefault.Location = New System.Drawing.Point(23, 114)
		Me.btnDefault.Name = "btnDefault"
		Me.btnDefault.Size = New System.Drawing.Size(244, 64)
		Me.btnDefault.TabIndex = 0
		Me.btnDefault.UseVisualStyleBackColor = True
		'
		'btnType1
		'
		Me.btnType1.BackgroundImage = Global.VBShootingGame.My.Resources.Resources.P_Type_1
		Me.btnType1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnType1.Location = New System.Drawing.Point(342, 114)
		Me.btnType1.Name = "btnType1"
		Me.btnType1.Size = New System.Drawing.Size(244, 64)
		Me.btnType1.TabIndex = 1
		Me.btnType1.UseVisualStyleBackColor = True
		'
		'btnType2
		'
		Me.btnType2.BackgroundImage = Global.VBShootingGame.My.Resources.Resources.P_Type_2
		Me.btnType2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnType2.Location = New System.Drawing.Point(661, 114)
		Me.btnType2.Name = "btnType2"
		Me.btnType2.Size = New System.Drawing.Size(244, 64)
		Me.btnType2.TabIndex = 2
		Me.btnType2.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("HY견고딕", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.Label1.Location = New System.Drawing.Point(271, 41)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(336, 32)
		Me.Label1.TabIndex = 3
		Me.Label1.Text = "Select Your Plane!"
		'
		'Panel1
		'
		Me.Panel1.BackColor = System.Drawing.Color.Transparent
		Me.Panel1.BackgroundImage = Global.VBShootingGame.My.Resources.Resources.UI_InfoBkgnd
		Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.Panel1.Controls.Add(Me.lbDefaultInfo)
		Me.Panel1.Location = New System.Drawing.Point(23, 184)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(256, 296)
		Me.Panel1.TabIndex = 4
		'
		'Panel2
		'
		Me.Panel2.BackColor = System.Drawing.Color.Transparent
		Me.Panel2.BackgroundImage = Global.VBShootingGame.My.Resources.Resources.UI_InfoBkgnd
		Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.Panel2.Controls.Add(Me.lbType1Info)
		Me.Panel2.Location = New System.Drawing.Point(342, 184)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(256, 296)
		Me.Panel2.TabIndex = 5
		'
		'Panel3
		'
		Me.Panel3.BackColor = System.Drawing.Color.Transparent
		Me.Panel3.BackgroundImage = Global.VBShootingGame.My.Resources.Resources.UI_InfoBkgnd
		Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.Panel3.Controls.Add(Me.Label4)
		Me.Panel3.Location = New System.Drawing.Point(666, 184)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(256, 296)
		Me.Panel3.TabIndex = 5
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Font = New System.Drawing.Font("나눔고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.Label4.ForeColor = System.Drawing.Color.LightPink
		Me.Label4.Location = New System.Drawing.Point(19, 19)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(86, 19)
		Me.Label4.TabIndex = 2
		Me.Label4.Text = "기체 타입 : "
		'
		'lbDefaultInfo
		'
		Me.lbDefaultInfo.Font = New System.Drawing.Font("나눔고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.lbDefaultInfo.ForeColor = System.Drawing.Color.LightPink
		Me.lbDefaultInfo.Location = New System.Drawing.Point(19, 19)
		Me.lbDefaultInfo.Name = "lbDefaultInfo"
		Me.lbDefaultInfo.Size = New System.Drawing.Size(213, 260)
		Me.lbDefaultInfo.TabIndex = 2
		Me.lbDefaultInfo.Text = "기체 타입 : Type"
		'
		'lbType1Info
		'
		Me.lbType1Info.Font = New System.Drawing.Font("나눔고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.lbType1Info.ForeColor = System.Drawing.Color.LightPink
		Me.lbType1Info.Location = New System.Drawing.Point(19, 19)
		Me.lbType1Info.Name = "lbType1Info"
		Me.lbType1Info.Size = New System.Drawing.Size(213, 260)
		Me.lbType1Info.TabIndex = 3
		Me.lbType1Info.Text = "기체 타입 : Type"
		'
		'SelectPlayer
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ClientSize = New System.Drawing.Size(934, 497)
		Me.Controls.Add(Me.Panel3)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.btnType2)
		Me.Controls.Add(Me.btnType1)
		Me.Controls.Add(Me.btnDefault)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "SelectPlayer"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "SelectPlayer"
		Me.Panel1.ResumeLayout(False)
		Me.Panel2.ResumeLayout(False)
		Me.Panel3.ResumeLayout(False)
		Me.Panel3.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents btnDefault As Button
	Friend WithEvents btnType1 As Button
	Friend WithEvents btnType2 As Button
	Friend WithEvents Label1 As Label
	Friend WithEvents Panel1 As Panel
	Friend WithEvents Panel2 As Panel
	Friend WithEvents Panel3 As Panel
	Friend WithEvents lbDefaultInfo As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents lbType1Info As Label
End Class
