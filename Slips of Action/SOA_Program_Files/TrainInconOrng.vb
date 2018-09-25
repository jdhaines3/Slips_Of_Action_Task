Imports System
Imports System.IO

Public Class TrainInconOrng

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

    'get variables for deval and score from Main
    Dim points As Integer

    Dim stpWatch As New Stopwatch()
    Dim milTime As Long



    '-----Form Load Function (what happens each time Showdialog is called for form)-----'

    Private Sub frmTrainOrng_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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


        'Set pathway to read/write to file
        cbx = frmMain.cbxSess.SelectedItem
        subID = frmMain.txtSubj.Text
        path = "C:\x\" & subID & "\" & subID & cbx & "_InconOrngTrain.txt"

        orderPath = "C:\x\" & subID & "\" & subID & cbx & "_TrainOrder.txt"
        stimType = "IncongruentOrange"

        points = frmMain.getTrainScore()

        'set response to arbitray number not used in 3 outcomes for error handling
        resp = 100

        'keyboard input on and pics visible
        KeyPreview = True

        FruitPic.Visible = True
        LeftArr.Visible = True
        RightArr.Visible = True


        FruitPic.Focus()

        stpWatch.Start()


    End Sub

    '-----Key Press Functions-----'

    Private Sub frmTrainOrng_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim response As MsgBoxResult

        'if x, pop up message asking if you want to quit, Dispose all forms and exit
        If e.KeyChar = "x" Then
            response = MsgBox("You are about to exit GPRA Quizzer. Are you sure?", MsgBoxStyle.YesNo, "Quit GRPA Quizzer?")

            If response = MsgBoxResult.Yes Then
                frmMain.Dispose()
                SOA_Stnd_Grape.Dispose()
                SOA_Stnd_Apple.Dispose()
                SOA_Cong_Ban.Dispose()
                SOA_Cong_Pear.Dispose()
                EndSOA.Dispose()
                SOA_Incon_Pine.Dispose()
                frmThanks.Dispose()
                Me.Dispose()
                Application.Exit()
            Else
            End If

        ElseIf e.KeyChar = "2" Then


            milTime = stpWatch.ElapsedMilliseconds()

            stpWatch.Reset()

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

            stimOff()

            FruitPic.Image = My.Resources.ResourceManager.GetObject("pineapple")

            resp = 1

        ElseIf e.KeyChar = "1" Then

            stimOff()

            FruitPic.Image = blankBox

            resp = 0

        Else
            'if other key pressed, Do nothing
        End If


    End Sub

    '-----What to do when betweenTimer runs out-----'

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
        FruitPic.Image = My.Resources.ResourceManager.GetObject("orange")

        'hide this form and go on to next statement in frmMain (A.K.A---next form is shown)
        Me.Hide()


    End Sub


    '-----Function for keypress/stim timer running out-----'

    Private Sub stimOff()

        KeyPreview = False

        FruitPic.Visible = False
        LeftArr.Visible = False
        RightArr.Visible = False

        'start timer for blank period between stim and feedback
        betweenTimer.Start()

    End Sub

End Class