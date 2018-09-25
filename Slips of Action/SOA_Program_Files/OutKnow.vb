Imports System
Imports System.IO
Imports System.Windows.Forms.Form

Public Class OutKnow

    Dim stimList As New List(Of Bitmap)
    Dim indxArray() As Integer = {0, 1, 2, 3, 4, 5}
    Dim stimIndx As Integer

    Dim grape, banana, orange, pineapple, pear, apple As Bitmap

    Dim cbx As String
    Dim subID As String

    Dim stimType As String
    Dim resp As Integer
    Dim respPath, orderPath, correctPath As String




    Private Sub OutKnow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        'Set cbx/subID to variables entered from Main
        cbx = frmMain.cbxSess.SelectedItem
        subID = frmMain.txtSubj.Text

        'set pathways to the three different text ouput files
        orderPath = "C:\x\" & subID & "\" & subID & cbx & "_OutKnowOrder.txt"
        respPath = "C:\x\" & subID & "\" & subID & cbx & "_OutKnowResp.txt"
        correctPath = "C:\x\" & subID & "\" & subID & cbx & "_OutKnowCorrect.txt"


        grape = My.Resources.ResourceManager.GetObject("grapes")
        banana = My.Resources.ResourceManager.GetObject("Banana")
        pineapple = My.Resources.ResourceManager.GetObject("pineapple")
        apple = My.Resources.ResourceManager.GetObject("apple")
        pear = My.Resources.ResourceManager.GetObject("pear2")
        orange = My.Resources.ResourceManager.GetObject("orange")

        stimList.Add(grape)
        stimList.Add(banana)
        stimList.Add(orange)
        stimList.Add(pineapple)
        stimList.Add(pear)
        stimList.Add(apple)

        stimIndx = 0

        randomizeArrays()

        KeyPreview = False

        runTask()

    End Sub

    Public Sub randomizeArrays()

        Dim loopCount, indx, temp, rndNum As Integer

        Dim rndm As Random = New Random()

        For loopCount = 0 To 2

            For indx = 0 To 5

                rndNum = rndm.Next(0, 6)

                While rndNum = indx

                    rndNum = rndm.Next(0, 6)

                End While

                temp = indxArray(rndNum)
                indxArray(rndNum) = indxArray(indx)
                indxArray(indx) = temp

            Next

        Next

    End Sub

    Public Sub runTask()

        Dim ind As Integer

        ind = indxArray(stimIndx)

        StimBox.Image = stimList(ind)

        Select Case ind
            Case 0
                stimType = "StandardGrapes"
            Case 1
                stimType = "CongruentBanana"
            Case 2
                stimType = "IncongruentOrange"
            Case 3
                stimType = "IncongruentPineapple"
            Case 4
                stimType = "CongruentPear"
            Case 5
                stimType = "StandardApple"
            Case Else
                MsgBox("Uh-oh. Someone goofed.", MsgBoxStyle.OkOnly, "Error")
        End Select

        makeVisible()

    End Sub

    Public Sub makeVisible()

        trkBar.Visible = True

        Label1.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        Label4.Visible = True
        Label5.Visible = True
        Label6.Visible = True
        Label11.Visible = True

        LabelB.Visible = True
        LabelC.Visible = True
        LabelD.Visible = True
        LabelE.Visible = True
        LabelF.Visible = True
        LabelG.Visible = True

        lblQstn.Visible = True
        StimBox.Visible = True

        KeyPreview = True

    End Sub

    Public Sub makeInvisible()

        trkBar.Visible = False

        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label11.Visible = False

        LabelB.Visible = False
        LabelC.Visible = False
        LabelD.Visible = False
        LabelE.Visible = False
        LabelF.Visible = False
        LabelG.Visible = False

        lblQstn.Visible = False
        StimBox.Visible = False

    End Sub
    Private Sub OutKnow_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim response As MsgBoxResult
        If e.KeyChar = "x" Then
            response = MsgBox("You are about to exit sQuizzer. Are you sure?", MsgBoxStyle.YesNo, "Quit sQuizzer?")
            If response = MsgBoxResult.Yes Then

                frmMain.cleanseEverything()

            Else
            End If

        ElseIf e.KeyChar = "2" Then

            Select Case trkBar.Value

                Case Is > 5
                    trkBar.Value = 6
                Case Else
                    trkBar.Value = trkBar.Value + 1

            End Select


        ElseIf e.KeyChar = "1" Then

            Select Case trkBar.Value

                Case Is < 1
                    trkBar.Value = 0
                Case Else
                    trkBar.Value = trkBar.Value - 1

            End Select

        ElseIf e.KeyChar = "8" Then

            If trkBar.Value = 0 Then

                MsgBox("Please choose a fruit.", MsgBoxStyle.OkOnly, "Invalid Entry")

            Else

                makeInvisible()

                textOutput()

                ITItimer.Start()

            End If

        End If

    End Sub

    Private Sub ITItimer_Tick() Handles ITItimer.Tick

        'if the index is less than 11 (last index in array, trial number - 1), continue
        If stimIndx < 5 Then

            'stop timer
            ITItimer.Stop()

            'increment outcome and box index for next run
            stimIndx = stimIndx + 1

            trkBar.Value = 0

            'start over again
            runTask()

        Else

            ITItimer.Stop()

            'if last trial, hide form and go to text one
            Me.Hide()

        End If

    End Sub

    Private Sub textOutput()

        Dim output As String

        Select Case trkBar.Value

            Case 1

                If indxArray(stimIndx) = 1 Then
                    resp = 1
                Else
                    resp = 0
                End If

                output = "Banana"

            Case 2

                If indxArray(stimIndx) = 0 Then
                    resp = 1
                Else
                    resp = 0
                End If

                output = "Cherry"

            Case 3

                If indxArray(stimIndx) = 3 Then
                    resp = 1
                Else
                    resp = 0
                End If

                output = "Orange"

            Case 4

                If indxArray(stimIndx) = 4 Then
                    resp = 1
                Else
                    resp = 0
                End If

                output = "Pear"

            Case 5

                If indxArray(stimIndx) = 2 Then
                    resp = 1
                Else
                    resp = 0
                End If

                output = "Pineapple"

            Case 6

                If indxArray(stimIndx) = 5 Then
                    resp = 1
                Else
                    resp = 0
                End If

                output = "Watermelon"

            Case Else
                resp = 100
                output = "ERROR"

        End Select

        Dim fs As New FileStream(orderPath, FileMode.Append, FileAccess.Write)
        Dim sr As New StreamWriter(fs)
        sr.WriteLine(Now & "  " & stimType)
        sr.Close()
        fs.Close()

        'response text file
        Dim fs2 As New FileStream(respPath, FileMode.Append, FileAccess.Write)
        Dim sr2 As New StreamWriter(fs2)
        sr2.WriteLine(Now & "  " & output)
        sr2.Close()
        fs2.Close()

        'valued stim order text file
        Dim fs3 As New FileStream(correctPath, FileMode.Append, FileAccess.Write)
        Dim sr3 As New StreamWriter(fs3)
        sr3.WriteLine(Now & "  " & resp)
        sr3.Close()
        fs3.Close()

    End Sub

End Class