<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SOA_Stnd_Grape
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
        Me.stimTimer = New System.Windows.Forms.Timer(Me.components)
        Me.betweenTimer = New System.Windows.Forms.Timer(Me.components)
        Me.feedbackTimer = New System.Windows.Forms.Timer(Me.components)
        Me.blankTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FruitPic = New System.Windows.Forms.PictureBox()
        Me.RightArr = New System.Windows.Forms.PictureBox()
        Me.LeftArr = New System.Windows.Forms.PictureBox()
        Me.ChestPic = New System.Windows.Forms.Panel()
        CType(Me.FruitPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightArr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftArr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ChestPic.SuspendLayout()
        Me.SuspendLayout()
        '
        'stimTimer
        '
        Me.stimTimer.Interval = 1500
        '
        'betweenTimer
        '
        Me.betweenTimer.Interval = 500
        '
        'feedbackTimer
        '
        Me.feedbackTimer.Interval = 2500
        '
        'blankTimer
        '
        Me.blankTimer.Interval = 1000
        '
        'FruitPic
        '
        Me.FruitPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FruitPic.BackColor = System.Drawing.Color.Transparent
        Me.FruitPic.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.grapes
        Me.FruitPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.FruitPic.InitialImage = Nothing
        Me.FruitPic.Location = New System.Drawing.Point(75, 60)
        Me.FruitPic.Name = "FruitPic"
        Me.FruitPic.Size = New System.Drawing.Size(350, 300)
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
        Me.RightArr.Location = New System.Drawing.Point(800, 595)
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
        Me.LeftArr.Location = New System.Drawing.Point(400, 595)
        Me.LeftArr.Name = "LeftArr"
        Me.LeftArr.Size = New System.Drawing.Size(100, 50)
        Me.LeftArr.TabIndex = 63
        Me.LeftArr.TabStop = False
        '
        'ChestPic
        '
        Me.ChestPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ChestPic.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.ClsChst
        Me.ChestPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ChestPic.Controls.Add(Me.FruitPic)
        Me.ChestPic.Location = New System.Drawing.Point(400, 110)
        Me.ChestPic.Name = "ChestPic"
        Me.ChestPic.Size = New System.Drawing.Size(500, 420)
        Me.ChestPic.TabIndex = 71
        '
        'SOA_Stnd_Grape
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1284, 729)
        Me.Controls.Add(Me.ChestPic)
        Me.Controls.Add(Me.RightArr)
        Me.Controls.Add(Me.LeftArr)
        Me.KeyPreview = True
        Me.Name = "SOA_Stnd_Grape"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.FruitPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightArr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftArr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ChestPic.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LeftArr As PictureBox
    Friend WithEvents RightArr As PictureBox
    Friend WithEvents FruitPic As PictureBox
    Friend WithEvents stimTimer As Timer
    Friend WithEvents betweenTimer As Timer
    Friend WithEvents feedbackTimer As Timer
    Friend WithEvents blankTimer As Timer
    Friend WithEvents ChestPic As Panel
End Class
