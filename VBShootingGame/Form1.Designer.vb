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
		Me.lbDebug.Size = New System.Drawing.Size(42, 12)
		Me.lbDebug.TabIndex = 0
		Me.lbDebug.Text = "Label1"
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ClientSize = New System.Drawing.Size(1184, 561)
		Me.Controls.Add(Me.lbDebug)
		Me.DoubleBuffered = True
		Me.MaximizeBox = False
		Me.Name = "Form1"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "ShootingGame"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents MainTimer As Timer
	Friend WithEvents lbDebug As Label
End Class
