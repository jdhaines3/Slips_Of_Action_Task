<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SOA_Practice
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
        Me.AllowKeyTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ChestPic = New System.Windows.Forms.Panel()
        Me.FruitPic = New System.Windows.Forms.PictureBox()
        Me.RightArr = New System.Windows.Forms.PictureBox()
        Me.LeftArr = New System.Windows.Forms.PictureBox()
        Me.InstrLbl = New System.Windows.Forms.Label()
        Me.LastTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ChestPic.SuspendLayout()
        CType(Me.FruitPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightArr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftArr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AllowKeyTimer
        '
        Me.AllowKeyTimer.Interval = 1500
        '
        'ChestPic
        '
        Me.ChestPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ChestPic.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.ClsChst
        Me.ChestPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ChestPic.Controls.Add(Me.FruitPic)
        Me.ChestPic.Location = New System.Drawing.Point(450, 242)
        Me.ChestPic.Name = "ChestPic"
        Me.ChestPic.Size = New System.Drawing.Size(400, 320)
        Me.ChestPic.TabIndex = 73
        '
        'FruitPic
        '
        Me.FruitPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FruitPic.BackColor = System.Drawing.Color.Transparent
        Me.FruitPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.FruitPic.Image = Global.Slips_Of_Action.My.Resources.Resources.razzleberry
        Me.FruitPic.InitialImage = Nothing
        Me.FruitPic.Location = New System.Drawing.Point(75, 60)
        Me.FruitPic.Name = "FruitPic"
        Me.FruitPic.Size = New System.Drawing.Size(250, 200)
        Me.FruitPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.FruitPic.TabIndex = 65
        Me.FruitPic.TabStop = False
        '
        'RightArr
        '
        Me.RightArr.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RightArr.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.Right
        Me.RightArr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RightArr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RightArr.Location = New System.Drawing.Point(750, 603)
        Me.RightArr.Name = "RightArr"
        Me.RightArr.Size = New System.Drawing.Size(100, 50)
        Me.RightArr.TabIndex = 64
        Me.RightArr.TabStop = False
        '
        'LeftArr
        '
        Me.LeftArr.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LeftArr.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.Left
        Me.LeftArr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.LeftArr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LeftArr.Location = New System.Drawing.Point(450, 603)
        Me.LeftArr.Name = "LeftArr"
        Me.LeftArr.Size = New System.Drawing.Size(100, 50)
        Me.LeftArr.TabIndex = 63
        Me.LeftArr.TabStop = False
        '
        'InstrLbl
        '
        Me.InstrLbl.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.InstrLbl.BackColor = System.Drawing.Color.Tomato
        Me.InstrLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.InstrLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InstrLbl.Location = New System.Drawing.Point(330, 22)
        Me.InstrLbl.Name = "InstrLbl"
        Me.InstrLbl.Size = New System.Drawing.Size(640, 210)
        Me.InstrLbl.TabIndex = 74
        Me.InstrLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LastTimer
        '
        Me.LastTimer.Interval = 10000
        '
        'SOA_Practice
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1284, 729)
        Me.Controls.Add(Me.InstrLbl)
        Me.Controls.Add(Me.ChestPic)
        Me.Controls.Add(Me.RightArr)
        Me.Controls.Add(Me.LeftArr)
        Me.KeyPreview = True
        Me.Name = "SOA_Practice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Part 4 Practice"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ChestPic.ResumeLayout(False)
        CType(Me.FruitPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightArr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftArr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LeftArr As PictureBox
    Friend WithEvents RightArr As PictureBox
    Friend WithEvents FruitPic As PictureBox
    Friend WithEvents AllowKeyTimer As Timer
    Friend WithEvents ChestPic As Panel
    Friend WithEvents InstrLbl As Label
    Friend WithEvents LastTimer As Timer
End Class
