<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EndDeval
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ScoreTxt = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.Label1.Location = New System.Drawing.Point(131, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(440, 186)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "The devaluation phase is complete!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Check your score below," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "then press 8 to cont" &
    "inue" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to the next phase!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Total Points Earned:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ScoreTxt
        '
        Me.ScoreTxt.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ScoreTxt.BackColor = System.Drawing.Color.LightBlue
        Me.ScoreTxt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.ScoreTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.7!)
        Me.ScoreTxt.Location = New System.Drawing.Point(295, 260)
        Me.ScoreTxt.Name = "ScoreTxt"
        Me.ScoreTxt.Size = New System.Drawing.Size(111, 38)
        Me.ScoreTxt.TabIndex = 71
        Me.ScoreTxt.Text = "0"
        Me.ScoreTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EndDeval
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(700, 400)
        Me.Controls.Add(Me.ScoreTxt)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "EndDeval"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "EndDevaluationPhase"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents ScoreTxt As Label
End Class
