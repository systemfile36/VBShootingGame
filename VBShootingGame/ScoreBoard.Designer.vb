<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ScoreBoard
	Inherits System.Windows.Forms.Form

	'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.tbScoreBoard = New System.Windows.Forms.TextBox()
		Me.btnReset = New System.Windows.Forms.Button()
		Me.btnTitle = New System.Windows.Forms.Button()
		Me.btnExit = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.lbDate = New System.Windows.Forms.Label()
		Me.lbIsDebug = New System.Windows.Forms.Label()
		Me.grpScoreAppend = New System.Windows.Forms.GroupBox()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.lbScore = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.tbName = New System.Windows.Forms.TextBox()
		Me.lbPType = New System.Windows.Forms.Label()
		Me.lbPname = New System.Windows.Forms.Label()
		Me.btnClear = New System.Windows.Forms.Button()
		Me.Label8 = New System.Windows.Forms.Label()
		Me.Label9 = New System.Windows.Forms.Label()
		Me.Label10 = New System.Windows.Forms.Label()
		Me.Label11 = New System.Windows.Forms.Label()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.grpScoreAppend.SuspendLayout()
		Me.SuspendLayout()
		'
		'tbScoreBoard
		'
		Me.tbScoreBoard.Font = New System.Drawing.Font("HY견고딕", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.tbScoreBoard.Location = New System.Drawing.Point(13, 25)
		Me.tbScoreBoard.Multiline = True
		Me.tbScoreBoard.Name = "tbScoreBoard"
		Me.tbScoreBoard.ReadOnly = True
		Me.tbScoreBoard.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.tbScoreBoard.Size = New System.Drawing.Size(775, 364)
		Me.tbScoreBoard.TabIndex = 0
		Me.tbScoreBoard.Text = "21-12-01    Test2    P_Type_1     0001600    Debug"
		'
		'btnReset
		'
		Me.btnReset.BackColor = System.Drawing.Color.Transparent
		Me.btnReset.FlatAppearance.BorderSize = 0
		Me.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
		Me.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnReset.Location = New System.Drawing.Point(12, 573)
		Me.btnReset.Name = "btnReset"
		Me.btnReset.Size = New System.Drawing.Size(173, 79)
		Me.btnReset.TabIndex = 1
		Me.btnReset.Text = "Restart Game"
		Me.btnReset.UseVisualStyleBackColor = False
		'
		'btnTitle
		'
		Me.btnTitle.BackColor = System.Drawing.Color.Transparent
		Me.btnTitle.FlatAppearance.BorderSize = 0
		Me.btnTitle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
		Me.btnTitle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnTitle.Location = New System.Drawing.Point(313, 573)
		Me.btnTitle.Name = "btnTitle"
		Me.btnTitle.Size = New System.Drawing.Size(173, 79)
		Me.btnTitle.TabIndex = 4
		Me.btnTitle.Text = "Go Title"
		Me.btnTitle.UseVisualStyleBackColor = False
		'
		'btnExit
		'
		Me.btnExit.BackColor = System.Drawing.Color.Transparent
		Me.btnExit.FlatAppearance.BorderSize = 0
		Me.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
		Me.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.btnExit.Location = New System.Drawing.Point(614, 573)
		Me.btnExit.Name = "btnExit"
		Me.btnExit.Size = New System.Drawing.Size(173, 79)
		Me.btnExit.TabIndex = 5
		Me.btnExit.Text = "Quit Game"
		Me.btnExit.UseVisualStyleBackColor = False
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(57, 113)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(141, 16)
		Me.Label1.TabIndex = 6
		Me.Label1.Text = "이름을 입력하세요"
		'
		'lbDate
		'
		Me.lbDate.AutoSize = True
		Me.lbDate.Location = New System.Drawing.Point(18, 47)
		Me.lbDate.Name = "lbDate"
		Me.lbDate.Size = New System.Drawing.Size(48, 16)
		Me.lbDate.TabIndex = 7
		Me.lbDate.Text = "Date"
		'
		'lbIsDebug
		'
		Me.lbIsDebug.AutoSize = True
		Me.lbIsDebug.Location = New System.Drawing.Point(412, 47)
		Me.lbIsDebug.Name = "lbIsDebug"
		Me.lbIsDebug.Size = New System.Drawing.Size(64, 16)
		Me.lbIsDebug.TabIndex = 8
		Me.lbIsDebug.Text = "Debug"
		'
		'grpScoreAppend
		'
		Me.grpScoreAppend.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.grpScoreAppend.Controls.Add(Me.Label7)
		Me.grpScoreAppend.Controls.Add(Me.Label6)
		Me.grpScoreAppend.Controls.Add(Me.Label5)
		Me.grpScoreAppend.Controls.Add(Me.Label4)
		Me.grpScoreAppend.Controls.Add(Me.Label3)
		Me.grpScoreAppend.Controls.Add(Me.lbScore)
		Me.grpScoreAppend.Controls.Add(Me.Label2)
		Me.grpScoreAppend.Controls.Add(Me.btnSave)
		Me.grpScoreAppend.Controls.Add(Me.tbName)
		Me.grpScoreAppend.Controls.Add(Me.Label1)
		Me.grpScoreAppend.Controls.Add(Me.lbPType)
		Me.grpScoreAppend.Controls.Add(Me.lbPname)
		Me.grpScoreAppend.Controls.Add(Me.lbDate)
		Me.grpScoreAppend.Controls.Add(Me.lbIsDebug)
		Me.grpScoreAppend.Font = New System.Drawing.Font("HY견고딕", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.grpScoreAppend.Location = New System.Drawing.Point(151, 395)
		Me.grpScoreAppend.Name = "grpScoreAppend"
		Me.grpScoreAppend.Size = New System.Drawing.Size(485, 155)
		Me.grpScoreAppend.TabIndex = 9
		Me.grpScoreAppend.TabStop = False
		Me.grpScoreAppend.Text = "스코어 등록"
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Font = New System.Drawing.Font("HY견고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.Label7.Location = New System.Drawing.Point(412, 26)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(33, 13)
		Me.Label7.TabIndex = 18
		Me.Label7.Text = "모드"
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Font = New System.Drawing.Font("HY견고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.Label6.Location = New System.Drawing.Point(307, 26)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(33, 13)
		Me.Label6.TabIndex = 17
		Me.Label6.Text = "점수"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Font = New System.Drawing.Font("HY견고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.Label5.Location = New System.Drawing.Point(214, 26)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(33, 13)
		Me.Label5.TabIndex = 16
		Me.Label5.Text = "기체"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Font = New System.Drawing.Font("HY견고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.Label4.Location = New System.Drawing.Point(113, 26)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(33, 13)
		Me.Label4.TabIndex = 15
		Me.Label4.Text = "이름"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("HY견고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.Label3.Location = New System.Drawing.Point(21, 26)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(33, 13)
		Me.Label3.TabIndex = 14
		Me.Label3.Text = "날짜"
		'
		'lbScore
		'
		Me.lbScore.AutoSize = True
		Me.lbScore.Location = New System.Drawing.Point(307, 47)
		Me.lbScore.Name = "lbScore"
		Me.lbScore.Size = New System.Drawing.Size(58, 16)
		Me.lbScore.TabIndex = 13
		Me.lbScore.Text = "Score"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("HY견고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.Label2.Location = New System.Drawing.Point(159, 84)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(143, 13)
		Me.Label2.TabIndex = 10
		Me.Label2.Text = "영문 3자 이상 5자 이하"
		'
		'btnSave
		'
		Me.btnSave.Location = New System.Drawing.Point(313, 108)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.Size = New System.Drawing.Size(100, 26)
		Me.btnSave.TabIndex = 12
		Me.btnSave.Text = "저장"
		Me.btnSave.UseVisualStyleBackColor = True
		'
		'tbName
		'
		Me.tbName.ImeMode = System.Windows.Forms.ImeMode.Disable
		Me.tbName.Location = New System.Drawing.Point(204, 108)
		Me.tbName.Name = "tbName"
		Me.tbName.Size = New System.Drawing.Size(100, 26)
		Me.tbName.TabIndex = 11
		'
		'lbPType
		'
		Me.lbPType.AutoSize = True
		Me.lbPType.Location = New System.Drawing.Point(214, 47)
		Me.lbPType.Name = "lbPType"
		Me.lbPType.Size = New System.Drawing.Size(46, 16)
		Me.lbPType.TabIndex = 10
		Me.lbPType.Text = "type"
		'
		'lbPname
		'
		Me.lbPname.AutoSize = True
		Me.lbPname.Location = New System.Drawing.Point(113, 47)
		Me.lbPname.Name = "lbPname"
		Me.lbPname.Size = New System.Drawing.Size(54, 16)
		Me.lbPname.TabIndex = 9
		Me.lbPname.Text = "name"
		'
		'btnClear
		'
		Me.btnClear.Location = New System.Drawing.Point(675, 451)
		Me.btnClear.Name = "btnClear"
		Me.btnClear.Size = New System.Drawing.Size(79, 52)
		Me.btnClear.TabIndex = 10
		Me.btnClear.Text = "스코어보드 초기화"
		Me.btnClear.UseVisualStyleBackColor = True
		'
		'Label8
		'
		Me.Label8.AutoSize = True
		Me.Label8.Font = New System.Drawing.Font("HY견고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.Label8.Location = New System.Drawing.Point(38, 9)
		Me.Label8.Name = "Label8"
		Me.Label8.Size = New System.Drawing.Size(33, 13)
		Me.Label8.TabIndex = 15
		Me.Label8.Text = "날짜"
		'
		'Label9
		'
		Me.Label9.AutoSize = True
		Me.Label9.Font = New System.Drawing.Font("HY견고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.Label9.Location = New System.Drawing.Point(126, 9)
		Me.Label9.Name = "Label9"
		Me.Label9.Size = New System.Drawing.Size(33, 13)
		Me.Label9.TabIndex = 19
		Me.Label9.Text = "이름"
		'
		'Label10
		'
		Me.Label10.AutoSize = True
		Me.Label10.Font = New System.Drawing.Font("HY견고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.Label10.Location = New System.Drawing.Point(208, 9)
		Me.Label10.Name = "Label10"
		Me.Label10.Size = New System.Drawing.Size(33, 13)
		Me.Label10.TabIndex = 19
		Me.Label10.Text = "기체"
		'
		'Label11
		'
		Me.Label11.AutoSize = True
		Me.Label11.Font = New System.Drawing.Font("HY견고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.Label11.Location = New System.Drawing.Point(310, 9)
		Me.Label11.Name = "Label11"
		Me.Label11.Size = New System.Drawing.Size(33, 13)
		Me.Label11.TabIndex = 19
		Me.Label11.Text = "점수"
		'
		'Label12
		'
		Me.Label12.AutoSize = True
		Me.Label12.Font = New System.Drawing.Font("HY견고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
		Me.Label12.Location = New System.Drawing.Point(393, 9)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(33, 13)
		Me.Label12.TabIndex = 19
		Me.Label12.Text = "모드"
		'
		'ScoreBoard
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
		Me.ClientSize = New System.Drawing.Size(800, 666)
		Me.Controls.Add(Me.Label12)
		Me.Controls.Add(Me.Label11)
		Me.Controls.Add(Me.Label10)
		Me.Controls.Add(Me.Label9)
		Me.Controls.Add(Me.Label8)
		Me.Controls.Add(Me.btnClear)
		Me.Controls.Add(Me.grpScoreAppend)
		Me.Controls.Add(Me.btnExit)
		Me.Controls.Add(Me.btnTitle)
		Me.Controls.Add(Me.btnReset)
		Me.Controls.Add(Me.tbScoreBoard)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "ScoreBoard"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "ScoreBoard"
		Me.grpScoreAppend.ResumeLayout(False)
		Me.grpScoreAppend.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents tbScoreBoard As TextBox
	Friend WithEvents btnReset As Button
	Friend WithEvents btnTitle As Button
	Friend WithEvents btnExit As Button
	Friend WithEvents Label1 As Label
	Friend WithEvents lbDate As Label
	Friend WithEvents lbIsDebug As Label
	Friend WithEvents grpScoreAppend As GroupBox
	Friend WithEvents Label2 As Label
	Friend WithEvents btnSave As Button
	Friend WithEvents tbName As TextBox
	Friend WithEvents lbPType As Label
	Friend WithEvents lbPname As Label
	Friend WithEvents lbScore As Label
	Friend WithEvents Label7 As Label
	Friend WithEvents Label6 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents Label4 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents btnClear As Button
	Friend WithEvents Label8 As Label
	Friend WithEvents Label9 As Label
	Friend WithEvents Label10 As Label
	Friend WithEvents Label11 As Label
	Friend WithEvents Label12 As Label
End Class
