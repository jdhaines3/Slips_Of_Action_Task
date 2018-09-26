Imports System.IO
Imports System.Data
Imports Microsoft.VisualBasic


Public Class frmMain

    '==================================='
    '-----Declare frmMain variables-----'
    '==================================='


    '----Declaring instances of forms----'

    'instruction forms
    Public clsTaskInstr As New TaskInstr
    Public clsSOAInstr As New InstructionsSOA
    Public clsTrainingInstr As New TrainingInstr
    Public clsODInstr As New InstructionsOD
    Public clsQstnInstr As New QstnInstr

    'End of phase forms
    Public clsEndSOA As New EndSOA
    Public clsEndTrain As New EndTrain
    Public clsEndDeval As New EndDeval
    Public clsDevalued As New SOA_Devalued
    Public clsThanks As New frmThanks

    'Training phase form instances
    Public StndGrapeTrain As New TrainStndGrape
    Public StndAppleTrain As New TrainStndApple
    Public CongBanTrain As New TrainCongBana
    Public CongPearTrain As New TrainCongPear
    Public InconOrngTrain As New TrainInconOrng
    Public InconPineTrain As New TrainInconPine

    'Deval form instance and questions
    Public clsOutcome As New OutcomeDeval
    Public clsOutKnow As New OutKnow
    Public clsRespKnow As New RespKnow

    'SOA forms
    Public StndGrapeSOA As New SOA_Stnd_Grape
    Public StndAppleSOA As New SOA_Stnd_Apple
    Public CongBanSOA As New SOA_Cong_Ban
    Public CongPearSOA As New SOA_Cong_Pear
    Public InconOrngSOA As New SOA_Incon_Orng
    Public InconPineSOA As New SOA_Incon_Pine


    '-----Declaring Other Variables-----'

    'SOA variables to keep track of score and which stims are devalued in the SOA phase
    Private score As Integer
    Private devalOne As Integer
    Private devalTwo As Integer

    'Score variables for other two phases
    Private trainingScore As Integer
    Private devalScore As Integer

    'for detecting screen size
    Public ScrHeight As Integer
    Public ScrWidth As Integer

    'form two arrays, one holding instances of forms, one for indexes that point to the arraylist (done for SOA phase and for Training phase)
    'indexes used this way for shuffling easier; used for randomization of trials, array size = number of trials
    Private formArraySOA As New ArrayList()
    Private indxArraySOA(59) As Integer

    Private formArrayTrain As New ArrayList()
    Private indxArrayTrain(47) As Integer

    'clock
    Dim go As New System.Threading.Thread(AddressOf clock)

    'coordinates for main start window
    Private m_xStart As Integer
    Private m_yStart As Integer

    '==============================================================================================================='
    '-----Property Functions (getters and setters for private varibles so they can be retrieved on other forms)-----'
    '==============================================================================================================='

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

    'Used separate getters and setters for score and devalued stim variables, more explicit than properties

    '-----Get/Set for SOA Score-----'

    Public Function getScore() As Integer                       'Function is used for getters (functions return values)

        Return score

    End Function

    Public Sub setScore(ByVal value As Integer)                 'Sub used for setters (no value returned, value passed IN)

        score = value

    End Sub

    '-----Getter and Setter for DevalOne (first stim devalued in SOA)-----'

    Public Function getD1() As Integer

        Return devalOne

    End Function

    Public Sub setD1(ByVal value As Integer)

        devalOne = value

    End Sub

    '-----Getter and Setter for DevalTwo (second stim devalued in SOA)-----'

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

    '-----Get/Set for Outcome Devaluation Phase-----'

    Public Function getDevalScore() As Integer

        Return devalScore

    End Function

    Public Sub setDevalScore(ByVal value As Integer)

        devalScore = value

    End Sub

    '======================================'
    '-----Sets Window Size for frmMain-----'
    '======================================'

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

    '==================================='
    '-----Loads Main Form (Step #1)-----'
    '==================================='

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

    '==============================================================================================================================='
    '-----Submit Button Clicked Function (Step #2: Ensures all info entered into Main form and makes sure subj isn't duplicate)-----'
    '==============================================================================================================================='

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        'checks if any fields blank, if so, error message box
        If txtSubj.Text = "" Or cbxSess.SelectedItem = "" Or cbxTech.SelectedItem = "" Then
            myMsgBox("Please fill in all fields.", MsgBoxStyle.OkOnly, "ERROR")
        Else

            'if not, check to ensure directory exists
            If My.Computer.FileSystem.DirectoryExists("C:\x\") Then

                If My.Computer.FileSystem.DirectoryExists("C:\x\" & txtSubj.Text & "\") Then

                    'creates variables and pathways to check if file exists for any of the three start conditions
                    Dim subjPath, fullTaskPath, outDevalPath, SOA_TaskPath As String

                    subjPath = "C:\x\" & txtSubj.Text & "\" & txtSubj.Text & cbxSess.SelectedItem
                    fullTaskPath = subjPath & "_TrainOrder.txt"
                    outDevalPath = subjPath & "_DevalOrder.txt"
                    SOA_TaskPath = subjPath & "_StimOrder.txt"

                    If My.Computer.FileSystem.FileExists(fullTaskPath) Then

                        'if file does exist in pathway, ask subject if they want to append to file. If yes, run; If no, give msg box to rename or delete
                        Select Case myMsgBox("Files exist for this Subject and Session, would you like to append to them?", MsgBoxStyle.YesNo, "ERROR")
                            Case "YES"
                                runTask()
                            Case "NO"
                                myMsgBox("Then please delete previous files or rename current run.", MsgBoxStyle.OkOnly, "ERROR")
                        End Select

                    ElseIf My.Computer.FileSystem.FileExists(outDevalPath) Then

                        Select Case myMsgBox("Files exist for this Subject and Session, would you like to append to them?", MsgBoxStyle.YesNo, "ERROR")
                            Case "YES"
                                runTask()
                            Case "NO"
                                myMsgBox("Then please delete previous files or rename current run.", MsgBoxStyle.OkOnly, "ERROR")
                        End Select

                    ElseIf My.Computer.FileSystem.FileExists(SOA_TaskPath) Then

                        Select Case myMsgBox("Files exist for this Subject and Session, would you like to append to them?", MsgBoxStyle.YesNo, "ERROR")
                            Case "YES"
                                runTask()
                            Case "NO"
                                myMsgBox("Then please delete previous files or rename current run.", MsgBoxStyle.OkOnly, "ERROR")
                        End Select

                    Else

                        'if folder exists but no files, run 
                        runTask()

                    End If

                Else

                    'if directory doesn't exist: create, then run
                    My.Computer.FileSystem.CreateDirectory("C:\x\" & txtSubj.Text & "\")
                    runTask()

                End If

            Else
                'if x directory doesn't even exist, try creating directories on C drive, if fails, try E drive, then run
                'may make catch block give error... no error clause if E isnt writable either
                Try

                    My.Computer.FileSystem.CreateDirectory("C:\x\")
                    My.Computer.FileSystem.CreateDirectory("C:\x\" & txtSubj.Text & "\")
                    runTask()

                Catch ex As Exception

                    My.Computer.FileSystem.CreateDirectory("E:\x\")
                    My.Computer.FileSystem.CreateDirectory("E:\x\" & txtSubj.Text & "\")
                    runTask()

                End Try
            End If
        End If
    End Sub

    '==============================================================================================='
    '-----Task Start Function (Step #3: Begins task based on phase started on in frmMain entry)-----'
    '==============================================================================================='

    Private Sub runTask()

        'aborts clock timer
        go.Abort()

        'hides main and sets window 
        Me.Hide()
        setWin()

        'call fillArray and Shuffle functions (seen below), this fills the arrays for first and last phases and shuffles the stim order
        fillArrays()
        Shuffle()

        'assign deval'd stims for last phase and set score to 0 for all phases
        assignOutcomes()
        setScore(0)
        setTrainScore(0)
        setDevalScore(0)

        'Get the session type entered in frmMain
        Select Case cbxSess.SelectedItem

            'if session type is full task, will start with training
            Case "Full SOA Task"

                trainingPhase()

            'if session type is devalPhase (ex: after a computer/program restart in middle of experiment), then skip training phase and start on phase II
            Case "DevalPhase Restart"

                devalPhase()

            'same as above, but start on last phase
            Case "SlipOfActionPhase Restart"

                SlipsOfActionPhase()


            Case Else

                'msgbox for error handling or debugging
                myMsgBox("Error. Idk what happened, man", MsgBoxStyle.OkOnly, "Oh no.")

        End Select

        'since each phase calls the next phase, can start from any easily (wanted to ensure "checkpoints" in case of accidental restart)


        '---------------------'
        'Runs through forms until completion, can be force closed before completion by user.
        'if force closed, showdialog will still try to run even when application exits and all forms disposed...don't know why
        'so set the Run/showdialog statements in a try/catch block, so if exception pops up, just disposes of this form and quits cleanly
        '---------------------'

    End Sub

    '========================================================================='
    '-----Method for Filling ArrayList of forms and Index Array (Step #4)-----'
    '========================================================================='

    Private Sub fillArrays()

        'counter variable
        Dim ind, inx As Integer

        ind = 0
        inx = 0

        'add all forms to each array list
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

    '========================================================='
    '-----Method for Shuffling Array of indexes (Step #5)-----'
    '========================================================='

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

                'swap the numbers at array indexes 'index' and 'rndNum'
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

    '=================================================================='
    '-----Randomly Assign Devalued Outcomes for SOA task (Step #6)-----'
    '=================================================================='

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

    '========================================'
    '-----Start Training Phase (Step #7)-----'
    '========================================'

    Private Sub trainingPhase()

        Try

            'declare a loop count
            Dim trainCount As Integer

            'Show instructions first
            clsTaskInstr.ShowDialog(Me)
            clsTrainingInstr.ShowDialog(Me)

            'after instructions, loop through each trial
            For trainCount = 0 To 47

                'Declare a variable to put the number from indxArrayTraining at index of traincount into
                Dim objIndex As Integer

                objIndex = indxArrayTrain(trainCount)

                'show the form at index of objIndex in Training form arraylist; since indxArray randomized, will show specified random forms in order
                formArrayTrain(objIndex).ShowDialog(Me)

            Next

            'after trials, show thanks form then endTrain form with points
            clsThanks.ShowDialog(Me)
            clsEndTrain.ShowDialog(Me)

            'move to deval Phase
            devalPhase()

        Catch ex As Exception

            'close if fails
            cleanseEverything()

        End Try

    End Sub

    '========================================================'
    '-----Phase Two: Outcome Devaluation Start (Step #8)-----'
    '========================================================'

    Private Sub devalPhase()

        Try

            'show instructions, then outcomeDevaluation form, then thanks and points forms
            clsODInstr.ShowDialog(Me)
            clsOutcome.ShowDialog(Me)
            clsThanks.ShowDialog(Me)
            clsEndDeval.ShowDialog(Me)

            clsQstnInstr.ShowDialog(Me)
            clsRespKnow.ShowDialog(Me)
            clsOutKnow.ShowDialog(Me)
            clsThanks.ShowDialog(Me)

            'continue on to slips of action
            SlipsOfActionPhase()


        Catch ex As Exception

            cleanseEverything()

        End Try

    End Sub

    '====================================================='
    '-----Phase Three: Slips of Action Task (Step #9)-----'
    '====================================================='

    Private Sub SlipsOfActionPhase()

        Try

            'similar to training phase, show instructions/devalued stim, loop through trials, show thanks and points forms
            Dim formCount As Integer

            clsSOAInstr.ShowDialog(Me)
            clsDevalued.ShowDialog(Me)

            For formCount = 0 To 59

                Dim objIndex As Integer

                objIndex = indxArraySOA(formCount)
                formArraySOA(objIndex).ShowDialog(Me)

            Next

            clsThanks.ShowDialog(Me)
            clsEndSOA.ShowDialog(Me)


        Catch ex As Exception

            'if this fails, close
            cleanseEverything()

        End Try

    End Sub

    '==============================='
    '-----Message box functions-----'
    '==============================='

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

    '========================'
    '-----Clock function-----'
    '========================'

    Private Sub clock()
        CheckForIllegalCrossThreadCalls() = False
        Do
            Label2.Text = Now
            Threading.Thread.Sleep(1000)
        Loop
    End Sub

    '==========================================='
    '-----What to do on Cancel Button click-----'
    '==========================================='

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        cleanseEverything()

    End Sub

    '==================================================='
    '-----Exit Program Function (used by all forms)-----'
    '==================================================='

    Public Sub cleanseEverything()

        'beginning and end of run forms
        frmThanks.Dispose()
        EndSOA.Dispose()
        EndTrain.Dispose()
        EndDeval.Dispose()

        InstructionsSOA.Dispose()
        TrainingInstr.Dispose()
        InstructionsOD.Dispose()
        SOA_Devalued.Dispose()
        TaskInstr.Dispose()

        'Training Stim Forms
        TrainStndGrape.Dispose()
        TrainStndApple.Dispose()
        TrainCongBana.Dispose()
        TrainCongPear.Dispose()
        TrainInconOrng.Dispose()
        TrainInconPine.Dispose()

        'Deval form
        OutcomeDeval.Dispose()
        QstnInstr.Dispose()
        OutKnow.Dispose()
        RespKnow.Dispose()

        'SOA forms
        SOA_Stnd_Grape.Dispose()
        SOA_Stnd_Apple.Dispose()
        SOA_Cong_Ban.Dispose()
        SOA_Cong_Pear.Dispose()
        SOA_Incon_Orng.Dispose()
        SOA_Incon_Pine.Dispose()

        Me.Close()
        Application.Exit()

    End Sub
End Class
