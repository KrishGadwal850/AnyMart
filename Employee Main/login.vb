Imports System.Globalization
Imports System.Security.Claims
Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient

Public Class login
    Dim connectionString As String = "Server=localhost;Database=inventory;User ID=root;Password=;Convert Zero Datetime=True"
    Dim connection As New MySqlConnection(connectionString)
    Dim code As Integer

    Private Sub LogIn(empCode As Integer, name As String)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' SQL query to insert login record
                Dim loginQuery As String = "INSERT INTO emphistory (ecode, ename, login, date) VALUES (@empcode, @empname, @login, @date)"

                Using command As New MySqlCommand(loginQuery, connection)
                    ' Add parameters to the query
                    command.Parameters.AddWithValue("@empcode", empCode)
                    command.Parameters.AddWithValue("@empname", name)
                    command.Parameters.AddWithValue("@login", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))
                    command.Parameters.AddWithValue("@date", DateTime.Today)

                    ' Execute the query
                    command.ExecuteNonQuery()

                    MessageBox.Show("Logged in successfully!")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error logging in: " & ex.Message)
        End Try
    End Sub

    Private Sub checkLog_Click(sender As Object, e As EventArgs) Handles checklog.Click
        username.Text = "admin"
        password.Text = "admin1"
        Try
            If AuthenticateUser() Then
                ' Successfully authenticated
                Dim role As String = GetUserRole(username.Text.Trim())
                code = getCode(username.Text.Trim())

                Dim name As String = GetUserName(code)

                If role = "employee" Then
                    'MsgBox(code)
                    ' Open the Employee Home form
                    Dim employeeHomeForm As New Employee_Home(code)
                    employeeHomeForm.Show()
                    LogIn(code, name)
                    Me.Hide()
                ElseIf role = "admin" Then
                    'Dim adminForm As New admin(code)
                    'adminForm.Show()
                    'LogIn(code, name)
                    'Me.Hide()
                Else
                    MessageBox.Show("Invalid role for the user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ' Authentication failed
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function AuthenticateUser() As Boolean
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT COUNT(*) FROM log WHERE username = @username AND password = @password"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@username", username.Text.Trim())
                    cmd.Parameters.AddWithValue("@password", password.Text.Trim())

                    Dim result As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return result > 0
                End Using
            End Using
        Catch ex As Exception
            ' Log the exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    ' Add a method to hash passwords
    Private Function HashPassword(password As String) As String
        Using sha256 As SHA256 = sha256.Create()
            Dim hashedBytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim stringBuilder As New StringBuilder()

            For Each b As Byte In hashedBytes
                stringBuilder.Append(b.ToString("x2"))
            Next

            Return stringBuilder.ToString()
        End Using
    End Function

    Private Function GetUserRole(username As String) As String
        Try
            connection.Open()

            Dim query As String = "SELECT role FROM log WHERE username = @username"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@username", username)

                Dim role As Object = cmd.ExecuteScalar()
                If role IsNot Nothing Then
                    Return role.ToString()
                Else
                    Return String.Empty
                End If
            End Using
        Finally
            connection.Close()
        End Try
        Return String.Empty
    End Function
    Private Function GetUserName(ecode As String) As String
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT ename FROM employee WHERE ecode = @ecode"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@ecode", ecode)

                    Dim name As Object = cmd.ExecuteScalar()
                    If name IsNot Nothing Then
                        Return name.ToString()
                    Else
                        Return String.Empty
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return String.Empty
    End Function

    Private Function getCode(username As String) As Integer
        Try
            connection.Open()

            Dim query As String = "SELECT * FROM log WHERE username = @username"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@username", username)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    Return CDec(reader.Item("code"))
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching user data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            connection.Close()
        End Try
        Return -1
    End Function
End Class