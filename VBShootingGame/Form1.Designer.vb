<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
		Me.components = New System.ComponentModel.Container()
		Me.MainTimer = New System.Windows.Forms.Timer(Me.components)
		Me.lbDebug = New System.Windows.Forms.Label()
		Me.lbGameTime = New System.Windows.Forms.Label()
		Me.lbDif = New System.Windows.Forms.Label()
		Me.lbScore = New System.Windows.Forms.Label()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.lbAmmo = New System.Windows.Forms.Label()
		Me.Panel1.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.SuspendLayout()
		'
		'MainTimer
		'
		Me.MainTimer.Enabled = True
		Me.MainTimer.Interval = 20
		'
		'lbDebug
		'
		Me.lbDebug.AutoSize = True
		Me.lbDebug.Location = New System.Drawing.Point(13, 537)
		Me.lbDebug.Name = "lbDebug"
		Me.lbDebug.Size = New System.Drawing.Size(0, 12)
		Me.lbDebug.TabIndex = 0
		'
		'lbGameTime
		'
		Me.lbGameTime.AutoSize = True
		Me.lbGameTime.BackColor = System.Drawing.Color.Transparent
		Me.lbGameTime.Font = New System.Drawing.Font("나눔고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.lbGameTime.ForeColor = System.Drawing.Color.LightPink
		Me.lbGameTime.Location = New System.Drawing.Point(15, 8)
		Me.lbGameTime.Name = "lbGameTime"
		Me.lbGameTime.Size = New System.Drawing.Size(59, 19)
		Me.lbGameTime.TabIndex = 1
		Me.lbGameTime.Text = "Time : "
		'
		'lbDif
		'
		Me.lbDif.AutoSize = True
		Me.lbDif.BackColor = System.Drawing.Color.Transparent
		Me.lbDif.Font = New System.Drawing.Font("나눔고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.lbDif.ForeColor = System.Drawing.Color.LightPink
		Me.lbDif.Location = New System.Drawing.Point(45, 8)
		Me.lbDif.Name = "lbDif"
		Me.lbDif.Size = New System.Drawing.Size(44, 19)
		Me.lbDif.TabIndex = 2
		Me.lbDif.Text = "Dif : "
		'
		'lbScore
		'
		Me.lbScore.AutoSize = True
		Me.lbScore.BackColor = System.Drawing.Color.Transparent
		Me.lbScore.Font = New System.Drawing.Font("나눔고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.lbScore.ForeColor = System.Drawing.Color.LightPink
		Me.lbScore.Location = New System.Drawing.Point(10, 39)
		Me.lbScore.Name = "lbScore"
		Me.lbScore.Size = New System.Drawing.Size(64, 19)
		Me.lbScore.TabIndex = 3
		Me.lbScore.Text = "Score : "
		'
		'Panel1
		'
		Me.Panel1.BackColor = System.Drawing.Color.Transparent
		Me.Panel1.BackgroundImage = Global.VBShootingGame.My.Resources.Resources.UI_Indicator_LeftUp_70
		Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.Panel1.Controls.Add(Me.lbGameTime)
		Me.Panel1.Controls.Add(Me.lbScore)
		Me.Panel1.Location = New System.Drawing.Point(1, 1)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(170, 68)
		Me.Panel1.TabIndex = 4
		'
		'Panel2
		'
		Me.Panel2.BackColor = System.Drawing.Color.Transparent
		Me.Panel2.BackgroundImage = Global.VBShootingGame.My.Resources.Resources.UI_Indicator_RightUp_70
		Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		Me.Panel2.Controls.Add(Me.lbAmmo)
		Me.Panel2.Controls.Add(Me.lbDif)
		Me.Panel2.Location = New System.Drawing.Point(1014, 1)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(170, 68)
		Me.Panel2.TabIndex = 5
		'
		'lbAmmo
		'
		Me.lbAmmo.AutoSize = True
		Me.lbAmmo.Font = New System.Drawing.Font("나눔고딕", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.lbAmmo.ForeColor = System.Drawing.Color.LightPink
		Me.lbAmmo.Location = New System.Drawing.Point(15, 39)
		Me.lbAmmo.Name = "lbAmmo"
		Me.lbAmmo.Size = New System.Drawing.Size(74, 19)
		Me.lbAmmo.TabIndex = 3
		Me.lbAmmo.Text = "Ammo : "
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ClientSize = New System.Drawing.Size(1184, 561)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.lbDebug)
		Me.DoubleBuffered = True
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "Form1"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "ShootingGame"
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.Panel2.ResumeLayout(False)
		Me.Panel2.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents MainTimer As Timer
	Friend WithEvents lbDebug As Label
	Friend WithEvents lbGameTime As Label
	Friend WithEvents lbDif As Label
	Friend WithEvents lbScore As Label
	Friend WithEvents Panel1 As Panel
	Friend WithEvents Panel2 As Panel
	Friend WithEvents lbAmmo As Label
End Class
