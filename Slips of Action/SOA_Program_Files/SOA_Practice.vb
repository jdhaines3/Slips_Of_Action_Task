Imports System
Imports System.IO

Public Class SOA_Practice

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

    Private Sub PracSOA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        FruitPic.Visible = False
        LeftArr.Visible = False
        RightArr.Visible = False
        InstrLbl.Visible = False

        Stim()

    End Sub

    Private Sub Stim()

        allVisible()
        InstrLbl.Visible = True
        acceptKey = False

        Select Case slideState
            Case 0


                ChestPic.BackgroundImage = My.Resources.ResourceManager.GetObject("ClsChst")
                FruitPic.Image = My.Resources.ResourceManager.GetObject("razzleberry")
                FruitPic.BackgroundImage = blankBox

                InstrLbl.Text = "Each trial starts showing a box with fruit on the" &
                    vbNewLine & "outside. These fruits are the same ones from earlier." &
                    vbNewLine & "In Part 1 practice, a '2' press on a box with a" &
                    vbNewLine & "raspberry did not earn a reward. Now, please hit" &
                    vbNewLine & "the '1' key for a reward."

                InstrLbl.Size = New Size(640, 210)
                InstrLbl.Refresh()

                AllowKeyTimer.Start()

            Case 4

                ChestPic.BackgroundImage = My.Resources.ResourceManager.GetObject("ClsChst")
                FruitPic.Image = My.Resources.ResourceManager.GetObject("Strwbry")
                FruitPic.BackgroundImage = blankBox

                InstrLbl.Text = "If you remember from the Part 1 practice, a" &
                    vbNewLine & "strawberry's correct key press is '1'. The reward" &
                    vbNewLine & "inside is a lemon. Earlier though, we saw that lemon" &
                    vbNewLine & "is now worthless. Please press '1' anyway."

                InstrLbl.Refresh()

                AllowKeyTimer.Start()

            Case 8

                ChestPic.BackgroundImage = My.Resources.ResourceManager.GetObject("ClsChst")
                FruitPic.Image = My.Resources.ResourceManager.GetObject("Strwbry")
                FruitPic.BackgroundImage = blankBox

                InstrLbl.Text = "This time the strawberry appears, we will say you" &
                    vbNewLine & "remember that the reward INSIDE the chest is" &
                    vbNewLine & "worthless. Instead of pressing the '1' key, you" &
                    vbNewLine & "let the timer run out and don't press anything." &
                    vbNewLine & "Please wait."

                InstrLbl.Refresh()

                acceptKey = False

                LastTimer.Start()

            Case 12

                ChestPic.BackgroundImage = My.Resources.ResourceManager.GetObject("ClsChst")
                FruitPic.Image = My.Resources.ResourceManager.GetObject("kiwi")
                FruitPic.BackgroundImage = blankBox

                InstrLbl.Text = "Now, let's say a kiwi on the box has a reward" &
                    vbNewLine & "fruit of a coconut.  The coconut is valuable." &
                    vbNewLine & "For this trial, let's say that you don't press" &
                    vbNewLine & "a key in time, and let the timer run out." &
                    vbNewLine & "Please wait."

                InstrLbl.Refresh()

                acceptKey = False

                LastTimer.Start()


            Case Else
                'error
        End Select

        'increment slide state at key press

    End Sub

    Private Sub Blank()

        allHidden()

        Select Case slideState
            Case 1


                InstrLbl.Text = "Again, similar to other parts, there will be a quick" &
                    vbNewLine & "pause before feedback. The screen will go blank for" &
                    vbNewLine & "about half a second." &
                    vbNewLine & "For now, please press '8' to continue."

                InstrLbl.Refresh()
                acceptKey = True

            Case 3

                InstrLbl.Text = "After feedback, there is another short pause before" &
                    vbNewLine & "the next round starts. This pause will be about one" &
                    vbNewLine & "second." &
                    vbNewLine & "For now, please press '8' to continue."

                InstrLbl.Refresh()
                acceptKey = True

            Case 5, 9, 13

                InstrLbl.Text = "Again, there is a short pause before feedback." &
                    vbNewLine & "Please press '8' to continue."

                InstrLbl.Refresh()
                acceptKey = True

            Case 7, 11, 15

                InstrLbl.Text = "Again, there is a short pause after feedback." &
                    vbNewLine & "For now, press '8' to continue."

                InstrLbl.Refresh()
                acceptKey = True

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
                FruitPic.Image = My.Resources.ResourceManager.GetObject("papaya")
                FruitPic.BackgroundImage = blankBox

                fdbkVis()

                InstrLbl.Text = "The box is open and it holds a reward fruit - you" &
                    vbNewLine & "have earned a point. Remember, you will only have" &
                    vbNewLine & "about one second to answer, so respond quickly. This" &
                    vbNewLine & "feedback will show for about one second, then the" &
                    vbNewLine & "program moves to the next trial." &
                    vbNewLine & "For now, please press '8' to continue."

                AllowKeyTimer.Start()

            Case 4, 8, 12

                '---Second Stim---'

                Stim()

            Case 6

                '---Second Feedback---'

                ChestPic.BackgroundImage = My.Resources.ResourceManager.GetObject("OpnChst")
                FruitPic.BackgroundImage = My.Resources.ResourceManager.GetObject("lemon")
                FruitPic.Image = My.Resources.ResourceManager.GetObject("xmark")

                fdbkVis()

                InstrLbl.Text = "The box is open and it contains a worthless reward" &
                    vbNewLine & "fruit. While you pressed the correct key for" &
                    vbNewLine & "strawberry, the lemon inside is worthless. The 'X'" &
                    vbNewLine & "means that you have lost a point. Again, feedback" &
                    vbNewLine & "will show for only about one second before the" &
                    vbNewLine & "program moves to the next trial." &
                    vbNewLine & "For now, press '8' to continue."

                InstrLbl.Refresh()

                AllowKeyTimer.Start()

            Case 10


                ChestPic.BackgroundImage = My.Resources.ResourceManager.GetObject("OpnChst")
                FruitPic.BackgroundImage = blankBox
                FruitPic.Image = My.Resources.ResourceManager.GetObject("Checkmark")

                fdbkVis()

                InstrLbl.Text = "Since you waited and didn't press anything, the" &
                    vbNewLine & "open box has a checkmark. You earned a point for" &
                    vbNewLine & "avoiding the worthless reward fruit." &
                    vbNewLine & "To continue, press '8' now. "

                InstrLbl.Refresh()

                AllowKeyTimer.Start()

            Case 14

                ChestPic.BackgroundImage = My.Resources.ResourceManager.GetObject("OpnChst")
                FruitPic.BackgroundImage = blankBox
                FruitPic.Image = blankBox

                fdbkVis()

                InstrLbl.Text = "Because you didn't press a key in time for a box" &
                    vbNewLine & "with a valuable reward fruit, you earn no points" &
                    vbNewLine & "and the box is empty. The checkmark DOES NOT" &
                    vbNewLine & "appear, because the reward fruit was valuable." &
                    vbNewLine & "To continue, press '8' now. "

                InstrLbl.Refresh()

                AllowKeyTimer.Start()

            Case 16

                allHidden()

                InstrLbl.Text = "Part 4 will begin after this slide. If you have questions," &
                    vbNewLine & "please ask now. For each outside fruit, the correct press" &
                    vbNewLine & "and reward fruit are the same as Part 1! Try to answer as" &
                    vbNewLine & "fast as possible, before the timer runs out. Remember to" &
                    vbNewLine & "NOT press anything if the reward fruit inside is" &
                    vbNewLine & "worthless. To do the practice again, press '1' or '2'." &
                    vbNewLine & "If you are ready to start the task, press '8'."

                InstrLbl.Size = New Size(640, 250)
                InstrLbl.Refresh()

                AllowKeyTimer.Start()

            Case Else
                'error
        End Select

    End Sub

    Private Sub allVisible()

        ChestPic.Visible = True
        FruitPic.Visible = True
        LeftArr.Visible = True
        RightArr.Visible = True

    End Sub

    Private Sub fdbkVis()

        ChestPic.Visible = True
        FruitPic.Visible = True


    End Sub

    Private Sub allHidden()

        ChestPic.Visible = False
        FruitPic.Visible = False
        LeftArr.Visible = False
        RightArr.Visible = False

    End Sub

    Public Sub allowKey() Handles AllowKeyTimer.Tick

        AllowKeyTimer.Stop()

        acceptKey = True

    End Sub

    Public Sub lastTime() Handles LastTimer.Tick

        LastTimer.Stop()
        slideState = slideState + 1

        Blank()

    End Sub


    '======================================='
    '-----Key Press Functions (Step #2)-----'
    '======================================='

    Private Sub PracSOA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
                    Case 0, 4

                        MsgBox("For this trial, please press the '1' key.", MsgBoxStyle.OkOnly, "Wrong Press")
                        acceptKey = True

                    Case 16
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
                    Case 0, 4

                        slideState = slideState + 1
                        Blank()

                    Case 16

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
                    Case 2, 6, 10, 14

                        slideState = slideState + 1
                        Blank()

                    Case 1, 3, 5, 7, 9, 11, 13, 15

                        afterBlank()

                    Case 16

                        Me.Hide()

                    Case Else

                        acceptKey = True

                End Select

            End If
            'if other key pressed, Do nothing
        End If


    End Sub

    Private Sub allowKey(sender As Object, e As EventArgs) Handles AllowKeyTimer.Tick

    End Sub
End Class