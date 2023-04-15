Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Public Class AdminManageUsers
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
    Public Sub dgv()
        Try
            connect()
            cmd = New MySqlCommand("Select username,Status,First_Name,Last_Name from adherent", cn)
            dr = cmd.ExecuteReader
            dt.Load(dr)
            Guna2DataGridView1.DataSource = dt
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub AdminManageUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2HtmlLabel7.Text = user
        dgv()
    End Sub

    Private Sub Guna2TextBox1_TextChanged(sender As Object, e As EventArgs) Handles Guna2TextBox1.TextChanged
        Try
            connect()
            cmd = New MySqlCommand("Select username,Status,First_Name,Last_Name from adherent where username like '%" + Guna2TextBox1.Text + "%'", cn)
            dr = cmd.ExecuteReader
            dt.Load(dr)
            Guna2DataGridView1.DataSource = dt
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Guna2DataGridView1.CellContentClick
        Dim selectedRow As DataGridViewRow = Guna2DataGridView1.CurrentRow
        Guna2TextBox1.Text = selectedRow.Cells(0).Value
        Guna2TextBox1.Enabled = False
        Guna2ComboBox1.SelectedItem = selectedRow.Cells(1).Value
        Guna2TextBox2.Text = selectedRow.Cells(2).Value
        Guna2TextBox2.Enabled = False
        Guna2TextBox3.Text = selectedRow.Cells(3).Value
        Guna2TextBox3.Enabled = False
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Guna2DataGridView1.Rows.Clear()
        Try
            connect()
            cmd = New MySqlCommand("UPDATE adherent SET First_Name = '" + Guna2TextBox2.Text + "',Last_Name = '" + Guna2TextBox2.Text + "', Status = '" + Guna2ComboBox1.SelectedItem + "' WHERE username = '" + Guna2TextBox1.Text + "'", cn)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        dgv()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Guna2DataGridView1.Rows.Clear()
        Try
            connect()
            cmd = New MySqlCommand("DELETE FROM adherent WHERE username = '" + Guna2TextBox1.Text + "'", cn)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        dgv()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Guna2TextBox1.Text = " "
        Guna2TextBox2.Text = " "
        Guna2TextBox3.Text = " "
        Guna2ComboBox1.SelectedIndex() = -1
        dgv()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Me.Close()
        AdminDashboard.Show()
    End Sub
End Class