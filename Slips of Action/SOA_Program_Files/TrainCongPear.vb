Imports System
Imports System.IO

Public Class TrainCongPear

    '==========================='
    '-----Declare Variables-----'
    '==========================='

    'sets response to write
    Dim resp As Integer

    'creates new 1 pixel image to put in feedback image's place in case of incorrect resp
    Dim blankBox As New Bitmap(1, 1)

    'sets variables that take values from Main form; used in file output
    Dim cbx, subID, path, stimType As String

    'dims variables that will be gotten from frmMain
    Dim points, pointsEarned As Integer

    'dim new stpwatch for resp time and millisecond variable for conversion
    Dim stpWatch As New Stopwatch()
    Dim milTime As Long

    Dim acceptKey As Boolean


    '============================================================================================'
    '-----Form Load Function (Step #1: what happens each time Showdialog is called for form)-----'
    '============================================================================================'

    Private Sub frmTrainPear_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.Location = screen.Bounds.Location + New Point(0, 0)


        'Set pathway to read/write to file
        cbx = frmMain.cbxSess.SelectedItem
        subID = frmMain.txtSubj.Text
        path = "C:\x\" & subID & "\" & subID & cbx & "_TrainPhase.txt"
        stimType = "CongruentPear"

        points = frmMain.getTrainScore()
        ScoreBox.Text = points

        'set response to arbitray number not used in 3 outcomes for error handling
        resp = 100
        pointsEarned = 100

        'turn on keyboard input and make pics visible
        FruitPic.Visible = True
        LeftArr.Visible = True
        RightArr.Visible = True
        ScoreBox.Visible = True

        stpWatch.Start()
        OverflowTimer.Start()

        acceptKey = True

    End Sub

    '======================================='
    '-----Key Press Functions (Step #2)-----'
    '======================================='

    Private Sub frmTrainPear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim response As MsgBoxResult

        'if x, pop up message asking if you want to quit, Dispose all forms and exit
        If e.KeyChar = "x" Then

            response = MsgBox("You are about to exit the Slips Of Action task. Are you sure?", MsgBoxStyle.YesNo, "Quit the Slips Of Action task?")

            If response = MsgBoxResult.Yes Then

                frmMain.cleanseEverything()

            Else
            End If

        ElseIf e.KeyChar = "2" Then
            'if 2 pressed then incorrect, reset stpwatch, turn off stim, set feedback and resp to incorrect
            If acceptKey = True Then

                acceptKey = False

                milTime = stpWatch.ElapsedMilliseconds()

                stpWatch.Reset()
                OverflowTimer.Stop()

                stimOff()

                FruitPic.Image = blankBox

                resp = 0
                pointsEarned = 0

            End If


        ElseIf e.KeyChar = "1" Then

            If acceptKey = True Then

                acceptKey = False


                'if 1 pressed, correct; get milliseconds resp time from timer then reset
                milTime = stpWatch.ElapsedMilliseconds()

                OverflowTimer.Stop()
                stpWatch.Reset()

                'determine points based on resp time; set new score on frmMain
                Select Case milTime

                    Case 0 To 1000

                        points = points + 5
                        frmMain.setTrainScore(points)
                        pointsEarned = 5

                    Case 1001 To 1500

                        points = points + 4
                        frmMain.setTrainScore(points)
                        pointsEarned = 4

                    Case 1501 To 2000

                        points = points + 3
                        frmMain.setTrainScore(points)
                        pointsEarned = 3

                    Case 2001 To 2500

                        points = points + 2
                        frmMain.setTrainScore(points)
                        pointsEarned = 2

                    Case Is > 2500

                        points = points + 1
                        frmMain.setTrainScore(points)
                        pointsEarned = 1

                    Case Else
                        'error debugging
                        MsgBox("The person coding this sucks.", MsgBoxStyle.OkOnly, "UH-OH. UH-OH. UH-OH.")

                End Select

                'turn off stim, set resp and feedback to correct

                stimOff()

                FruitPic.Image = My.Resources.ResourceManager.GetObject("pear2")

                ScoreBox.Text = points

                resp = 1

            End If

        Else
            'if other key pressed, Do nothing
        End If


    End Sub

    '=========================================================================================================='
    '-----Stim Off function (Step #3: Turn pics and keyboard input off and start pre-feedback blank timer)-----'
    '=========================================================================================================='

    Private Sub stimOff()

        FruitPic.Visible = False
        LeftArr.Visible = False
        RightArr.Visible = False
        ScoreBox.Visible = False

        betweenTimer.Start()

    End Sub

    '======================================'
    '-----Overflow Timer Tick Function-----'
    '======================================'

    'the overflow timer ensures that the milTime variable doesn't overflow (if stim left unanswered for VERY long time)
    Private Sub OverflowTimer_Tick() Handles OverflowTimer.Tick

        Dim response As MsgBoxResult

        'turns off key input
        acceptKey = False

        'stops timer and stopwatch 
        OverflowTimer.Stop()
        stpWatch.Reset()

        'throws msg to user that they reached time limit on this trial, and lets them know the task will be moving on
        response = MsgBox("Time limit reached on this trial. Moving to feedback.", MsgBoxStyle.OkOnly, "Timed Out.")

        If response = MsgBoxResult.Ok Then

            stimOff()

            'sets resp, milTime, and pointsEarned to values not normally gotten, so the textOutput will show a timeOut
            resp = 2
            milTime = -5
            pointsEarned = -5

            'set feedback image to blank crate
            FruitPic.Image = blankBox

        End If

    End Sub

    '============================================================================='
    '-----Between-Timer tick (Step #4: What to do when betweenTimer runs out)-----'
    '============================================================================='

    Private Sub betweenTimer_Tick() Handles betweenTimer.Tick

        'Again, stop/reset timer
        betweenTimer.Stop()

        'set new feedback pic as visible
        FruitPic.Visible = True
        ScoreBox.Visible = True

        'start timer for how long feedback image stays on screen
        feedbackTimer.Start()

    End Sub

    '==============================================================================='
    '-----Feedback-Timer Tick (Step #5: What to do when feedbackTimer runs out)-----'
    '==============================================================================='

    Private Sub feedbackTimer_Tick() Handles feedbackTimer.Tick

        'stop/reset timer
        feedbackTimer.Stop()

        'turn off feedback pic
        FruitPic.Visible = False
        ScoreBox.Visible = False

        'write the output variables to a file, if file exists appends to next line
        Dim fs As New FileStream(path, FileMode.Append, FileAccess.Write)
        Dim sr As New StreamWriter(fs)
        sr.WriteLine(stimType & "," & resp & "," & milTime & "," & pointsEarned & "," & points)
        sr.Close()
        fs.Close()

        'start InterTrialInterval
        blankTimer.Start()

    End Sub

    '=========================================================================='
    '-----Blank-Timer Tick (Step #6: What to do after blankTimer runs out)-----'
    '=========================================================================='

    Private Sub blankTimer_Tick() Handles blankTimer.Tick

        'stop/reset timer
        blankTimer.Stop()

        'change pic back to original stim pic for next trial
        FruitPic.Image = My.Resources.ResourceManager.GetObject("pear2")

        'hide this form and go on to next statement in frmMain (A.K.A---next form is shown)
        Me.Hide()


    End Sub

End Class