Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class AdminDeleteBook
    Dim cn As MySqlConnection
    Dim dr As MySqlDataReader
    Dim dt As New DataTable
    Dim cmd, cmd1 As MySqlCommand
    Dim a As Integer
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

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Me.Close()
        AdminDashboard.Show()

    End Sub
    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Me.Close()
        LogIn.Show()
    End Sub

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged
        Try
            connect()
            cmd = New MySqlCommand("select * from book where Title like '%" + Guna2TextBox1.Text + "%'", cn)
            dr = cmd.ExecuteReader()
            dt.Load(dr)
            Guna2DataGridView1.DataSource = dt
            cn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim selectedRow As DataGridViewRow = Guna2DataGridView1.CurrentRow
        a = selectedRow.Cells(0).Value
        Guna2TextBox1.Text = selectedRow.Cells(1).Value
        Guna2TextBox2.Text = selectedRow.Cells(2).Value
        Guna2TextBox3.Text = selectedRow.Cells(3).Value
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        a = 0
        Guna2TextBox1.Text = " "
        Guna2TextBox2.Text = " "
        Guna2TextBox3.Text = " "
        Try
            connect()
            cmd = New MySqlCommand("select * from book", cn)
            dr = cmd.ExecuteReader()
            dt.Load(dr)
            Guna2DataGridView1.DataSource = dt
            cn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Try
            connect()
            cmd = New MySqlCommand("DELETE FROM book WHERE ID_Book = " + a + " ", cn)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AdminDeleteBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2HtmlLabel6.Text = user
        Try
            connect()
            cmd = New MySqlCommand("select * from book", cn)
            dr = cmd.ExecuteReader()
            dt.Load(dr)
            Guna2DataGridView1.DataSource = dt
            cn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class