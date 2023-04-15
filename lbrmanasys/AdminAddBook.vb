Imports Guna.UI2.WinForms
Imports Microsoft.VisualBasic.ApplicationServices
Imports MySql.Data.MySqlClient

Public Class AdminAddBook
    Dim cn As MySqlConnection
    Dim dr As MySqlDataReader
    Dim dt As New DataTable
    Dim cmd As MySqlCommand
    Dim myForm1 As LogIn = CType(Application.OpenForms("LogIn"), LogIn)
    Dim user As String = myForm1.username
    Public Sub data_load()
        Try
            connect()
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
    Public Sub connect()
        Try
            cn = New MySqlConnection("server=localhost;userid=root;password=;database=sysmanbibliotheque")
            cn.Open()


        Catch ex As Exception
            MessageBox.Show("echec de connexion")

        End Try

    End Sub
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Me.Close()
        AdminDashboard.Show()

    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Me.Close()
        LogIn.Show()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click

        Try
            connect()
            cmd = New MySqlCommand("insert into book(Title,Author,Editor) values('" + Guna2TextBox1.Text + "','" + Guna2TextBox2.Text + "','" + Guna2TextBox3.Text + "')", cn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("inserted")
            cn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Guna2TextBox1.Text = " "
        Guna2TextBox2.Text = " "
        Guna2TextBox3.Text = " "
        data_load()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        data_load()
        Guna2TextBox1.Text = " "
        Guna2TextBox2.Text = " "
        Guna2TextBox3.Text = " "
    End Sub

    Private Sub AdminAddBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2HtmlLabel6.Text = user
        data_load()
    End Sub
End Class