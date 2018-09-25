Imports System
Imports System.IO

Public Class SOA_Devalued

    Dim devalNumOne As Integer
    Dim devalNumTwo As Integer

    'sets variables that take values from Main form; used in file output
    Dim cbx As String
    Dim subID As String

    'sets variables for text output of deval'd outcomes
    Dim orderPath As String
    Dim stimType As String

    '-----Form Load Function (what happens each time Showdialog is called for form)-----'

    Private Sub frmCongruent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        orderPath = "C:\x\" & subID & "\" & subID & cbx & "_StimOrder.txt"

        'turn on Key Preview for exiting if needed
        KeyPreview = True

        'get the random numbers for devalued outcomes from frmMain
        devalNumOne = frmMain.getD1()
        devalNumTwo = frmMain.getD2()


        'put a red x over the fruit picture to mark as devalued based on the random number
        'set stimType to whichever pic is devalued, write out line to StimOrder text
        Select Case devalNumOne
            Case 0

                CherryPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                stimType = "Deval-Cherry"
                textOutput()


            Case 1

                BananaPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                stimType = "Deval-Banana"
                textOutput()

            Case 2

                PineapplePic.Image = My.Resources.ResourceManager.GetObject("xmark")
                stimType = "Deval-Pineapple"
                textOutput()

            Case 3

                WatermelonPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                stimType = "Deval-Watermelon"
                textOutput()

            Case 4

                PearPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                stimType = "Deval-Pear"
                textOutput()

            Case 5

                OrangePic.Image = My.Resources.ResourceManager.GetObject("xmark")
                stimType = "Deval-Orange"
                textOutput()

            Case Else

                myMsgBox("ERROR! YOUR CODE SUCKS", MsgBoxStyle.OkOnly, "Program is broke AF.")

        End Select

        'same as with first deval number, but this time after setting x and outputting, start 10 second timer


        Select Case devalNumTwo
            Case 0

                CherryPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                stimType = "Deval-Cherry"
                textOutput()
                durTimer.Start()

            Case 1

                BananaPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                stimType = "Deval-Banana"
                textOutput()
                durTimer.Start()

            Case 2

                PineapplePic.Image = My.Resources.ResourceManager.GetObject("xmark")
                stimType = "Deval-Pineapple"
                textOutput()
                durTimer.Start()

            Case 3

                WatermelonPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                stimType = "Deval-Watermelon"
                textOutput()
                durTimer.Start()

            Case 4

                PearPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                stimType = "Deval-Pear"
                textOutput()
                durTimer.Start()

            Case 5

                OrangePic.Image = My.Resources.ResourceManager.GetObject("xmark")
                stimType = "Deval-Orange"
                textOutput()
                durTimer.Start()

            Case Else

                myMsgBox("ERROR! YOUR CODE SUCKS", MsgBoxStyle.OkOnly, "Program is broke AF.")
                durTimer.Start()

        End Select


    End Sub

    '-----FileStream Function-----'
    Private Sub textOutput()

        Dim fs As New FileStream(orderPath, FileMode.Append, FileAccess.Write)
        Dim sr As New StreamWriter(fs)
        sr.WriteLine(Now & "  " & stimType)
        sr.Close()
        fs.Close()

    End Sub
    Private Sub durTimer_Tick() Handles durTimer.Tick

        'stop/reset timer
        durTimer.Stop()

        'hide this form and go on to next statement in frmMain (A.K.A---next form is shown)
        Me.Hide()


    End Sub

    Private Sub SOA_Devalued_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim response As MsgBoxResult
        If e.KeyChar = "x" Then
            response = MsgBox("You are about to exit the program. Are you sure?", MsgBoxStyle.YesNo, "Quit Program?")
            If response = MsgBoxResult.Yes Then
                frmMain.Dispose()
                SOA_Stnd_Grape.Dispose()
                SOA_Stnd_Apple.Dispose()
                SOA_Cong_Ban.Dispose()
                SOA_Cong_Pear.Dispose()
                SOA_Incon_Orng.Dispose()
                SOA_Incon_Pine.Dispose()
                frmBlank.Dispose()
                frmThanks.Dispose()
                Me.Dispose()
                Application.Exit()
            Else
            End If
        End If
    End Sub

    Public Function myMsgBox(ByVal Prompt As Object, ByVal Buttons As MsgBoxStyle, ByVal Title As Object) As String

        Dim response As MsgBoxResult

        response = MsgBox(Prompt, Buttons, Title)

        If response = MsgBoxResult.Yes Then
            Return "YES"
        ElseIf response = MsgBoxResult.Ok Then
            Return "OK"
        ElseIf response = MsgBoxResult.No Then
            Return "NO"
        Else
            Return Nothing
        End If

    End Function

End Class