Imports System
Imports System.IO

Public Class OutDevPractice

    '======================='
    '---Declare variables---'
    '======================='


    Dim acceptKey As Boolean

    Dim slideState As Integer

    Dim blankBox As New Bitmap(1, 1)

    '============================================================================================'
    '-----Form Load Function (Step #1: what happens each time Showdialog is called for form)-----'
    '============================================================================================'

    Private Sub OutcomeDeval_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        TopPic.Visible = False
        BottomPic.Visible = False
        InstrLbl.Visible = False

        Stim()

    End Sub

    Private Sub Stim()

        InstrLbl.Visible = True
        TopPic.Visible = True
        BottomPic.Visible = True

        acceptKey = False

        Select Case slideState
            Case 0

                TopPic.BackgroundImage = My.Resources.ResourceManager.GetObject("plum-2")
                TopPic.Image = My.Resources.ResourceManager.GetObject("xmark")

                BottomPic.BackgroundImage = My.Resources.ResourceManager.GetObject("lemon")
                BottomPic.Image = blankBox

                InstrLbl.Text = "Here you see the plum has a red 'X' over it, and" &
                    vbNewLine & "a lemon without one. The plum is devalued, so you" &
                    vbNewLine & "should press the key that EARNED a lemon last time." &
                    vbNewLine & "For the last practice, pressing '1' on a strawberry" &
                    vbNewLine & "was correct, and a lemon was INSIDE the box. So" &
                    vbNewLine & "for this trial, you should press '1'." &
                    vbNewLine & "Please press '1' now."

                InstrLbl.Refresh()

                AllowKeyTimer.Start()

            Case 2

                TopPic.BackgroundImage = My.Resources.ResourceManager.GetObject("papaya")
                TopPic.Image = blankBox

                BottomPic.BackgroundImage = My.Resources.ResourceManager.GetObject("pom")
                BottomPic.Image = My.Resources.ResourceManager.GetObject("xmark")


                InstrLbl.Text = "Now the 'X' is on the bottom, over a pomegranate." &
                    vbNewLine & "You will want to hit the button that earned a" &
                    vbNewLine & "papaya.  Let's say a '1' key press earned the" &
                    vbNewLine & "pomegranate, and a '2' earned a papaya. So, you" &
                    vbNewLine & "should press '2' to be correct. Please do so now."

                InstrLbl.Refresh()

                AllowKeyTimer.Start()

            Case Else
                'error
        End Select

        'increment slide state at key press

    End Sub

    Private Sub Blank()

        acceptKey = True
        TopPic.Visible = False
        BottomPic.Visible = False

        Select Case slideState
            Case 1

                InstrLbl.Text = "Again, after you make your choice, the screen" &
                    vbNewLine & "will go blank for about half a second. You" &
                    vbNewLine & "will NOT see feedback on whether you got it" &
                    vbNewLine & "correct or not. The next trial will begin" &
                    vbNewLine & "immediately after." &
                    vbNewLine & "For now, please press '8' to continue."

                InstrLbl.Refresh()

            Case 3

                InstrLbl.Text = "Please be aware that the 'X' can be on either" &
                    vbNewLine & "the top or the bottom. Also, the fruits can" &
                    vbNewLine & "be in either spot, so the top isn't always" &
                    vbNewLine & "a '2' key press and the bottom isn't always" &
                    vbNewLine & "a '1' press." &
                    vbNewLine & "Press '8' to continue."

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
            Case 4

                '---Final Form Before Going on to Experiment---'

                TopPic.Visible = False
                BottomPic.Visible = False

                'InstrLbl.Text = "Each trial starts with a closed box and a fruit" &
                InstrLbl.Text = "The experiment will begin after this slide. If" &
                    vbNewLine & "you have any questions, please ask them now. For" &
                    vbNewLine & "each trial, remember to press as quickly as you" &
                    vbNewLine & "can.  Each fruit will be valuable twice, for a" &
                    vbNewLine & "total of 12 trials. There is no feedback, and" &
                    vbNewLine & "your score won't be shown until the end." &
                    vbNewLine & "If you are ready, press '8' to start. If you" &
                    vbNewLine & "want to do the practice again, please press" &
                    vbNewLine & "'1' or '2'."

                InstrLbl.Refresh()

                AllowKeyTimer.Start()

            Case Else
                'error
        End Select

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

                    Case 2

                        slideState = slideState + 1
                        Blank()

                    Case 4
                        Dim resp As MsgBoxResult

                        resp = MsgBox("Are you sure you would like to restart practice?", MsgBoxStyle.YesNo, "Restart?")

                        If resp = MsgBoxResult.Yes Then
                            slideState = 0
                            Stim()
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

                    Case 2

                        MsgBox("For this trial, please press the '2' key.", MsgBoxStyle.OkOnly, "Wrong Press")
                        acceptKey = True

                    Case 4

                        Dim resp As MsgBoxResult

                        resp = MsgBox("Are you sure you would like to restart practice?", MsgBoxStyle.YesNo, "Restart?")

                        If resp = MsgBoxResult.Yes Then
                            slideState = 0
                            Stim()
                        End If


                    Case Else

                        acceptKey = True

                End Select

            End If

        ElseIf e.KeyChar = "8" Then

            If acceptKey = True Then

                acceptKey = False

                Select Case slideState
                    Case 1, 3

                        Stim()

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
