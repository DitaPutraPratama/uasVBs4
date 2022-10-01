Imports System.Data.Odbc
Public Class daftarpenerima
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
    Sub tampil()
        DataGridView1.Rows.Clear()
        Try
            koneksi()
            da = New OdbcDataAdapter("select *from tbpenerima order by nama asc", con)
            dt = New DataTable
            da.Fill(dt)
            For Each row In dt.Rows
                DataGridView1.Rows.Add(row(0), row(1), row(2), row(3),
               row(4))
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
                cmd = New OdbcCommand("delete from tbpenerima where nik='" & a &
               "'", con)
                cmd.ExecuteNonQuery()
                MsgBox("Menghapus data BERHASIL", vbInformation, "INFORMASI")
                con.Close()
                tampil()
            End If
        End If
    End Sub
    Sub histori()
        Dim a As String = DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value
        If a = "" Then
            MsgBox("Mohon Pilih Data Penerima")
        Else
            koneksi()
            cmd = New OdbcCommand("select a.nik,a.nama,b.nama, from tbpenerima where nik='" & a &
           "'", con)
            cmd.ExecuteNonQuery()
            MsgBox("Menghapus data BERHASIL", vbInformation, "INFORMASI")
            con.Close()
            tampil()
        End If
    End Sub
    Sub aturdgv()
        DataGridView1.Columns(0).Width = 110
        DataGridView1.Columns(1).Width = 180
        DataGridView1.Columns(2).Width = 150
        DataGridView1.Columns(3).Width = 120
        DataGridView1.Columns(4).Width = 230

        
    End Sub
    Sub aturdgv2()
        DataGridView2.Columns(0).Width = 150
        DataGridView2.Columns(1).Width = 200
        DataGridView2.Columns(2).Width = 150
        DataGridView2.Columns(3).Width = 150
        DataGridView2.Columns(4).Width = 250
    End Sub
    Private Sub daftarpenerima_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampil()
        Call aturdgv()
        Call aturdgv2()
        TextBox1.Text = "Cari NIK"
        TextBox2.Visible = False
        ComboBox1.Visible = False
        TextBox4.Visible = False
        TextBox5.Visible = False
        Button3.Visible = False
        TextBox3.Visible = False
        Button6.Visible = False
        DataGridView2.Visible = False
        ComboBox1.Items.Add("Laki-laki")
        ComboBox1.Items.Add("Perempuan")
        TextBox3.MaxLength = 16
        TextBox2.MaxLength = 20
        TextBox4.MaxLength = 12
        TextBox5.MaxLength = 70
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        hapus()
        tampil()
    End Sub

    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        If TextBox1.Text = "Cari NIK" Then
            TextBox1.Text = ""
        End If
    End Sub
    Private Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
        If TextBox1.Text = "" Then
            TextBox1.Text = "Cari NIK"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Visible = True
        ComboBox1.Visible = True
        TextBox4.Visible = True
        TextBox5.Visible = True
        TextBox3.Visible = True
        Button3.Visible = True
        Button6.Visible = True

        cmd = New OdbcCommand("SELECT * FROM tbpenerima WHERE nik like '%" & DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value & "%'", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            TextBox2.Text = dr.Item("nama")
            ComboBox1.Text = dr.Item("jk")
            TextBox4.Text = dr.Item("hp")
            TextBox5.Text = dr.Item("alamat")
            TextBox3.Text = dr.Item("nik")
        End If
    End Sub
    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        DataGridView1.Rows.Clear()
        Try
            koneksi()
            da = New OdbcDataAdapter("select * from tbpenerima where nik like'%" & TextBox1.Text & "%' ", con)
            dt = New DataTable
            da.Fill(dt)
            For Each row In dt.Rows
                DataGridView1.Rows.Add(row(0), row(1), row(2), row(3), row(4))
            Next
            dt.Rows.Clear()
        Catch ex As Exception
            MsgBox("Menampilkan data GAGAL")
        End Try
    End Sub
    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox3.Visible = False
        TextBox2.Visible = False
        ComboBox1.Visible = False
        TextBox4.Visible = False
        TextBox5.Visible = False
        Button3.Visible = False
        Button6.Visible = False
        Call koneksi()
        cmd = New OdbcCommand("select nik from tbpenerima where nik = '" & TextBox3.Text & "'", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows And TextBox3.Text <> DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value Then
            MsgBox("NIK SUDAH ADA")
        Else
            koneksi()
            Dim sql As String = "update tbpenerima set nik='" & TextBox3.Text & "', nama ='" & TextBox2.Text & "', jk = '" & ComboBox1.Text & "',hp ='" & TextBox4.Text & "', alamat ='" & TextBox5.Text & "' where nik = '" & DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value & "'"
            cmd = New OdbcCommand(sql, con)
            cmd.ExecuteNonQuery()
            Try
                MsgBox("Menyimpan data BERHASIL", vbInformation, "INFORMASI")
            Catch ex As Exception
                MsgBox("Menyimpan data GAGAL", vbInformation, "PERINGATAN")
            End Try
        End If
        


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tampil()
        DataGridView2.Visible = False
        DataGridView1.Visible = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        DataGridView2.Visible = True
        DataGridView1.Visible = False
        DataGridView2.Rows.Clear()
        Try
            koneksi()
            da = New OdbcDataAdapter("select a.nama,c.nama,sum(b.jumlah_keluar),b.tglkeluar,sum(b.harga_total) from tbpenerima a,tbpupuk c,tbkeluar b where a.nik=b.nik and b.id_pupuk = c.id_pupuk and a.nik like '%" & DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value & "%' group by b.tglkeluar,c.id_pupuk", con)
            dt = New DataTable
            da.Fill(dt)
            For Each row In dt.Rows
                DataGridView2.Rows.Add(row(0), row(1), row(2), Format(row(3), "dd-MMMM-yy"),
               FormatCurrency(row(4)))
            Next
            dt.Rows.Clear()
        Catch ex As Exception
            MsgBox("Menampilkan data GAGAL")
        End Try
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        hapus()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TextBox3.Visible = False
        TextBox2.Visible = False
        ComboBox1.Visible = False
        TextBox4.Visible = False
        TextBox5.Visible = False
        Button3.Visible = False
        Button6.Visible = False
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        formLap_penerima.ShowDialog()
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub


End Class