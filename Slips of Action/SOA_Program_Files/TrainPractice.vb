Imports System
Imports System.IO

Public Class TrainPractice

    '==========================='
    '-----Declare Variables-----'
    '==========================='

    'creates new 1 pixel image to put in feedback image's place in case of incorrect resp
    Dim blankBox As New Bitmap(1, 1)

    Dim acceptKey As Boolean

    Dim slideState As Integer


    '============================================================================================'
    '-----Form Load Function (Step #1: what happens each time Showdialog is called for form)-----'
    '============================================================================================'

    Private Sub TrainPractice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        acceptKey = False

        slideState = 0

        ChestPic.Visible = False
        PointsTxt.Visible = False
        FruitPic.Visible = False
        LeftArr.Visible = False
        RightArr.Visible = False
        ScoreBox.Visible = False
        InstrLbl.Visible = False

        Stim()

    End Sub

    Private Sub Stim()

        allVisible()
        InstrLbl.Visible = True
        acceptKey = False

        Select Case slideState
            Case 0

                ScoreBox.Text = 0
                ScoreBox.Refresh()

                ChestPic.BackgroundImage = My.Resources.ResourceManager.GetObject("ClsChst")
                FruitPic.Image = My.Resources.ResourceManager.GetObject("Strwbry")

                InstrLbl.Text = "Each trial starts with a closed box and a fruit on the" &
                    vbNewLine & "outside. Press '1' or '2' as quickly as you can. For" &
                    vbNewLine & "each fruit, one of these key presses is the 'correct'" &
                    vbNewLine & "answer, and will be the same each time. Your total" &
                    vbNewLine & "points are in the upper left corner." &
                    vbNewLine & "For this fruit, please press '1'."

                InstrLbl.Refresh()

                AllowKeyTimer.Start()

            Case 4

                ChestPic.BackgroundImage = My.Resources.ResourceManager.GetObject("ClsChst")
                FruitPic.Image = My.Resources.ResourceManager.GetObject("razzleberry")

                InstrLbl.Text = "Now, we are on a new trial with a different fruit. Your" &
                    vbNewLine & "score box and the left/right arrows have reappeared." &
                    vbNewLine & "For this fruit, please press '2'."

                InstrLbl.Refresh()

                AllowKeyTimer.Start()

            Case Else
                'error
        End Select

        'increment slide state at key press

    End Sub

    Private Sub Blank()

        acceptKey = True
        allHidden()

        Select Case slideState
            Case 1

                ScoreBox.Text = 5
                ScoreBox.Refresh()

                InstrLbl.Text = "After you answer, there is a quick pause before" &
                    vbNewLine & "feedback. The screen will go blank for about" &
                    vbNewLine & "half a second." &
                    vbNewLine & "For now, please press '8' to continue."

                InstrLbl.Refresh()

            Case 3

                InstrLbl.Text = "After feedback, there is another short pause before" &
                    vbNewLine & "the next round starts. This pause will be about one" &
                    vbNewLine & "second." &
                    vbNewLine & "For now, please press '8' to continue."

                InstrLbl.Refresh()

            Case 5

                InstrLbl.Text = "Again, there is a short pause before feedback." &
                    vbNewLine & "Please press '8' to continue."

                InstrLbl.Refresh()

            Case 7

                InstrLbl.Text = "Again, there is a short pause after you see feedback." &
                    vbNewLine & "For now, press '8' to continue."

                InstrLbl.Refresh()

            Case Else
                'error
        End Select

        'increments slide state in tick

    End Sub

    Private Sub afterBlank()

        acceptKey = False
        slideState = slideState + 1

        'increments slide state at keypress

        Select Case slideState
            Case 2

                '---First Feedback---'
                ChestPic.BackgroundImage = My.Resources.ResourceManager.GetObject("OpnChst")
                FruitPic.Image = My.Resources.ResourceManager.GetObject("lemon")

                fdbkVis()

                InstrLbl.Text = "The box is now open, and there's a reward fruit" &
                    vbNewLine & "inside! Pressing '1' was correct and your score" &
                    vbNewLine & "went up. In this practice, you would press '1' for" &
                    vbNewLine & "every strawberry on the outside of the box. Faster" &
                    vbNewLine & "correct answers earn more points. You will always" &
                    vbNewLine & "get feedback about your choice, which will appear" &
                    vbNewLine & "for about a second before moving to the next trial." &
                    vbNewLine & "For now, please press '8' to continue."

                AllowKeyTimer.Start()

            Case 4

                '---Second Stim---'

                Stim()

            Case 6

                '---Second Feedback---'

                ChestPic.BackgroundImage = My.Resources.ResourceManager.GetObject("OpnChst")
                FruitPic.Image = blankBox

                fdbkVis()

                InstrLbl.Text = "Now the box is open but empty. Pressing '2' is" &
                    vbNewLine & "NOT correct when you see a raspberry. Your score" &
                    vbNewLine & "stayed the same. Again, feedback will appear for" &
                    vbNewLine & "about a second for each trial during the task." &
                    vbNewLine & "For now, please press '8' to continue."

                InstrLbl.Refresh()

                AllowKeyTimer.Start()

            Case 8

                '---Final Form Before Going on to Experiment---'

                allHidden()

                InstrLbl.Text = "Part 1 will begin after this slide. If you have" &
                    vbNewLine & "questions, please ask now. For each outside fruit, try" &
                    vbNewLine & "to remember the correct key and reward fruit. They" &
                    vbNewLine & "will NOT change! Try to answer as quickly as possible" &
                    vbNewLine & "possible to get the most points. To do the practice" &
                    vbNewLine & "again, please press '1' or '2'. If you are ready to" &
                    vbNewLine & "begin the task, press '8'."

                InstrLbl.Refresh()

                AllowKeyTimer.Start()

            Case Else
                'error
        End Select

    End Sub

    Private Sub allVisible()

        ChestPic.Visible = True
        PointsTxt.Visible = True
        FruitPic.Visible = True
        LeftArr.Visible = True
        RightArr.Visible = True
        ScoreBox.Visible = True

    End Sub

    Private Sub fdbkVis()

        ChestPic.Visible = True
        PointsTxt.Visible = True
        FruitPic.Visible = True
        ScoreBox.Visible = True

    End Sub

    Private Sub allHidden()

        ChestPic.Visible = False
        PointsTxt.Visible = False
        FruitPic.Visible = False
        LeftArr.Visible = False
        RightArr.Visible = False
        ScoreBox.Visible = False

    End Sub

    Public Sub allowKey() Handles AllowKeyTimer.Tick

        AllowKeyTimer.Stop()

        acceptKey = True

    End Sub

    '======================================='
    '-----Key Press Functions (Step #2)-----'
    '======================================='

    Private Sub TrainPractice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim response As MsgBoxResult

        'if x, pop up message asking if you want to quit, Dispose all forms and exit
        If e.KeyChar = "x" Then

            response = MsgBox("You are about to exit the Slips Of Action task. Are you sure?", MsgBoxStyle.YesNo, "Quit the Slips Of Action task?")

            If response = MsgBoxResult.Yes Then

                frmMain.cleanseEverything()

            Else
            End If

        ElseIf e.KeyChar = "2" Then
            'if 2 then correct, get milliseconds resp time then reset stpwatch
            If acceptKey = True Then

                acceptKey = False

                Select Case slideState
                    Case 0

                        MsgBox("For this trial, please press the '1' key.", MsgBoxStyle.OkOnly, "Wrong Press")
                        acceptKey = True

                    Case 4

                        slideState = slideState + 1
                        Blank()

                    Case 8
                        Dim resp As MsgBoxResult

                        resp = MsgBox("Are you sure you would like to restart practice?", MsgBoxStyle.YesNo, "Restart?")

                        If resp = MsgBoxResult.Yes Then
                            slideState = 0
                            Stim()
                        Else
                            acceptKey = True
                        End If


                    Case Else

                        acceptKey = True

                End Select

            End If

        ElseIf e.KeyChar = "1" Then

            'if 1, incorrect; turn off stpwatch and stims; set feedback and resp to incorrect
            If acceptKey = True Then

                acceptKey = False

                Select Case slideState
                    Case 0

                        slideState = slideState + 1
                        Blank()

                    Case 4

                        MsgBox("For this trial, please press the '2' key.", MsgBoxStyle.OkOnly, "Wrong Press")
                        acceptKey = True

                    Case 8

                        Dim resp As MsgBoxResult

                        resp = MsgBox("Are you sure you would like to restart practice?", MsgBoxStyle.YesNo, "Restart?")

                        If resp = MsgBoxResult.Yes Then
                            slideState = 0
                            Stim()
                        Else
                            acceptKey = True
                        End If


                    Case Else

                        acceptKey = True

                End Select

            End If

        ElseIf e.KeyChar = "8" Then

            If acceptKey = True Then

                acceptKey = False

                Select Case slideState
                    Case 2, 6

                        slideState = slideState + 1
                        Blank()

                    Case 1, 3, 5, 7

                        afterBlank()

                    Case 8

                        Me.Hide()

                    Case Else

                        acceptKey = True

                End Select

            End If
            'if other key pressed, Do nothing
        End If


    End Sub


End Class