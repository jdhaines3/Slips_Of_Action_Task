<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OutDevPractice
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
        Me.BottomPic = New System.Windows.Forms.PictureBox()
        Me.TopPic = New System.Windows.Forms.PictureBox()
        Me.AllowKeyTimer = New System.Windows.Forms.Timer(Me.components)
        Me.InstrLbl = New System.Windows.Forms.Label()
        CType(Me.BottomPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BottomPic
        '
        Me.BottomPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BottomPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BottomPic.Location = New System.Drawing.Point(500, 375)
        Me.BottomPic.Name = "BottomPic"
        Me.BottomPic.Size = New System.Drawing.Size(300, 275)
        Me.BottomPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BottomPic.TabIndex = 3
        Me.BottomPic.TabStop = False
        '
        'TopPic
        '
        Me.TopPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TopPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TopPic.Location = New System.Drawing.Point(500, 52)
        Me.TopPic.Name = "TopPic"
        Me.TopPic.Size = New System.Drawing.Size(300, 275)
        Me.TopPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TopPic.TabIndex = 1
        Me.TopPic.TabStop = False
        '
        'AllowKeyTimer
        '
        Me.AllowKeyTimer.Interval = 1500
        '
        'InstrLbl
        '
        Me.InstrLbl.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.InstrLbl.BackColor = System.Drawing.Color.Tomato
        Me.InstrLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.InstrLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InstrLbl.Location = New System.Drawing.Point(12, 199)
        Me.InstrLbl.Name = "InstrLbl"
        Me.InstrLbl.Size = New System.Drawing.Size(460, 370)
        Me.InstrLbl.TabIndex = 73
        Me.InstrLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'OutDevPractice
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1284, 729)
        Me.Controls.Add(Me.InstrLbl)
        Me.Controls.Add(Me.BottomPic)
        Me.Controls.Add(Me.TopPic)
        Me.Name = "OutDevPractice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "OutcomeDeval"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.BottomPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TopPic As PictureBox
    Friend WithEvents BottomPic As PictureBox
    Friend WithEvents AllowKeyTimer As Timer
    Friend WithEvents InstrLbl As Label
End Class
