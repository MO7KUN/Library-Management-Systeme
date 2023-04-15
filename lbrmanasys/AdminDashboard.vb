Imports System.Windows
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class AdminDashboard
    Dim cn As MySqlConnection
    Dim dr As MySqlDataReader
    Dim dt As New DataTable
    Dim cmd, cmd1 As MySqlCommand
    Dim myForm1 As LogIn = CType(Application.OpenForms("LogIn"), LogIn)
    Dim user As String = myForm1.username
    Public Sub connect()
        Try
            cn = New MySqlConnection("server=localhost;userid=root;password=;database=sysmanbibliotheque")
            cn.Open()


        Catch ex As Exception
            MessageBox.Show("echec de connexion")

        End Try

    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Me.Close()
        LogIn.Show()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Me.Close()
        AdminAddBook.Show()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Me.Close()
        AdminEditBook.Show()
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        Me.Close()
        AdminReturnBook.Show()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Me.Close()
        AdminDeleteBook.Show()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Me.Close()
        AdminManageUsers.Show()
    End Sub

    Private Sub Guna2Button7_Click(sender As Object, e As EventArgs) Handles Guna2Button7.Click
        Me.Close()
        AdherentDashboared.Show()
    End Sub



    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2HtmlLabel6.Text = user
        Try
            connect()

            cmd = New MySqlCommand("select count(*) from book", cn)
            Guna2HtmlLabel3.Text = cmd.ExecuteScalar


            cmd = New MySqlCommand("select count(*) from adherent", cn)
            Guna2HtmlLabel1.Text = cmd.ExecuteScalar


            cmd = New MySqlCommand("select count(*) from loan", cn)
            Guna2HtmlLabel2.Text = cmd.ExecuteScalar


            cmd1 = New MySqlCommand("select count(*) from loan where Start_Date = DATE(NOW()) ", cn)
            Dim a As Integer = cmd1.ExecuteScalar
            Dim b As Integer = cmd.ExecuteScalar
            Guna2HtmlLabel4.Text = cmd1.ExecuteScalar
            Guna2HtmlLabel5.Text = b - a





            cmd = New MySqlCommand("select * from book ", cn)
            dr = cmd.ExecuteReader()
            dt.Load(dr)
            dr.Close()
            Guna2DataGridView1.DataSource = dt
            cn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class