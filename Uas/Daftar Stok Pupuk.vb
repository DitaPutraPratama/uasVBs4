Imports System.Data.Odbc
Public Class daftarpupuk
    Dim con As OdbcConnection
    Dim dr As OdbcDataReader
    Dim da As OdbcDataAdapter
    Dim ds As DataSet
    Dim dt As DataTable
    Dim cmd As OdbcCommand

    Sub koneksi()
        con = New OdbcConnection
        con.ConnectionString = "dsn=pupuk"
        con.Open()
    End Sub
    Sub filter()
        Dim a As String = TextBox4.Text
        Dim b As String
        Dim c As String
        Dim d As String
        a = Replace(TextBox4.Text, "Rp", "")
        b = Replace(a, ",", "")
        c = Replace(a, ".", "")
        d = c.Replace(",00", "")
        TextBox4.Text = d
    End Sub
    Sub tampil()
        DataGridView1.Rows.Clear()
        Try
            koneksi()
            da = New OdbcDataAdapter("select *from tbpupuk order by tglmasuk asc", con)
            dt = New DataTable
            da.Fill(dt)
            For Each row In dt.Rows
                DataGridView1.Rows.Add(row(0), row(1), row(2), FormatCurrency(row(3)),
               Format(row(4), "dd-MMMM-yy"))
            Next
            dt.Rows.Clear()
        Catch ex As Exception
            MsgBox("Menampilkan data GAGAL")
        End Try
    End Sub
    Sub hapus()
        Dim a As String = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
        If a = "" Then
            MsgBox("Data Pupuk yang dihapus belum DIPILIH")
        Else
            If (MessageBox.Show("Anda yakin menghapus data dengan KODE=" & a &
           "...?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) =
           Windows.Forms.DialogResult.OK) Then
                koneksi()
                cmd = New OdbcCommand("delete from tbpupuk where id_pupuk='" & a &
               "'", con)
                cmd.ExecuteNonQuery()
                MsgBox("Menghapus data BERHASIL", vbInformation, "INFORMASI")
                con.Close()
                tampil()
            End If
        End If
    End Sub
    Sub aturdgv()
        DataGridView1.Columns(0).Width = 100
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(2).Width = 100
        DataGridView1.Columns(3).Width = 170
        DataGridView1.Columns(4).Width = 150
    End Sub
    Sub updat()
        koneksi()
        filter()
        Call koneksi()
        cmd = New OdbcCommand("select id_pupuk from tbpupuk where id_pupuk = '" & TextBox5.Text & "'", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows And TextBox5.Text <> DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value Then
            MsgBox("ID PUPUK SUDAH ADA")
        Else
            Dim sql As String = "update tbpupuk set id_pupuk='" & TextBox5.Text & "', nama ='" & TextBox2.Text & "', jumlah = '" & TextBox3.Text & "',harga ='" & TextBox4.Text & "', tglmasuk ='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "' where id_pupuk = '" & DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value & "'"
            cmd = New OdbcCommand(sql, con)
            cmd.ExecuteNonQuery()
            Try
                MsgBox("Menyimpan data BERHASIL", vbInformation, "INFORMASI")
            Catch ex As Exception
                MsgBox("Menyimpan data GAGAL", vbInformation, "PERINGATAN")
            End Try

        End If
       
    End Sub
    Private Sub daftarpupuk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampil()
        Call aturdgv()
        TextBox1.Text = "Cari ID Pupuk"
        TextBox2.Visible = False
        TextBox3.Visible = False
        TextBox4.Visible = False
        DateTimePicker1.Visible = False
        Button3.Visible = False
        Button5.Visible = False
        TextBox5.Visible = False
        TextBox5.MaxLength = 5
        TextBox2.MaxLength = 20
        TextBox3.MaxLength = 10
        TextBox4.MaxLength = 10
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        hapus()
        tampil()
    End Sub


    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        DataGridView1.Rows.Clear()
        Try
            koneksi()
            da = New OdbcDataAdapter("select * from tbpupuk where id_pupuk like'%" & TextBox1.Text & "%' ", con)
            dt = New DataTable
            da.Fill(dt)
            For Each row In dt.Rows
                DataGridView1.Rows.Add(row(0), row(1), row(2), FormatCurrency(row(3)), row(4))
            Next
            dt.Rows.Clear()
        Catch ex As Exception
            MsgBox("Menampilkan data GAGAL")
        End Try
    End Sub

    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        If TextBox1.Text = "Cari ID Pupuk" Then
            TextBox1.Text = ""
        End If
    End Sub
    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
        If TextBox1.Text = "" Then
            TextBox1.Text = "Cari ID Pupuk"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox5.Visible = True
        TextBox2.Visible = True
        TextBox3.Visible = True
        TextBox4.Visible = True
        DateTimePicker1.Visible = True
        Button3.Visible = True
        Button5.Visible = True



        cmd = New OdbcCommand("SELECT * FROM tbpupuk WHERE id_pupuk like '%" & DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value & "%'", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            TextBox5.Text = dr.Item("id_pupuk")
            TextBox2.Text = dr.Item("nama")
            TextBox3.Text = dr.Item("jumlah")
            TextBox4.Text = FormatCurrency(dr.Item("harga"))
            DateTimePicker1.Text = dr.Item("tglmasuk")
        End If
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox5.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        TextBox4.Visible = False
        DateTimePicker1.Visible = False
        Button3.Visible = False
        Button5.Visible = False
        updat()

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


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tampil()
    End Sub



    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox5.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        TextBox4.Visible = False
        DateTimePicker1.Visible = False
        Button3.Visible = False
        Button5.Visible = False
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        formLap_pupuk.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class