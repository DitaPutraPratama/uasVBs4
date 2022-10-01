Imports System.Data.Odbc
Public Class pembagian
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
    Sub tampilnik()
        koneksi()
        cmd = New OdbcCommand("select nik from tbpenerima", con)
        dr = cmd.ExecuteReader
        ComboBox1.Items.Clear()
        Do While dr.Read
            ComboBox1.Items.Add(dr.Item("nik"))
        Loop
    End Sub
    Sub tampilpupuk()
        koneksi()
        cmd = New OdbcCommand("select id_pupuk from tbpupuk", con)
        dr = cmd.ExecuteReader
        ComboBox2.Items.Clear()
        Do While dr.Read
            ComboBox2.Items.Add(dr.Item("id_pupuk"))
        Loop
    End Sub
    Sub simpan()
        koneksi()
        Dim a As String = TextBox10.Text
        Dim b As String
        Dim c As String
        Dim d As String
        a = Replace(TextBox10.Text, "Rp", "")
        b = Replace(a, ",", "")
        c = Replace(a, ".", "")
        d = Replace(c, ",00", "")
        TextBox10.Text = d
        Dim sql As String = "insert into tbkeluar values('""','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & TextBox9.Text & "','" & d & "')"
        cmd = New OdbcCommand(sql, con)
        cmd.ExecuteNonQuery()
        Try
            MsgBox("Menyimpan data BERHASIL", vbInformation, "INFORMASI")
        Catch ex As Exception
            MsgBox("Menyimpan data GAGAL", vbInformation, "PERINGATAN")
        End Try
    End Sub
    Sub aturdgv()
        DataGridView1.Columns(0).Width = 200
        DataGridView1.Columns(1).Width = 200
        DataGridView2.Columns(0).Width = 200
        DataGridView2.Columns(1).Width = 200
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        cmd = New OdbcCommand("select * from tbpenerima where nik='" & ComboBox1.Text & "'", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            TextBox1.Text = dr.Item("nama")
            TextBox2.Text = dr.Item("alamat")
            TextBox3.Text = dr.Item("hp")
        Else
            MsgBox("Data Penerima Belum diInput")
        End If


    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tampilnik()
        tampilpupuk()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False

        TextBox8.Text = "Cari ID Pupuk"

        TextBox7.Text = "Cari NIK"
        Call aturdgv()

        DataGridView1.Rows.Clear()
        Try
            koneksi()
            da = New OdbcDataAdapter("select nik,nama from tbpenerima", con)
            dt = New DataTable
            da.Fill(dt)
            For Each row In dt.Rows
                DataGridView1.Rows.Add(row(0), row(1))
            Next
            dt.Rows.Clear()
        Catch ex As Exception
            MsgBox("Menampilkan data GAGAL")
        End Try

        DataGridView2.Rows.Clear()
        Try
            koneksi()
            da = New OdbcDataAdapter("select id_pupuk,nama from tbpupuk", con)
            dt = New DataTable
            da.Fill(dt)
            For Each row In dt.Rows
                DataGridView2.Rows.Add(row(0), row(1))
            Next
            dt.Rows.Clear()
        Catch ex As Exception
            MsgBox("Menampilkan data GAGAL")
        End Try

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        cmd = New OdbcCommand("select * from tbpupuk where id_pupuk='" & ComboBox2.Text & "'", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            TextBox6.Text = dr.Item("jumlah")
            TextBox5.Text = FormatCurrency(dr.Item("harga"))
            TextBox4.Text = dr.Item("tglmasuk")
        Else
            MsgBox("ID Pupuk tidak ada")
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        DateTimePicker1.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As Integer = TextBox9.Text
        Dim b As Integer = TextBox6.Text

        a = CInt(TextBox9.Text)
        b = CInt(TextBox6.Text)
        If b < a Then
            MsgBox("Stok tidak mencukupi")
        Else
            If TextBox9.Text <> "" Then
                simpan()
            Else
                MsgBox("Harap Lengkapi Inputan")
            End If
            Dim sql As String = "update tbpupuk set jumlah= '" & b & "' - '" & a & "' where id_pupuk = '" & ComboBox2.Text & "'"
            cmd = New OdbcCommand(sql, con)
            cmd.ExecuteNonQuery()
        End If

        

    End Sub

    Private Sub TextBox7_GotFocus(sender As Object, e As EventArgs) Handles TextBox7.GotFocus
        If TextBox7.Text = "Cari NIK" Then
            TextBox7.Text = ""
        End If
    End Sub

    Private Sub TextBox7_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox7.KeyUp
        DataGridView1.Rows.Clear()
        Try
            koneksi()
            da = New OdbcDataAdapter("select nik,nama from tbpenerima where nik like'%" & TextBox7.Text & "%' ", con)
            dt = New DataTable
            da.Fill(dt)
            For Each row In dt.Rows
                DataGridView1.Rows.Add(row(0), row(1))
            Next
            dt.Rows.Clear()
        Catch ex As Exception
            MsgBox("Menampilkan data GAGAL")
        End Try
    End Sub

    Private Sub TextBox7_LostFocus(sender As Object, e As EventArgs) Handles TextBox7.LostFocus
        If TextBox7.Text = "" Then
            TextBox7.Text = "Cari NIK"
        End If
    End Sub


    Private Sub TextBox8_GotFocus(sender As Object, e As EventArgs) Handles TextBox8.GotFocus
        If TextBox8.Text = "Cari ID Pupuk" Then
            TextBox8.Text = ""
        End If
    End Sub

    Private Sub TextBox8_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox8.KeyUp
        DataGridView2.Rows.Clear()
        Try
            koneksi()
            da = New OdbcDataAdapter("select id_pupuk,nama from tbpupuk where id_pupuk like'%" & TextBox8.Text & "%' ", con)
            dt = New DataTable
            da.Fill(dt)
            For Each row In dt.Rows
                DataGridView2.Rows.Add(row(0), row(1))
            Next
            dt.Rows.Clear()
        Catch ex As Exception
            MsgBox("Menampilkan data GAGAL")
        End Try
    End Sub

    Private Sub TextBox8_LostFocus(sender As Object, e As EventArgs) Handles TextBox8.LostFocus
        If TextBox8.Text = "" Then
            TextBox8.Text = "Cari ID Pupuk"
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        cmd = New OdbcCommand("SELECT * FROM tbpenerima WHERE nik like '%" & DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value & "%'", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            TextBox1.Text = dr.Item("nama")
            TextBox2.Text = dr.Item("alamat")
            TextBox3.Text = dr.Item("hp")
            ComboBox1.Text = dr.Item("nik")
        End If

    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        cmd = New OdbcCommand("SELECT * FROM tbpupuk WHERE id_pupuk like '%" & DataGridView2.Item(0, DataGridView2.CurrentRow.Index).Value & "%'", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            TextBox6.Text = dr.Item("jumlah")
            TextBox5.Text = FormatCurrency(dr.Item("harga"))
            TextBox4.Text = dr.Item("tglmasuk")
            ComboBox2.Text = dr.Item("id_pupuk")
        End If
    End Sub

    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBox9_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox9.KeyUp
        If TextBox9.Text = "0" Then
            MsgBox("Jumlah Keluar tidak Boleh 0")
        End If
    End Sub



    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged, DataGridView2.CellClick
        If TextBox9.Text <> "" Then
            Dim a As String = TextBox5.Text
            Dim b As String
            Dim c As String
            Dim d As String
            Dim f As Integer = TextBox9.Text
            a = Replace(TextBox5.Text, "Rp", "")
            b = Replace(a, ",", "")
            c = Replace(a, ".", "")
            d = Replace(c, ",00", "")
            f = CInt(TextBox9.Text)
            d = CInt(d)
            TextBox10.Text = FormatCurrency(d * f)
        End If

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class