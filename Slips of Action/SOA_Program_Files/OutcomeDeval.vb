Imports System
Imports System.IO

Public Class OutcomeDeval

    '======================='
    '---Declare variables---'
    '======================='


    'Declares variables for # of points and key response
    Dim points, resp As Integer

    '--arrays used in this form--'                                                  'length of box and outcome array MUST BE #trials, right/left array = #trials/2
    Dim boxArray() As Integer = {1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2}                'used to determine which box to put devalued stim in: 1 is top, 2 is bottom
    Dim outcmArray() As Integer = {0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5}              'used to determine which picture is devalued, #s point to location in outcomeList
    Dim outcomeList As New List(Of Bitmap)
    Dim rightArray() As Integer = {0, 0, 1, 1, 2, 2}                                'both used to determine which pic to make NOT devalued, #s point to location in outcomeList 
    Dim leftArray() As Integer = {3, 3, 4, 4, 5, 5}

    Dim outcomeIndx, boxIndx, rightIndx, leftIndx As Integer                        'global variables for loop indexes for each array

    Dim blankBox As New Bitmap(1, 1)                                                'sets up a 1 pixel image to use as foreground of NON deval'd image (workaround for transparent top layer)


    'variables set to specific stim
    Dim cherry, banana, pineapple, melon, pear, orange As Bitmap

    'declares variables from frmMain for session and subID (entered at beginning)
    Dim cbx As String
    Dim subID As String

    'sets variables for text output pathways of: Deval'd stim order, response to each trial, and non deval'd stim order
    Dim orderPath As String
    Dim respPath As String
    Dim nonDevalPath As String

    'string variables for use in output; devalued stim and valued stim
    Dim nonDevalPic As String
    Dim devalType As String

    'stopwatch to measure reaction time and convert to points, Long variable (for large ints) used to convert stopwatch time to milliseconds
    Dim stpWatch As New Stopwatch()
    Dim milTime As Long


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

        ' Set the form location so it appears at Location (100, 100) on the screen 1
        Me.Location = screen.Bounds.Location + New Point(0, 0)


        'Set cbx/subID to variables entered from Main
        cbx = frmMain.cbxSess.SelectedItem
        subID = frmMain.txtSubj.Text

        'set pathways to the three different text ouput files
        orderPath = "C:\x\" & subID & "\" & subID & cbx & "_DevalOrder.txt"
        respPath = "C:\x\" & subID & "\" & subID & cbx & "_DevalResp.txt"
        nonDevalPath = "C:\x\" & subID & "\" & subID & cbx & "_NonDevOrder.txt"

        'turn off keyPreview to prevent accidental button presses
        KeyPreview = False

        'set each picture variable to the corresponding resources pic
        cherry = My.Resources.ResourceManager.GetObject("cherries")
        banana = My.Resources.ResourceManager.GetObject("Banana")
        pineapple = My.Resources.ResourceManager.GetObject("pineapple")
        melon = My.Resources.ResourceManager.GetObject("halfWMelon")
        pear = My.Resources.ResourceManager.GetObject("pear2")
        orange = My.Resources.ResourceManager.GetObject("orange")

        'add each of those variables to the List (order is very important; must match the left/rightArrays; first three are right, last three are left)
        outcomeList.Add(cherry)
        outcomeList.Add(banana)
        outcomeList.Add(pineapple)
        outcomeList.Add(melon)
        outcomeList.Add(pear)
        outcomeList.Add(orange)

        'Call function to randomize the needed arrays
        randomizeArrays()

        'once arrays are randomized, start task
        runTask()

    End Sub

    '========================================================='
    '------Function to randomize needed arrays (Step #2)------'
    '========================================================='

    Private Sub randomizeArrays()

        'declare variables for index of box/out array, variable to hold random #, temp variables to swap elements of array, and loop count to run randomization X amnt of times
        Dim indx, tempBox, tempOut, rdNumBox, rdNumOut, loopCount As Integer

        'same as above but for left/right arrays (not loop count though)
        Dim tmpRight, tmpLeft, ind, rndRight, rndLeft As Integer

        'Start new random # gen seed
        Dim rndm As Random = New Random()


        'loop through randomization x amount of times (3 times here), not NEEDED, but increases variability.
        For loopCount = 0 To 2

            'loop through each element of box and outcome arrays
            For indx = 0 To 11

                'generate random number between 0 and 11 (index of box and outcome arrays)
                rdNumBox = rndm.Next(0, 12)
                rdNumOut = rndm.Next(0, 12)

                'check if the random number = the current index, if so choose a new random number (if it was same as index, no swap would occur)
                While rdNumBox = indx

                    rdNumBox = rndm.Next(0, 12)

                End While

                While rdNumOut = indx

                    rdNumOut = rndm.Next(0, 12)

                End While

                'swap the numbers at array(indx) and array(rndmNum) for both arrays
                tempBox = boxArray(rdNumBox)
                boxArray(rdNumBox) = boxArray(indx)
                boxArray(indx) = tempBox

                tempOut = outcmArray(rdNumOut)
                outcmArray(rdNumOut) = outcmArray(indx)
                outcmArray(indx) = tempOut

            Next

            'same randomize shuffle as above but for the right/left arrays
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

    '======================================================================================================='
    '-----Main Function to run task (Step #3: puts the two pictures up on the form, one being devalued)-----'
    '======================================================================================================='

    Private Sub runTask()

        'declare variables to get the number at the current index for box, right/left, and outcome arrays
        Dim boxNum, outNum, rightLeft As Integer

        'set the two variables
        boxNum = boxArray(outcomeIndx)
        outNum = outcmArray(outcomeIndx)

        'if statement to determine which press is devalued, right or left
        If outNum <= 2 AndAlso outNum >= 0 Then

            'since deval'd is right press, get the number at the current left index from left array to find valued stim
            rightLeft = leftArray(leftIndx)

            'determine which stim the valued pic is and set the output variable to that word
            Select Case rightLeft
                Case 3
                    nonDevalPic = "Watermelon"
                Case 4
                    nonDevalPic = "Pear"
                Case 5
                    nonDevalPic = "Orange"
                Case Else
                    'debugging/error
                    myMsgBox("Code not working right, you dunce.", MsgBoxStyle.OkOnly, "Whoopsie")
            End Select

            'determine which box position the deval'd stim will be in
            Select Case boxNum

                'if index for box array points to 1, deval'd image will be in top box
                Case 1

                    TopPic.BackgroundImage = outcomeList(outNum)                                'set background image to the picture specified by outNum (outNum is now index for picture list)
                    TopPic.Image = My.Resources.ResourceManager.GetObject("xmark")              'place red x over the stim image
                    TopPic.Visible = True                                                       'set visibility to true

                    BottomPic.BackgroundImage = outcomeList(rightLeft)                          'for bottom image, set the background pic to the pic at index 'rightleft' of picList
                    BottomPic.Image = blankBox                                                  'set top image to blank (transparent shortcut; ensures red X from previous trial is "erased")
                    BottomPic.Visible = True                                                    'visibility = true

                    leftIndx = leftIndx + 1                                                     'since we used left index to find valued stim, increment it to next spot in array

                Case 2

                    'similar to above but switch box positions
                    BottomPic.BackgroundImage = outcomeList(outNum)
                    BottomPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                    BottomPic.Visible = True

                    TopPic.BackgroundImage = outcomeList(rightLeft)
                    TopPic.Image = blankBox
                    TopPic.Visible = True

                    leftIndx = leftIndx + 1

                Case Else
                    'debugging/error
                    myMsgBox("Code not working right, you dunce.", MsgBoxStyle.OkOnly, "Whoopsie")
            End Select


        ElseIf outNum >= 3 AndAlso outNum <= 5 Then

            'if outcome number between 3 and 5 then deval'd number is Left press, so find valued right press
            'similar code to above
            rightLeft = rightArray(rightIndx)

            Select Case rightLeft
                Case 0
                    nonDevalPic = "cherry"
                Case 1
                    nonDevalPic = "banana"
                Case 2
                    nonDevalPic = "pineapple"
                Case Else
                    'msgbox error/debugging
                    myMsgBox("Code not working right, you dunce.", MsgBoxStyle.OkOnly, "Whoopsie")
            End Select

            Select Case boxNum
                Case 1

                    TopPic.BackgroundImage = outcomeList(outNum)
                    TopPic.Image = My.Resources.ResourceManager.GetObject("xmark")
                    TopPic.Visible = True

                    BottomPic.BackgroundImage = outcomeList(rightLeft)
                    BottomPic.Image = blankBox
                    BottomPic.Visible = True

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
                    myMsgBox("Code not working right, you dunce.", MsgBoxStyle.OkOnly, "Whoopsie")
            End Select

        Else

            myMsgBox("Code not working right, you dunce.", MsgBoxStyle.OkOnly, "Whoopsie")

        End If

        'Now that stims are chosen and visible, start stopwatch and turn on keyboard input
        stpWatch.Start()
        KeyPreview = True

    End Sub

    '========================================================================'
    '-----Key Press (Step #4: What happens when subject presses a button-----'
    '========================================================================'

    Private Sub OutcomeDeval_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim response As MsgBoxResult
        'if x is pressed, exit (after confirming exit)
        If e.KeyChar = "x" Then
            response = MsgBox("You are about to exit the program. Are you sure?", MsgBoxStyle.YesNo, "Quit Program?")
            If response = MsgBoxResult.Yes Then
                'dispose of all forms
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

            'if 1 pressed (left) determine what the number in outcome array index is, if right press is deval'd then correct, if left press deval'd incorrect
            Select Case outcmArray(outcomeIndx)
                Case 0 To 2
                    correctPress()
                Case 3 To 5
                    incorrectPress()
                Case Else
                    'msgbox error/debugging
                    myMsgBox("Code not working right, you dunce.", MsgBoxStyle.OkOnly, "Whoopsie")
            End Select

        ElseIf e.KeyChar = "2" Then
            'reverse of keypress 1
            Select Case outcmArray(outcomeIndx)
                Case 0 To 2
                    incorrectPress()
                Case 3 To 5
                    correctPress()
                Case Else
                    'msgbox error
                    myMsgBox("Code not working right, you dunce.", MsgBoxStyle.OkOnly, "Whoopsie")
            End Select

        Else
            'any other key press, do nothing
        End If
    End Sub

    '====================================='
    '-----Correct Key Press (Step #5)-----'
    '====================================='

    Public Sub correctPress()

        'turn off keyboard input to prevent misclicks/keypress function from being run again
        KeyPreview = False

        'make the response variable 1 for correct
        resp = 1

        'get the elapsed time from the stopwatch and reset it
        milTime = stpWatch.ElapsedMilliseconds()
        stpWatch.Reset()

        'get points from frmMain
        points = frmMain.getDevalScore()

        'determine points based off the time in miliseconds of button press
        Select Case milTime

            Case 0 To 1000

                points = points + 5
                frmMain.setDevalScore(points)

            Case 1001 To 1500

                points = points + 4
                frmMain.setDevalScore(points)

            Case 1501 To 2000

                points = points + 3
                frmMain.setDevalScore(points)

            Case 2001 To 2500

                points = points + 2
                frmMain.setDevalScore(points)

            Case Is > 2500

                points = points + 1
                frmMain.setDevalScore(points)

            Case Else

                'debugging/error msg
                MsgBox("The person coding this sucks.", MsgBoxStyle.OkOnly, "UH-OH. UH-OH. UH-OH.")

        End Select

        'make the pictures no longer visible for intertrial pause
        TopPic.Visible = False
        BottomPic.Visible = False

        'run outcome string function to get deval'd stim in string form, run textoutput function, then start ITI timer
        outcomeString()
        textOutput()
        durTimer.Start()

    End Sub

    '======================================='
    '-----Incorrect Key Press (Step #5)-----'
    '======================================='


    Public Sub incorrectPress()

        'similar to correct press, but no assigning points, just reset timer and set response to 0

        KeyPreview = False
        resp = 0

        stpWatch.Reset()

        TopPic.Visible = False
        BottomPic.Visible = False

        outcomeString()
        textOutput()
        durTimer.Start()

    End Sub

    '====================================================================================================='
    '-----Outcome To String (Step #6: get the string for the deval'd stim and set to output variable)-----'
    '====================================================================================================='

    Public Sub outcomeString()

        'determines which string to set output variable to based on number at outcomeIndx in outcomeArray
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
                'debugging
                devalType = "error"
        End Select

    End Sub

    '================================================================================================================================='
    '-----Text Output (Step #7: take the string variables for deval and non deval pic, as well as resp, and output to text files)-----'
    '================================================================================================================================='

    Private Sub textOutput()

        'use file names declared in Load function
        'could make into csv maybe, do we need time?

        'deval order text file
        Dim fs As New FileStream(orderPath, FileMode.Append, FileAccess.Write)
        Dim sr As New StreamWriter(fs)
        sr.WriteLine(Now & "  " & devalType)
        sr.Close()
        fs.Close()

        'response text file
        Dim fs2 As New FileStream(respPath, FileMode.Append, FileAccess.Write)
        Dim sr2 As New StreamWriter(fs2)
        sr2.WriteLine(Now & "  " & resp)
        sr2.Close()
        fs2.Close()

        'valued stim order text file
        Dim fs3 As New FileStream(nonDevalPath, FileMode.Append, FileAccess.Write)
        Dim sr3 As New StreamWriter(fs3)
        sr3.WriteLine(Now & "  " & nonDevalPic)
        sr3.Close()
        fs3.Close()

    End Sub

    '==================================================================='
    '-----Time Up (Step #8: What to do when the ITI timer runs out)-----'
    '==================================================================='

    Private Sub durTimer_Tick() Handles durTimer.Tick

        'if the index is less than 11 (last index in array, trial number - 1), continue
        If outcomeIndx < 11 Then

            'stop timer
            durTimer.Stop()

            'increment outcome and box index for next run
            outcomeIndx = outcomeIndx + 1
            boxIndx = boxIndx + 1

            'start over again
            runTask()

        Else

            durTimer.Stop()

            'if last trial, hide form and go to text one
            Me.Hide()

        End If

    End Sub

    '=============================='
    '-----Message Box function-----'
    '=============================='

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

