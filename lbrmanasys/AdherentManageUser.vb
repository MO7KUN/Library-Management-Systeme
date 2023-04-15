Imports MySql.Data.MySqlClient

Public Class AdherentManageUser
    Dim cn As MySqlConnection
    Dim dr As MySqlDataReader
    Dim dt As New DataTable
    Dim cmd As MySqlCommand
    Dim pswd As String
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

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Me.Close()
        AdherentDashboared.Show()
    End Sub
    Public Sub go()
        Me.Close()
        AdherentDeleteAccount.Show()
    End Sub
    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        go()
    End Sub



    Private Sub AdherentManageUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2HtmlLabel6.Text = user
        Guna2TextBox1.Text = user
        Try
            connect()
            cmd = New MySqlCommand("Select * from adherent where username = '" + user + "'", cn)
            dr = cmd.ExecuteReader
            dr.Read()
            Guna2HtmlLabel11.Text = dr(0)
            pswd = dr.GetString(1)
            Guna2HtmlLabel9.Text = dr.GetString(2)
            Guna2HtmlLabel10.Text = dr.GetString(3)
            Guna2HtmlLabel17.Text = dr.GetString(4)
            Guna2HtmlLabel12.Text = dr.GetString(5)
            Guna2HtmlLabel19.Text = dr.GetString(6)
            Guna2HtmlLabel18.Text = dr.GetString(7)
            Guna2HtmlLabel21.Text = dr.GetString(8)
            Guna2HtmlLabel20.Text = dr.GetString(9)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        If pswd = Guna2TextBox12.Text And Guna2TextBox10.Text = Guna2TextBox11.Text Then
            pswd = Guna2TextBox10.Text
        End If
        Try
            connect()
            cmd = New MySqlCommand("UPDATE adherent SET password = '" + pswd + "' WHERE username = '" + user + "'", cn)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Guna2TextBox12.Text = " "
        Guna2TextBox11.Text = " "
        Guna2TextBox10.Text = " "
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Guna2TextBox1.Text = " "
        Guna2TextBox2.Text = " "
        Guna2TextBox3.Text = " "
        Guna2TextBox4.Text = " "
        Guna2TextBox5.Text = " "
        Guna2TextBox6.Text = " "
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Try
            connect()
            cmd = New MySqlCommand("UPDATE adherent SET First_Name = '" + Guna2TextBox2.Text + "',Last_Name = '" + Guna2TextBox2.Text + "',birthdate = '" & Guna2DateTimePicker1.Value & "',E_Mail = '" + Guna2TextBox6.Text + "',Phone_Number = '" + Guna2TextBox5.Text + "',adresse = '" + Guna2TextBox4.Text + "' WHERE username = '" + user + "'", cn)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class