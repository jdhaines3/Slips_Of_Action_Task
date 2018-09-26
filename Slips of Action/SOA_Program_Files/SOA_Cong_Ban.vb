Imports System
Imports System.IO

Public Class SOA_Cong_Ban

    '==========================='
    '-----Declare Variables-----'
    '==========================='

    'sets response to write
    Dim resp As Integer

    'creates new 1 pixel image to put in feedback image's place in case of incorrect resp
    Dim blankBox As New Bitmap(1, 1)

    'sets variables that take values from Main form; used in file output
    Dim cbx, subID, path, stimType As String

    'dim variables from frmMain
    Dim d1, d2, score, pointsEarned As Integer

    Dim acceptKey As Boolean

    '==================================================================================='
    '-----Form Load Function (what happens each time Showdialog is called for form)-----'
    '==================================================================================='

    Private Sub BanaSOA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        path = "C:\x\" & subID & "\" & subID & cbx & "_SlipsPhase.txt"
        stimType = "CongruentBanana"

        'sets variables to deval and points from frm Main
        d1 = frmMain.getD1()
        d2 = frmMain.getD2()
        score = frmMain.getScore()

        'set response to arbitray number not used in 3 outcomes for error handling
        resp = 100
        pointsEarned = 100

        'turn on keyboard input and ensure all pics visible
        ChestPic.Visible = True
        FruitPic.Visible = True
        LeftArr.Visible = True
        RightArr.Visible = True

        FruitPic.Focus()

        'start first timer
        stimTimer.Start()

        acceptKey = True

    End Sub


    '==========================='
    '-----KeyPress Function-----'
    '==========================='

    Private Sub BanaSOA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim response As MsgBoxResult

        'if x, pop up message asking if you want to quit, Dispose all forms and exit
        If e.KeyChar = "x" Then

            response = MsgBox("You are about to exit the Slips Of Action task. Are you sure?", MsgBoxStyle.YesNo, "Quit the Slips Of Action task?")

            If response = MsgBoxResult.Yes Then

                frmMain.cleanseEverything()

            Else
            End If

        ElseIf e.KeyChar = "2" Then

            'if 2 pressed, see if stim is devalued
            If acceptKey = True Then

                acceptKey = False

                'if so, set feedback to red x and resp to 2 for incorrect go, subtract point
                If d1 = 1 Or d2 = 1 Then

                    stimOff()

                    ChestPic.BackgroundImage = My.Resources.ResourceManager.GetObject("OpnChst")
                    FruitPic.BackgroundImage = My.Resources.ResourceManager.GetObject("Banana")
                    FruitPic.Image = My.Resources.ResourceManager.GetObject("xmark")

                    resp = 2

                    score = score - 1
                    frmMain.setScore(score)
                    pointsEarned = -1

                Else
                    'if not, correct press
                    stimOff()

                    ChestPic.BackgroundImage = My.Resources.ResourceManager.GetObject("OpnChst")
                    FruitPic.BackgroundImage = My.Resources.ResourceManager.GetObject("Banana")
                    FruitPic.Image = blankBox

                    resp = 1

                    score = score + 1
                    frmMain.setScore(score)
                    pointsEarned = 1

                End If

            End If

        ElseIf e.KeyChar = "1" Then

            'incorrect press
            If acceptKey = True Then

                acceptKey = False
                If d1 = 1 Or d2 = 1 Then

                    stimOff()

                    ChestPic.BackgroundImage = My.Resources.ResourceManager.GetObject("OpnChst")
                    FruitPic.BackgroundImage = blankBox
                    FruitPic.Image = My.Resources.ResourceManager.GetObject("xmark")

                    resp = 3

                    score = score - 1
                    frmMain.setScore(score)
                    pointsEarned = -1

                Else

                    stimOff()

                    ChestPic.BackgroundImage = My.Resources.ResourceManager.GetObject("OpnChst")
                    FruitPic.Image = blankBox
                    FruitPic.BackgroundImage = blankBox

                    resp = 0
                    pointsEarned = 0

                End If

            End If

        Else
            'if other key pressed, Do nothing
        End If


    End Sub

    '================================='
    '-----Stim Timer Tick/Elapsed-----'
    '================================='


    'similar to key press functions for 1/2, but happens if first timer runs out

    Private Sub stimTimer_Tick() Handles stimTimer.Tick

        acceptKey = False

        If d1 = 1 Or d2 = 1 Then

            stimOff()

            ChestPic.BackgroundImage = My.Resources.ResourceManager.GetObject("OpnChst")
            FruitPic.Image = My.Resources.ResourceManager.GetObject("Checkmark")
            FruitPic.BackgroundImage = blankBox

            resp = 5

            score = score + 1
            frmMain.setScore(score)
            pointsEarned = 1

        Else

            stimOff()

            ChestPic.BackgroundImage = My.Resources.ResourceManager.GetObject("OpnChst")
            FruitPic.Image = blankBox
            FruitPic.BackgroundImage = blankBox

            resp = 4

            pointsEarned = 0

        End If

    End Sub

    '====================================================='
    '-----Stimulus Off/Hide Function (and timer stop)-----'
    '====================================================='

    Private Sub stimOff()

        'reset/stop timer, make pics invisible and turn off keyboard input
        stimTimer.Stop()

        ChestPic.Visible = False
        FruitPic.Visible = False
        LeftArr.Visible = False
        RightArr.Visible = False

        'start timer for blank period between stim and feedback
        betweenTimer.Start()

    End Sub

    '================================================================'
    '-----Blank Period (between stim and feedback) Timer Elapsed-----'
    '================================================================'

    Private Sub betweenTimer_Tick() Handles betweenTimer.Tick

        'Again, stop/reset timer
        betweenTimer.Stop()

        'set new feedback pic as visible
        ChestPic.Visible = True
        FruitPic.Visible = True

        'start timer for how long feedback image stays on screen
        feedbackTimer.Start()

    End Sub

    '==============================='
    '-----Feedback Timer Elapse-----'
    '==============================='

    Private Sub feedbackTimer_Tick() Handles feedbackTimer.Tick

        'stop/reset timer
        feedbackTimer.Stop()

        'turn off feedback pic
        ChestPic.Visible = False
        FruitPic.Visible = False

        'write the resp variable to the text file, then close filestream
        Dim fs As New FileStream(path, FileMode.Append, FileAccess.Write)
        Dim sr As New StreamWriter(fs)
        sr.WriteLine(stimType & "," & resp & "," & pointsEarned & "," & score)
        sr.Close()
        fs.Close()

        'start InterTrialInterval
        blankTimer.Start()

    End Sub

    '================================================='
    '-----Post Feedback Blank Period Timer Elapse-----'
    '================================================='

    Private Sub blankTimer_Tick() Handles blankTimer.Tick

        'stop/reset timer
        blankTimer.Stop()

        'change pic back to original stim pic for next trial
        ChestPic.BackgroundImage = My.Resources.ResourceManager.GetObject("ClsChst")
        FruitPic.BackgroundImage = My.Resources.ResourceManager.GetObject("Banana")
        FruitPic.Image = blankBox

        'hide this form and go on to next statement in frmMain (A.K.A---next form is shown)
        Me.Hide()


    End Sub

End Class