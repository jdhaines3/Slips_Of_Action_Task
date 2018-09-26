Public Class EndDeval


    Dim score As Integer

    '=============================='
    '------Key Press Functions-----'
    '=============================='

    Private Sub EndDeval_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim response As MsgBoxResult

        'if x, pop up message asking if you want to quit, Dispose all forms and exit
        If e.KeyChar = "x" Then

            response = MsgBox("You are about to exit the Slips Of Action task. Are you sure?", MsgBoxStyle.YesNo, "Quit the Slips Of Action task?")

            If response = MsgBoxResult.Yes Then

                frmMain.cleanseEverything()

            Else
            End If

        ElseIf e.KeyChar = "8" Then

            Me.Hide()

        Else
            'if other key pressed, Do nothing
        End If


    End Sub

    '============================'
    '-----Form Load Function-----'
    '============================'

    Private Sub EndDeval_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        KeyPreview = True

        'get score from Main and show in number box
        score = frmMain.getDevalScore()

        ScoreTxt.Text = score

    End Sub




End Class