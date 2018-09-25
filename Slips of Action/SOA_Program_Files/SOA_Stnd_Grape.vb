Imports System
Imports System.IO

Public Class SOA_Stnd_Grape

    '-----set variables-----'

    'sets response to write
    Dim resp As Integer

    'creates new 1 pixel image to put in feedback image's place in case of incorrect resp
    Dim blankBox As New Bitmap(1, 1)

    'sets variables that take values from Main form; used in file output
    Dim cbx As String
    Dim subID As String
    Dim path As String

    'sets variables for text output of order of stims
    Dim orderPath As String
    Dim stimType As String

    'sets variables to get deval outcomes number from frmMain
    Dim d1 As Integer
    Dim d2 As Integer

    'sets points variable
    Dim score As Integer


    '-----Form Load Function (what happens each time Showdialog is called for form)-----'

    Private Sub SOA_Stnd_Grape_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'set the screen to extended monitor
        Dim screen As Screen
        ' We want to display a form on screen 1
        Try
            screen = Screen.AllScreens(1)
        Catch ex As Exception
            screen = Screen.AllScreens(0)
        End Try

        ' Set the StartPosition to Manual otherwise the system will assign an automatic start position
        Me.StartPosition = FormStartPosition.Manual
        ' Set the form location so it appears at Location (100, 100) on the screen 1
        Me.Location = screen.Bounds.Location + New Point(0, 0)


        'Set pathway to read/write to file-need selected session and subID from Main, then use those to make file path
        cbx = frmMain.cbxSess.SelectedItem
        subID = frmMain.txtSubj.Text
        path = "C:\x\" & subID & "\" & subID & cbx & "_StndGrapeSOA.txt"

        'set path and stimtype for output to stimOrder text
        orderPath = "C:\x\" & subID & "\" & subID & cbx & "_StimOrder.txt"
        stimType = "StandardGrape"

        'get deval numbers and score
        d1 = frmMain.getD1()
        d2 = frmMain.getD2()
        score = frmMain.getScore()

        'set response to arbitray number not used in 3 outcomes for error handling
        resp = 100

        'turn on keyboard input and ensure all pictures visible
        KeyPreview = True

        FruitPic.Visible = True
        LeftArr.Visible = True
        RightArr.Visible = True

        'start first timer (for stim)
        FruitPic.Focus()
        stimTimer.Start()


    End Sub


    '-----what to do on key press-----'

    Private Sub SOA_Stnd_Grape_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim response As MsgBoxResult

        'if x, pop up message asking if you want to quit, Dispose all forms and exit
        If e.KeyChar = "x" Then

            response = MsgBox("You are about to exit GPRA Quizzer. Are you sure?", MsgBoxStyle.YesNo, "Quit GRPA Quizzer?")

            If response = MsgBoxResult.Yes Then
                frmMain.Dispose()
                EndSOA.Dispose()
                SOA_Stnd_Apple.Dispose()
                SOA_Cong_Ban.Dispose()
                SOA_Cong_Pear.Dispose()
                SOA_Incon_Orng.Dispose()
                SOA_Incon_Pine.Dispose()
                frmThanks.Dispose()
                Me.Dispose()
                Application.Exit()
            Else
            End If

        ElseIf e.KeyChar = "2" Then

            'if 2 pressed, determine if feedback has been devalued. if so, show xmark feedback and subtract points. if not, show cherries and add points

            '0 is the number for cherries being deval'd
            If d1 = 0 Or d2 = 0 Then

                'see sub at bottom of page for comments
                stimOff()

                'set image to feedback image for correct BUT DEVALUED Resp
                FruitPic.Image = My.Resources.ResourceManager.GetObject("xmark")

                'set response to number designation for correct key, but DEVAL resp
                resp = 2

                'subtract points from total
                score = score - 5
                frmMain.setScore(score)

            Else

                stimOff()

                'feedback set to cherries instead
                FruitPic.Image = My.Resources.ResourceManager.GetObject("cherries")

                'resp output set to correct key press
                resp = 1

                'add points and set the frmMain variable to new number
                score = score + 5
                frmMain.setScore(score)

            End If


        ElseIf e.KeyChar = "1" Then

            stimOff()

            'feedback image set to background: empty box
            FruitPic.Image = blankBox

            resp = 0

            'points

        Else
            'if other key pressed, Do nothing
        End If


    End Sub

    '-----What to do when stimTimer runs out-----'

    'similar to key press functions for 1/2, but happens if first timer runs out

    Private Sub stimTimer_Tick() Handles stimTimer.Tick

        'another check on DEVAL'd outcomes; if cherries are devalued, stim time-out changes slightly.
        'similar code to keypress
        If d1 = 0 Or d2 = 0 Then

            stimOff()

            FruitPic.Image = My.Resources.ResourceManager.GetObject("Checkmark")

            resp = 4

            score = score + 5
            frmMain.setScore(score)

        Else

            stimOff()

            FruitPic.Image = blankBox

            resp = 3

            'points = points

        End If

    End Sub


    '-----What to do when betweenTimer runs out-----'

    'blank period between stim and feedback
    Private Sub betweenTimer_Tick() Handles betweenTimer.Tick

        'Again, stop/reset timer
        betweenTimer.Stop()

        'set new feedback pic as visible
        FruitPic.Visible = True

        'start timer for how long feedback image stays on screen
        feedbackTimer.Start()

    End Sub


    '-----What to do when feedbackTimer runs out-----'
    Private Sub feedbackTimer_Tick() Handles feedbackTimer.Tick

        'stop/reset timer
        feedbackTimer.Stop()

        'turn off feedback pic
        FruitPic.Visible = False


        'write the resp variable to the text file, then close filestream
        Dim fs As New FileStream(path, FileMode.Append, FileAccess.Write)
        Dim sr As New StreamWriter(fs)
        sr.WriteLine(Now & "  " & resp)
        sr.Close()
        fs.Close()

        'write type of stim to text file
        Dim fsOP As New FileStream(orderPath, FileMode.Append, FileAccess.Write)
        Dim srOP As New StreamWriter(fsOP)
        srOP.WriteLine(Now & "  " & stimType)
        srOP.Close()
        fsOP.Close()

        'start InterTrialInterval
        blankTimer.Start()

    End Sub


    '-----What to do after blankTimer runs out-----'
    Private Sub blankTimer_Tick() Handles blankTimer.Tick

        'stop/reset timer
        blankTimer.Stop()

        'change pic back to original stim pic for next trial
        FruitPic.Image = My.Resources.ResourceManager.GetObject("grapes")

        'hide this form and go on to next statement in frmMain (A.K.A---next form is shown)
        Me.Hide()


    End Sub

    '-----What to do after stim (button press or time out)-----'

    Private Sub stimOff()

        'reset/stop timer, make pics invisible and turn off keyboard input
        stimTimer.Stop()

        KeyPreview = False

        FruitPic.Visible = False
        LeftArr.Visible = False
        RightArr.Visible = False

        'start timer for blank period between stim and feedback
        betweenTimer.Start()

    End Sub

End Class