<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Beranda
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.KeluarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InputDataPupukToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InputPupukToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DaftarStokPupukToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InputDataPenerimaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InputDataPenerimaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DaftarPenerimaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PembagianToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PupukKeluarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DaftarPupukKeluarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.InputDataPupukToolStripMenuItem, Me.InputDataPenerimaToolStripMenuItem, Me.PembagianToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(3, 1, 0, 1)
        Me.MenuStrip1.Size = New System.Drawing.Size(662, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoginToolStripMenuItem, Me.LogoutToolStripMenuItem, Me.ToolStripMenuItem1, Me.KeluarToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(47, 22)
        Me.FileToolStripMenuItem.Text = "Form"
        '
        'LoginToolStripMenuItem
        '
        Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
        Me.LoginToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LoginToolStripMenuItem.Text = "Login"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(149, 6)
        '
        'KeluarToolStripMenuItem
        '
        Me.KeluarToolStripMenuItem.Name = "KeluarToolStripMenuItem"
        Me.KeluarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.KeluarToolStripMenuItem.Text = "Keluar"
        '
        'InputDataPupukToolStripMenuItem
        '
        Me.InputDataPupukToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InputPupukToolStripMenuItem, Me.DaftarStokPupukToolStripMenuItem})
        Me.InputDataPupukToolStripMenuItem.Name = "InputDataPupukToolStripMenuItem"
        Me.InputDataPupukToolStripMenuItem.Size = New System.Drawing.Size(53, 22)
        Me.InputDataPupukToolStripMenuItem.Text = "Pupuk"
        '
        'InputPupukToolStripMenuItem
        '
        Me.InputPupukToolStripMenuItem.Name = "InputPupukToolStripMenuItem"
        Me.InputPupukToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.InputPupukToolStripMenuItem.Text = "Input Data Pupuk"
        '
        'DaftarStokPupukToolStripMenuItem
        '
        Me.DaftarStokPupukToolStripMenuItem.Name = "DaftarStokPupukToolStripMenuItem"
        Me.DaftarStokPupukToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.DaftarStokPupukToolStripMenuItem.Text = "Daftar Stok Pupuk"
        '
        'InputDataPenerimaToolStripMenuItem
        '
        Me.InputDataPenerimaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InputDataPenerimaToolStripMenuItem1, Me.DaftarPenerimaToolStripMenuItem1})
        Me.InputDataPenerimaToolStripMenuItem.Name = "InputDataPenerimaToolStripMenuItem"
        Me.InputDataPenerimaToolStripMenuItem.Size = New System.Drawing.Size(69, 22)
        Me.InputDataPenerimaToolStripMenuItem.Text = "Penerima"
        '
        'InputDataPenerimaToolStripMenuItem1
        '
        Me.InputDataPenerimaToolStripMenuItem1.Name = "InputDataPenerimaToolStripMenuItem1"
        Me.InputDataPenerimaToolStripMenuItem1.Size = New System.Drawing.Size(182, 22)
        Me.InputDataPenerimaToolStripMenuItem1.Text = "Input Data Penerima"
        '
        'DaftarPenerimaToolStripMenuItem1
        '
        Me.DaftarPenerimaToolStripMenuItem1.Name = "DaftarPenerimaToolStripMenuItem1"
        Me.DaftarPenerimaToolStripMenuItem1.Size = New System.Drawing.Size(182, 22)
        Me.DaftarPenerimaToolStripMenuItem1.Text = "Daftar Penerima"
        '
        'PembagianToolStripMenuItem
        '
        Me.PembagianToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PupukKeluarToolStripMenuItem, Me.DaftarPupukKeluarToolStripMenuItem})
        Me.PembagianToolStripMenuItem.Name = "PembagianToolStripMenuItem"
        Me.PembagianToolStripMenuItem.Size = New System.Drawing.Size(79, 22)
        Me.PembagianToolStripMenuItem.Text = "Pembagian"
        '
        'PupukKeluarToolStripMenuItem
        '
        Me.PupukKeluarToolStripMenuItem.Name = "PupukKeluarToolStripMenuItem"
        Me.PupukKeluarToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.PupukKeluarToolStripMenuItem.Text = "Pupuk Keluar"
        '
        'DaftarPupukKeluarToolStripMenuItem
        '
        Me.DaftarPupukKeluarToolStripMenuItem.Name = "DaftarPupukKeluarToolStripMenuItem"
        Me.DaftarPupukKeluarToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.DaftarPupukKeluarToolStripMenuItem.Text = "Daftar Pupuk Keluar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(168, 88)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(386, 99)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "APLIKASI" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "MANAJEMEN DISTRIBUSI" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PUPUK BERSUBSIDI"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(13, 54)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 33)
        Me.Label2.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.PictureBox1.Image = Global.Uas.My.Resources.Resources.Wonogiri_1
        Me.PictureBox1.Location = New System.Drawing.Point(44, 88)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(109, 137)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Beranda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(164, Byte), Integer))
        Me.BackgroundImage = Global.Uas.My.Resources.Resources._20220629_091137
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(662, 343)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Beranda"
        Me.Text = "Beranda"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InputDataPupukToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InputDataPenerimaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PembagianToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents KeluarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents InputPupukToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DaftarStokPupukToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InputDataPenerimaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DaftarPenerimaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PupukKeluarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DaftarPupukKeluarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
