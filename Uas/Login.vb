Imports System.Data.Odbc
Public Class Login
    Sub terbuka()
        Beranda.LoginToolStripMenuItem.Visible = False
        Beranda.LogoutToolStripMenuItem.Visible = True
        Beranda.InputDataPupukToolStripMenuItem.Visible = True
        Beranda.InputDataPenerimaToolStripMenuItem.Visible = True
        Beranda.PembagianToolStripMenuItem.Visible = True

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("form tidak boleh kosong")
        Else
            Call Koneksi()
            CMd = New OdbcCommand("select*from tbadmin where username='" & TextBox1.Text & "' and pwd='" & TextBox2.Text & "'", Conn)
            Rd = CMd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                Me.Close()
                Call terbuka()
            Else
                MsgBox("Password atau Username salah")
            End If
        End If

    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox2.PasswordChar = "."
    End Sub


    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "."
        End If
    End Sub
End Class