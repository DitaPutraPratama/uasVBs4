Imports System.Data.Odbc
Public Class pupukkeluar
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
            da = New OdbcDataAdapter("select nik,id_pupuk,tglkeluar,jumlah_keluar,sum(harga_total) from tbkeluar group by tglkeluar,nik,id_pupuk order by tglkeluar desc", con)
            dt = New DataTable
            da.Fill(dt)
            For Each row In dt.Rows
                DataGridView1.Rows.Add(row(0), row(1), Format(row(2), "dd-MMMM-yy"), row(3),
               FormatCurrency(row(4)))
            Next
            dt.Rows.Clear()
        Catch ex As Exception
            MsgBox("Menampilkan data GAGAL")
        End Try
    End Sub
    Sub aturdgv()
        DataGridView1.Columns(0).Width = 110
        DataGridView1.Columns(1).Width = 110
        DataGridView1.Columns(2).Width = 130
        DataGridView1.Columns(3).Width = 130
        DataGridView1.Columns(4).Width = 110

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

    Private Sub pupukkeluar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tampil()
        Call aturdgv()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tampil()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        formLap_keluar.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class