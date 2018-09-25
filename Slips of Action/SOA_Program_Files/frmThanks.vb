Imports System.Windows.Forms.Form

Public Class frmThanks

    Public timer As New System.Timers.Timer

    Private Sub frmThanks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CheckForIllegalCrossThreadCalls = False
        timer.Interval = 1000
        timer.Start()

        AddHandler timer.Elapsed, New System.Timers.ElapsedEventHandler(AddressOf timer_elapsed)

    End Sub

    Private Sub timer_elapsed(ByVal myObject As Object, ByVal myEventArgs As System.Timers.ElapsedEventArgs)
        Me.Hide()
    End Sub


    Private Sub frmThanks_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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
                Me.Dispose()
                Application.Exit()
            Else
            End If
        End If
    End Sub

    Private Sub frmThanks_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Dim LocalMousePosition As Point
        Dim myScreens() As Screen = Screen.AllScreens
        Dim objPoint As Point = PointToScreen(New Point(0, 0))

        If (myScreens.Length = 2) Then
            LocalMousePosition = PointToClient(Cursor.Position)
            If LocalMousePosition.X() < 1285 Then
                objPoint.X += 1290
                objPoint.Y += LocalMousePosition.Y()
                Cursor.Position = objPoint
            Else
            End If
        End If

    End Sub


End Class