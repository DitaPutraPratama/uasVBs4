Imports System.Data.Odbc
Public Class Pupuk
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
        cmd = New OdbcCommand("select * from tbpupuk where id_pupuk = '" & TextBox1.Text & "'", con)
        Rd = cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            MsgBox("ID Pupuk sudah ada,silahkan buat baru atau edit")
        Else
            koneksi()
            Dim a As String = TextBox4.Text
            Dim b As String
            Dim c As String
            Dim d As String
            a = Replace(TextBox4.Text, "Rp", "")
            b = Replace(a, ",", "")
            c = Replace(a, ".", "")
            d = c.Replace(",00", "")
            TextBox4.Text = d
            Dim sql As String = "insert into tbpupuk values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "')"
            cmd = New OdbcCommand(sql, con)
            cmd.ExecuteNonQuery()
            Try
                MsgBox("Menyimpan data BERHASIL", vbInformation, "INFORMASI")
            Catch ex As Exception
                MsgBox("Menyimpan data GAGAL", vbInformation, "PERINGATAN")
            End Try
        End If
        
    End Sub
    Function CheckEmpty(ByVal Ctrl As Control) As Boolean
        Dim textBoxes = Ctrl.Controls.OfType(Of TextBox)()

        For Each t In textBoxes
            If String.IsNullOrEmpty(t.Text) Or TextBox3.Text = "" Then
                MsgBox("Harap lengkapi terlebih dahulu isian yang masih kosong", vbCritical + vbInformation, "Peringatan")
                kosong = True
                Exit For
            Else
                simpan()
                hapus()
                kosong = False
                Exit For
            End If
        Next

        Return kosong
    End Function
    Sub hapus()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        DateTimePicker1.Text = ""
        TextBox1.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        hapus()
    End Sub

    Private Sub Pupuk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.MaxLength = 5
        TextBox2.MaxLength = 20
        TextBox3.MaxLength = 10
        TextBox4.MaxLength = 10
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CheckEmpty(Me)
    End Sub

    Private Sub TextBox4_Click(sender As Object, e As EventArgs) Handles TextBox4.Click
        Dim a As String = TextBox4.Text
        Dim b As String
        Dim c As String
        Dim d As String
        a = Replace(TextBox4.Text, "Rp", "")
        b = Replace(a, ",", "")
        c = Replace(b, ".", "")
        d = Replace(c, "00", "")
        TextBox4.Text = d
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
       
    End Sub

    Private Sub TextBox4_Leave(sender As Object, e As EventArgs) Handles TextBox4.Leave
        If TextBox4.Text <> "" Then
            TextBox4.Text = FormatCurrency(TextBox4.Text)
        End If
    End Sub
End Class