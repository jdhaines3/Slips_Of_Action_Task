﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OutcomeDeval
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
        Me.durTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.BottomPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BottomPic
        '
        Me.BottomPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BottomPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BottomPic.Location = New System.Drawing.Point(263, 193)
        Me.BottomPic.Name = "BottomPic"
        Me.BottomPic.Size = New System.Drawing.Size(187, 195)
        Me.BottomPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BottomPic.TabIndex = 3
        Me.BottomPic.TabStop = False
        '
        'TopPic
        '
        Me.TopPic.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TopPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TopPic.Location = New System.Drawing.Point(263, 12)
        Me.TopPic.Name = "TopPic"
        Me.TopPic.Size = New System.Drawing.Size(187, 175)
        Me.TopPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TopPic.TabIndex = 1
        Me.TopPic.TabStop = False
        '
        'durTimer
        '
        Me.durTimer.Interval = 1500
        '
        'OutcomeDeval
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(700, 400)
        Me.Controls.Add(Me.BottomPic)
        Me.Controls.Add(Me.TopPic)
        Me.Name = "OutcomeDeval"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "OutcomeDeval"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.BottomPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TopPic As PictureBox
    Friend WithEvents BottomPic As PictureBox
    Friend WithEvents durTimer As Timer
End Class