Imports System.Data.OleDb
Public Class LoginForm
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUser.Text.Trim()
        Dim password As String = txtPass.Text.Trim()
        If username = "" Or password = "" Then
            MessageBox.Show("請輸入帳號與密碼")
            Exit Sub
        End If
        Dim conStr As String = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=FinancialStatement.accdb;"
        Using conn As New OleDbConnection(conStr)
            conn.Open()
            Dim cmd As New OleDbCommand("SELECT * FROM Users WHERE Username = ? AND [Password] = ?", conn)
            cmd.Parameters.AddWithValue("?", username)
            cmd.Parameters.AddWithValue("?", password)
            Dim reader = cmd.ExecuteReader()
            If reader.Read() Then
                '登入成功
                CurrentUserID = reader("UserID").ToString()
                CurrentUserRole = reader("Role").ToString()
                CurrentUserEmail = reader("Email").ToString()
                CurrentUserEmailPassword = reader("Emailpassword").ToString()
                MessageBox.Show("登入成功！")
                '開啟主畫面
                Dim mainForm As New FStatement()
                mainForm.Show()
                Me.Hide()
            Else
                MessageBox.Show("登入失敗，請確認帳號與密碼。")
            End If
        End Using
    End Sub

End Class
