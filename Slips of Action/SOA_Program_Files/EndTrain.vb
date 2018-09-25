Public Class EndTrain


    Dim score As Integer


    Private Sub frmCongruent1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim response As MsgBoxResult

        'if x, pop up message asking if you want to quit, Dispose all forms and exit
        If e.KeyChar = "x" Then

            response = MsgBox("You are about to exit GPRA Quizzer. Are you sure?", MsgBoxStyle.YesNo, "Quit GRPA Quizzer?")

            If response = MsgBoxResult.Yes Then
                frmMain.Dispose()
                SOA_Stnd_Grape.Dispose()
                SOA_Stnd_Apple.Dispose()
                EndSOA.Dispose()
                SOA_Cong_Pear.Dispose()
                SOA_Incon_Orng.Dispose()
                SOA_Incon_Pine.Dispose()
                frmThanks.Dispose()
                Me.Dispose()
                Application.Exit()
            Else
            End If

        ElseIf e.KeyChar = "8" Then

            Me.Hide()

        Else
            'if other key pressed, Do nothing
        End If


    End Sub



    Private Sub EndTrain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        score = frmMain.getTrainScore()

        ScoreTxt.Text = score




    End Sub




End Class