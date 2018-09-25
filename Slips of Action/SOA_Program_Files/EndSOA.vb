Public Class EndSOA


    Dim score As Integer


    Private Sub frmBlank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'Dim response As MsgBoxResult

        'Keeping this section in case want ability to go a second round

        'If e.Control And e.KeyCode = Keys.N Then
        'Me.Hide()
        'End If

        If e.Control And e.KeyCode = Keys.X Then
            frmMain.Dispose()
            SOA_Stnd_Grape.Dispose()
            SOA_Stnd_Apple.Dispose()
            SOA_Cong_Ban.Dispose()
            SOA_Cong_Pear.Dispose()
            SOA_Incon_Orng.Dispose()
            SOA_Incon_Pine.Dispose()
            frmThanks.Dispose()
            Me.Dispose()
            Application.Exit()
        End If

    End Sub



    Private Sub frmBlank_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objPoint As Point = PointToScreen(New Point(0, 0))
        objPoint.X += 0
        objPoint.Y += 0
        Cursor.Position = objPoint
        KeyPreview = True
        Dim screen As Screen

        ' We want to display a form on screen 0 (Primary)
        screen = Screen.AllScreens(0)
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = screen.Bounds.Location + New Point(0, 0)

        score = frmMain.getScore()

        ScoreTxt.Text = score




    End Sub


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'Dim response As MsgBoxResult
        'response = MsgBox("You are about to exit sQuizzer. Are you sure?", MsgBoxStyle.YesNo, "Quit sQuizzer?")
        'If response = MsgBoxResult.Yes Then
        frmMain.Dispose()
        SOA_Stnd_Grape.Dispose()
        SOA_Stnd_Apple.Dispose()
        SOA_Cong_Ban.Dispose()
        SOA_Cong_Pear.Dispose()
        SOA_Incon_Orng.Dispose()
        SOA_Incon_Pine.Dispose()
        frmThanks.Dispose()
        Me.Dispose()
        Application.Exit()
        'Else
        'End If
    End Sub


End Class