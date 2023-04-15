Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class SignUp
    Dim cn As MySqlConnection
    Dim dr As MySqlDataReader
    Dim dt As New DataTable
    Dim cmd, cmd1 As MySqlCommand
    Dim statuse, pswd As String
    Public username As String
    Public s As Char
    Public Sub connect()
        Try
            cn = New MySqlConnection("server=localhost;userid=root;password=;database=sysmanbibliotheque")
            cn.Open()


        Catch ex As Exception
            MessageBox.Show("echec de connexion")

        End Try

    End Sub
    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Try
            connect()
            If (Guna2RadioButton1.Checked) Then
                s = "M"
            ElseIf (Guna2RadioButton2.Checked) Then
                s = "F"
            End If
            cmd = New MySqlCommand("insert into adherent(username,password,First_Name,Last_Name,Phone_Number,E_Mail,birthdate,adresse,sexe) values('" + Guna2TextBox1.Text + "','" + Guna2TextBox10.Text + "','" + Guna2TextBox2.Text + "','" + Guna2TextBox3.Text + "','" + Guna2TextBox5.Text + "','" + Guna2TextBox6.Text + "','" & Guna2DateTimePicker1.Value & "','" + Guna2TextBox4.Text + "','" + s + "')", cn)
            cmd.ExecuteNonQuery()
            Me.Close()
            LogIn.Show()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SignUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Me.Close()
        LogIn.Show()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Me.Close()
        LogIn.Show()
    End Sub
End Class