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
		Me.lbSTitle = New System.Windows.Forms.Label()
		Me.panDefault = New System.Windows.Forms.Panel()
		Me.lbDefaultInfo = New System.Windows.Forms.Label()
		Me.panType1 = New System.Windows.Forms.Panel()
		Me.lbType1Info = New System.Windows.Forms.Label()
		Me.panType2 = New System.Windows.Forms.Panel()
		Me.lbType2Info = New System.Windows.Forms.Label()
		Me.panDefault.SuspendLayout()
		Me.panType1.SuspendLayout()
		Me.panType2.SuspendLayout()
		Me.SuspendLayout()
		'
		'btnDefault
		'
		Me.btnDefault.BackColor = System.Drawing.Color.Transparent
		Me.btnDefault.BackgroundImage = Global.VBShootingGame.My.Resources.Resources.ButtonBase_Default
		Me.btnDefault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnDefault.FlatAppearance.BorderSize = 0
		Me.btnDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnDefault.Image = Global.VBShootingGame.My.Resources.Resources.P_Default_x3
		Me.btnDefault.Location = New System.Drawing.Point(23, 114)
		Me.btnDefault.Name = "btnDefault"
		Me.btnDefault.Size = New System.Drawing.Size(244, 64)
		Me.btnDefault.TabIndex = 0
		Me.btnDefault.UseVisualStyleBackColor = False
		'
		'btnType1
		'
		Me.btnType1.BackColor = System.Drawing.Color.Transparent
		Me.btnType1.BackgroundImage = Global.VBShootingGame.My.Resources.Resources.ButtonBase_Default
		Me.btnType1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnType1.FlatAppearance.BorderSize = 0
		Me.btnType1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnType1.Image = Global.VBShootingGame.My.Resources.Resources.P_Type_1_x3
		Me.btnType1.Location = New System.Drawing.Point(342, 114)
		Me.btnType1.Name = "btnType1"
		Me.btnType1.Size = New System.Drawing.Size(244, 64)
		Me.btnType1.TabIndex = 1
		Me.btnType1.UseVisualStyleBackColor = False
		'
		'btnType2
		'
		Me.btnType2.BackColor = System.Drawing.Color.Transparent
		Me.btnType2.BackgroundImage = Global.VBShootingGame.My.Resources.Resources.ButtonBase_Default
		Me.btnType2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.btnType2.FlatAppearance.BorderSize = 0
		Me.btnType2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnType2.Image = Global.VBShootingGame.My.Resources.Resources.P_Type_2_x3
		Me.btnType2.Location = New System.Drawing.Point(661, 114)
		Me.btnType2.Name = "btnType2"
		Me.btnType2.Size = New System.Drawing.Size(244, 64)
		Me.btnType2.TabIndex = 2
		Me.btnType2.UseVisualStyleBackColor = False
		'
		'lbSTitle
		'
		Me.lbSTitle.AutoSize = True
		Me.lbSTitle.Font = New System.Drawing.Font("HY견고딕", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.lbSTitle.Location = New System.Drawing.Point(271, 41)
		Me.lbSTitle.Name = "lbSTitle"
		Me.lbSTitle.Size = New System.Drawing.Size(336, 32)
		Me.lbSTitle.TabIndex = 3
		Me.lbSTitle.Text = "Select Your Plane!"
		'
		'panDefault
		'
		Me.panDefault.BackColor = System.Drawing.Color.Transparent
		Me.panDefault.BackgroundImage = Global.VBShootingGame.My.Resources.Resources.UI_InfoBkgnd
		Me.panDefault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.panDefault.Controls.Add(Me.lbDefaultInfo)
		Me.panDefault.Location = New System.Drawing.Point(23, 184)
		Me.panDefault.Name = "panDefault"
		Me.panDefault.Size = New System.Drawing.Size(256, 296)
		Me.panDefault.TabIndex = 4
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
		'panType1
		'
		Me.panType1.BackColor = System.Drawing.Color.Transparent
		Me.panType1.BackgroundImage = Global.VBShootingGame.My.Resources.Resources.UI_InfoBkgnd
		Me.panType1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.panType1.Controls.Add(Me.lbType1Info)
		Me.panType1.Location = New System.Drawing.Point(342, 184)
		Me.panType1.Name = "panType1"
		Me.panType1.Size = New System.Drawing.Size(256, 296)
		Me.panType1.TabIndex = 5
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
		'panType2
		'
		Me.panType2.BackColor = System.Drawing.Color.Transparent
		Me.panType2.BackgroundImage = Global.VBShootingGame.My.Resources.Resources.UI_InfoBkgnd
		Me.panType2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.panType2.Controls.Add(Me.lbType2Info)
		Me.panType2.Location = New System.Drawing.Point(666, 184)
		Me.panType2.Name = "panType2"
		Me.panType2.Size = New System.Drawing.Size(256, 296)
		Me.panType2.TabIndex = 5
		'
		'lbType2Info
		'
		Me.lbType2Info.Font = New System.Drawing.Font("나눔고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.lbType2Info.ForeColor = System.Drawing.Color.LightPink
		Me.lbType2Info.Location = New System.Drawing.Point(26, 19)
		Me.lbType2Info.Name = "lbType2Info"
		Me.lbType2Info.Size = New System.Drawing.Size(213, 260)
		Me.lbType2Info.TabIndex = 4
		Me.lbType2Info.Text = "기체 타입 : Type"
		'
		'SelectPlayer
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ClientSize = New System.Drawing.Size(934, 497)
		Me.Controls.Add(Me.panType2)
		Me.Controls.Add(Me.panType1)
		Me.Controls.Add(Me.panDefault)
		Me.Controls.Add(Me.lbSTitle)
		Me.Controls.Add(Me.btnType2)
		Me.Controls.Add(Me.btnType1)
		Me.Controls.Add(Me.btnDefault)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "SelectPlayer"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "SelectPlayer"
		Me.panDefault.ResumeLayout(False)
		Me.panType1.ResumeLayout(False)
		Me.panType2.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents btnDefault As Button
	Friend WithEvents btnType1 As Button
	Friend WithEvents btnType2 As Button
	Friend WithEvents lbSTitle As Label
	Friend WithEvents panDefault As Panel
	Friend WithEvents panType1 As Panel
	Friend WithEvents panType2 As Panel
	Friend WithEvents lbDefaultInfo As Label
	Friend WithEvents lbType1Info As Label
	Friend WithEvents lbType2Info As Label
End Class
