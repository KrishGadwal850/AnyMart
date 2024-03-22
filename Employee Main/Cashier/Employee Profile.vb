Public Class Employee_Profile

    Dim empcode As Integer

    Public Sub New(code As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        empcode = code
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Employee_Profile_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class