Imports System.Data.Odbc
Public Class penerima
    Dim con As OdbcConnection
    Dim dr As OdbcDataReader
    Dim da As OdbcDataAdapter
    Dim ds As DataSet
    Dim dt As DataTable
    Dim cmd As OdbcCommand
    Dim kosong As Boolean
    Sub koneksi()
        con = New OdbcConnection
        con.ConnectionString = "dsn=pupuk"
        con.Open()
    End Sub

    Sub simpan()

        Call koneksi()
        cmd = New OdbcCommand("select nik from tbpenerima where nik = '" & TextBox1.Text & "'", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            MsgBox("NIK SUDAH ADA")
        Else
            koneksi()
            Dim sql As String = "insert into tbpenerima values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
            cmd = New OdbcCommand(sql, con)
            cmd.ExecuteNonQuery()
            MsgBox("Menyimpan data BERHASIL", vbInformation, "INFORMASI")
        End If

    End Sub
    Function CheckEmpty(ByVal Ctrl As Control) As Boolean
        Dim textBoxes = Ctrl.Controls.OfType(Of TextBox)()

        For Each t In textBoxes
            If String.IsNullOrEmpty(t.Text) Then
                MsgBox("Harap lengkapi terlebih dahulu isian yang masih kosong", vbCritical + vbInformation, "Peringatan")
                kosong = True
                Exit For
            Else
                simpan()
                Exit For
                kosong = False
            End If
        Next t

        Return kosong
    End Function
    Sub hapus()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
        TextBox1.Focus()
    End Sub
    Private Sub penerima_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Laki-laki")
        ComboBox1.Items.Add("Perempuan")
        TextBox1.MaxLength = 16
        TextBox2.MaxLength = 20
        TextBox3.MaxLength = 12
        TextBox4.MaxLength = 70

    End Sub
 

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CheckEmpty(Me)
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        hapus()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub
End Class