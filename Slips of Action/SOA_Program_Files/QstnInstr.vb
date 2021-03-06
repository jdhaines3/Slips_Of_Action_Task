Imports System
Imports System.IO

Public Class QstnInstr

    '==================================================================================='
    '-----Form Load Function (what happens each time Showdialog is called for form)-----'
    '==================================================================================='

    Private Sub QstnInstr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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


        'turn on keyboard input
        KeyPreview = True

    End Sub

    '============================='
    '-----Key Press Functions-----'
    '============================='

    Private Sub QstnInstr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim response As MsgBoxResult

        'if x, pop up message asking if you want to quit, Dispose all forms and exit
        If e.KeyChar = "x" Then

            response = MsgBox("You are about to exit the Slips Of Action task. Are you sure?", MsgBoxStyle.YesNo, "Quit the Slips Of Action task?")

            If response = MsgBoxResult.Yes Then

                frmMain.cleanseEverything()

            Else
            End If

        ElseIf e.KeyChar = "8" Then

            'if 8 is pressed, make sure subject meant to press it.  If so, continue on to task, else go back to instructions
            Select Case myMsgBox("Have you finished reading all the instructions, and want to continue?", MsgBoxStyle.YesNo, "Continue?")
                Case "YES"
                    Me.Hide()
                Case "NO"
                    'do nothing
            End Select

        Else
            'if other key pressed, Do nothing
        End If


    End Sub

    '=============================='
    '-----Message Box Function-----'
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