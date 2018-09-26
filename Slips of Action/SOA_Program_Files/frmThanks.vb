Imports System.Windows.Forms.Form

Public Class frmThanks

    '============================'
    '-----Dim Timer for Form-----'
    '============================'

    Public timer As New System.Timers.Timer

    '============================'
    '-----Form Load Function-----'
    '============================'

    Private Sub frmThanks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'start timer to show form for one second
        CheckForIllegalCrossThreadCalls = False
        timer.Interval = 1000
        timer.Start()

        AddHandler timer.Elapsed, New System.Timers.ElapsedEventHandler(AddressOf timer_elapsed)

    End Sub

    '=================================================='
    '-----Timer Tick Function (When timer elapses)-----'
    '=================================================='

    Private Sub timer_elapsed(ByVal myObject As Object, ByVal myEventArgs As System.Timers.ElapsedEventArgs)
        Me.Hide()
    End Sub

    '============================'
    '-----KeyPress Functions-----'
    '============================'

    Private Sub frmThanks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim response As MsgBoxResult
        If e.KeyChar = "x" Then
            response = MsgBox("You are about to exit the Slips Of Action task. Are you sure?", MsgBoxStyle.YesNo, "Quit Slips Of Action task?")
            If response = MsgBoxResult.Yes Then

                'if x pressed, close
                frmMain.cleanseEverything()

            Else
            End If
        End If
    End Sub

End Class