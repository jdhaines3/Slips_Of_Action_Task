Imports System
Imports System.IO

Public Class SOA_Devalued

    '==========================='
    '-----Declare Variables-----'
    '==========================='

    'variable to get deval'd stim numbers from frmMain
    Dim devalNumOne As Integer
    Dim devalNumTwo As Integer

    'sets variables that take values from Main form; used in file output
    Dim cbx As String
    Dim subID As String

    'sets variables for text output of deval'd outcomes
    Dim orderPath As String
    Dim FirstDeval, SecondDeval As String

    '==================================================================================='
    '-----Form Load Function (what happens each time Showdialog is called for form)-----'
    '==================================================================================='

    Private Sub DevaluedSOA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        orderPath = "C:\x\" & subID & "\" & subID & cbx & "_SlipsDevalued.txt"

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
                FirstDeval = "Deval-Cherry"

            Case 1

                BananaPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                FirstDeval = "Deval-Banana"

            Case 2

                PineapplePic.Image = My.Resources.ResourceManager.GetObject("xmark")
                FirstDeval = "Deval-Pineapple"

            Case 3

                WatermelonPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                FirstDeval = "Deval-Watermelon"

            Case 4

                PearPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                FirstDeval = "Deval-Pear"

            Case 5

                OrangePic.Image = My.Resources.ResourceManager.GetObject("xmark")
                FirstDeval = "Deval-Orange"

            Case Else

                myMsgBox("ERROR! YOUR CODE SUCKS", MsgBoxStyle.OkOnly, "Program is broke AF.")

        End Select


        'same as with first deval number, but this time after setting x and outputting, start 10 second timer
        Select Case devalNumTwo
            Case 0

                CherryPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                SecondDeval = "Deval-Cherry"
                textOutput()
                durTimer.Start()

            Case 1

                BananaPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                SecondDeval = "Deval-Banana"
                textOutput()
                durTimer.Start()

            Case 2

                PineapplePic.Image = My.Resources.ResourceManager.GetObject("xmark")
                SecondDeval = "Deval-Pineapple"
                textOutput()
                durTimer.Start()

            Case 3

                WatermelonPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                SecondDeval = "Deval-Watermelon"
                textOutput()
                durTimer.Start()

            Case 4

                PearPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                SecondDeval = "Deval-Pear"
                textOutput()
                durTimer.Start()

            Case 5

                OrangePic.Image = My.Resources.ResourceManager.GetObject("xmark")
                SecondDeval = "Deval-Orange"
                textOutput()
                durTimer.Start()

            Case Else

                myMsgBox("ERROR! YOUR CODE SUCKS", MsgBoxStyle.OkOnly, "Program is broke AF.")
                durTimer.Start()

        End Select


    End Sub

    '========================================='
    '-----FileStream/Text Output Function-----'
    '========================================='

    Private Sub textOutput()

        Dim fs As New FileStream(orderPath, FileMode.Append, FileAccess.Write)
        Dim sr As New StreamWriter(fs)
        sr.WriteLine(FirstDeval & "," & SecondDeval)
        sr.Close()
        fs.Close()

    End Sub

    '======================================'
    '-----Slide Duration Timer Elapsed-----'
    '======================================'

    Private Sub durTimer_Tick() Handles durTimer.Tick

        'stop/reset timer
        durTimer.Stop()

        'hide this form and go on to next statement in frmMain (A.K.A---next form is shown)
        Me.Hide()


    End Sub

    '==========================='
    '-----KeyPress Function-----'
    '==========================='

    Private Sub SOA_Devalued_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim response As MsgBoxResult

        'if x pressed, exit program
        If e.KeyChar = "x" Then
            response = MsgBox("You are about to exit the Slips Of Action task. Are you sure?", MsgBoxStyle.YesNo, "Quit the Slips Of Action task?")
            If response = MsgBoxResult.Yes Then

                frmMain.cleanseEverything()

            Else
            End If
        End If
    End Sub

    '========================='
    '-----MsgBox Function-----'
    '========================='

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