Imports System
Imports System.IO

Public Class TrainCongBana

    '==========================='
    '-----Declare Variables-----'
    '==========================='

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

    'dim variables from frmMain
    Dim points As Integer

    'create new stopwatch to record time
    Dim stpWatch As New Stopwatch()
    Dim milTime As Long

    '============================================================================================'
    '-----Form Load Function (Step #1: what happens each time Showdialog is called for form)-----'
    '============================================================================================'

    Private Sub frmTrainBanana_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        path = "C:\x\" & subID & "\" & subID & cbx & "_CongBanaTrain.txt"

        orderPath = "C:\x\" & subID & "\" & subID & cbx & "_TrainOrder.txt"
        stimType = "CongruentBanana"

        'sets variables to deval and points from frm Main
        points = frmMain.getTrainScore()

        'set response to arbitray number not used in 3 outcomes for error handling
        resp = 100

        'turn on keyboard input and ensure all pics visible
        KeyPreview = True

        FruitPic.Visible = True
        LeftArr.Visible = True
        RightArr.Visible = True

        'start stopwatch
        stpWatch.Start()

    End Sub

    '======================================='
    '-----Key Press Functions (Step #2)-----'
    '======================================='

    Private Sub frmTrainBanana_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim response As MsgBoxResult

        'if x, pop up message asking if you want to quit, Dispose all forms and exit
        If e.KeyChar = "x" Then

            response = MsgBox("You are about to exit GPRA Quizzer. Are you sure?", MsgBoxStyle.YesNo, "Quit GRPA Quizzer?")

            If response = MsgBoxResult.Yes Then

                frmMain.cleanseEverything()

            Else
            End If

        ElseIf e.KeyChar = "2" Then
            'if 2 then correct, get milliseconds resp time then reset stpwatch

            milTime = stpWatch.ElapsedMilliseconds()

            stpWatch.Reset()

            'determine points awarded based off resp time; set new score in frmMain
            Select Case milTime

                Case 0 To 1000

                    points = points + 5
                    frmMain.setTrainScore(points)

                Case 1001 To 1500

                    points = points + 4
                    frmMain.setTrainScore(points)

                Case 1501 To 2000

                    points = points + 3
                    frmMain.setTrainScore(points)

                Case 2001 To 2500

                    points = points + 2
                    frmMain.setTrainScore(points)

                Case Is > 2500

                    points = points + 1
                    frmMain.setTrainScore(points)

                Case Else

                    MsgBox("The person coding this sucks.", MsgBoxStyle.OkOnly, "UH-OH. UH-OH. UH-OH.")

            End Select

            'turn off stim, set resp and feedback to correct
            stimOff()

            FruitPic.Image = My.Resources.ResourceManager.GetObject("Banana")

            resp = 1


        ElseIf e.KeyChar = "1" Then

            'if 1, incorrect; turn off stpwatch and stims; set feedback and resp to incorrect
            stpWatch.Reset()

            stimOff()

            FruitPic.Image = blankBox

            resp = 0

        Else
            'if other key pressed, Do nothing
        End If


    End Sub

    '=========================================================================================================='
    '-----Stim Off function (Step #3: Turn pics and keyboard input off and start pre-feedback blank timer)-----'
    '=========================================================================================================='

    Private Sub stimOff()

        KeyPreview = False

        FruitPic.Visible = False
        LeftArr.Visible = False
        RightArr.Visible = False

        betweenTimer.Start()

    End Sub

    '============================================================================='
    '-----Between-Timer tick (Step #4: What to do when betweenTimer runs out)-----'
    '============================================================================='

    Private Sub betweenTimer_Tick() Handles betweenTimer.Tick

        'Again, stop/reset timer
        betweenTimer.Stop()

        'set new feedback pic as visible
        FruitPic.Visible = True

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

    '=========================================================================='
    '-----Blank-Timer Tick (Step #6: What to do after blankTimer runs out)-----'
    '=========================================================================='

    Private Sub blankTimer_Tick() Handles blankTimer.Tick

        'stop/reset timer
        blankTimer.Stop()

        'change pic back to original stim pic for next trial
        FruitPic.Image = My.Resources.ResourceManager.GetObject("Banana")

        'hide this form and go on to next statement in frmMain (A.K.A---next form is shown)
        Me.Hide()


    End Sub

End Class