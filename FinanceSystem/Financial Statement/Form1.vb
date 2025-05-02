Imports System.Data
Imports System.Data.OleDb
Imports System.Net
Imports System.Net.Mail
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Wordprocessing
Public Class FStatement
    Private ReadOnly connStr As String = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=FinancialStatement.accdb;"
    Private Sub CalculateTotals()
        If cmbYear.SelectedItem Is Nothing OrElse cmbMonth.SelectedItem Is Nothing Then Exit Sub
        Dim selectedYear As Integer = CInt(cmbYear.SelectedItem)
        Dim selectedMonth As Integer = CInt(cmbMonth.SelectedItem)
        Dim query As String = "SELECT SUM([收入]) AS TotalIncome, SUM([支出]) AS TotalExpense FROM FS WHERE Year([日期]) = ? AND Month([日期]) = ?"
        Using conn As New OleDbConnection(connStr)
            Using cmd As New OleDbCommand(query, conn)
                cmd.Parameters.AddWithValue("?", selectedYear)
                cmd.Parameters.AddWithValue("?", selectedMonth)
                Try
                    conn.Open()
                    Dim reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim totalIncome As Decimal = If(IsDBNull(reader("TotalIncome")), 0D, reader("TotalIncome"))
                        Dim totalExpense As Decimal = If(IsDBNull(reader("TotalExpense")), 0D, reader("TotalExpense"))
                        lblIncomeTotal.Text = $"收入總額：{totalIncome:C0}"
                        lblExpenseTotal.Text = $"支出總額：{totalExpense:C0}"
                    End If
                Catch ex As Exception
                    MsgBox("查詢失敗：" & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub cmbYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbYear.SelectedIndexChanged
        CalculateTotals()
    End Sub

    Private Sub cmbMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMonth.SelectedIndexChanged
        CalculateTotals()
    End Sub

    Private Sub FStatement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '自動填入使用者的UserID
        txbfounder.Text = CurrentUserID
        '設定權限user僅可新增、查詢，無法註冊
        If CurrentUserRole = "user" Then
            btnUpdate.Enabled = False '不可修改
            btnDelete.Enabled = False '不可刪除
            btnPrint.Enabled = False '不可匯出
            btnSend.Enabled = False '不可寄信
            btnRegister.Enabled = False '不可註冊
        End If
        ' 顯示使用者權限
        lblUserRole.Text = "使用者權限: " & CurrentUserRole
        ' 初始化年份（例如 2015-今年）
        Dim currentYear As Integer = DateTime.Now.Year
        For y = currentYear - 10 To currentYear + 1
            cmbYear.Items.Add(y)
        Next
        '初始化月份（1~12）
        For m = 1 To 12
            cmbMonth.Items.Add(m.ToString("D2")) ' 轉成 01, 02, ..., 12
        Next
        '設定預設值
        cmbYear.SelectedItem = currentYear
        cmbMonth.SelectedItem = DateTime.Now.Month.ToString("D2")
        '年月combox置中
        cmbYear.DrawMode = DrawMode.OwnerDrawFixed
        cmbMonth.DrawMode = DrawMode.OwnerDrawFixed
        '自動計算當月收入與支出總和
        CalculateTotals()
    End Sub
    Private Sub cmbYear_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cmbYear.DrawItem '下拉式表單水平垂直置中
        If e.Index < 0 Then Exit Sub
        e.DrawBackground()
        Dim text As String = cmbYear.Items(e.Index).ToString()
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
        e.Graphics.DrawString(text, cmbYear.Font, New SolidBrush(cmbYear.ForeColor), e.Bounds, sf)
        e.DrawFocusRectangle()
    End Sub

    Private Sub cmbMonth_DrawItem(sender As Object, e As DrawItemEventArgs) Handles cmbMonth.DrawItem '下拉式表單水平垂直置中
        If e.Index < 0 Then Exit Sub
        e.DrawBackground()
        Dim text As String = cmbMonth.Items(e.Index).ToString()
        Dim sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
        e.Graphics.DrawString(text, cmbMonth.Font, New SolidBrush(cmbMonth.ForeColor), e.Bounds, sf)
        e.DrawFocusRectangle()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        '宣告收入與支出的變數&UserID=數值
        Dim income As Decimal = If(IsNumeric(txbincome.Text) AndAlso txbincome.Text <> "", CDec(txbincome.Text), 0D)
        Dim expense As Decimal = If(IsNumeric(txbexpense.Text) AndAlso txbexpense.Text <> "", CDec(txbexpense.Text), 0D)
        Dim userId As Integer
        If Not Integer.TryParse(txbfounder.Text, userId) Then
            MsgBox("請輸入有效的使用者ID（數字）")
            Exit Sub
        End If
        '檢查UserID是否存在於 Users 資料表中
        Dim checkQuery As String = "SELECT COUNT(*) FROM Users WHERE UserID = ?"
        Using checkConn As New OleDbConnection(connStr)
            Using checkCmd As New OleDbCommand(checkQuery, checkConn)
                checkCmd.Parameters.AddWithValue("?", userId)
                checkConn.Open()
                Dim count As Integer = CInt(checkCmd.ExecuteScalar())
                If count = 0 Then
                    MsgBox("找不到對應的使用者 ID，請確認是否輸入正確")
                    Exit Sub
                End If
            End Using
        End Using
        'SQL 插入語句，使用 ? 參數避免 SQL 注入
        ' 建立 SQL 插入語句（使用中括號包住欄位名稱）
        Dim query As String = "INSERT INTO FS ( [日期], [科目], [摘要], [收入], [支出], [備註], [UserID]) VALUES (?, ?, ?, ?, ?, ?, ?)"
        Using conn As New OleDbConnection(connStr)
            Using cmd As New OleDbCommand(query, conn)
                '對應每一個 ? 加入參數
                cmd.Parameters.AddWithValue("?", OleDbType.Date).Value = DTP.Value '日期
                cmd.Parameters.AddWithValue("?", txbsubject.Text) '科目
                cmd.Parameters.AddWithValue("?", txbsummary.Text) '摘要
                cmd.Parameters.AddWithValue("?", income) '收入
                cmd.Parameters.AddWithValue("?", expense) '支出
                cmd.Parameters.AddWithValue("?", txbnote.Text) '備註
                cmd.Parameters.AddWithValue("?", userId) 'UserID（整數）
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MsgBox("新增成功，請按查詢確認")
                Catch ex As Exception
                    MsgBox("新增時發生錯誤：" & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        '查詢指定 UserID 的資料
        Dim userId As Integer
        If Not Integer.TryParse(txbfounder.Text, userId) Then
            MsgBox("請輸入有效的使用者 ID（必須是數字）")
            Exit Sub
        End If
        Dim query As String = "SELECT ID, [日期], [科目], [摘要], [收入], [支出], [備註], [建立日期], [UserID] FROM FS WHERE UserID = ?"
        Using conn As New OleDbConnection(connStr)
            Using cmd As New OleDbCommand(query, conn)
                cmd.Parameters.AddWithValue("?", userId)
                Dim adapter As New OleDbDataAdapter(cmd)
                Dim dt As New DataTable()
                Try
                    conn.Open()
                    adapter.Fill(dt)
                    dgFS.DataSource = dt '顯示查詢結果到 DataGridView
                Catch ex As Exception
                    MsgBox("查詢錯誤：" & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        '確認是否選擇資料
        If dgFS.SelectedRows.Count = 0 Then
            MsgBox("請先選擇要修改的資料")
            Exit Sub
        End If
        '取得選取列的 ID
        Dim selectedId As Integer = CInt(dgFS.SelectedRows(0).Cells("ID").Value)
        '驗證 UserID
        Dim userId As Integer
        If Not Integer.TryParse(txbfounder.Text, userId) Then
            MsgBox("請輸入有效的使用者 ID（必須是數字）")
            Exit Sub
        End If
        '宣告收入與支出的變數&UserID=數值
        Dim income As Decimal = If(IsNumeric(txbincome.Text) AndAlso txbincome.Text <> "", CDec(txbincome.Text), 0D)
        Dim expense As Decimal = If(IsNumeric(txbexpense.Text) AndAlso txbexpense.Text <> "", CDec(txbexpense.Text), 0D)
        '檢查 UserID 是否存在於 Users 資料表中
        Dim checkQuery As String = "SELECT COUNT(*) FROM Users WHERE UserID = ?"
        Using checkConn As New OleDbConnection(connStr)
            Using checkCmd As New OleDbCommand(checkQuery, checkConn)
                checkCmd.Parameters.AddWithValue("?", userId)
                checkConn.Open()
                Dim count As Integer = CInt(checkCmd.ExecuteScalar())
                If count = 0 Then
                    MsgBox("找不到對應的使用者 ID，請確認是否輸入正確")
                    Exit Sub
                End If
            End Using
        End Using
        Dim query As String = "UPDATE FS SET [日期]=?, [科目]=?, [摘要]=?, [收入]=?, [支出]=?, [備註]=?, [UserID]=? WHERE ID=?"
        Using conn As New OleDbConnection(connStr)
            Using cmd As New OleDbCommand(query, conn)
                cmd.Parameters.AddWithValue("?", OleDbType.Date).Value = DTP.Value '日期
                cmd.Parameters.AddWithValue("?", txbsubject.Text) '科目
                cmd.Parameters.AddWithValue("?", txbsummary.Text) '摘要
                cmd.Parameters.AddWithValue("?", income) '收入
                cmd.Parameters.AddWithValue("?", expense) '支出
                cmd.Parameters.AddWithValue("?", txbnote.Text) '備註
                cmd.Parameters.AddWithValue("?", userId) 'UserID（整數）
                cmd.Parameters.AddWithValue("?", selectedId)
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MsgBox("修改成功")
                Catch ex As Exception
                    MsgBox("修改失敗：" & ex.Message)
                End Try
            End Using
        End Using

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        '確認是否選擇資料
        If dgFS.SelectedRows.Count = 0 Then
            MsgBox("請先選擇要刪除的資料")
            Exit Sub
        End If
        Dim selectedId As Integer = CInt(dgFS.SelectedRows(0).Cells("ID").Value)
        '確認是否刪除
        If MsgBox("確定要刪除 ID 為 " & selectedId & " 的資料嗎？", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            Exit Sub
        End If
        Dim query As String = "DELETE FROM FS WHERE ID=?"
        Using conn As New OleDbConnection(connStr)
            Using cmd As New OleDbCommand(query, conn)
                cmd.Parameters.AddWithValue("?", selectedId)
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MsgBox("刪除成功")
                Catch ex As Exception
                    MsgBox("刪除失敗：" & ex.Message)
                End Try
            End Using
        End Using
    End Sub
    '匯出word基本格式區============================
    '置中段落，含可設定加粗與大小
    Private Function CreateCenteredParagraph(text As String, Optional bold As Boolean = False, Optional fontSize As Integer = 20) As Paragraph
        Return New Paragraph(New ParagraphProperties(
                             New Justification() With {.Val = JustificationValues.Center}),
                         New Run(New RunProperties(New FontSize() With {.Val = fontSize.ToString()},
                                                   If(bold, New Bold(), Nothing)),
                                 New Text(text)))
    End Function
    '左對齊普通段落
    Private Function CreateParagraph(text As String) As Paragraph
        Return New Paragraph(New Run(New Text(text)))
    End Function
    '表格邊框屬性設定
    Private Function CreateTableProperties() As TableProperties
        ' 表格總寬度設定為 100%
        Dim tableWidth = New TableWidth() With {
        .Width = "5000", ' 可調整，這裡表示大約100%
        .Type = TableWidthUnitValues.Pct
    }
        ' 邊框
        Dim tblBorders = New TableBorders(
        New TopBorder() With {.Val = BorderValues.Single, .Size = 12},
        New BottomBorder() With {.Val = BorderValues.Single, .Size = 12},
        New LeftBorder() With {.Val = BorderValues.Single, .Size = 12},
        New RightBorder() With {.Val = BorderValues.Single, .Size = 12},
        New InsideHorizontalBorder() With {.Val = BorderValues.Single, .Size = 12},
        New InsideVerticalBorder() With {.Val = BorderValues.Single, .Size = 12}
    )
        Return New TableProperties(tableWidth, tblBorders)
    End Function
    '表頭列
    Private Function CreateHeaderRow(headers As String()) As TableRow
        Dim headerRow = New TableRow()
        For Each header In headers
            Dim para As New Paragraph(
            New ParagraphProperties(
                New Justification() With {.Val = JustificationValues.Center}
            ),
            New Run(New Text(header))
        )
            Dim cellProps As New TableCellProperties(
            New TableCellVerticalAlignment() With {.Val = TableVerticalAlignmentValues.Center},
            New TableCellBorders(
                New TopBorder() With {.Val = BorderValues.Single, .Size = 8},
                New BottomBorder() With {.Val = BorderValues.Single, .Size = 8},
                New LeftBorder() With {.Val = BorderValues.Single, .Size = 8},
                New RightBorder() With {.Val = BorderValues.Single, .Size = 8}
            )
        )
            Dim cell As New TableCell(para, cellProps)
            headerRow.Append(cell)
        Next
        Return headerRow
    End Function
    '資料列
    Private Function CreateDataRow(data As String()) As TableRow
        Dim row As New TableRow()
        For Each cell In data
            ' 建立一個置中的段落
            Dim para As New Paragraph(
            New ParagraphProperties(
                New Justification() With {.Val = New EnumValue(Of JustificationValues)(JustificationValues.Center)}
            ),
            New Run(New Text(cell))
        )
            ' 建立儲存格，含段落與垂直置中設定
            Dim tableCell As New TableCell(
            para,
            New TableCellProperties(New TableCellVerticalAlignment() With {.Val = TableVerticalAlignmentValues.Center})
        )
            row.Append(tableCell)
        Next
        Return row
    End Function '匯出word基本格式區===============================================

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        '組合檔案名稱（自動包含年月）
        Dim year = cmbYear.SelectedItem.ToString()
        Dim month = cmbMonth.SelectedItem.ToString().PadLeft(2, "0"c)
        Dim fileName = $"梁鈺禾公司{year}年{month}月財務報表.docx"
        Dim filePath As String = AppDomain.CurrentDomain.BaseDirectory & fileName
        '顯示報表儲存位置，教學用（可選）
        'MsgBox("報表將儲存於：" & filePath)
        '撈取資料
        Dim dt As New DataTable()
        Dim conn As New OleDbConnection(connStr)
        Dim adapter As New OleDbDataAdapter($"SELECT * FROM FS WHERE Year([日期])={year} AND Month([日期])={month} ORDER BY [日期]", conn)
        adapter.Fill(dt)
        Try
            ' 建立 Word 文件
            Using wordDoc As WordprocessingDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document)
                Dim mainPart = wordDoc.AddMainDocumentPart()
                mainPart.Document = New Document()
                Dim body = New Body()
                Dim rowsPerPage As Integer = 20
                Dim pageCount As Integer = CInt(System.Math.Ceiling(dt.Rows.Count / rowsPerPage))
                Dim prevBalance As Decimal = 0
                For page = 0 To pageCount - 1
                    ' 新頁面：標題 or 上頁結餘
                    If page = 0 Then
                        body.Append(CreateCenteredParagraph($"梁鈺禾公司{year}年{month}月財務報表", True, 24))
                    Else
                        body.Append(CreateParagraph($"上頁結餘：{prevBalance:N0} 元"))
                    End If
                    '表格
                    Dim table = New Table()
                    table.Append(CreateTableProperties())
                    Dim tableGrid = New TableGrid(
                        New GridColumn() With {.Width = "1000"},
                        New GridColumn() With {.Width = "1000"},
                        New GridColumn() With {.Width = "1000"},
                        New GridColumn() With {.Width = "1000"},
                        New GridColumn() With {.Width = "1000"},
                        New GridColumn() With {.Width = "1000"},
                        New GridColumn() With {.Width = "1000"}
                    )
                    table.Append(tableGrid)
                    '表頭
                    Dim headers = {"編號", "日期", "科目", "摘要", "收入", "支出", "備註"}
                    table.Append(CreateHeaderRow(headers))
                    '資料
                    Dim incomeTotal As Decimal = 0, expenseTotal As Decimal = 0
                    Dim startIdx = page * rowsPerPage
                    Dim endIdx = System.Math.Min(startIdx + rowsPerPage - 1, dt.Rows.Count - 1)
                    For i = startIdx To endIdx
                        Dim row = dt.Rows(i)
                        Dim income = If(IsDBNull(row("收入")), 0D, Convert.ToDecimal(row("收入")))
                        Dim expense = If(IsDBNull(row("支出")), 0D, Convert.ToDecimal(row("支出")))
                        incomeTotal += income
                        expenseTotal += expense
                        Dim data = {
                        (i + 1).ToString(),
                        Convert.ToDateTime(row("日期")).ToString("yyyy/M/d"),
                        row("科目").ToString(),
                        row("摘要").ToString(),
                        If(income = 0, "", income.ToString("N0")),
                        If(expense = 0, "", expense.ToString("N0")),
                        row("備註").ToString()
                    }
                        table.Append(CreateDataRow(data))
                    Next
                    '合計與本頁結餘
                    table.Append(CreateDataRow({"合計", "", "", "", incomeTotal.ToString("N0"), expenseTotal.ToString("N0"), ""}))
                    Dim balance = prevBalance + incomeTotal - expenseTotal
                    table.Append(CreateDataRow({"本頁結餘", "", "", "", "", "", balance.ToString("N0")}))
                    prevBalance = balance
                    body.Append(table)
                    '換頁（非最後一頁）
                    If page < pageCount - 1 Then
                        body.Append(New Paragraph(New Run(New Break() With {.Type = BreakValues.Page})))
                    End If
                Next
                mainPart.Document.Append(body)
                mainPart.Document.Save()
            End Using
            '通知使用者
            MessageBox.Show("報表已建立：" & filePath, "成功", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '自動開啟報表(可關閉)
            Process.Start(filePath)
        Catch ex As Exception
            MessageBox.Show("發生錯誤：" & ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        '組合報表檔案名稱
        Dim yearText As String = cmbYear.SelectedItem.ToString()
        Dim monthText As String = cmbMonth.SelectedItem.ToString()
        Dim fileName As String = $"梁鈺禾公司{yearText}年{monthText}月財務報表.docx"
        Dim filePath As String = AppDomain.CurrentDomain.BaseDirectory & fileName
        '確認報表檔案存在
        If Not System.IO.File.Exists(filePath) Then
            MessageBox.Show("報表檔案不存在，請先匯出報表。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        '檢查收件人地址
        If String.IsNullOrWhiteSpace(txbemail.Text) Then
            MessageBox.Show("請輸入收件者 Email。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        '產出信件內文
        Dim prompt As String = String.Format("您好，附件為 {0}，請查閱。", fileName)
        Try
            '發送郵件
            Using SmtpClient As New SmtpClient("smtp.office365.com") '該功能線支援微軟帳戶
                SmtpClient.Port = 587
                SmtpClient.EnableSsl = True
                SmtpClient.Credentials = New NetworkCredential(CurrentUserEmail, CurrentUserEmailPassword) '使用登入者資訊
                Using MailMessage As New MailMessage()
                    MailMessage.From = New MailAddress(CurrentUserEmail)
                    MailMessage.To.Add(txbemail.Text.Trim()) '收件者由輸入欄位指定
                    MailMessage.Subject = $"梁鈺禾公司 {yearText}年{monthText}月 財務報表"
                    MailMessage.Body = prompt
                    MailMessage.IsBodyHtml = False '純文字
                    MailMessage.Attachments.Add(New Attachment(filePath)) '加入報表做附件
                    SmtpClient.Send(MailMessage)
                    MessageBox.Show("Email 已成功寄出！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"寄送失敗：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    '登出功能
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        '清除當前的全域變數
        CurrentUserID = String.Empty
        CurrentUserRole = String.Empty
        CurrentUserEmail = String.Empty
        CurrentUserEmailPassword = String.Empty
        '顯示登出提示並回到登入畫面
        MessageBox.Show("您已成功登出！", "登出成功", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '顯示登入表單，並關閉當前畫面
        Dim loginForm As New LoginForm()
        loginForm.Show()
        Me.Hide()
    End Sub
    '註冊功能
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim regForm As New RegisterForm()
        regForm.ShowDialog()
    End Sub
End Class
