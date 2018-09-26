<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EndBlockTrain
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
        Me.lblThanks = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblThanks
        '
        Me.lblThanks.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblThanks.AutoSize = True
        Me.lblThanks.Font = New System.Drawing.Font("Arial", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThanks.Location = New System.Drawing.Point(429, 288)
        Me.lblThanks.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblThanks.Name = "lblThanks"
        Me.lblThanks.Size = New System.Drawing.Size(813, 372)
        Me.lblThanks.TabIndex = 0
        Me.lblThanks.Text = "End of Block." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Press '8' to continue" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to next block."
        Me.lblThanks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EndBlockTrain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MediumTurquoise
        Me.ClientSize = New System.Drawing.Size(1712, 897)
        Me.Controls.Add(Me.lblThanks)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "EndBlockTrain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblThanks As System.Windows.Forms.Label
End Class
