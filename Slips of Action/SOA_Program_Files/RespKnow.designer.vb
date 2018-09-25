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
        Me.StimBox = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ITItimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.trkBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StimBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'trkBar
        '
        Me.trkBar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.trkBar.BackColor = System.Drawing.Color.LightSteelBlue
        Me.trkBar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.trkBar.LargeChange = 1
        Me.trkBar.Location = New System.Drawing.Point(75, 287)
        Me.trkBar.Maximum = 2
        Me.trkBar.Name = "trkBar"
        Me.trkBar.RightToLeftLayout = True
        Me.trkBar.Size = New System.Drawing.Size(553, 45)
        Me.trkBar.TabIndex = 0
        Me.trkBar.Value = 1
        '
        'lblQstn
        '
        Me.lblQstn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblQstn.Font = New System.Drawing.Font("Arial Black", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblQstn.Location = New System.Drawing.Point(12, 9)
        Me.lblQstn.Name = "lblQstn"
        Me.lblQstn.Size = New System.Drawing.Size(676, 83)
        Me.lblQstn.TabIndex = 38
        Me.lblQstn.Text = "Please select the correct button press" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for the stimuli below:"
        Me.lblQstn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(74, 286)
        Me.Label5.MinimumSize = New System.Drawing.Size(555, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(555, 50)
        Me.Label5.TabIndex = 51
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(82, 330)
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
        Me.Label4.Location = New System.Drawing.Point(609, 330)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(14, 23)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "|"
        '
        'StimBox
        '
        Me.StimBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.StimBox.BackgroundImage = Global.Slips_Of_Action.My.Resources.Resources.crate
        Me.StimBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StimBox.Location = New System.Drawing.Point(242, 89)
        Me.StimBox.Name = "StimBox"
        Me.StimBox.Size = New System.Drawing.Size(218, 192)
        Me.StimBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.StimBox.TabIndex = 55
        Me.StimBox.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(57, 353)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 19)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Left (1)"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(575, 353)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 19)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Right (2)"
        '
        'ITItimer
        '
        Me.ITItimer.Interval = 1000
        '
        'RespKnow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(700, 400)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StimBox)
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
        CType(Me.StimBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents trkBar As System.Windows.Forms.TrackBar
    Friend WithEvents lblQstn As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents StimBox As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ITItimer As Timer
End Class
