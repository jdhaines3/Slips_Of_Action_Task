Imports System.IO
Imports System.Data
Imports Microsoft.VisualBasic

'==================================='
'This task was designed by Gillan et al in their paper: Disruption in the Balance Between Goal-Directed Behavior and Habit Learning in Obsessive Compulsive Disorder

'The code/program was designed, coded, tested, and everything else by DAVID HAINES for the NSL and IU School of Medicine Dept of Psych
'Changes from original task design also implemented by DAVID HAINES, and thought out by David Haines, Martin Plawecki, and Dr. Melissa Cyders
'What I am saying is that I did a metric butt ton of work on this.

'If you have any questions, ask David if he is around.
'If not, figure it out.

'==================================='


Public Class frmMain

    '==================================='
    '-----Declare frmMain variables-----'
    '==================================='

    'TO CHANGE BLOCK NUMBER, OPEN -----GlobVars.vb-----  And change each. MUST BE DIVISIBLE BY 6, ELSE CODE FUCKS UP

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

    'block forms
    Public BlckEndTrain As New EndBlockTrain
    Public BlckEndSOA As New EndBlockSOA

    'Training phase form instances
    Public clsTrainPractice As New TrainPractice
    Public StndGrapeTrain As New TrainStndGrape
    Public StndAppleTrain As New TrainStndApple
    Public CongBanTrain As New TrainCongBana
    Public CongPearTrain As New TrainCongPear
    Public InconOrngTrain As New TrainInconOrng
    Public InconPineTrain As New TrainInconPine

    'Deval form instance and questions
    Public clsODpractice As New OutDevPractice
    Public clsOutcome As New OutcomeDeval
    Public clsOutKnow As New OutKnow
    Public clsRespKnow As New RespKnow

    'SOA forms
    Public DevPracSOA As New SOA_Practice_Devald
    Public PracSOA As New SOA_Practice
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
    Private indxArraySOA(GlobVars.SlipsTrialNum - 1) As Integer

    Private formArrayTrain As New ArrayList()
    Private indxArrayTrain(GlobVars.TrainTrialNum - 1) As Integer

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
                    Dim subjPath, fullTaskPath, outDevalPath, qstnPath, SOA_TaskPath As String

                    subjPath = "C:\x\" & txtSubj.Text & "\" & txtSubj.Text & cbxSess.SelectedItem
                    fullTaskPath = subjPath & "_TrainOrder.txt"
                    outDevalPath = subjPath & "_DevalOrder.txt"
                    SOA_TaskPath = subjPath & "_StimOrder.txt"
                    qstnPath = subjPath & "_RespKnow.txxt"

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

                    ElseIf My.Computer.FileSystem.FileExists(qstnPath) Then

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

        'hides main and sets window 
        Me.Hide()
        setWin()

        'call fillArray and Shuffle functions (seen below), this fills the arrays for first and last phases and shuffles the stim order
        fillTrainArray()
        fillSOAarray()
        ShuffleSlips()
        ShuffleTrain()

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

            Case "Qstn Phase Restart"

                qstnPhase()

            'same as above, but start on last phase
            Case "SlipOfActionPhase Restart"

                SlipsOfActionPhase()


            Case Else

                'msgbox for error handling or debugging
                myMsgBox("Error. Idk what happened, man", MsgBoxStyle.OkOnly, "Oh no.")
                cleanseEverything()

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

    Private Sub fillTrainArray()

        'counter variable
        Dim inx, TrnCount As Integer

        inx = 0
        TrnCount = (GlobVars.TrainTrialNum) \ 6

        formArrayTrain.Add(CongBanTrain)
        formArrayTrain.Add(CongPearTrain)
        formArrayTrain.Add(InconOrngTrain)
        formArrayTrain.Add(InconPineTrain)
        formArrayTrain.Add(StndGrapeTrain)
        formArrayTrain.Add(StndAppleTrain)

        For inx = 0 To GlobVars.TrainTrialNum - 1

            'based on counter number, add specific integer to index array at position 'ind' that references index of formArraySOA
            Select Case inx

                'so in indxArraySOA spots 0 through TrnCount - 1, will contain 0's in each spot; indxArraySOA positions trnCount through 2*trncount - 1 have 1's in each spot, etc
                'can changes cases to have more or less of specific form occurences
                'say, if you want more of Congruent1 form, make first case through 15 or 20 (since Congruent1 is index '0' as seen in Add statements above

                Case 0 To TrnCount - 1
                    indxArrayTrain(inx) = 0

                Case TrnCount To (2 * TrnCount) - 1
                    indxArrayTrain(inx) = 1

                Case 2 * TrnCount To (3 * TrnCount) - 1
                    indxArrayTrain(inx) = 2

                Case 3 * TrnCount To (4 * TrnCount) - 1
                    indxArrayTrain(inx) = 3

                Case 4 * TrnCount To (5 * TrnCount) - 1
                    indxArrayTrain(inx) = 4

                Case 5 * TrnCount To (6 * TrnCount) - 1
                    indxArrayTrain(inx) = 5

                Case Else
                    'error handling
                    myMsgBox("YOUR STUPID FILL ARRAYS DONT WORK RIGHT", MsgBoxStyle.OkOnly, "YOU DONE FUCKED UP")

            End Select

        Next

    End Sub

    Public Sub fillSOAarray()

        Dim ind, SopCount As Integer

        ind = 0
        SopCount = (GlobVars.SlipsTrialNum) \ 6

        'add all forms to each array list
        formArraySOA.Add(CongBanSOA)
        formArraySOA.Add(CongPearSOA)
        formArraySOA.Add(InconOrngSOA)
        formArraySOA.Add(InconPineSOA)
        formArraySOA.Add(StndGrapeSOA)
        formArraySOA.Add(StndAppleSOA)

        'add numbers to index array
        For ind = 0 To GlobVars.SlipsTrialNum - 1

            'based on counter number, add specific integer to index array at position 'ind' that references index of formArraySOA
            Select Case ind

                'so in indxArraySOA spots 0 through SopCount - 1 will contain 0's in each spot; indxArraySOA positions sopCount through 2*SopCount - 1 have 1's in each spot, etc
                'can changes cases to have more or less of specific form occurences
                'say, if you want more of Congruent1 form, make first case through 15 or 20 (since Congruent1 is index '0' as seen in Add statements above

                Case 0 To SopCount - 1
                    indxArraySOA(ind) = 0

                Case SopCount To (2 * SopCount) - 1
                    indxArraySOA(ind) = 1

                Case 2 * SopCount To (3 * SopCount) - 1
                    indxArraySOA(ind) = 2

                Case 3 * SopCount To (4 * SopCount) - 1
                    indxArraySOA(ind) = 3

                Case 4 * SopCount To (5 * SopCount) - 1
                    indxArraySOA(ind) = 4

                Case 5 * SopCount To (6 * SopCount) - 1
                    indxArraySOA(ind) = 5

                Case Else
                    'error handling
                    myMsgBox("YOUR STUPID FILL ARRAYS DONT WORK RIGHT", MsgBoxStyle.OkOnly, "YOU DONE FUCKED UP")

            End Select

        Next


    End Sub
    '========================================================='
    '-----Method for Shuffling Array of indexes (Step #5)-----'
    '========================================================='

    Private Sub ShuffleSlips()

        'need for loop counter variable, random number variable and temp variable
        'temp holds swapped int
        Dim count, index, rndNum, temp As Integer

        'call new random seeder class
        Dim rndm As Random = New Random()

        'for each index in indxArraySOA, choose random number between 0 and Block Trial Number, take the indxArraySOA integer at rndNum index and swap with indxArraySOA at current counter index
        'Goes through shuffle 3 times for more randomization
        For count = 0 To 2

            For index = 0 To GlobVars.SlipsTrialNum - 1

                rndNum = rndm.Next(0, GlobVars.SlipsTrialNum)


                While rndNum = index

                    'If rndNum is equal to index, then the number at index will be 'swapped' with itself (aka no swap)
                    'We want to 're-roll' rndm in order to actually have it swap with a different place
                    rndNum = rndm.Next(0, GlobVars.SlipsTrialNum)

                End While

                'swap the numbers at array indexes 'index' and 'rndNum'
                temp = indxArraySOA(rndNum)
                indxArraySOA(rndNum) = indxArraySOA(index)
                indxArraySOA(index) = temp

            Next


        Next


    End Sub


    Private Sub ShuffleTrain()

        Dim count, i, tmp, rdNum As Integer

        'call new random seeder class
        Dim rndm As Random = New Random()

        For count = 0 To 2

            For i = 0 To GlobVars.TrainTrialNum - 1

                rdNum = rndm.Next(0, GlobVars.TrainTrialNum)

                While rdNum = i

                    rdNum = rndm.Next(0, GlobVars.TrainTrialNum)

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
            Dim i As Integer

            'Show instructions first
            clsTaskInstr.ShowDialog(Me)
            clsTrainingInstr.ShowDialog(Me)
            clsTrainPractice.ShowDialog(Me)

            For i = 1 To GlobVars.TrainBlocks

                'after instructions, loop through each trial
                For trainCount = 0 To GlobVars.TrainTrialNum - 1

                    'Declare a variable to put the number from indxArrayTraining at index of traincount into
                    Dim objIndex As Integer

                    objIndex = indxArrayTrain(trainCount)

                    'show the form at index of objIndex in Training form arraylist; since indxArray randomized, will show specified random forms in order
                    formArrayTrain(objIndex).ShowDialog(Me)

                Next

                BlckEndTrain.ShowDialog(Me)

                're-randomize trials
                formArrayTrain.Clear()
                fillTrainArray()
                ShuffleTrain()

            Next

            'after trials, show thanks form then endTrain form with points
            clsThanks.ShowDialog(Me)
            clsEndTrain.ShowDialog(Me)

            'move to deval Phase
            devalPhase()

        Catch ex As Exception

            'close if fails
            Exit Try

        End Try

        cleanseEverything()

    End Sub

    '========================================================'
    '-----Phase Two: Outcome Devaluation Start (Step #8)-----'
    '========================================================'

    Private Sub devalPhase()

        Try

            'show instructions, then outcomeDevaluation form, then thanks and points forms
            clsODInstr.ShowDialog(Me)
            clsODpractice.ShowDialog(Me)
            clsOutcome.ShowDialog(Me)
            clsThanks.ShowDialog(Me)
            clsEndDeval.ShowDialog(Me)

            'continue on to slips of action
            qstnPhase()


        Catch ex As Exception

            Exit Try

        End Try

        cleanseEverything()

    End Sub

    '=========================================='
    '-----Phase Five: Questions (Step #10)-----'
    '=========================================='

    Private Sub qstnPhase()

        Try

            clsQstnInstr.ShowDialog(Me)
            clsRespKnow.ShowDialog(Me)
            clsOutKnow.ShowDialog(Me)
            clsThanks.ShowDialog(Me)

            SlipsOfActionPhase()

        Catch ex As Exception

            Exit Try

        End Try

        cleanseEverything()

    End Sub


    '====================================================='
    '-----Phase Four: Slips of Action Task (Step #10)-----'
    '====================================================='

    Private Sub SlipsOfActionPhase()

        Try

            'similar to training phase, show instructions/devalued stim, loop through trials, show thanks and points forms
            Dim formCount As Integer
            Dim i As Integer

            clsSOAInstr.ShowDialog(Me)
            DevPracSOA.ShowDialog(Me)
            PracSOA.ShowDialog(Me)

            For i = 1 To GlobVars.SlipsBlocks

                clsDevalued.ShowDialog(Me)

                For formCount = 0 To GlobVars.SlipsTrialNum - 1

                    Dim objIndex As Integer

                    objIndex = indxArraySOA(formCount)
                    formArraySOA(objIndex).ShowDialog(Me)

                Next

                BlckEndSOA.ShowDialog(Me)

                formArraySOA.Clear()
                fillSOAarray()
                ShuffleSlips()

            Next

            clsThanks.ShowDialog(Me)
            clsEndSOA.ShowDialog(Me)

            cleanseEverything()

        Catch ex As Exception

            'if this fails, close
            Exit Try

        End Try

        cleanseEverything()

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
        clsTaskInstr.Dispose()

        clsSOAInstr.Dispose()
        clsTrainingInstr.Dispose()
        clsODInstr.Dispose()
        clsQstnInstr.Dispose()

        'End of phase forms
        clsEndSOA.Dispose()
        clsEndTrain.Dispose()
        clsEndDeval.Dispose()
        clsDevalued.Dispose()
        clsThanks.Dispose()

        'Training phase form instances
        clsTrainPractice.Dispose()
        StndGrapeTrain.Dispose()
        StndAppleTrain.Dispose()
        CongBanTrain.Dispose()
        CongPearTrain.Dispose()
        InconOrngTrain.Dispose()
        InconPineTrain.Dispose()

        'Deval form instance and questions
        clsODpractice.Dispose()
        clsOutcome.Dispose()
        clsOutKnow.Dispose()
        clsRespKnow.Dispose()

        'SOA forms
        DevPracSOA.Dispose()
        PracSOA.Dispose()
        StndGrapeSOA.Dispose()
        StndAppleSOA.Dispose()
        CongBanSOA.Dispose()
        CongPearSOA.Dispose()
        InconOrngSOA.Dispose()
        InconPineSOA.Dispose()

        BlckEndTrain.Dispose()
        BlckEndSOA.Dispose()

        'frmThanks.Dispose()
        'EndSOA.Dispose()
        'EndTrain.Dispose()
        'EndDeval.Dispose()

        'InstructionsSOA.Dispose()
        'TrainingInstr.Dispose()
        'InstructionsOD.Dispose()
        'SOA_Devalued.Dispose()
        'TaskInstr.Dispose()

        ''Training Stim Forms
        'TrainPractice.Dispose()
        'TrainStndGrape.Dispose()
        'TrainStndApple.Dispose()
        'TrainCongBana.Dispose()
        'TrainCongPear.Dispose()
        'TrainInconOrng.Dispose()
        'TrainInconPine.Dispose()

        ''Deval form
        'OutDevPractice.Dispose()
        'OutcomeDeval.Dispose()
        'QstnInstr.Dispose()
        'OutKnow.Dispose()
        'RespKnow.Dispose()

        ''SOA forms
        'SOA_Practice.Dispose()
        'SOA_Practice_Devald.Dispose()
        'SOA_Stnd_Grape.Dispose()
        'SOA_Stnd_Apple.Dispose()
        'SOA_Cong_Ban.Dispose()
        'SOA_Cong_Pear.Dispose()
        'SOA_Incon_Orng.Dispose()
        'SOA_Incon_Pine.Dispose()

        Me.Close()
        Application.Exit()

    End Sub
End Class
