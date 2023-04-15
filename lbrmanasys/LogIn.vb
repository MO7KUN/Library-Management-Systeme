Imports MySql.Data.MySqlClient

Imports System.Windows
Public Class LogIn
    Dim cn As MySqlConnection
    Dim dr As MySqlDataReader
    Dim dt As New DataTable
    Dim cmd, cmd1 As MySqlCommand
    Public statuse, pswd As String
    Public username As String
    Public Sub connect()
        Try
            cn = New MySqlConnection("server=localhost;userid=root;password=;database=sysmanbibliotheque")
            cn.Open()


        Catch ex As Exception
            MessageBox.Show("echec de connexion")

        End Try

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Me.Hide()
        SignUp.Show()
    End Sub



    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Try
            connect()
            cmd = New MySqlCommand("select Status from adherent where username = '" + Guna2TextBox1.Text + "'", cn)
            cmd1 = New MySqlCommand("select password from adherent where username = '" + Guna2TextBox1.Text + "'", cn)
            statuse = cmd.ExecuteScalar()
            pswd = cmd1.ExecuteScalar()
            cn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        If (statuse = "") Then
            MessageBox.Show("you need To signup")
        ElseIf (statuse = "Admin" And pswd = Guna2TextBox2.Text) Then
            username = Guna2TextBox1.Text
            pswd = Guna2TextBox2.Text
            Me.Hide()
            AdminDashboard.Show()
        ElseIf (statuse = "User" And pswd = Guna2TextBox2.Text) Then
            username = Guna2TextBox1.Text
            pswd = Guna2TextBox2.Text
            Me.Hide()
            AdherentDashboared.Show()
        Else
            MessageBox.Show("Password incorrect")
        End If
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Me.Close()
    End Sub
End Class
