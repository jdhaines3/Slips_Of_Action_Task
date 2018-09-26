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

                TopPic.BackgroundImage = My.Resources.ResourceManager.GetObject("plum_2")
                TopPic.Image = My.Resources.ResourceManager.GetObject("xmark")

                BottomPic.BackgroundImage = My.Resources.ResourceManager.GetObject("lemon")
                BottomPic.Image = blankBox

                InstrLbl.Text = "The plum has a red 'X' over it. This means the" &
                    vbNewLine & "plum is not worth any points. So, you should" &
                    vbNewLine & "press the key that EARNED a lemon. Earlier," &
                    vbNewLine & "pressing '1' when you saw a strawberry was" &
                    vbNewLine & "correct, and a lemon was INSIDE the box. So" &
                    vbNewLine & "for this trial, you should press '1'."

                InstrLbl.Refresh()

                AllowKeyTimer.Start()

            Case 2

                TopPic.BackgroundImage = My.Resources.ResourceManager.GetObject("papaya")
                TopPic.Image = blankBox

                BottomPic.BackgroundImage = My.Resources.ResourceManager.GetObject("pom")
                BottomPic.Image = My.Resources.ResourceManager.GetObject("xmark")


                InstrLbl.Text = "Now the 'X' is on a pomegranate. You will" &
                    vbNewLine & "want to press the key that earned a papaya." &
                    vbNewLine & "Let's say a '1' key press earned the" &
                    vbNewLine & "pomegranite and a '2' earned a papaya. So," &
                    vbNewLine & "you should press '2' to earn points."

                InstrLbl.Refresh()

                AllowKeyTimer.Start()

            Case Else
                'error
        End Select

        'increment slide state at key press

    End Sub

    Private Sub Blank()

        acceptKey = False
        TopPic.Visible = False
        BottomPic.Visible = False

        Select Case slideState
            Case 1

                InstrLbl.Text = "After you make your choice, the screen will" &
                    vbNewLine & "go blank for about one-half second. You will" &
                    vbNewLine & "NOT see feedback during this phase. The" &
                    vbNewLine & "next trial will begin immediately after." &
                    vbNewLine & "For now, please press '8' to continue."

                InstrLbl.Refresh()

                AllowKeyTimer.Start()

            Case 3

                InstrLbl.Text = "The 'X' can be on either the top or the" &
                    vbNewLine & "bottom. The fruits can also be in either" &
                    vbNewLine & "spot, so the top isn't always a '2' key" &
                    vbNewLine & "press and the bottom isn't always a '1'." &
                    vbNewLine & "Press '8' to continue."

                InstrLbl.Refresh()

                AllowKeyTimer.Start()

            Case Else
                'error
        End Select

        'increments slide state in tick

    End Sub

    Private Sub afterBlank()

        acceptKey = False

        'increments slide state at keypress

        Select Case slideState
            Case 4

                '---Final Form Before Going on to Experiment---'

                TopPic.Visible = False
                BottomPic.Visible = False


                InstrLbl.Text = "Part 2 will begin after this slide. If you" &
                    vbNewLine & "have any questions, please ask now. For" &
                    vbNewLine & "each trial, remember to press as fast as" &
                    vbNewLine & "possible. There is no feedback, and your" &
                    vbNewLine & "score won't be shown until the end. To" &
                    vbNewLine & "practice again, please press '1' or '2'." &
                    vbNewLine & "If you are ready to begin Part 2, press" &
                    vbNewLine & "'8' to start."

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

    Private Sub OutDevPractice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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

                    Case 2

                        MsgBox("For this trial, please press the '2' key.", MsgBoxStyle.OkOnly, "Wrong Press")
                        acceptKey = True

                    Case 4

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
                    Case 1

                        slideState = slideState + 1
                        Stim()

                    Case 3

                        slideState = slideState + 1
                        afterBlank()

                    Case 4

                        Me.Hide()

                    Case Else

                        acceptKey = True

                End Select

            End If
            'if other key pressed, Do nothing
        End If


    End Sub


End Class
