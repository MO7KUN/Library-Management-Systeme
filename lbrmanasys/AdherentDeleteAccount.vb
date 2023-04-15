Imports MySql.Data.MySqlClient

Public Class AdherentDeleteAccount
    Dim cn As MySqlConnection
    Dim dr As MySqlDataReader
    Dim dt As New DataTable
    Dim cmd As MySqlCommand
    Dim pswd As String
    Dim myForm1 As LogIn = CType(Application.OpenForms("LogIn"), LogIn)
    Dim user As String = myForm1.username
    ReadOnly pass As String = myForm1.pswd
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
        AdherentManageUser.Show()

    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        If pass = Guna2TextBox5.Text Then
            Try
                connect()
                cmd = New MySqlCommand("DELETE FROM adherent WHERE username = '" + user + "'", cn)
                cmd.ExecuteNonQuery()
                cn.Close()
                Me.Close()
                LogIn.Show()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class