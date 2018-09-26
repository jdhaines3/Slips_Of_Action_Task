Imports System.Windows.Forms.Form
Imports System
Imports System.IO

Public Class EndBlockSOA


    Dim cbx, subID, path, stimType As String


    '============================'
    '-----Form Load Function-----'
    '============================'

    Private Sub EndBlock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        cbx = frmMain.cbxSess.SelectedItem
        subID = frmMain.txtSubj.Text
        path = "C:\x\" & subID & "\" & subID & cbx & "_SlipsPhase.txt"
        stimType = "End Of Block"

        Dim fs As New FileStream(path, FileMode.Append, FileAccess.Write)
        Dim sr As New StreamWriter(fs)
        sr.WriteLine(stimType & "," & stimType & "," & stimType & "," & stimType)
        sr.Close()
        fs.Close()

    End Sub

    '============================'
    '-----KeyPress Functions-----'
    '============================'

    Private Sub EndBlock_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim response As MsgBoxResult
        If e.KeyChar = "x" Then
            response = MsgBox("You are about to exit the Slips Of Action task. Are you sure?", MsgBoxStyle.YesNo, "Quit Slips Of Action task?")
            If response = MsgBoxResult.Yes Then

                'if x pressed, close
                frmMain.cleanseEverything()

            Else
            End If

        ElseIf e.KeyChar = "8" Then

            Me.Hide()

        End If
    End Sub

End Class