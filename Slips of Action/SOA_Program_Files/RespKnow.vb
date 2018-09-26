Imports System
Imports System.IO
Imports System.Windows.Forms.Form

Public Class RespKnow

    '==========================='
    '-----Declare Variables-----'
    '==========================='

    'need a list of pictures, and an array of indexes pointing to that list; will also need a global variable for current index
    Dim stimList As New List(Of Bitmap)
    Dim indxArray() As Integer = {0, 1, 2, 3, 4, 5}
    Dim stimIndx As Integer

    'declare variables for pictures
    Dim grape, banana, orange, pineapple, pear, apple As Bitmap

    'frmMain variables for output path
    Dim cbx As String
    Dim subID As String

    'stimType and response code for output, along with variables for their output paths
    Dim stimType As String
    Dim resp As Integer
    Dim path As String

    Dim acceptKey As Boolean

    '============================'
    '-----Form Load Function-----'
    '============================'

    Private Sub RespKnow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        'Set cbx/subID to variables entered from Main
        cbx = frmMain.cbxSess.SelectedItem
        subID = frmMain.txtSubj.Text

        'set pathways to the three different text ouput files
        path = "C:\x\" & subID & "\" & subID & cbx & "_RespKnow.txt"

        'set each picture variable to the corresponding picture
        grape = My.Resources.ResourceManager.GetObject("grapes")
        banana = My.Resources.ResourceManager.GetObject("Banana")
        pineapple = My.Resources.ResourceManager.GetObject("pineapple")
        apple = My.Resources.ResourceManager.GetObject("apple")
        pear = My.Resources.ResourceManager.GetObject("pear2")
        orange = My.Resources.ResourceManager.GetObject("orange")

        'add each picture to the list (order matters-right key response are first three, left key response are last 3)
        stimList.Add(grape)
        stimList.Add(banana)
        stimList.Add(orange)
        stimList.Add(pineapple)
        stimList.Add(pear)
        stimList.Add(apple)

        'start the index at 0 for indxArray
        stimIndx = 0

        'shuffle the indxArray to have random ordering for each subject
        randomizeArrays()

        runTask()

    End Sub

    '======================================'
    '-----Index Array Shuffle Function-----'
    '======================================'

    Public Sub randomizeArrays()

        Dim loopCount, indx, temp, rndNum As Integer

        Dim rndm As Random = New Random()

        'loop through shuffle mechanism 3 times for higher randomization
        For loopCount = 0 To 2

            'for each indx in indxArray, get random number 0 thru 5
            For indx = 0 To 5

                rndNum = rndm.Next(0, 6)

                'make sure its not the same as current val of indx
                While rndNum = indx

                    rndNum = rndm.Next(0, 6)

                End While

                'swap indxArray(rndNum) and indxArray(indx)
                temp = indxArray(rndNum)
                indxArray(rndNum) = indxArray(indx)
                indxArray(indx) = temp

            Next

        Next

    End Sub

    '===================================='
    '-----Start of Each Loop of Task-----'
    '===================================='

    Public Sub runTask()

        Dim ind As Integer

        'get number from indxArray for current iteration
        ind = indxArray(stimIndx)

        'set the picture's image to that picture
        StimBox.Image = stimList(ind)

        'set stimType output
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
                'error/debugging
                MsgBox("Uh-oh. Someone goofed.", MsgBoxStyle.OkOnly, "Error")
        End Select

        'after images are all set, make them visible
        makeVisible()

    End Sub

    '======================================================================'
    '-----Function to Make all Form Elements Visible (after blank ITI)-----'
    '======================================================================'

    Public Sub makeVisible()

        trkBar.Visible = True

        Instruct.Visible = True
        Label1.Visible = True
        Label2.Visible = True
        Label4.Visible = True
        Label3.Visible = True
        Label5.Visible = True

        lblQstn.Visible = True
        ChestPic.Visible = True
        StimBox.Visible = True

        'ensure keyboard input accepted, as keypress lets code continue
        acceptKey = True

    End Sub

    '==========================================================================================='
    '-----Function to Make all Form Elements Invisible (for blank period between questions)-----'
    '==========================================================================================='

    Public Sub makeInvisible()

        trkBar.Visible = False

        Instruct.Visible = False
        Label1.Visible = False
        Label2.Visible = False
        Label4.Visible = False
        Label3.Visible = False
        Label5.Visible = False

        lblQstn.Visible = False
        ChestPic.Visible = False
        StimBox.Visible = False

    End Sub

    '============================='
    '-----Key Press Functions-----'
    '============================='

    Private Sub RespKnow_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim response As MsgBoxResult
        'if x press, clean everything and exit
        If e.KeyChar = "x" Then
            response = MsgBox("You are about to exit the Slips Of Action task. Are you sure?", MsgBoxStyle.YesNo, "Quit the Slips Of Action task?")
            If response = MsgBoxResult.Yes Then

                frmMain.cleanseEverything()

            Else
            End If

        ElseIf e.KeyChar = "2" Then

            'if 2 pressed, move track bar slider right. this trackbar only goes to 2, so anything over 1 just equals 2
            Select Case trkBar.Value

                Case Is > 1
                    trkBar.Value = 2
                Case Else
                    trkBar.Value = trkBar.Value + 1

            End Select


        ElseIf e.KeyChar = "1" Then

            'if 1 pressed, move trackbar left, ensuring no values below 0
            Select Case trkBar.Value

                Case Is < 1
                    trkBar.Value = 0
                Case Else
                    trkBar.Value = trkBar.Value - 1

            End Select

        ElseIf e.KeyChar = "8" Then

            'turn off keyboard input to avoid accidental keypress function going 
            If acceptKey = True Then

                'if 8 is pressed, check the trackbar value (answer) and compar it to the number at indxArray for current iteration
                'if subj responded right (trkBar = 2) and pic was right press (indxArray(stimIndx) <=2 then correct
                'same goes for opposite

                If indxArray(stimIndx) <= 2 AndAlso trkBar.Value = 2 Then

                    acceptKey = False
                    correctPress()

                ElseIf indxArray(stimIndx) >= 3 AndAlso trkBar.Value = 0 Then

                    correctPress()
                    acceptKey = False

                ElseIf trkBar.Value = 1 Then

                    'if subject tries to select middle value (1), tell them to choose a valid answer
                    MsgBox("Please choose a valid response, the '1' key or '2' Key.", MsgBoxStyle.OkOnly, "Invalid Response")

                Else

                    'anything else is incorrect press
                    acceptKey = False
                    incorrectPress()
                End If

            End If

        End If

    End Sub

    '======================================='
    '-----Function for a Correct Answer-----'
    '======================================='

    Private Sub correctPress()

        'turn off elements for blank ITI
        makeInvisible()

        'resp is correct
        resp = 1

        'output stimType and resp
        textOutput()

        'start blank period timer
        ITItimer.Start()

    End Sub

    '======================================='
    '-----Function for Incorrect Answer-----'
    '======================================='

    Private Sub incorrectPress()

        'just like correct press function but resp = 0
        'could've made them one function, but wanted future flexibility

        makeInvisible()

        resp = 0

        textOutput()

        ITItimer.Start()

    End Sub

    '============================================================================='
    '-----Timer Tick Function (what happens when blank period timer runs out)-----'
    '============================================================================='

    Private Sub ITItimer_Tick() Handles ITItimer.Tick

        'if the index is less than last index in array (trial number - 1), continue
        If stimIndx < 5 Then

            'stop timer
            ITItimer.Stop()

            'increment loop index for next run
            stimIndx = stimIndx + 1

            'reset trackbar value to middle
            trkBar.Value = 1

            'start over again
            runTask()

        Else

            ITItimer.Stop()

            'if last trial, hide form and go to text one
            Me.Hide()

        End If

    End Sub

    '=============================='
    '-----Text Output Function-----'
    '=============================='

    Private Sub textOutput()

        Dim fs As New FileStream(path, FileMode.Append, FileAccess.Write)
        Dim sr As New StreamWriter(fs)
        sr.WriteLine(stimType & "," & resp)
        sr.Close()
        fs.Close()

    End Sub
End Class