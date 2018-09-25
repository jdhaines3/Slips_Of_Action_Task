Imports System
Imports System.IO

Public Class OutcomeDeval

    '=========TO DO========='

    'it is currently spitting out DEVALUED image, may need it to spit out valued image too
    'correct and incorrect button presses might be backwards. might be "correct" if pressing the opposite direction
    'comment what all this shit does
    'make a points screen at end





    '-----Dim variables-----'

    'score for outcome deval portion
    Dim points, resp As Integer

    'global variable for loop index (needed for key press)
    Dim outcomeIndx, boxIndx, rightIndx, leftIndx As Integer

    'arrays for dynamically changing the pictures
    Dim boxArray() As Integer = {1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2}
    Dim outcmArray() As Integer = {0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5}
    Dim outcomeList As New List(Of Bitmap)
    Dim rightArray() As Integer = {0, 0, 1, 1, 2, 2}
    Dim leftArray() As Integer = {3, 3, 4, 4, 5, 5}

    'for foreground image (to see background)
    Dim blankBox As New Bitmap(1, 1)

    'dim picture variables
    Dim cherry, banana, pineapple, melon, pear, orange As Bitmap

    'sets variables that take values from Main form; used in file output
    Dim cbx As String
    Dim subID As String

    'sets variables for text output of deval'd outcomes
    Dim orderPath As String
    Dim respPath As String
    Dim devalType As String



    'stopwatch and points


    '-----Form Load Function (what happens each time Showdialog is called for form)-----'

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

        ' Set the form location so it appears at Location (100, 100) on the screen 1
        Me.Location = screen.Bounds.Location + New Point(0, 0)


        'Set pathway to read/write to file
        cbx = frmMain.cbxSess.SelectedItem
        subID = frmMain.txtSubj.Text
        orderPath = "C:\x\" & subID & "\" & subID & cbx & "_DevalOrder.txt"
        respPath = "C:\x\" & subID & "\" & subID & cbx & "_DevalResp.txt"

        'turn on Key Preview for exiting if needed
        KeyPreview = False


        'TO DO: add these to array
        cherry = My.Resources.ResourceManager.GetObject("cherries")
        banana = My.Resources.ResourceManager.GetObject("Banana")
        pineapple = My.Resources.ResourceManager.GetObject("pineapple")
        melon = My.Resources.ResourceManager.GetObject("halfWMelon")
        pear = My.Resources.ResourceManager.GetObject("pear2")
        orange = My.Resources.ResourceManager.GetObject("orange")

        outcomeList.Add(cherry)
        outcomeList.Add(banana)
        outcomeList.Add(pineapple)
        outcomeList.Add(melon)
        outcomeList.Add(pear)
        outcomeList.Add(orange)

        randomizeArrays()

        runTask()

    End Sub

    '-----FileStream Function-----'
    Private Sub textOutput()

        Dim fs As New FileStream(orderPath, FileMode.Append, FileAccess.Write)
        Dim sr As New StreamWriter(fs)
        sr.WriteLine(Now & "  " & devalType)
        sr.Close()
        fs.Close()

        Dim fs2 As New FileStream(respPath, FileMode.Append, FileAccess.Write)
        Dim sr2 As New StreamWriter(fs2)
        sr2.WriteLine(Now & "  " & resp)
        sr2.Close()
        fs2.Close()

    End Sub
    Private Sub durTimer_Tick() Handles durTimer.Tick

        If outcomeIndx < 11 Then

            durTimer.Stop()

            outcomeIndx = outcomeIndx + 1
            boxIndx = boxIndx + 1
            runTask()

        Else

            Me.Hide()

        End If

        'Else Hide


    End Sub

    Private Sub OutcomeDeval_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
                EndSOA.Dispose()
                frmThanks.Dispose()
                Me.Dispose()
                Application.Exit()
            Else
            End If

        ElseIf e.KeyChar = "1" Then

            Select Case outcmArray(outcomeIndx)
                Case 0 To 2
                    'incorrect
                    incorrectPress()
                Case 3 To 5
                    'correct
                    correctPress()
                Case Else
                    'msgbox error
            End Select

        ElseIf e.KeyChar = "2" Then

            Select Case outcmArray(outcomeIndx)
                Case 0 To 2
                    'correct
                    correctPress()
                Case 3 To 5
                    'incorrect
                    incorrectPress()
                Case Else
                    'msgbox error
            End Select

        Else
            'do nothing
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

    Private Sub runTask()

        Dim boxNum, outNum, rightLeft As Integer

        boxNum = boxArray(outcomeIndx)
        outNum = outcmArray(outcomeIndx)

        If outNum <= 2 AndAlso outNum >= 0 Then

            rightLeft = leftArray(leftIndx)

            Select Case boxNum
                Case 1

                    TopPic.BackgroundImage = outcomeList(outNum)
                    TopPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                    TopPic.Visible = True

                    BottomPic.BackgroundImage = outcomeList(rightLeft)
                    BottomPic.Image = blankBox
                    BottomPic.Visible = True

                    leftIndx = leftIndx + 1
                Case 2

                    BottomPic.BackgroundImage = outcomeList(outNum)
                    BottomPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                    BottomPic.Visible = True

                    TopPic.BackgroundImage = outcomeList(rightLeft)
                    TopPic.Image = blankBox
                    TopPic.Visible = True

                    'leftIndx++
                    leftIndx = leftIndx + 1

                Case Else
                    'msgbox error
            End Select

        ElseIf outNum >= 3 AndAlso outNum <= 5 Then

            rightLeft = rightArray(rightIndx)

            Select Case boxNum
                Case 1

                    TopPic.BackgroundImage = outcomeList(outNum)
                    TopPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                    TopPic.Visible = True

                    BottomPic.BackgroundImage = outcomeList(rightLeft)
                    BottomPic.Image = blankBox
                    BottomPic.Visible = True

                    'rightIndx++
                    rightIndx = rightIndx + 1
                Case 2

                    BottomPic.BackgroundImage = outcomeList(outNum)
                    BottomPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                    BottomPic.Visible = True

                    TopPic.BackgroundImage = outcomeList(rightLeft)
                    TopPic.Image = blankBox
                    TopPic.Visible = True

                    rightIndx = rightIndx + 1
                Case Else
                    'msgbox error
            End Select

        Else

            'msgbox error

        End If

        KeyPreview = True

    End Sub


    Private Sub randomizeArrays()

        Dim indx, tempBox, tempOut, rdNumBox, rdNumOut, loopCount As Integer
        Dim tmpRight, tmpLeft, ind, rndRight, rndLeft As Integer

        Dim rndm As Random = New Random()

        For loopCount = 0 To 2

            For indx = 0 To 11

                rdNumBox = rndm.Next(0, 11)
                rdNumOut = rndm.Next(0, 11)

                While rdNumBox = indx

                    rdNumBox = rndm.Next(0, 11)

                End While

                While rdNumOut = indx

                    rdNumOut = rndm.Next(0, 11)

                End While

                tempBox = boxArray(rdNumBox)
                boxArray(rdNumBox) = boxArray(indx)
                boxArray(indx) = tempBox

                tempOut = outcmArray(rdNumOut)
                outcmArray(rdNumOut) = outcmArray(indx)
                outcmArray(indx) = tempOut

            Next

            For ind = 0 To 5

                rndRight = rndm.Next(0, 6)
                rndLeft = rndm.Next(0, 6)

                While rndRight = ind

                    rndRight = rndm.Next(0, 6)

                End While

                While rndLeft = ind

                    rndLeft = rndm.Next(0, 6)

                End While

                tmpRight = rightArray(rndRight)
                rightArray(rndRight) = rightArray(ind)
                rightArray(ind) = tmpRight

                tmpLeft = leftArray(rndLeft)
                leftArray(rndLeft) = leftArray(ind)
                leftArray(ind) = tmpLeft

            Next

        Next
    End Sub


    'add correct sub
    Public Sub correctPress()

        KeyPreview = False

        resp = 1
        points = points + 5

        TopPic.Visible = False
        BottomPic.Visible = False

        outcomeString()
        textOutput()
        durTimer.Start()

    End Sub
    'incorrect sub

    Public Sub incorrectPress()

        KeyPreview = False
        resp = 0

        TopPic.Visible = False
        BottomPic.Visible = False

        outcomeString()
        textOutput()
        durTimer.Start()

    End Sub

    Public Sub outcomeString()

        Select Case outcmArray(outcomeIndx)
            Case 0
                devalType = "cherry"
            Case 1
                devalType = "banana"
            Case 2
                devalType = "pineapple"
            Case 3
                devalType = "melon"
            Case 4
                devalType = "pear"
            Case 5
                devalType = "orange"
            Case Else
                devalType = "error"

        End Select
    End Sub
End Class

