Imports System
Imports System.IO

Public Class OutcomeDeval

    '-----Dim variables-----'

    'score for outcome deval portion
    Dim points As Integer

    'global variable for loop index (needed for key press)
    Dim outcomeIndx As Integer

    'arrays for dynamically changing the pictures
    Dim boxArray(12) As Integer
    Dim outcmArray(12) As Integer
    Dim outcomeList As New List(Of Bitmap)
    Dim rightArray(3) As Integer
    Dim leftArray(3) As Integer

    'for foreground image (to see background)
    Dim blankBox As New Bitmap(1, 1)

    'dim picture variables
    Dim cherry, banana, pineapple, melon, pear, orange As Bitmap

    'sets variables that take values from Main form; used in file output
    Dim cbx As String
    Dim subID As String

    'sets variables for text output of deval'd outcomes
    Dim orderPath As String
    Dim stimType As String

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
        orderPath = "C:\x\" & subID & "\" & subID & cbx & "_StimOrder.txt"

        'turn on Key Preview for exiting if needed
        KeyPreview = False


        'TO DO: add these to array
        cherry = My.Resources.ResourceManager.GetObject("cherries")
        banana = My.Resources.ResourceManager.GetObject("Banana")
        pineapple = My.Resources.ResourceManager.GetObject("pineapple")
        melon = My.Resources.ResourceManager.GetObject("halfWMelon")
        pear = My.Resources.ResourceManager.GetObject("pear2")
        orange = My.Resources.ResourceManager.GetObject("orange")



        runTask()

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

        'run algorithm

    End Sub

    Private Sub fillArrays()

        'fill outcmArray and box array

        'add in order of left then right, pic variables to list

        'fill left array with 0,1,2 and right array with 3,4,5

    End Sub

    Private Sub randomizeArrays()

        'randomize box and outcm Arrays

        'no need to randomize left,right arrays and list, they are used for pointers and bools

    End Sub

End Class

