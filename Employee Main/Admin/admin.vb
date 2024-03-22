Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class management
    Dim connectionString As String = "Server=localhost;Database=inventory;Uid=root;Pwd=;Convert Zero Datetime=True"
    Dim empcode As Integer
    Public Sub New(code As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        empcode = code
    End Sub

    Public Sub ChangePanel(panel As Form)
        MainPanel.Controls.Clear()
        panel.TopLevel = False
        MainPanel.Controls.Add(panel)
        panel.Show()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs)
        'ChangePanel(Manage_Stock)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        'ChangePanel(StockHistory)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'ChangePanel(StockRefill)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        'ChangePanel(EmployeeHistory)
    End Sub

    Private Sub admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChangePanel(New Bill_Generator(empcode))
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        Hide()
        'loginuser.Show
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ChangePanel(EmployeeDetails)
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        ChangePanel(New Bill_Generator(empcode))
    End Sub



    Dim billcount As Integer
    Private Sub LogOut(empCode As Integer)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' SQL query to update logout time for the current date and employee code
                Dim logoutQuery As String = "UPDATE emphistory SET logout = @logoutdate,billcount = @billcount WHERE ecode = @empcode AND date >= CURDATE()"

                Using command As New MySqlCommand(logoutQuery, connection)
                    ' Add parameters to the query
                    command.Parameters.AddWithValue("@empcode", empCode)
                    command.Parameters.AddWithValue("@billcount", billcount)
                    command.Parameters.AddWithValue("@logoutdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))

                    ' Execute the query
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Logged out successfully!")
                    Else
                        MessageBox.Show("No matching login record found for today.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging out: " & ex.Message)
        End Try
    End Sub

    Private Function FetchRecordCount(empCode As String) As Integer
        Dim count As Integer = 0

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' SQL query to fetch count of records for the specified cashier and bill date
                Dim query As String = "SELECT COUNT(*) FROM customerpurchases WHERE cashier = @cashier AND billdate >= CURDATE()"

                Using command As New MySqlCommand(query, connection)
                    ' Add parameters to the query
                    command.Parameters.AddWithValue("@cashier", empCode)

                    ' Execute the query and get the count
                    count = Convert.ToInt32(command.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error fetching record count: {ex.Message}")
        End Try

        Return count
    End Function


    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        billcount = FetchRecordCount(empcode)
        LogOut(empcode)
        Me.Close()
    End Sub



    'Manage Stock
    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        ChangePanel(New Manage_Stock)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        ChangePanel(New StockRefill)
    End Sub
End Class
