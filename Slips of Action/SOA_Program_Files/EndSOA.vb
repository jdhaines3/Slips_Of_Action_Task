Public Class EndSOA


    Dim score As Integer

    '============================='
    '-----Key Press Functions-----'
    '============================='

    Private Sub frmBlank_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.Control And e.KeyCode = Keys.X Then

            'if x pressed, close/end experiment
            frmMain.cleanseEverything()

        End If

    End Sub

    '============================'
    '-----Form Load Function-----'
    '============================'

    Private Sub frmBlank_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        'make sure keyboard input is on, get score from Main, then show score in number box
        KeyPreview = True

        score = frmMain.getScore()

        ScoreTxt.Text = score




    End Sub

    '========================================='
    '-----Function for Cancel/Exit Button-----'
    '========================================='

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        'if the button is clicked, exit (like if cntrl x is pressed)
        frmMain.cleanseEverything()

    End Sub


End Class