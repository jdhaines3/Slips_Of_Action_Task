<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SOA_Devalued
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
        Me.components = New System.ComponentModel.Container()
        Me.WatermelonPic = New System.Windows.Forms.PictureBox()
        Me.OrangePic = New System.Windows.Forms.PictureBox()
        Me.PearPic = New System.Windows.Forms.PictureBox()
        Me.PineapplePic = New System.Windows.Forms.PictureBox()
        Me.BananaPic = New System.Windows.Forms.PictureBox()
        Me.CherryPic = New System.Windows.Forms.PictureBox()
        Me.durTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.WatermelonPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrangePic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PearPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PineapplePic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BananaPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CherryPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WatermelonPic
        '
        Me.WatermelonPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.WatermelonPic.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.halfWMelon
        Me.WatermelonPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.WatermelonPic.Location = New System.Drawing.Point(12, 213)
        Me.WatermelonPic.Name = "WatermelonPic"
        Me.WatermelonPic.Size = New System.Drawing.Size(175, 175)
        Me.WatermelonPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.WatermelonPic.TabIndex = 5
        Me.WatermelonPic.TabStop = False
        '
        'OrangePic
        '
        Me.OrangePic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OrangePic.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.orange
        Me.OrangePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.OrangePic.Location = New System.Drawing.Point(513, 213)
        Me.OrangePic.Name = "OrangePic"
        Me.OrangePic.Size = New System.Drawing.Size(175, 175)
        Me.OrangePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.OrangePic.TabIndex = 4
        Me.OrangePic.TabStop = False
        '
        'PearPic
        '
        Me.PearPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PearPic.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.pear2
        Me.PearPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PearPic.Location = New System.Drawing.Point(263, 213)
        Me.PearPic.Name = "PearPic"
        Me.PearPic.Size = New System.Drawing.Size(175, 175)
        Me.PearPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PearPic.TabIndex = 3
        Me.PearPic.TabStop = False
        '
        'PineapplePic
        '
        Me.PineapplePic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PineapplePic.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.pineapple
        Me.PineapplePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PineapplePic.Location = New System.Drawing.Point(513, 12)
        Me.PineapplePic.Name = "PineapplePic"
        Me.PineapplePic.Size = New System.Drawing.Size(175, 175)
        Me.PineapplePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PineapplePic.TabIndex = 2
        Me.PineapplePic.TabStop = False
        '
        'BananaPic
        '
        Me.BananaPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BananaPic.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.Banana
        Me.BananaPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BananaPic.Location = New System.Drawing.Point(263, 12)
        Me.BananaPic.Name = "BananaPic"
        Me.BananaPic.Size = New System.Drawing.Size(175, 175)
        Me.BananaPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BananaPic.TabIndex = 1
        Me.BananaPic.TabStop = False
        '
        'CherryPic
        '
        Me.CherryPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CherryPic.BackColor = System.Drawing.Color.LightBlue
        Me.CherryPic.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.cherries
        Me.CherryPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CherryPic.Location = New System.Drawing.Point(12, 12)
        Me.CherryPic.Name = "CherryPic"
        Me.CherryPic.Size = New System.Drawing.Size(175, 175)
        Me.CherryPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CherryPic.TabIndex = 0
        Me.CherryPic.TabStop = False
        '
        'durTimer
        '
        Me.durTimer.Interval = 10000
        '
        'SOA_Devalued
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(700, 400)
        Me.Controls.Add(Me.WatermelonPic)
        Me.Controls.Add(Me.OrangePic)
        Me.Controls.Add(Me.PearPic)
        Me.Controls.Add(Me.PineapplePic)
        Me.Controls.Add(Me.BananaPic)
        Me.Controls.Add(Me.CherryPic)
        Me.Name = "SOA_Devalued"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Devalued Stims SOA"
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
    Friend WithEvents durTimer As Timer
End Class
