Imports System.Data.OleDb
Public Class RegisterForm
    Private Sub RegisterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 初始化角色下拉選單
        cmbRole.Items.Clear()
        cmbRole.Items.Add("admin")
        cmbRole.Items.Add("user")
        cmbRole.SelectedIndex = 1 '預設選擇 user
        lblErrorMessage.Text = String.Empty
    End Sub
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        '讀取輸入值
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()
        Dim fullname As String = txtFullname.Text.Trim()
        Dim role As String = If(cmbRole.SelectedItem IsNot Nothing, cmbRole.SelectedItem.ToString(), String.Empty)
        Dim email As String = txtEmail.Text.Trim()
        Dim emailPass As String = txtEmailPassword.Text.Trim()
        '驗證輸入
        If username = String.Empty Or password = String.Empty Or fullname = String.Empty _
           Or role = String.Empty Or email = String.Empty Or emailPass = String.Empty Then
            lblErrorMessage.ForeColor = Color.Red
            lblErrorMessage.Text = "請填寫所有欄位！"
            Return
        End If
        Dim connStr As String = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=FinancialStatement.accdb;"
        Try
            Using conn As New OleDbConnection(connStr)
                conn.Open()
                '檢查Username是否已存在
                Dim cmdCheck As New OleDbCommand("SELECT COUNT(*) FROM Users WHERE Username = ?", conn)
                cmdCheck.Parameters.AddWithValue("?", username)
                If CInt(cmdCheck.ExecuteScalar()) > 0 Then
                    lblErrorMessage.ForeColor = Color.Red
                    lblErrorMessage.Text = "此使用者名稱已存在，請更換。"
                    Return
                End If
                '插入新使用者
                Dim cmdInsert As New OleDbCommand("INSERT INTO Users (Username, [Password], Fullname, Role, Email, Emailpassword) VALUES (?, ?, ?, ?, ?, ?)", conn)
                cmdInsert.Parameters.AddWithValue("?", username)
                cmdInsert.Parameters.AddWithValue("?", password)
                cmdInsert.Parameters.AddWithValue("?", fullname)
                cmdInsert.Parameters.AddWithValue("?", role)
                cmdInsert.Parameters.AddWithValue("?", email)
                cmdInsert.Parameters.AddWithValue("?", emailPass)
                cmdInsert.ExecuteNonQuery()
                lblErrorMessage.ForeColor = Color.Green
                lblErrorMessage.Text = "註冊成功！請返回登入頁面登入。"
                '直接關閉註冊視窗(暫時不開，主要確認有沒有註冊成功)
                'Me.Close()
            End Using
        Catch ex As Exception
            lblErrorMessage.ForeColor = Color.Red
            lblErrorMessage.Text = "註冊失敗: " & ex.Message
        End Try
    End Sub
End Class
