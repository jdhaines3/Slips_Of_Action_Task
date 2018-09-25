Imports System.IO
Imports System.Data
Imports Microsoft.VisualBasic


Public Class frmMain


    'list instances of all forms

    'beginning and end of run forms
    Public clsThanks As New frmThanks
    Public clsEndSOA As New EndSOA
    Public clsEndTrain As New EndTrain
    Public clsSOAInstr As New InstructionsSOA
    Public clsTrainingInstr As New TrainingInstr
    Public clsDevalued As New SOA_Devalued


    'Training Stim Forms
    Public StndGrapeTrain As New TrainStndGrape
    Public StndAppleTrain As New TrainStndApple
    Public CongBanTrain As New TrainCongBana
    Public CongPearTrain As New TrainCongPear
    Public InconOrngTrain As New TrainInconOrng
    Public InconPineTrain As New TrainInconPine

    'SOA forms
    Public StndGrapeSOA As New SOA_Stnd_Grape
    Public StndAppleSOA As New SOA_Stnd_Apple
    Public CongBanSOA As New SOA_Cong_Ban
    Public CongPearSOA As New SOA_Cong_Pear
    Public InconOrngSOA As New SOA_Incon_Orng
    Public InconPineSOA As New SOA_Incon_Pine

    'Variable to keep track of points won by subject; which outcomes are devalued
    Private score As Integer
    Private devalOne As Integer
    Private devalTwo As Integer

    Private trainingScore As Integer

    'for detecting screen size
    Public ScrHeight As Integer
    Public ScrWidth As Integer

    'for two arrays, one holding instances of forms, one for indexes that point to the arraylist
    'indexes used this way for shuffling easier; used for randomization of trials, array size = number of trials
    Private formArraySOA As New ArrayList()
    Private indxArraySOA(60) As Integer

    Private formArrayTrain As New ArrayList()
    Private indxArrayTrain(48) As Integer

    'clock
    Dim go As New System.Threading.Thread(AddressOf clock)

    'coordinates for main start window
    Private m_xStart As Integer
    Private m_yStart As Integer

    'for where Main window starts
    Public Property xStart() As Integer
        Get
            Return m_xStart
        End Get
        Set(ByVal value As Integer)
            m_xStart = value
        End Set
    End Property

    Public Property yStart() As Integer
        Get
            Return m_yStart
        End Get
        Set(ByVal value As Integer)
            m_yStart = value
        End Set
    End Property

    '-----Getter and Setter for score-----'
    'could use Property, but honestly having getter and setter in one function is wierd to me
    Public Function getScore() As Integer

        Return score

    End Function

    Public Sub setScore(ByVal value As Integer)

        score = value

    End Sub

    '-----Getter and Setter for DevalOne-----'

    Public Function getD1() As Integer

        Return devalOne

    End Function

    Public Sub setD1(ByVal value As Integer)

        devalOne = value

    End Sub

    '-----Getter and Setter for DevalTwo-----'

    Public Function getD2() As Integer

        Return devalTwo

    End Function

    Public Sub setD2(ByVal value As Integer)

        devalTwo = value

    End Sub

    '-----Getter and Setter for Training Score-----'
    Public Function getTrainScore() As Integer

        Return trainingScore

    End Function

    Public Sub setTrainScore(ByVal value As Integer)

        trainingScore = value

    End Sub


    'sets window size

    Public Sub setWin()

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
        'end set screen

    End Sub


    'loads the form
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        go.Priority = Threading.ThreadPriority.Lowest
        'find screen resolution
        'variables to use ScrHeight ScrWidth
        Dim myScreens() As Screen = Screen.AllScreens
        If (myScreens.Length = 2) Then
            ScrHeight = myScreens(1).WorkingArea.Height
            ScrWidth = myScreens(1).WorkingArea.Width
        Else

            ScrHeight = Screen.PrimaryScreen.WorkingArea.Height
            ScrWidth = Screen.PrimaryScreen.WorkingArea.Width
        End If

        yStart = (ScrHeight / 2) - 15
        xStart = ((ScrWidth - 533) / 2) - 2
        go.Start()
    End Sub

    'this happens when submit button is clicked
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        'checks if any fields blank, if so, error message box
        If txtSubj.Text = "" Or cbxSess.SelectedItem = "" Or cbxTech.SelectedItem = "" Then
            myMsgBox("Please fill in all fields.", MsgBoxStyle.OkOnly, "ERROR")
        Else
            'if not, check to ensure directory exists
            If My.Computer.FileSystem.DirectoryExists("C:\x\") Then

                If My.Computer.FileSystem.DirectoryExists("C:\x\" & txtSubj.Text & "\") Then

                    'if subject folder does exist and has files in it for that session, check if want to overwrite
                    If My.Computer.FileSystem.FileExists("C:\x\" & txtSubj.Text & "\" & txtSubj.Text & cbxSess.SelectedItem & "_StndGrapeSOA.txt") Then

                        Select Case myMsgBox("Files exist for this Subject and Session, would you like to append to them?", MsgBoxStyle.YesNo, "ERROR")
                            Case "YES"
                                Squizzer()
                            Case "NO"
                                myMsgBox("Then please delete previous files or rename current run.", MsgBoxStyle.OkOnly, "ERROR")
                        End Select
                        'if folder exists but no files, run 
                    Else
                        Squizzer()
                    End If

                Else

                    'if directory doesn't exist, create then run
                    My.Computer.FileSystem.CreateDirectory("C:\x\" & txtSubj.Text & "\")
                    Squizzer()

                End If

            Else
                'if x directory doesn't even exist, try creating directories on C drive, if fails, try E drive, then run
                'may make catch block give error... no error clause if E isnt writable either
                Try

                    My.Computer.FileSystem.CreateDirectory("C:\x\")
                    My.Computer.FileSystem.CreateDirectory("C:\x\" & txtSubj.Text & "\")
                    Squizzer()

                Catch ex As Exception

                    My.Computer.FileSystem.CreateDirectory("E:\x\")
                    My.Computer.FileSystem.CreateDirectory("E:\x\" & txtSubj.Text & "\")
                    Squizzer()

                End Try
            End If
        End If
    End Sub

    'Message box functions
    Public Shared Function myMsgBox(ByVal Prompt As Object, ByVal Buttons As MsgBoxStyle, ByVal Title As Object) As String

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
    '-----Method for Filling ArrayList of forms and Index Array-----'

    Private Sub fillArrays()

        'counter variable
        Dim ind, inx As Integer

        ind = 0
        inx = 0

        'add all forms to array list
        formArraySOA.Add(CongBanSOA)
        formArraySOA.Add(CongPearSOA)
        formArraySOA.Add(InconOrngSOA)
        formArraySOA.Add(InconPineSOA)
        formArraySOA.Add(StndGrapeSOA)
        formArraySOA.Add(StndAppleSOA)

        formArrayTrain.Add(CongBanTrain)
        formArrayTrain.Add(CongPearTrain)
        formArrayTrain.Add(InconOrngTrain)
        formArrayTrain.Add(InconPineTrain)
        formArrayTrain.Add(StndGrapeTrain)
        formArrayTrain.Add(StndAppleTrain)

        'add numbers to index array
        For ind = 0 To 59

            'based on counter number, add specific integer to index array at position 'ind' that references index of formArraySOA
            Select Case ind

                'so in indxArraySOA spots 0 through 9, will contain 0's in each spot; indxArraySOA positions 10 through 19 have 1's in each spot, etc
                'can changes cases to have more or less of specific form occurences
                'say, if you want more of Congruent1 form, make first case through 15 or 20 (since Congruent1 is index '0' as seen in Add statements above

                Case 0 To 9
                    indxArraySOA(ind) = 0
                Case 10 To 19
                    indxArraySOA(ind) = 1
                Case 20 To 29
                    indxArraySOA(ind) = 2
                Case 30 To 39
                    indxArraySOA(ind) = 3
                Case 40 To 49
                    indxArraySOA(ind) = 4
                Case 50 To 59
                    indxArraySOA(ind) = 5
                Case Else
                    'error handling
                    myMsgBox("YOUR STUPID FILL ARRAYS DONT WORK RIGHT", MsgBoxStyle.OkOnly, "YOU DONE FUCKED UP")

            End Select

        Next

        For inx = 0 To 47

            'based on counter number, add specific integer to index array at position 'ind' that references index of formArraySOA
            Select Case inx

                'so in indxArraySOA spots 0 through 9, will contain 0's in each spot; indxArraySOA positions 10 through 19 have 1's in each spot, etc
                'can changes cases to have more or less of specific form occurences
                'say, if you want more of Congruent1 form, make first case through 15 or 20 (since Congruent1 is index '0' as seen in Add statements above

                Case 0 To 7
                    indxArrayTrain(inx) = 0
                Case 8 To 15
                    indxArrayTrain(inx) = 1
                Case 16 To 23
                    indxArrayTrain(inx) = 2
                Case 24 To 31
                    indxArrayTrain(inx) = 3
                Case 32 To 39
                    indxArrayTrain(inx) = 4
                Case 40 To 47
                    indxArrayTrain(inx) = 5
                Case Else
                    'error handling
                    myMsgBox("YOUR STUPID FILL ARRAYS DONT WORK RIGHT", MsgBoxStyle.OkOnly, "YOU DONE FUCKED UP")

            End Select

        Next

    End Sub

    '-----Method for Shuffling Array of indexes-----'
    Private Sub Shuffle()

        'need for loop counter variable, random number variable and temp variable
        'temp holds swapped int
        Dim count, index, rndNum, temp, i, tmp, rdNum As Integer

        'call new random seeder class
        Dim rndm As Random = New Random()

        'for each index in indxArraySOA, choose random number between 0 and 59, take the indxArraySOA integer at rndNum index and swap with indxArraySOA at current counter index
        'Goes through shuffle 3 times for more randomization
        For count = 0 To 2

            For index = 0 To 59

                rndNum = rndm.Next(0, 60)


                While rndNum = index

                    'If rndNum is equal to index, then the number at index will be 'swapped' with itself (aka no swap)
                    'We want to 're-roll' rndm in order to actually have it swap with a different place
                    rndNum = rndm.Next(0, 60)

                End While

                temp = indxArraySOA(rndNum)
                indxArraySOA(rndNum) = indxArraySOA(index)
                indxArraySOA(index) = temp

            Next

            For i = 0 To 47

                rdNum = rndm.Next(0, 48)

                While rdNum = i

                    rdNum = rndm.Next(0, 48)

                End While

                tmp = indxArrayTrain(rdNum)
                indxArrayTrain(rdNum) = indxArrayTrain(i)
                indxArrayTrain(i) = tmp

            Next
        Next

    End Sub

    '-----Randomly Assign Devalued Outcomes for SOA task-----'

    Private Sub assignOutcomes()

        'starts random number generator, and two number variables
        Dim randm As Random = New Random()
        Dim devOut1, devOut2 As Integer

        'gets random number between 0 and 5 (6 diff stim types)
        devOut1 = randm.Next(0, 6)
        devOut2 = randm.Next(0, 6)

        'if equal, get new random number for devOut2
        'could do in a DO WHILE loop, I suppose /shrug
        While devOut1 = devOut2

            devOut2 = randm.Next(0, 6)

        End While

        'set the global variables to two random numbers to be used later
        Me.setD1(devOut1)
        Me.setD2(devOut2)

    End Sub


    '------------------------------------'
    '-----SQUIZZER RUN/MAIN FUNCTION-----'
    '------------------------------------'

    Private Sub Squizzer()
        go.Abort()
        'hides main and sets window 
        Me.Hide()
        setWin()

        'fill array function called, then shuffle indexArray
        fillArrays()
        Shuffle()

        'assign deval'd outcomes and set score to 0
        assignOutcomes()
        setScore(0)
        setTrainScore(0)

        'for loop counter
        Dim formCount As Integer
        Dim trainCount As Integer

        '---------------------'
        'Runs through forms until completion, can be force closed before completion by user.
        'if force closed, showdialog will still try to run even when application exits and all forms disposed...don't know why
        'so set the Run/showdialog statements in a try/catch block, so if exception pops up, just disposes of this form and quits cleanly
        '---------------------'
        Try

            clsTrainingInstr.ShowDialog(Me)

            For trainCount = 0 To 47

                Dim objIndex As Integer

                objIndex = indxArrayTrain(trainCount)
                formArrayTrain(objIndex).ShowDialog(Me)

            Next

            clsThanks.ShowDialog(Me)
            clsEndTrain.ShowDialog(Me)


            clsSOAInstr.ShowDialog(Me)
            clsDevalued.ShowDialog(Me)

            For formCount = 0 To 59

                'set variable that collects the number in indxArraySOA, not needed, just looks cleaner to me
                Dim objIndex As Integer

                objIndex = indxArraySOA(formCount)
                formArraySOA(objIndex).ShowDialog(Me)

            Next

            clsThanks.ShowDialog(Me)
            clsEndSOA.ShowDialog(Me)


        Catch ex As Exception

            Me.Close()
            Application.Exit()

        End Try

    End Sub

    Private Sub clock()
        CheckForIllegalCrossThreadCalls() = False
        Do
            Label2.Text = Now
            Threading.Thread.Sleep(1000)
        Loop
    End Sub

    'if cancel, close
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        EndSOA.Dispose()
        SOA_Stnd_Grape.Dispose()
        SOA_Stnd_Apple.Dispose()
        SOA_Cong_Ban.Dispose()
        SOA_Cong_Pear.Dispose()
        SOA_Incon_Orng.Dispose()
        SOA_Incon_Pine.Dispose()
        frmThanks.Dispose()
        Me.Dispose()
        Application.Exit()
    End Sub

End Class
