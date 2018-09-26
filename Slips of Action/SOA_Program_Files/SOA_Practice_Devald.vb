Imports System
Imports System.IO

Public Class SOA_Practice_Devald

    Dim allowKey As Boolean

    Private Sub SOA_Practice_Devald_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        allowKey = False

        AllowKeyTimer.Start()

    End Sub

    Private Sub AllowKeyTimer_Tick() Handles AllowKeyTimer.Tick

        'stop/reset timer
        AllowKeyTimer.Stop()

        allowKey = True

    End Sub

    '==========================='
    '-----KeyPress Function-----'
    '==========================='

    Private Sub SOA_Practice_Devald_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim response As MsgBoxResult

        'if x pressed, exit program
        If e.KeyChar = "x" Then
            response = MsgBox("You are about to exit the Slips Of Action task. Are you sure?", MsgBoxStyle.YesNo, "Quit the Slips Of Action task?")
            If response = MsgBoxResult.Yes Then

                frmMain.cleanseEverything()

            Else
            End If

        ElseIf e.KeyChar = "8" Then

            If allowKey = True Then

                Me.Hide()

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