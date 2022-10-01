Public Class Beranda

    Sub terkunci()
        LoginToolStripMenuItem.Visible = True
        LogoutToolStripMenuItem.Visible = False
        InputDataPupukToolStripMenuItem.Visible = False
        InputDataPenerimaToolStripMenuItem.Visible = False
        PembagianToolStripMenuItem.Visible = False

    End Sub

    Private Sub Beranda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Pupuk.Close()
        penerima.Close()
        pembagian.Close()
    End Sub

    Private Sub Beranda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call terkunci()
    End Sub

    Private Sub KeluarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeluarToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        Login.ShowDialog()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Call terkunci()
    End Sub

    Private Sub InputPupukToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InputPupukToolStripMenuItem.Click
        Pupuk.ShowDialog()
    End Sub


    Private Sub DaftarStokPupukToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DaftarStokPupukToolStripMenuItem.Click
        daftarpupuk.ShowDialog()
    End Sub

    Private Sub InputDataPenerimaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles InputDataPenerimaToolStripMenuItem1.Click
        penerima.ShowDialog()
    End Sub

    Private Sub DaftarPenerimaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DaftarPenerimaToolStripMenuItem1.Click
        daftarpenerima.ShowDialog()
    End Sub

    Private Sub PupukKeluarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PupukKeluarToolStripMenuItem.Click
        pembagian.ShowDialog()
    End Sub

    Private Sub DaftarPupukKeluarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DaftarPupukKeluarToolStripMenuItem.Click
        pupukkeluar.ShowDialog()
    End Sub
End Class