Imports Guna.UI2.WinForms
Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient

Public Class AdherentDashboared
    Dim cn As MySqlConnection
    Dim dr As MySqlDataReader
    Dim dt As New DataTable
    Dim cmd As MySqlCommand
    Dim myForm1 As LogIn = CType(Application.OpenForms("LogIn"), LogIn)
    Dim user As String = myForm1.username
    Dim st As String = myForm1.statuse
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

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Me.Close()
        AdminDashboard.Show()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Me.Close()
        AdherentAddLoan.Show()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Me.Close()
        AdherentManageUser.Show()
    End Sub

    Private Sub AdherentDashboared_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If st = "User" Then
            Guna2Button2.Enabled = False
        End If
        Guna2HtmlLabel6.Text = user
        Try
            connect()


            cmd = New MySqlCommand("select count(*) from loan where username = '" + user + "'", cn)
            Guna2HtmlLabel3.Text = cmd.ExecuteScalar

            cmd = New MySqlCommand("select count(*) from loan where username = '" + user + "' AND Start_Date = DATE(NOW())", cn)
            Guna2HtmlLabel4.Text = cmd.ExecuteScalar


            cmd = New MySqlCommand("select count(*) from return_book where username = '" + user + "' AND Return_Date = DATE(NOW())", cn)
            Guna2HtmlLabel2.Text = cmd.ExecuteScalar

            cmd = New MySqlCommand("select count(*) from loan where username = '" + user + "'", cn)
            Guna2HtmlLabel1.Text = cmd.ExecuteScalar



            cmd = New MySqlCommand("select Title,username,Start_Date,End_Date from book b,loan l where l.username ='" + user + "' and b.ID_Book = l.ID_Book", cn)
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