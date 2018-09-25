<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TrainingInstr
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TrainingInstr))
        Me.Title = New System.Windows.Forms.Label()
        Me.InstrLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Title
        '
        Me.Title.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Title.AutoSize = True
        Me.Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title.Location = New System.Drawing.Point(302, 58)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(167, 31)
        Me.Title.TabIndex = 0
        Me.Title.Text = "Instructions"
        '
        'InstrLabel
        '
        Me.InstrLabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.InstrLabel.AutoSize = True
        Me.InstrLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InstrLabel.Location = New System.Drawing.Point(284, 414)
        Me.InstrLabel.Name = "InstrLabel"
        Me.InstrLabel.Size = New System.Drawing.Size(203, 25)
        Me.InstrLabel.TabIndex = 1
        Me.InstrLabel.Text = "Press 8 to continue."
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label1.Location = New System.Drawing.Point(25, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(730, 264)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'TrainingInstr
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.InstrLabel)
        Me.Controls.Add(Me.Title)
        Me.KeyPreview = True
        Me.Name = "TrainingInstr"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Instructions-Training Phase"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Title As Label
    Friend WithEvents InstrLabel As Label
    Friend WithEvents Label1 As Label
End Class
