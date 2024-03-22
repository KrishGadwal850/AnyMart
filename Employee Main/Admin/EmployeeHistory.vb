Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports Mysqlx
Imports Mysqlx.XDevAPI.Relational
Imports Org.BouncyCastle.Asn1.Cms

Public Class EmployeeHistory

    Dim empcode As Integer

    Public Sub New(code As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        empcode = code
    End Sub

    Dim i As Integer
    Dim srno As Integer

    Private connectionString As String = "Server=localhost;Database=inventory;Uid=root;Pwd=;Convert Zero Datetime=True"


    'Data Grid View Loader
    Public Sub loadRecord()
        DataGridView1.Rows.Clear()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Using cmd As New MySqlCommand("SELECT * FROM emphistory where ecode = @ecode", connection)
                    ' Assuming ecode is a parameter that needs to be set
                    cmd.Parameters.AddWithValue("@ecode", empcode)

                    Using dr As MySqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            DataGridView1.Rows.Add(dr.Item("sno"), dr.Item("ecode"), dr.Item("ename"), dr.Item("date"), dr.Item("login"), dr.Item("logout"), dr.Item("billcount"))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try
        formClear()
        FilterDataGridView(ComboBox1.Text)
    End Sub


    Public Sub getEmployeeRec()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' SQL query with parameterized query to prevent SQL injection
                Dim query As String = "SELECT ename, address, city FROM employee WHERE ecode = @ecode"
                Using cmd As New MySqlCommand(query, connection)
                    ' Add parameter for the employee code
                    cmd.Parameters.AddWithValue("@ecode", empcode)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtCode.Text = empcode
                            txtName.Text = reader("ename").ToString()
                            txtAddress.Text = reader("address").ToString()
                            txtCity.Text = reader("city").ToString()
                        Else
                            MessageBox.Show("No data found for the provided employee code.")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub EmployeeHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getEmployeeRec()
        loadRecord()
    End Sub


    ' Cell Click Event
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        srno = DataGridView1.CurrentRow.Cells(0).Value
        combo_date.Value = DataGridView1.CurrentRow.Cells(3).Value
        combo_login.Value = DataGridView1.CurrentRow.Cells(4).Value
        combo_logout.Value = DataGridView1.CurrentRow.Cells(5).Value
        txt_pcount.Text = DataGridView1.CurrentRow.Cells(6).Value
    End Sub

    'Form Reset
    Private Sub formClear()
        combo_date.Value = Date.Now
        combo_login.Value = Now
        combo_logout.Value = Now
        txt_pcount.Clear()
    End Sub

    ' Clear Code
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        formClear()
    End Sub

    'Deletion Code
    Private Sub handleDeletion()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Use TryParse to convert srno and empcode to their respective data types
                Dim parsedSrno As Integer
                Dim parsedEmpcode As Integer

                If Integer.TryParse(srno, parsedSrno) AndAlso Integer.TryParse(empcode, parsedEmpcode) Then
                    Using cmd As New MySqlCommand("DELETE FROM `emphistory` WHERE `sno`= @sno AND `ecode`= @ecode", connection)
                        ' Use parameterized queries
                        cmd.Parameters.AddWithValue("@sno", parsedSrno)
                        cmd.Parameters.AddWithValue("@ecode", parsedEmpcode)

                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show("Employee History Deletion Successful", "Manage employee", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            formClear()
                            loadRecord()
                        Else
                            MessageBox.Show("No records were deleted. Please check the provided details.", "Manage employee", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End Using
                Else
                    MessageBox.Show("Invalid sno or ecode. Please provide valid numeric values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
            FilterDataGridView(ComboBox1.Text)
        Catch ex As MySqlException
            MessageBox.Show("MySQL Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Delete Button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        handleDeletion()
    End Sub


    'Update Code
    Private Sub handleUpdation()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim updateQuery As String = "UPDATE `emphistory` SET `date`=@date, `login`=@login, `logout`=@logout, `billcount`=@billcount WHERE `sno`=@sno AND `ecode`=@ecode"

                Using cmd As New MySqlCommand(updateQuery, connection)
                    ' Add parameters to the command
                    cmd.Parameters.AddWithValue("@date", combo_date.Value.Date)
                    cmd.Parameters.AddWithValue("@login", combo_login.Value)
                    cmd.Parameters.AddWithValue("@logout", combo_logout.Value)
                    cmd.Parameters.AddWithValue("@billcount", Integer.Parse(txt_pcount.Text))
                    cmd.Parameters.AddWithValue("@sno", srno)
                    cmd.Parameters.AddWithValue("@ecode", empcode)

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Employee History Updation Successful", "Manage Employee", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ' Only clear the form if the update was successful
                        formClear()
                        loadRecord()
                    Else
                        MessageBox.Show("No records were updated. Please check the provided details.", "Manage Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
            FilterDataGridView(ComboBox1.Text)
        Catch ex As MySqlException
            MessageBox.Show("MySQL Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Delete Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        handleUpdation()
    End Sub

    'Adding Code
    Public Sub handleAdd()

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Using cmd As New MySqlCommand("INSERT INTO `emphistory`(`ecode`, `ename`, `date`, `login`, `logout`, `billcount`) VALUES (@ecode,@ename,@date,@login,@logout,@billcount)", connection)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@ecode", empcode)
                    cmd.Parameters.AddWithValue("@ename", txtName.Text)
                    cmd.Parameters.AddWithValue("@date", combo_date.Value.Date)
                    cmd.Parameters.AddWithValue("@login", combo_login.Value)
                    cmd.Parameters.AddWithValue("@logout", combo_logout.Value)
                    cmd.Parameters.AddWithValue("@billcount", CDec(txt_pcount.Text))

                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Employee History Insertion Successful", "Manage Employee", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        formClear()
                    Else
                        MessageBox.Show("Employee History Insertion Unsuccessful", "Manage Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
                formClear()
                FilterDataGridView(ComboBox1.Text)
            End Using
        Catch ex As MySqlException
            MessageBox.Show("MySQL Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        loadRecord()
    End Sub

    'Adding Code
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        handleAdd()
    End Sub


    'total working hour
    Private Function CalculateTotalWorkingTime(loginTime As DateTime, logoutTime As DateTime) As TimeSpan
        ' Calculate total working time
        Return If(logoutTime > loginTime, logoutTime - loginTime, TimeSpan.Zero)
    End Function

    'filter
    Private Sub FilterDataGridView(filterType As String)
        Dim currentDate As Date = Date.Today
        Dim startDate As Date

        Select Case filterType
            Case "month"
                startDate = currentDate.AddMonths(-1)
            Case "week"
                startDate = currentDate.AddDays(-7)
            Case "year"
                startDate = currentDate.AddYears(-1)
            Case Else
                ' Handle the case for no filter or unknown filter type
                Exit Sub
        End Select
        Dim totalWorkingTime As TimeSpan
        Dim totalBillCount As Integer = 0
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT * FROM emphistory WHERE date >= @startDate AND date <= @endDate AND ecode = @ecode"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@startDate", startDate)
                    cmd.Parameters.AddWithValue("@endDate", currentDate)
                    cmd.Parameters.AddWithValue("@ecode", empcode)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        DataGridView1.Rows.Clear()
                        While reader.Read
                            Dim loginTime As DateTime = Convert.ToDateTime(reader("login"))
                            Dim logoutTime As DateTime = Convert.ToDateTime(reader("logout"))

                            'Calculate Bill Count
                            totalBillCount += reader("billcount")

                            ' Calculate total working time using the separate function
                            totalWorkingTime += CalculateTotalWorkingTime(loginTime, logoutTime)



                            DataGridView1.Rows.Add(reader.Item("sno"), reader.Item("ecode"), reader.Item("ename"), reader.Item("date"), reader.Item("login"), reader.Item("logout"), reader.Item("billcount"))
                        End While

                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'label product count
        labelPC.Text = totalBillCount

        ' Display total working time in a TextBox (assuming TextBox1 is the name of your TextBox)
        labelWH.Text = String.Format("{0:%d} days, {0:%h} hours, {0:%m} minutes", totalWorkingTime)

    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        FilterDataGridView(ComboBox1.Text)
    End Sub


    'manage salary
    Private Sub button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            ' Assuming TextBox1 is the name of the TextBox containing the total working hours
            Dim totalWorkingHoursText As String = labelWH.Text

            ' Prompt the user to enter the hourly rate
            Dim hourlyRateString As String = InputBox("Enter the hourly wages :", "Hourly wages", "0.00")

            ' Convert the user-entered hourly rate to a decimal
            Dim hourlyRate As Decimal
            If Decimal.TryParse(hourlyRateString, hourlyRate) Then
                ' Assuming the working hours are in the format "X days, Y hours, Z minutes"
                Dim totalWorkingTimeSpan As TimeSpan = ParseWorkingHours(totalWorkingHoursText)

                ' Calculate total salary
                Dim totalSalary As Decimal = CDec(totalWorkingTimeSpan.TotalHours) * hourlyRate

                ' Display the total salary
                MessageBox.Show("Total Salary :Rs." & totalSalary, "Total Salary", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Invalid hourly rate entered. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function ParseWorkingHours(workingHoursText As String) As TimeSpan
        Dim regex As New Regex("(\d+) days, (\d+) hours, (\d+) minutes")
        Dim match As Match = regex.Match(workingHoursText)

        If match.Success Then
            Dim days As Integer = Integer.Parse(match.Groups(1).Value)
            Dim hours As Integer = Integer.Parse(match.Groups(2).Value)
            Dim minutes As Integer = Integer.Parse(match.Groups(3).Value)

            ' Create a TimeSpan based on parsed values
            Return New TimeSpan(days, hours, minutes, 0)
        Else
            ' Return TimeSpan.Zero if the format doesn't match
            Return TimeSpan.Zero
        End If
    End Function
End Class