<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RespKnow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.trkBar = New System.Windows.Forms.TrackBar()
        Me.lblQstn = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ITItimer = New System.Windows.Forms.Timer(Me.components)
        Me.ChestPic = New System.Windows.Forms.Panel()
        Me.StimBox = New System.Windows.Forms.PictureBox()
        Me.Instruct = New System.Windows.Forms.Label()
        CType(Me.trkBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ChestPic.SuspendLayout()
        CType(Me.StimBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'trkBar
        '
        Me.trkBar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.trkBar.BackColor = System.Drawing.Color.LightSteelBlue
        Me.trkBar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.trkBar.LargeChange = 1
        Me.trkBar.Location = New System.Drawing.Point(300, 529)
        Me.trkBar.Maximum = 2
        Me.trkBar.Name = "trkBar"
        Me.trkBar.RightToLeftLayout = True
        Me.trkBar.Size = New System.Drawing.Size(700, 45)
        Me.trkBar.TabIndex = 0
        Me.trkBar.Value = 1
        '
        'lblQstn
        '
        Me.lblQstn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblQstn.AutoSize = True
        Me.lblQstn.Font = New System.Drawing.Font("Arial Black", 30.0!, System.Drawing.FontStyle.Bold)
        Me.lblQstn.Location = New System.Drawing.Point(208, 40)
        Me.lblQstn.Name = "lblQstn"
        Me.lblQstn.Size = New System.Drawing.Size(874, 112)
        Me.lblQstn.TabIndex = 38
        Me.lblQstn.Text = "Please select the correct button press" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for the fruit below:"
        Me.lblQstn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(299, 528)
        Me.Label5.MinimumSize = New System.Drawing.Size(555, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(705, 50)
        Me.Label5.TabIndex = 51
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(303, 569)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 23)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "|"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(983, 569)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 23)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "|"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(261, 592)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 19)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = """1"" Key (left)"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(926, 592)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 19)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = """2"" Key (right)"
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
        Me.ChestPic.Size = New System.Drawing.Size(400, 320)
        Me.ChestPic.TabIndex = 75
        '
        'StimBox
        '
        Me.StimBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.StimBox.BackColor = System.Drawing.Color.Transparent
        Me.StimBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StimBox.Location = New System.Drawing.Point(88, 60)
        Me.StimBox.Name = "StimBox"
        Me.StimBox.Size = New System.Drawing.Size(225, 200)
        Me.StimBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.StimBox.TabIndex = 54
        Me.StimBox.TabStop = False
        '
        'Instruct
        '
        Me.Instruct.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Instruct.AutoSize = True
        Me.Instruct.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Instruct.Location = New System.Drawing.Point(387, 665)
        Me.Instruct.Name = "Instruct"
        Me.Instruct.Size = New System.Drawing.Size(532, 24)
        Me.Instruct.TabIndex = 76
        Me.Instruct.Text = "Once the slider is at your choice, press the ""8"" key to continue."
        '
        'RespKnow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(1284, 729)
        Me.Controls.Add(Me.Instruct)
        Me.Controls.Add(Me.ChestPic)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.trkBar)
        Me.Controls.Add(Me.lblQstn)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.KeyPreview = True
        Me.Name = "RespKnow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RespKnowledge"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.trkBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ChestPic.ResumeLayout(False)
        CType(Me.StimBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents trkBar As System.Windows.Forms.TrackBar
    Friend WithEvents lblQstn As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ITItimer As Timer
    Friend WithEvents ChestPic As Panel
    Friend WithEvents StimBox As PictureBox
    Friend WithEvents Instruct As Label
End Class
