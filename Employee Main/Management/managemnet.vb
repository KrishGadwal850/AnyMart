Public Class managemnet
    Dim connectionString As String = "Server=localhost;Database=inventory;Uid=root;Pwd=;"
    Dim empcode As Integer
    Dim panelName As String
    Public Sub New(code As Integer, panel As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        empcode = code
        panelName = panel
    End Sub

    Public Sub ChangePanel(panel As Form)
        MainPanel.Controls.Clear()
        panel.TopLevel = False
        MainPanel.Controls.Add(panel)
        panel.Show()
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ChangePanel(New EmployeeDetails)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ChangePanel(New Manage_Stock)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ChangePanel(New Bill_Generator(empcode))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ChangePanel(New StockRefill)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ChangePanel(New Customer)
    End Sub

    Private Sub managemnet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class