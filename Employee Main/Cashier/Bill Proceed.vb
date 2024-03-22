Imports MySql.Data.MySqlClient
Imports Mysqlx
Imports Org.BouncyCastle.Asn1.X509
Imports System.Drawing.Printing

Public Class Bill_Proceed

    'Dim conn As New MySqlConnection("server=localhost;port=3306;username=root;password=;database=inventory;Convert Zero Datetime=True")
    Dim dr As MySqlDataReader
    Dim cmd As MySqlCommand
    Dim WithEvents pd As New PrintDocument
    Dim ppd As New PrintPreviewDialog
    Dim longPaper As Integer
    Dim connectionString As String = "Server=localhost;Database=inventory;Uid=root;Pwd=;"
    Dim cartNo As String
    Dim empcode As Integer
    Public Sub New(cart As String, ecode As Integer)
        InitializeComponent()
        cartNo = cart
        empcode = ecode
        Label14.Text = ecode
        LoadData(cartNo)
    End Sub
    Private Sub LoadData(cartNo As String)
        Dim connection As New MySqlConnection(connectionString)

        Try
            connection.Open()
            cmd = New MySqlCommand("Select * FROM customercart WHERE cartno = @cartno", connection)
            cmd.Parameters.AddWithValue("@cartno", cartNo)

            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add(dr.Item("pcode"), dr.Item("pname"), dr.Item("type"), dr.Item("quantity"), dr.Item("unit"), dr.Item("price"))
            End While
        Catch ex As Exception
            MessageBox.Show("Error fetching data from customercart: " & ex.Message)
        Finally
            connection.Close()
            dr.Close()
        End Try
    End Sub


    Private Function GenerateUniqueBillNumber() As Integer
        ' Connect to the database and retrieve the latest bill number
        Dim latestBillNumber As Integer = GetLatestBillNumber()

        ' Increment the latest bill number to generate a new unique bill number
        Dim i As Integer = 0
        While i < 4
            latestBillNumber = latestBillNumber / 10
            i += 1
        End While

        Dim newBillNumber As Integer = latestBillNumber + 1

        ' Get the current year
        Dim currentYear As Integer = DateTime.Now.Year

        Dim BillNumber As Integer = (newBillNumber * 10000) + currentYear

        ' Update the database with the new bill number
        UpdateDatabase(BillNumber)

        ' Return the new bill number as a string with the current year
        Return BillNumber
    End Function

    Private Function GetLatestBillNumber() As Integer
        Dim query As String = "SELECT MAX(billno) FROM customerpurchases"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                connection.Open()
                Dim result As Object = command.ExecuteScalar()

                If result IsNot DBNull.Value Then
                    Return Convert.ToDecimal(result)
                Else
                    Return 0 ' Return 0 if no bill number is found (e.g., no records in the table)
                End If
            End Using
        End Using
    End Function

    Private Sub UpdateDatabase(newBillNumber As Integer)
        Dim query As String = "INSERT INTO customerpurchases (billno) VALUES (@billno)"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@billno", newBillNumber)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub Bill_Proceed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CalculateTotal(cartNo)
        AddLabel.Text = "Mall Vasant Sagar Complex, Thakur Village(E)"
        PnoLabel.Text = "1234xxxxxx"
        DateLabel.Text = Now.Date

        ' Generate a unique bill number and display it
        Dim uniqueBillNumber As String = GenerateUniqueBillNumber()
        billNo.Text = uniqueBillNumber


        ' Call the UpdateTime method when the form loads
        UpdateTime()

        ' Set up a timer to update the time every second
        Dim timer As New Timer()
        timer.Interval = 1000 ' 1000 milliseconds = 1 second
        AddHandler timer.Tick, AddressOf Timer_Tick
        timer.Start()
    End Sub

    'Time
    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        ' Call the UpdateTime method on every timer tick
        UpdateTime()
    End Sub

    Private Sub UpdateTime()
        ' Set the Text property of the TimeLabel to the current time
        TimeLabel.Text = DateTime.Now.ToShortTimeString()
    End Sub



    Private Sub CalculateTotal(cartNo As String)
        Dim connection As New MySqlConnection(connectionString)
        Try
            connection.Open()

            Dim query As String = "SELECT SUM(quantity * price) AS TotalAmount FROM customercart WHERE cartNo = " & cartNo
            Dim command As New MySqlCommand(query, connection)

            Dim totalAmount As Object = command.ExecuteScalar()

            If totalAmount IsNot DBNull.Value AndAlso totalAmount IsNot Nothing Then
                TLabel.Text = Convert.ToDecimal(totalAmount)
            Else
                TLabel.Text = "N/A"
            End If
        Catch ex As Exception
        Finally
            connection.Close()
        End Try
    End Sub


    Private Sub txt_phone_TextChanged(sender As Object, e As EventArgs) Handles txt_phone.TextChanged
        Dim phone As String = txt_phone.Text.Trim()

        If String.IsNullOrEmpty(phone) Then
            ' Clear txt_cname if txt_phone is empty
            txt_cname.Text = ""
            Return
        End If

        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Check if the phone number exists in the customer table
            Dim selectQuery As String = "SELECT cname FROM customer WHERE phone = @phone"
            Using selectCommand As New MySqlCommand(selectQuery, connection)
                selectCommand.Parameters.AddWithValue("@phone", phone)
                Dim result As Object = selectCommand.ExecuteScalar()

                If result IsNot Nothing Then
                    ' Phone number exists, set the txt_cname value
                    txt_cname.Text = result.ToString()
                Else
                    ' Phone number does not exist, clear txt_cname
                    txt_cname.Text = ""
                End If
            End Using
        End Using
    End Sub

    Private Function InsertOrUpdateCustomer() As Boolean
        Dim phone As String = txt_phone.Text.Trim()
        Dim cname As String = txt_cname.Text.Trim()

        If String.IsNullOrEmpty(phone) Then
            MessageBox.Show("Please enter a phone number.")
            Return False
        End If
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Check if the phone number exists in the customer table
                Dim selectQuery As String = "SELECT cname FROM customer WHERE phone = @phone"
                Using selectCommand As New MySqlCommand(selectQuery, connection)
                    selectCommand.Parameters.AddWithValue("@phone", phone)
                    Dim result As Object = selectCommand.ExecuteScalar()

                    If result IsNot Nothing Then
                        ' Phone number exists, update the cname
                        Dim updateQuery As String = "UPDATE customer SET cname = @cname WHERE phone = @phone"
                        Dim updateCommand As New MySqlCommand(updateQuery, connection)
                        updateCommand.Parameters.AddWithValue("@cname", cname)
                        updateCommand.Parameters.AddWithValue("@phone", phone)
                        updateCommand.ExecuteNonQuery()

                    Else
                        ' Phone number does not exist, insert a new record
                        Dim insertQuery As String = "INSERT INTO customer (phone, cname) VALUES (@phone, @cname)"
                        Dim insertCommand As New MySqlCommand(insertQuery, connection)
                        insertCommand.Parameters.AddWithValue("@phone", CDec(phone))
                        insertCommand.Parameters.AddWithValue("@cname", cname.ToString())
                        insertCommand.ExecuteNonQuery()
                    End If
                End Using
            End Using

            MessageBox.Show("Operation completed successfully.")
            Return True
        Catch ex As Exception
            MessageBox.Show("Error Handling Records")
            Return False
        End Try
    End Function

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If InsertOrUpdateCustomer() Then
            Dim payment As New payment(cartNo, billNo.Text, txt_phone.Text, empcode)
            payment.Show()
            Me.Close()
        End If
    End Sub
End Class