<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChance
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChance))
        Me.btnChance = New System.Windows.Forms.Button
        Me.lblStim = New System.Windows.Forms.Label
        Me.bwTimer = New System.ComponentModel.BackgroundWorker
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.trbCrave = New System.Windows.Forms.TrackBar
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trbCrave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnChance
        '
        Me.btnChance.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnChance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChance.Location = New System.Drawing.Point(157, 337)
        Me.btnChance.Name = "btnChance"
        Me.btnChance.Size = New System.Drawing.Size(385, 51)
        Me.btnChance.TabIndex = 13
        Me.btnChance.Text = "Next Question"
        Me.btnChance.UseVisualStyleBackColor = True
        '
        'lblStim
        '
        Me.lblStim.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblStim.Font = New System.Drawing.Font("Arial Black", 24.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStim.Location = New System.Drawing.Point(12, 9)
        Me.lblStim.Name = "lblStim"
        Me.lblStim.Size = New System.Drawing.Size(662, 98)
        Me.lblStim.TabIndex = 37
        Me.lblStim.Text = "Select which figure most closely matches how you feel right now:"
        Me.lblStim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bwTimer
        '
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(71, 110)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(553, 126)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 57
        Me.PictureBox1.TabStop = False
        '
        'trbCrave
        '
        Me.trbCrave.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.trbCrave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.trbCrave.LargeChange = 1
        Me.trbCrave.Location = New System.Drawing.Point(92, 254)
        Me.trbCrave.Maximum = 8
        Me.trbCrave.Name = "trbCrave"
        Me.trbCrave.RightToLeftLayout = True
        Me.trbCrave.Size = New System.Drawing.Size(511, 45)
        Me.trbCrave.TabIndex = 67
        Me.trbCrave.Value = 8
        '
        'frmChance
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(700, 400)
        Me.Controls.Add(Me.trbCrave)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblStim)
        Me.Controls.Add(Me.btnChance)
        Me.KeyPreview = True
        Me.Name = "frmChance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Chance"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trbCrave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnChance As System.Windows.Forms.Button
    Friend WithEvents lblStim As System.Windows.Forms.Label
    Friend WithEvents bwTimer As System.ComponentModel.BackgroundWorker
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents trbCrave As System.Windows.Forms.TrackBar
End Class
