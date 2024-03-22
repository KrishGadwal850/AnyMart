Public Class receivedimage
    Private WithEvents timer As New Timer()
    Private secondsRemaining As Integer = 3

    Public Sub New()
        InitializeComponent()
        InitializeTimer()
    End Sub

    Private Sub InitializeTimer()
        ' Set the timer interval to 1000 milliseconds (1 second)
        timer.Interval = 1000
        AddHandler timer.Tick, AddressOf TimerTick
        timer.Start()
    End Sub

    Private Sub receivedimage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = My.Resources.tick_mark
    End Sub

    Private Sub TimerTick(sender As Object, e As EventArgs)
        secondsRemaining -= 1

        If secondsRemaining <= 0 Then
            ' Close the form after 3 seconds
            Me.Close()
        End If
    End Sub
End Class