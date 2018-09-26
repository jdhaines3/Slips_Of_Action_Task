<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OutKnow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.trkBar = New System.Windows.Forms.TrackBar()
        Me.lblQstn = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.StimBox = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ITItimer = New System.Windows.Forms.Timer(Me.components)
        Me.ChestPic = New System.Windows.Forms.Panel()
        Me.Instruct = New System.Windows.Forms.Label()
        Me.BanPic = New System.Windows.Forms.PictureBox()
        Me.ChrPic = New System.Windows.Forms.PictureBox()
        Me.OrnPic = New System.Windows.Forms.PictureBox()
        Me.PearPic = New System.Windows.Forms.PictureBox()
        Me.WmlnPic = New System.Windows.Forms.PictureBox()
        Me.PinePic = New System.Windows.Forms.PictureBox()
        CType(Me.trkBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StimBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ChestPic.SuspendLayout()
        CType(Me.BanPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChrPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrnPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PearPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WmlnPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PinePic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'trkBar
        '
        Me.trkBar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.trkBar.BackColor = System.Drawing.Color.LightSteelBlue
        Me.trkBar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.trkBar.LargeChange = 1
        Me.trkBar.Location = New System.Drawing.Point(300, 529)
        Me.trkBar.Maximum = 6
        Me.trkBar.Name = "trkBar"
        Me.trkBar.RightToLeftLayout = True
        Me.trkBar.Size = New System.Drawing.Size(700, 45)
        Me.trkBar.TabIndex = 0
        '
        'lblQstn
        '
        Me.lblQstn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblQstn.AutoSize = True
        Me.lblQstn.Font = New System.Drawing.Font("Arial Black", 25.0!, System.Drawing.FontStyle.Bold)
        Me.lblQstn.Location = New System.Drawing.Point(131, 28)
        Me.lblQstn.Name = "lblQstn"
        Me.lblQstn.Size = New System.Drawing.Size(1043, 144)
        Me.lblQstn.TabIndex = 38
        Me.lblQstn.Text = "Select the REWARD fruit you would earn after pressing" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the correct button for the" &
    " fruit on the OUTSIDE of the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "box below."
        Me.lblQstn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Location = New System.Drawing.Point(299, 528)
        Me.Label11.MinimumSize = New System.Drawing.Size(555, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(705, 50)
        Me.Label11.TabIndex = 51
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(980, 569)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 23)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "|"
        '
        'StimBox
        '
        Me.StimBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.StimBox.BackColor = System.Drawing.Color.Transparent
        Me.StimBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StimBox.Location = New System.Drawing.Point(60, 50)
        Me.StimBox.Name = "StimBox"
        Me.StimBox.Size = New System.Drawing.Size(280, 240)
        Me.StimBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.StimBox.TabIndex = 54
        Me.StimBox.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(420, 569)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 23)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "|"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(534, 569)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 23)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "|"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(644, 569)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 23)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "|"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(757, 569)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 23)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "|"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(868, 569)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 23)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "|"
        '
        'ITItimer
        '
        Me.ITItimer.Interval = 1000
        '
        'ChestPic
        '
        Me.ChestPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ChestPic.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.ClsChst
        Me.ChestPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ChestPic.Controls.Add(Me.StimBox)
        Me.ChestPic.Location = New System.Drawing.Point(450, 175)
        Me.ChestPic.Name = "ChestPic"
        Me.ChestPic.Size = New System.Drawing.Size(400, 340)
        Me.ChestPic.TabIndex = 74
        '
        'Instruct
        '
        Me.Instruct.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Instruct.AutoSize = True
        Me.Instruct.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Instruct.Location = New System.Drawing.Point(386, 703)
        Me.Instruct.Name = "Instruct"
        Me.Instruct.Size = New System.Drawing.Size(526, 24)
        Me.Instruct.TabIndex = 75
        Me.Instruct.Text = "Once the slider is at your choice, press the '8' key to continue."
        '
        'BanPic
        '
        Me.BanPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BanPic.Image = Global.Slips_Of_Action.My.Resources.Resources.Banana
        Me.BanPic.Location = New System.Drawing.Point(385, 595)
        Me.BanPic.Name = "BanPic"
        Me.BanPic.Size = New System.Drawing.Size(80, 80)
        Me.BanPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BanPic.TabIndex = 76
        Me.BanPic.TabStop = False
        '
        'ChrPic
        '
        Me.ChrPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ChrPic.Image = Global.Slips_Of_Action.My.Resources.Resources.cherries
        Me.ChrPic.Location = New System.Drawing.Point(499, 595)
        Me.ChrPic.Name = "ChrPic"
        Me.ChrPic.Size = New System.Drawing.Size(80, 80)
        Me.ChrPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ChrPic.TabIndex = 77
        Me.ChrPic.TabStop = False
        '
        'OrnPic
        '
        Me.OrnPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OrnPic.Image = Global.Slips_Of_Action.My.Resources.Resources.orange
        Me.OrnPic.Location = New System.Drawing.Point(610, 595)
        Me.OrnPic.Name = "OrnPic"
        Me.OrnPic.Size = New System.Drawing.Size(80, 80)
        Me.OrnPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.OrnPic.TabIndex = 78
        Me.OrnPic.TabStop = False
        '
        'PearPic
        '
        Me.PearPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PearPic.Image = Global.Slips_Of_Action.My.Resources.Resources.pear2
        Me.PearPic.Location = New System.Drawing.Point(723, 595)
        Me.PearPic.Name = "PearPic"
        Me.PearPic.Size = New System.Drawing.Size(80, 80)
        Me.PearPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PearPic.TabIndex = 79
        Me.PearPic.TabStop = False
        '
        'WmlnPic
        '
        Me.WmlnPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.WmlnPic.Image = Global.Slips_Of_Action.My.Resources.Resources.wmelon2
        Me.WmlnPic.Location = New System.Drawing.Point(946, 595)
        Me.WmlnPic.Name = "WmlnPic"
        Me.WmlnPic.Size = New System.Drawing.Size(80, 80)
        Me.WmlnPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.WmlnPic.TabIndex = 80
        Me.WmlnPic.TabStop = False
        '
        'PinePic
        '
        Me.PinePic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PinePic.Image = Global.Slips_Of_Action.My.Resources.Resources.pineapple
        Me.PinePic.Location = New System.Drawing.Point(835, 595)
        Me.PinePic.Name = "PinePic"
        Me.PinePic.Size = New System.Drawing.Size(80, 80)
        Me.PinePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PinePic.TabIndex = 81
        Me.PinePic.TabStop = False
        '
        'OutKnow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1284, 729)
        Me.Controls.Add(Me.PinePic)
        Me.Controls.Add(Me.WmlnPic)
        Me.Controls.Add(Me.PearPic)
        Me.Controls.Add(Me.OrnPic)
        Me.Controls.Add(Me.ChrPic)
        Me.Controls.Add(Me.BanPic)
        Me.Controls.Add(Me.Instruct)
        Me.Controls.Add(Me.ChestPic)
        Me.Controls.Add(Me.lblQstn)
        Me.Controls.Add(Me.trkBar)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.KeyPreview = True
        Me.Name = "OutKnow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.trkBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StimBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ChestPic.ResumeLayout(False)
        CType(Me.BanPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChrPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrnPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PearPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WmlnPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PinePic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents trkBar As System.Windows.Forms.TrackBar
    Friend WithEvents lblQstn As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents StimBox As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ITItimer As Timer
    Friend WithEvents ChestPic As Panel
    Friend WithEvents Instruct As Label
    Friend WithEvents BanPic As PictureBox
    Friend WithEvents ChrPic As PictureBox
    Friend WithEvents OrnPic As PictureBox
    Friend WithEvents PearPic As PictureBox
    Friend WithEvents WmlnPic As PictureBox
    Friend WithEvents PinePic As PictureBox
End Class
