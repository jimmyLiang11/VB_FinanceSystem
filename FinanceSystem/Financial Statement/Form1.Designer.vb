<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FStatement
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.DTP = New System.Windows.Forms.DateTimePicker()
        Me.txbsubject = New System.Windows.Forms.ComboBox()
        Me.lblsubject = New System.Windows.Forms.Label()
        Me.lblsummary = New System.Windows.Forms.Label()
        Me.txbsummary = New System.Windows.Forms.TextBox()
        Me.lblincome = New System.Windows.Forms.Label()
        Me.lblexpense = New System.Windows.Forms.Label()
        Me.txbincome = New System.Windows.Forms.TextBox()
        Me.txbexpense = New System.Windows.Forms.TextBox()
        Me.lblnote = New System.Windows.Forms.Label()
        Me.txbnote = New System.Windows.Forms.TextBox()
        Me.lblfounder = New System.Windows.Forms.Label()
        Me.txbfounder = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.txbemail = New System.Windows.Forms.TextBox()
        Me.lblemail = New System.Windows.Forms.Label()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.dgFS = New System.Windows.Forms.DataGridView()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.lblIncomeTotal = New System.Windows.Forms.Label()
        Me.lblExpenseTotal = New System.Windows.Forms.Label()
        Me.Year = New System.Windows.Forms.Label()
        Me.Month = New System.Windows.Forms.Label()
        Me.lblUserRole = New System.Windows.Forms.Label()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnRegister = New System.Windows.Forms.Button()
        CType(Me.dgFS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbldate
        '
        Me.lbldate.AutoSize = True
        Me.lbldate.BackColor = System.Drawing.Color.Transparent
        Me.lbldate.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lbldate.Location = New System.Drawing.Point(85, 118)
        Me.lbldate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbldate.Name = "lbldate"
        Me.lbldate.Size = New System.Drawing.Size(92, 46)
        Me.lbldate.TabIndex = 0
        Me.lbldate.Text = "日期"
        '
        'DTP
        '
        Me.DTP.CalendarFont = New System.Drawing.Font("微軟正黑體", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DTP.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DTP.Location = New System.Drawing.Point(183, 118)
        Me.DTP.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DTP.Name = "DTP"
        Me.DTP.Size = New System.Drawing.Size(326, 39)
        Me.DTP.TabIndex = 1
        '
        'txbsubject
        '
        Me.txbsubject.Font = New System.Drawing.Font("微軟正黑體", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txbsubject.FormattingEnabled = True
        Me.txbsubject.Items.AddRange(New Object() {"社費", "美宣費", "雜費", "活動道具", "點心"})
        Me.txbsubject.Location = New System.Drawing.Point(183, 157)
        Me.txbsubject.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txbsubject.Name = "txbsubject"
        Me.txbsubject.Size = New System.Drawing.Size(326, 36)
        Me.txbsubject.TabIndex = 2
        '
        'lblsubject
        '
        Me.lblsubject.AutoSize = True
        Me.lblsubject.BackColor = System.Drawing.Color.Transparent
        Me.lblsubject.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblsubject.Location = New System.Drawing.Point(85, 157)
        Me.lblsubject.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblsubject.Name = "lblsubject"
        Me.lblsubject.Size = New System.Drawing.Size(92, 46)
        Me.lblsubject.TabIndex = 3
        Me.lblsubject.Text = "科目"
        '
        'lblsummary
        '
        Me.lblsummary.AutoSize = True
        Me.lblsummary.BackColor = System.Drawing.Color.Transparent
        Me.lblsummary.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblsummary.Location = New System.Drawing.Point(85, 194)
        Me.lblsummary.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblsummary.Name = "lblsummary"
        Me.lblsummary.Size = New System.Drawing.Size(92, 46)
        Me.lblsummary.TabIndex = 4
        Me.lblsummary.Text = "摘要"
        '
        'txbsummary
        '
        Me.txbsummary.Font = New System.Drawing.Font("微軟正黑體", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txbsummary.Location = New System.Drawing.Point(183, 194)
        Me.txbsummary.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txbsummary.Name = "txbsummary"
        Me.txbsummary.Size = New System.Drawing.Size(326, 37)
        Me.txbsummary.TabIndex = 5
        '
        'lblincome
        '
        Me.lblincome.AutoSize = True
        Me.lblincome.BackColor = System.Drawing.Color.Transparent
        Me.lblincome.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblincome.Location = New System.Drawing.Point(85, 231)
        Me.lblincome.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblincome.Name = "lblincome"
        Me.lblincome.Size = New System.Drawing.Size(92, 46)
        Me.lblincome.TabIndex = 6
        Me.lblincome.Text = "收入"
        Me.lblincome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblexpense
        '
        Me.lblexpense.AutoSize = True
        Me.lblexpense.BackColor = System.Drawing.Color.Transparent
        Me.lblexpense.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblexpense.Location = New System.Drawing.Point(311, 231)
        Me.lblexpense.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblexpense.Name = "lblexpense"
        Me.lblexpense.Size = New System.Drawing.Size(92, 46)
        Me.lblexpense.TabIndex = 7
        Me.lblexpense.Text = "支出"
        '
        'txbincome
        '
        Me.txbincome.Font = New System.Drawing.Font("微軟正黑體", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txbincome.Location = New System.Drawing.Point(183, 231)
        Me.txbincome.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txbincome.Name = "txbincome"
        Me.txbincome.Size = New System.Drawing.Size(98, 37)
        Me.txbincome.TabIndex = 8
        '
        'txbexpense
        '
        Me.txbexpense.Font = New System.Drawing.Font("微軟正黑體", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txbexpense.Location = New System.Drawing.Point(411, 231)
        Me.txbexpense.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txbexpense.Name = "txbexpense"
        Me.txbexpense.Size = New System.Drawing.Size(98, 37)
        Me.txbexpense.TabIndex = 9
        '
        'lblnote
        '
        Me.lblnote.AutoSize = True
        Me.lblnote.BackColor = System.Drawing.Color.Transparent
        Me.lblnote.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblnote.Location = New System.Drawing.Point(85, 268)
        Me.lblnote.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblnote.Name = "lblnote"
        Me.lblnote.Size = New System.Drawing.Size(92, 46)
        Me.lblnote.TabIndex = 10
        Me.lblnote.Text = "備註"
        '
        'txbnote
        '
        Me.txbnote.Font = New System.Drawing.Font("微軟正黑體", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txbnote.Location = New System.Drawing.Point(183, 268)
        Me.txbnote.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txbnote.Name = "txbnote"
        Me.txbnote.Size = New System.Drawing.Size(326, 37)
        Me.txbnote.TabIndex = 11
        '
        'lblfounder
        '
        Me.lblfounder.AutoSize = True
        Me.lblfounder.BackColor = System.Drawing.Color.Transparent
        Me.lblfounder.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblfounder.Location = New System.Drawing.Point(85, 305)
        Me.lblfounder.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblfounder.Name = "lblfounder"
        Me.lblfounder.Size = New System.Drawing.Size(138, 46)
        Me.lblfounder.TabIndex = 12
        Me.lblfounder.Text = "UserID"
        '
        'txbfounder
        '
        Me.txbfounder.Font = New System.Drawing.Font("微軟正黑體", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txbfounder.Location = New System.Drawing.Point(183, 305)
        Me.txbfounder.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txbfounder.Name = "txbfounder"
        Me.txbfounder.ReadOnly = True
        Me.txbfounder.Size = New System.Drawing.Size(326, 37)
        Me.txbfounder.TabIndex = 13
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnAdd.Font = New System.Drawing.Font("微軟正黑體", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(91, 340)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(101, 48)
        Me.btnAdd.TabIndex = 14
        Me.btnAdd.Text = "新增"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnSelect
        '
        Me.btnSelect.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnSelect.Font = New System.Drawing.Font("微軟正黑體", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSelect.Location = New System.Drawing.Point(198, 340)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(101, 48)
        Me.btnSelect.TabIndex = 15
        Me.btnSelect.Text = "查詢"
        Me.btnSelect.UseVisualStyleBackColor = False
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnUpdate.Font = New System.Drawing.Font("微軟正黑體", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(305, 340)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(101, 48)
        Me.btnUpdate.TabIndex = 16
        Me.btnUpdate.Text = "修改"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnDelete.Font = New System.Drawing.Font("微軟正黑體", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(412, 340)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(101, 48)
        Me.btnDelete.TabIndex = 17
        Me.btnDelete.Text = "刪除"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnPrint.Font = New System.Drawing.Font("微軟正黑體", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(91, 430)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(204, 48)
        Me.btnPrint.TabIndex = 18
        Me.btnPrint.Text = "匯出報表"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'txbemail
        '
        Me.txbemail.Font = New System.Drawing.Font("微軟正黑體", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txbemail.Location = New System.Drawing.Point(242, 396)
        Me.txbemail.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txbemail.Name = "txbemail"
        Me.txbemail.Size = New System.Drawing.Size(267, 37)
        Me.txbemail.TabIndex = 20
        '
        'lblemail
        '
        Me.lblemail.AutoSize = True
        Me.lblemail.BackColor = System.Drawing.Color.Transparent
        Me.lblemail.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblemail.Location = New System.Drawing.Point(85, 396)
        Me.lblemail.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblemail.Name = "lblemail"
        Me.lblemail.Size = New System.Drawing.Size(222, 46)
        Me.lblemail.TabIndex = 19
        Me.lblemail.Text = "收件者Email"
        '
        'btnSend
        '
        Me.btnSend.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSend.Font = New System.Drawing.Font("微軟正黑體", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSend.Location = New System.Drawing.Point(301, 430)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(204, 48)
        Me.btnSend.TabIndex = 21
        Me.btnSend.Text = "寄信通知"
        Me.btnSend.UseVisualStyleBackColor = False
        '
        'dgFS
        '
        Me.dgFS.AllowUserToOrderColumns = True
        Me.dgFS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFS.Location = New System.Drawing.Point(519, 118)
        Me.dgFS.Name = "dgFS"
        Me.dgFS.RowTemplate.Height = 24
        Me.dgFS.Size = New System.Drawing.Size(645, 360)
        Me.dgFS.TabIndex = 22
        '
        'cmbYear
        '
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(519, 484)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(121, 36)
        Me.cmbYear.TabIndex = 23
        '
        'cmbMonth
        '
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Location = New System.Drawing.Point(695, 484)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(121, 36)
        Me.cmbMonth.TabIndex = 24
        '
        'lblIncomeTotal
        '
        Me.lblIncomeTotal.AutoSize = True
        Me.lblIncomeTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblIncomeTotal.Font = New System.Drawing.Font("微軟正黑體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblIncomeTotal.ForeColor = System.Drawing.Color.Green
        Me.lblIncomeTotal.Location = New System.Drawing.Point(513, 523)
        Me.lblIncomeTotal.Name = "lblIncomeTotal"
        Me.lblIncomeTotal.Size = New System.Drawing.Size(155, 36)
        Me.lblIncomeTotal.TabIndex = 26
        Me.lblIncomeTotal.Text = "顯示總收入"
        '
        'lblExpenseTotal
        '
        Me.lblExpenseTotal.AutoSize = True
        Me.lblExpenseTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblExpenseTotal.Font = New System.Drawing.Font("微軟正黑體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblExpenseTotal.ForeColor = System.Drawing.Color.Maroon
        Me.lblExpenseTotal.Location = New System.Drawing.Point(513, 559)
        Me.lblExpenseTotal.Name = "lblExpenseTotal"
        Me.lblExpenseTotal.Size = New System.Drawing.Size(155, 36)
        Me.lblExpenseTotal.TabIndex = 27
        Me.lblExpenseTotal.Text = "顯示總支出"
        '
        'Year
        '
        Me.Year.AutoSize = True
        Me.Year.BackColor = System.Drawing.Color.Transparent
        Me.Year.Font = New System.Drawing.Font("微軟正黑體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Year.Location = New System.Drawing.Point(646, 484)
        Me.Year.Name = "Year"
        Me.Year.Size = New System.Drawing.Size(43, 36)
        Me.Year.TabIndex = 28
        Me.Year.Text = "年"
        '
        'Month
        '
        Me.Month.AutoSize = True
        Me.Month.BackColor = System.Drawing.Color.Transparent
        Me.Month.Font = New System.Drawing.Font("微軟正黑體", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Month.Location = New System.Drawing.Point(822, 484)
        Me.Month.Name = "Month"
        Me.Month.Size = New System.Drawing.Size(43, 36)
        Me.Month.TabIndex = 29
        Me.Month.Text = "月"
        '
        'lblUserRole
        '
        Me.lblUserRole.AutoSize = True
        Me.lblUserRole.BackColor = System.Drawing.Color.Transparent
        Me.lblUserRole.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblUserRole.Location = New System.Drawing.Point(88, 481)
        Me.lblUserRole.Name = "lblUserRole"
        Me.lblUserRole.Size = New System.Drawing.Size(134, 31)
        Me.lblUserRole.TabIndex = 30
        Me.lblUserRole.Text = "使用者權限"
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.Transparent
        Me.btnLogout.Font = New System.Drawing.Font("微軟正黑體", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnLogout.Location = New System.Drawing.Point(1050, 64)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(114, 48)
        Me.btnLogout.TabIndex = 32
        Me.btnLogout.Text = "登出"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'btnRegister
        '
        Me.btnRegister.BackColor = System.Drawing.Color.Transparent
        Me.btnRegister.Font = New System.Drawing.Font("微軟正黑體", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnRegister.Location = New System.Drawing.Point(930, 64)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(114, 48)
        Me.btnRegister.TabIndex = 31
        Me.btnRegister.Text = "註冊"
        Me.btnRegister.UseVisualStyleBackColor = False
        '
        'FStatement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Financial_Statement.My.Resources.Resources.background1381
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1238, 677)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.btnRegister)
        Me.Controls.Add(Me.lblUserRole)
        Me.Controls.Add(Me.Month)
        Me.Controls.Add(Me.Year)
        Me.Controls.Add(Me.lblExpenseTotal)
        Me.Controls.Add(Me.lblIncomeTotal)
        Me.Controls.Add(Me.cmbMonth)
        Me.Controls.Add(Me.cmbYear)
        Me.Controls.Add(Me.dgFS)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.txbemail)
        Me.Controls.Add(Me.lblemail)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txbfounder)
        Me.Controls.Add(Me.lblfounder)
        Me.Controls.Add(Me.txbnote)
        Me.Controls.Add(Me.lblnote)
        Me.Controls.Add(Me.txbexpense)
        Me.Controls.Add(Me.txbincome)
        Me.Controls.Add(Me.lblexpense)
        Me.Controls.Add(Me.lblincome)
        Me.Controls.Add(Me.txbsummary)
        Me.Controls.Add(Me.lblsummary)
        Me.Controls.Add(Me.lblsubject)
        Me.Controls.Add(Me.txbsubject)
        Me.Controls.Add(Me.DTP)
        Me.Controls.Add(Me.lbldate)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("微軟正黑體", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FStatement"
        Me.Text = "財務報表系統"
        CType(Me.dgFS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbldate As Label
    Friend WithEvents DTP As DateTimePicker
    Friend WithEvents txbsubject As ComboBox
    Friend WithEvents lblsubject As Label
    Friend WithEvents lblsummary As Label
    Friend WithEvents txbsummary As TextBox
    Friend WithEvents lblincome As Label
    Friend WithEvents lblexpense As Label
    Friend WithEvents txbincome As TextBox
    Friend WithEvents txbexpense As TextBox
    Friend WithEvents lblnote As Label
    Friend WithEvents txbnote As TextBox
    Friend WithEvents lblfounder As Label
    Friend WithEvents txbfounder As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnSelect As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents txbemail As TextBox
    Friend WithEvents lblemail As Label
    Friend WithEvents btnSend As Button
    Friend WithEvents dgFS As DataGridView
    Friend WithEvents cmbYear As ComboBox
    Friend WithEvents cmbMonth As ComboBox
    Friend WithEvents lblIncomeTotal As Label
    Friend WithEvents lblExpenseTotal As Label
    Friend WithEvents Year As Label
    Friend WithEvents Month As Label
    Friend WithEvents lblUserRole As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnRegister As Button
End Class
