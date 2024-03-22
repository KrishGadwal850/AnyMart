Imports System.Text
Imports MySql.Data.MySqlClient
Imports Mysqlx

Public Class EmployeeDetails

    Private connectionString As String = "Server=localhost;Database=inventory;Uid=root;Pwd=;Convert Zero Datetime=True"

    Dim i As Integer

    'Data Grid View Loader
    Function GetFormattedDate(dateValue As Object) As String
        Dim formattedDate As String = String.Empty

        If Not IsDBNull(dateValue) AndAlso DateTime.TryParse(dateValue.ToString(), Nothing) Then
            formattedDate = Convert.ToDateTime(dateValue).ToString("yyyy-MM-dd")
        End If

        Return formattedDate
    End Function
    Public Sub loadRecord()
        DataGridView1.Rows.Clear()
        Try
            Using connection As New MySqlConnection(connectionString)

                connection.Open()

                Using cmd As New MySqlCommand("SELECT * FROM employee", connection)
                    Using dr As MySqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            ' Format dates for better readability
                            Dim doj As String = If(dr.IsDBNull(dr.GetOrdinal("doj")), String.Empty, GetFormattedDate(dr("doj")))

                            Dim dob As String = If(dr.IsDBNull(dr.GetOrdinal("dob")), String.Empty, GetFormattedDate(dr("dob")))

                            Dim dol As String = If(dr.IsDBNull(dr.GetOrdinal("dol")), String.Empty, GetFormattedDate(dr("dol")))

                            DataGridView1.Rows.Add(dr("ecode"), dr("ename"), dr("address"), dr("city"), dob, dr("phone"), dr("email"), doj, dr("status"), dol)
                        End While
                    End Using
                End Using

            End Using

        Catch ex As Exception
            MessageBox.Show("Error occurred while loading records.")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EmployeeDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadRecord()
        formClear()
        uniqueCode()
    End Sub

    'Form Reset
    Private Sub formClear()
        txt_code.Clear()
        txt_user.Clear()
        txt_name.Clear()
        txt_pass.Clear()
        txt_address.Clear()
        txt_city.Clear()
        txt_email.Clear()
        txt_phone.Clear()
        txt_status.Clear()
        txt_dol.Text = Date.Today
        txt_dob.Text = Date.Today
        txt_doj.Text = Date.Today
        txt_role.Text = "employee"

        uniqueCode()
        txt_status.Text = "hired"

    End Sub

    'Clear Button
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        formClear()
    End Sub


    'Searching
    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        DataGridView1.Rows.Clear()

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Use parameterized query to prevent SQL injection
                Dim query As String = "SELECT * FROM employee WHERE ecode LIKE @searchText OR ename LIKE @searchText OR status LIKE @searchText"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@searchText", "%" & txt_search.Text & "%")

                    Using dr As MySqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            ' Format dates for better readability
                            Dim doj As String = If(dr.IsDBNull(dr.GetOrdinal("doj")), String.Empty, Convert.ToDateTime(dr("doj")).ToString("yyyy-MM-dd"))
                            Dim dol As String = If(dr.IsDBNull(dr.GetOrdinal("dol")), String.Empty, Convert.ToDateTime(dr("dol")).ToString("yyyy-MM-dd"))

                            DataGridView1.Rows.Add(dr("ecode"), dr("ename"), dr("address"), dr("city"), dr("dob"), dr("phone"), dr("email"), doj, dr("status"), dol)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error occurred while searching records.")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            formClear()
            Using connection2 As New MySqlConnection(connectionString)
                connection2.Open()
                ' Use parameterized query to prevent SQL injection
                Dim query As String = "SELECT * FROM employee WHERE ecode LIKE @searchText OR ename LIKE @searchText OR status LIKE @searchText"
                Using cmd As New MySqlCommand(query, connection2)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@searchText", "%" & txt_search.Text & "%")

                    Using dr As MySqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            ' Format dates for better readability
                            Dim doj As String = If(dr.IsDBNull(dr.GetOrdinal("doj")), String.Empty, Convert.ToDateTime(dr("doj")).ToString("yyyy-MM-dd"))
                            Dim dob As String = If(dr.IsDBNull(dr.GetOrdinal("dob")), String.Empty, Convert.ToDateTime(dr("dob")).ToString("yyyy-MM-dd"))
                            Dim dol As String = If(dr.IsDBNull(dr.GetOrdinal("dol")), String.Empty, Convert.ToDateTime(dr("dol")).ToString("yyyy-MM-dd"))

                            txt_code.Text = dr("ecode")
                            txt_name.Text = dr("ename")
                            txt_address.Text = dr("address")
                            txt_city.Text = dr("city")
                            txt_dob.Text = dob
                            txt_phone.Text = dr("phone")
                            txt_email.Text = dr("email")
                            txt_doj.Text = doj
                            txt_status.Text = dr("status")
                            txt_dol.Text = dol
                        End While
                    End Using

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error occurred while searching records for employee text Boxes.")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Using connection3 As New MySqlConnection(connectionString)
                connection3.Open()
                ' Use parameterized query to prevent SQL injection
                Dim query As String = "SELECT * FROM log WHERE code LIKE @searchText"
                Using cmd As New MySqlCommand(query, connection3)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@searchText", txt_code.Text)


                    Using dr As MySqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            txt_user.Text = dr("username")
                            txt_pass.Text = dr("password")
                            txt_role.Text = dr("role")
                        End While
                    End Using

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error occurred while searching records for Log text Boxes.")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    'Adding Code
    Private Function GenerateUniqueUsername(employeeCode As String) As String
        Return "user_" & employeeCode
    End Function
    Private Function GenerateUniquePassword() As String
        ' Define the characters to use in the password
        Dim chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"

        ' Set the length of the password
        Dim passwordLength As Integer = 8

        ' Use a StringBuilder to efficiently build the password
        Dim passwordBuilder As New StringBuilder()

        ' Use a random number generator to select characters from the pool
        Dim random As New Random()

        ' Build the password by randomly selecting characters
        For i As Integer = 1 To passwordLength
            Dim randomIndex As Integer = random.Next(0, chars.Length)
            passwordBuilder.Append(chars(randomIndex))
        Next

        ' Convert StringBuilder to String and return the generated password
        Return passwordBuilder.ToString()
    End Function

    Private Sub uniqueCode()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Retrieve the maximum existing code from the employee table
                Dim maxCodeQuery As String = "SELECT MAX(ecode) FROM employee"
                Using maxCodeCommand As New MySqlCommand(maxCodeQuery, connection)
                    Dim maxCode As Object = maxCodeCommand.ExecuteScalar()

                    ' If there are no existing records, set the code to 1; otherwise, increment the maximum code
                    Dim newCode As Integer = If(maxCode IsNot DBNull.Value, CInt(maxCode) + 1, 1)

                    ' Display the generated code
                    txt_code.Text = newCode.ToString()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Unique code Error: " & ex.Message)
        End Try
    End Sub

    'handle hiring and firing
    Public Sub handleAdd()

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()


                ' Insert into employee table
                Dim employeeQuery As String = "INSERT INTO employee (ecode, ename, address, city, dob,phone,email, doj,status) VALUES (@ecode, @ename, @address, @city, @dob,@phone,@email, @doj,@status)"
                Using employeeCommand As New MySqlCommand(employeeQuery, connection)

                    employeeCommand.Parameters.Clear()

                    employeeCommand.Parameters.AddWithValue("@ecode", Integer.Parse(txt_code.Text))

                    employeeCommand.Parameters.AddWithValue("@ename", txt_name.Text)

                    employeeCommand.Parameters.AddWithValue("@address", txt_address.Text)

                    employeeCommand.Parameters.AddWithValue("@city", txt_city.Text)

                    employeeCommand.Parameters.AddWithValue("@dob", DateTime.Parse(txt_dob.Text).ToString("yyyy-MM-dd"))

                    employeeCommand.Parameters.AddWithValue("@phone", CDec(txt_phone.Text))

                    employeeCommand.Parameters.AddWithValue("@email", txt_email.Text)

                    employeeCommand.Parameters.AddWithValue("@doj", DateTime.Parse(txt_doj.Text).ToString("yyyy-MM-dd"))

                    employeeCommand.Parameters.AddWithValue("@status", txt_status.Text)

                    employeeCommand.ExecuteNonQuery()
                End Using

                ' Generate unique username and password
                Dim username As String = GenerateUniqueUsername(txt_code.Text)
                Dim password As String = GenerateUniquePassword()

                ' Insert into log table
                Dim logQuery As String = "INSERT INTO log (username, password, code, role) VALUES (@username, @password, @code,@role)"
                Using logCommand As New MySqlCommand(logQuery, connection)
                    logCommand.Parameters.Clear()
                    logCommand.Parameters.AddWithValue("@username", username)
                    logCommand.Parameters.AddWithValue("@password", password)
                    logCommand.Parameters.AddWithValue("@code", CDec(txt_code.Text))
                    logCommand.Parameters.AddWithValue("@role", txt_role.Text)
                    logCommand.ExecuteNonQuery()
                End Using

                MessageBox.Show("Record inserted successfully. Username: " & username & ", Password: " & password)
            End Using
            formClear()
        Catch ex As Exception
            MessageBox.Show("handle add Error: " & ex.Message)
        Finally
            loadRecord()
        End Try
    End Sub

    'Fired Code
    Private Sub handleFired()
        Try
            Dim employeeCode As Integer = Integer.Parse(txt_code.Text)

            If MessageBox.Show("Are you sure you want to fire this employee?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()
                    Dim query As String = "UPDATE employee SET status = 'fired', dol = DATE(CURDATE()) WHERE ecode = @code"
                    Using command As New MySqlCommand(query, connection)
                        command.Parameters.Clear()
                        command.Parameters.AddWithValue("@code", employeeCode)
                        command.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Employee fired successfully.")
                End Using
                formClear()
                loadRecord()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            loadRecord()
        End Try
    End Sub

    'Add Button
    Private Sub Hire_Click(sender As Object, e As EventArgs) Handles Hire.Click
        Dim result As MsgBoxResult = MsgBox("Want to hire (YES)" + vbNewLine + "Want to fire (NO)", MsgBoxStyle.YesNoCancel + MsgBoxStyle.Information)
        If result = MsgBoxResult.Yes Then
            handleAdd()
        ElseIf result = MsgBoxResult.No Then
            handleFired()
        End If
    End Sub




    'Handle Click
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        txt_code.Text = DataGridView1.CurrentRow.Cells(0).Value
        txt_name.Text = DataGridView1.CurrentRow.Cells(1).Value
        txt_address.Text = DataGridView1.CurrentRow.Cells(2).Value
        txt_city.Text = DataGridView1.CurrentRow.Cells(3).Value
        txt_dob.Text = DataGridView1.CurrentRow.Cells(4).Value
        txt_phone.Text = DataGridView1.CurrentRow.Cells(5).Value
        txt_email.Text = DataGridView1.CurrentRow.Cells(6).Value
        txt_doj.Text = DataGridView1.CurrentRow.Cells(7).Value
        txt_status.Text = DataGridView1.CurrentRow.Cells(8).Value
        txt_dol.Text = DataGridView1.CurrentRow.Cells(9).Value


        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Assuming you have DataGridView1 as your DataGridView control
                If DataGridView1.CurrentRow IsNot Nothing Then
                    Dim selectedCode As String = DataGridView1.CurrentRow.Cells(0).Value.ToString()

                    Using cmd As New MySqlCommand("SELECT * FROM log WHERE code = @code", connection)
                        cmd.Parameters.AddWithValue("@code", selectedCode)

                        Using reader As MySqlDataReader = cmd.ExecuteReader()
                            If reader.Read() Then
                                txt_user.Text = reader.GetString("username")
                                txt_pass.Text = reader.GetString("password")
                            End If
                        End Using
                    End Using
                Else
                    MessageBox.Show("Please select a valid row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        Catch ex As MySqlException
            MessageBox.Show("MySQL Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub





    'Update Code
    Private Sub handleUpdate()
        Try
            Dim employeeCode As Integer = Integer.Parse(txt_code.Text)

            If MessageBox.Show("Are you sure you want to update this employee's record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    ' Update the record in the employee table
                    Dim updateEmployeeQuery As String = "UPDATE employee SET ename = @name, address = @address, city= @city, dob = @dob,phone = @phone,email = @email, doj = @doj,dol = @dol WHERE ecode = @code"
                    Using updateEmployeeCommand As New MySqlCommand(updateEmployeeQuery, connection)

                        updateEmployeeCommand.Parameters.Clear()

                        updateEmployeeCommand.Parameters.AddWithValue("@code", employeeCode)

                        updateEmployeeCommand.Parameters.AddWithValue("@name", txt_name.Text)

                        updateEmployeeCommand.Parameters.AddWithValue("@address", txt_address.Text)

                        updateEmployeeCommand.Parameters.AddWithValue("@city", txt_city.Text)

                        updateEmployeeCommand.Parameters.AddWithValue("@phone", CDec(txt_phone.Text))

                        updateEmployeeCommand.Parameters.AddWithValue("@email", txt_email.Text)

                        updateEmployeeCommand.Parameters.AddWithValue("@dob", DateTime.Parse(txt_dob.Text).ToString("yyyy-MM-dd"))

                        updateEmployeeCommand.Parameters.AddWithValue("@doj", DateTime.Parse(txt_doj.Text).ToString("yyyy-MM-dd"))

                        updateEmployeeCommand.Parameters.AddWithValue("@dol", DateTime.Parse(txt_dol.Text).ToString("yyyy-MM-dd"))

                        updateEmployeeCommand.ExecuteNonQuery()
                    End Using

                    ' Update the record in the log table
                    Dim updateLogQuery As String = "UPDATE log SET username = @username, password = @password,role = @role WHERE code = @code"
                    Using updateLogCommand As New MySqlCommand(updateLogQuery, connection)
                        updateLogCommand.Parameters.Clear()
                        updateLogCommand.Parameters.AddWithValue("@code", employeeCode)
                        updateLogCommand.Parameters.AddWithValue("@username", txt_user.Text)
                        updateLogCommand.Parameters.AddWithValue("@password", txt_pass.Text)
                        updateLogCommand.Parameters.AddWithValue("@password", txt_role.Text)
                        updateLogCommand.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Employee record updated successfully.")
                End Using
                formClear()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            loadRecord()
        End Try
    End Sub

    'Update Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        handleUpdate()
    End Sub

    'Delete Code
    Private Sub handleDelete()
        Try
            Dim employeeCode As Integer = Integer.Parse(txt_code.Text)

            If MessageBox.Show("Are you sure you want to delete this employee?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    ' Delete the record from the employee table
                    Dim deleteEmployeeQuery As String = "DELETE FROM employee WHERE ecode = @code"
                    Using deleteEmployeeCommand As New MySqlCommand(deleteEmployeeQuery, connection)

                        deleteEmployeeCommand.Parameters.Clear()

                        deleteEmployeeCommand.Parameters.AddWithValue("@code", employeeCode)
                        deleteEmployeeCommand.ExecuteNonQuery()
                    End Using

                    ' Delete the record from the log table
                    Dim deleteLogQuery As String = "DELETE FROM log WHERE code = @code"
                    Using deleteLogCommand As New MySqlCommand(deleteLogQuery, connection)
                        deleteLogCommand.Parameters.Clear()
                        deleteLogCommand.Parameters.AddWithValue("@code", employeeCode)
                        deleteLogCommand.ExecuteNonQuery()
                    End Using

                    ' Delete the record from the emphistory table
                    Dim deleteEmpHistoryQuery As String = "DELETE FROM emphistory WHERE ecode = @ecode"
                    Using deleteEmpHistoryCommand As New MySqlCommand(deleteEmpHistoryQuery, connection)
                        deleteEmpHistoryCommand.Parameters.Clear()
                        deleteEmpHistoryCommand.Parameters.AddWithValue("@ecode", employeeCode)
                        deleteEmpHistoryCommand.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Employee deleted successfully.")
                End Using
                formClear()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            loadRecord()
        End Try
    End Sub

    'delete button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        handleDelete()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        'Me.Hide()
        'EmployeeSalary.Show()
    End Sub



    Public Function IsCodeExists(codeToCheck As String) As Boolean
        Dim codeExists As Boolean = False

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT COUNT(*) FROM employee WHERE ecode = @code"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@code", codeToCheck)

                    ' ExecuteScalar returns the first column of the first row in the result set
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    ' If count is greater than 0, the code exists
                    codeExists = (count > 0)
                End Using
            End Using
        Catch ex As Exception
            ' Handle exceptions if needed
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try

        Return codeExists
    End Function

    'Employee History
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim codeToCheck As String = txt_code.Text
        If IsCodeExists(codeToCheck) Then
            Dim emphis As New EmployeeHistory(Integer.Parse(txt_code.Text))
            emphis.Show()
        Else
            MessageBox.Show("Code does not exist in the employee table.")
        End If
    End Sub
End Class