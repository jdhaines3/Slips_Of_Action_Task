<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SOA_Practice_Devald
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SOA_Practice_Devald))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.WatermelonPic = New System.Windows.Forms.PictureBox()
        Me.OrangePic = New System.Windows.Forms.PictureBox()
        Me.PearPic = New System.Windows.Forms.PictureBox()
        Me.PineapplePic = New System.Windows.Forms.PictureBox()
        Me.BananaPic = New System.Windows.Forms.PictureBox()
        Me.CherryPic = New System.Windows.Forms.PictureBox()
        Me.AllowKeyTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.WatermelonPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrangePic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PearPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PineapplePic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BananaPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CherryPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.BackColor = System.Drawing.Color.Tomato
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(120, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1015, 188)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = resources.GetString("Label1.Text")
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'WatermelonPic
        '
        Me.WatermelonPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.WatermelonPic.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.blackberry
        Me.WatermelonPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.WatermelonPic.Image = Global.Slips_Of_Action.My.Resources.Resources.xmark
        Me.WatermelonPic.Location = New System.Drawing.Point(120, 468)
        Me.WatermelonPic.Name = "WatermelonPic"
        Me.WatermelonPic.Size = New System.Drawing.Size(225, 225)
        Me.WatermelonPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.WatermelonPic.TabIndex = 5
        Me.WatermelonPic.TabStop = False
        '
        'OrangePic
        '
        Me.OrangePic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OrangePic.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.coconut
        Me.OrangePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.OrangePic.Location = New System.Drawing.Point(910, 468)
        Me.OrangePic.Name = "OrangePic"
        Me.OrangePic.Size = New System.Drawing.Size(225, 225)
        Me.OrangePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.OrangePic.TabIndex = 4
        Me.OrangePic.TabStop = False
        '
        'PearPic
        '
        Me.PearPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PearPic.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.pom
        Me.PearPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PearPic.Location = New System.Drawing.Point(523, 468)
        Me.PearPic.Name = "PearPic"
        Me.PearPic.Size = New System.Drawing.Size(225, 225)
        Me.PearPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PearPic.TabIndex = 3
        Me.PearPic.TabStop = False
        '
        'PineapplePic
        '
        Me.PineapplePic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PineapplePic.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.plum_2
        Me.PineapplePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PineapplePic.Location = New System.Drawing.Point(910, 211)
        Me.PineapplePic.Name = "PineapplePic"
        Me.PineapplePic.Size = New System.Drawing.Size(225, 225)
        Me.PineapplePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PineapplePic.TabIndex = 2
        Me.PineapplePic.TabStop = False
        '
        'BananaPic
        '
        Me.BananaPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BananaPic.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.lemon
        Me.BananaPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BananaPic.Image = Global.Slips_Of_Action.My.Resources.Resources.xmark
        Me.BananaPic.Location = New System.Drawing.Point(523, 211)
        Me.BananaPic.Name = "BananaPic"
        Me.BananaPic.Size = New System.Drawing.Size(225, 225)
        Me.BananaPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BananaPic.TabIndex = 1
        Me.BananaPic.TabStop = False
        '
        'CherryPic
        '
        Me.CherryPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CherryPic.BackColor = System.Drawing.Color.LightBlue
        Me.CherryPic.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.papaya
        Me.CherryPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CherryPic.Location = New System.Drawing.Point(120, 211)
        Me.CherryPic.Name = "CherryPic"
        Me.CherryPic.Size = New System.Drawing.Size(225, 225)
        Me.CherryPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CherryPic.TabIndex = 0
        Me.CherryPic.TabStop = False
        '
        'AllowKeyTimer
        '
        Me.AllowKeyTimer.Interval = 1500
        '
        'SOA_Practice_Devald
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1284, 729)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.WatermelonPic)
        Me.Controls.Add(Me.OrangePic)
        Me.Controls.Add(Me.PearPic)
        Me.Controls.Add(Me.PineapplePic)
        Me.Controls.Add(Me.BananaPic)
        Me.Controls.Add(Me.CherryPic)
        Me.Name = "SOA_Practice_Devald"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Part 4 Practice: Worthless Fruit"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.WatermelonPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrangePic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PearPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PineapplePic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BananaPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CherryPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CherryPic As PictureBox
    Friend WithEvents BananaPic As PictureBox
    Friend WithEvents PineapplePic As PictureBox
    Friend WithEvents PearPic As PictureBox
    Friend WithEvents OrangePic As PictureBox
    Friend WithEvents WatermelonPic As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents AllowKeyTimer As Timer
End Class
