Imports System.Web.UI.Design.WebControls.WebParts
Imports MySql.Data.MySqlClient

Public Class AdherentAddLoan
    Dim cn As MySqlConnection
    Dim dr As MySqlDataReader
    Dim dt As New DataTable
    Dim cmd As MySqlCommand
    Dim myForm1 As LogIn = CType(Application.OpenForms("LogIn"), LogIn)
    Dim user As String = myForm1.username
    Dim IDBook As Integer
    Public Sub connect()
        Try
            cn = New MySqlConnection("server=localhost;userid=root;password=;database=sysmanbibliotheque")
            cn.Open()


        Catch ex As Exception
            MessageBox.Show("echec de connexion")

        End Try

    End Sub
    Public Sub lodF()
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
    Public Sub clear()
        Guna2DataGridView1.DataSource = Nothing
    End Sub
    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Me.Close()
        LogIn.Show()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Me.Close()
        AdherentDashboared.Show()
    End Sub

    Private Sub AdherentAddLoan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2HtmlLabel6.Text = user
        clear()
        lodF()
    End Sub

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged
        clear()
        lodF()
    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        Dim selectedRow As DataGridViewRow = Guna2DataGridView1.CurrentRow
        Guna2TextBox1.Text = selectedRow.Cells(1).Value
        Guna2TextBox2.Text = selectedRow.Cells(2).Value
        Guna2TextBox3.Text = selectedRow.Cells(3).Value
        clear()
        lodF()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Guna2TextBox1.Text = " "
        Guna2TextBox2.Text = " "
        Guna2TextBox3.Text = " "
        lodF()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Try
            connect()
            cmd = New MySqlCommand("select ID_Book from book where Title = '" + Guna2TextBox1.Text + "' and Author = '" + Guna2TextBox2.Text + "' and Editor='" + Guna2TextBox3.Text + "'", cn)
            IDBook = cmd.ExecuteScalar()
            cmd = New MySqlCommand("insert into loan(ID_Book,username,Start_Date,End_Date) values (" + IDBook + ",'" + user + "','" & Guna2DateTimePicker1.Value & "','" & Guna2DateTimePicker2.Value & "')", cn)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class