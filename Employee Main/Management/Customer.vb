Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports MySql.Data.MySqlClient
Imports Org.BouncyCastle.Asn1.Cmp

Public Class Customer
    Dim sno As Integer
    Dim connectionString As String = "Server=localhost;Database=inventory;Uid=root;Pwd=;"

    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        Clear()
        loadBills()
        loadCustomer()

    End Sub

    Private Sub Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'DataGridView 
        loadCustomer()
    End Sub

    Sub Clear()
        txtcname.Text = ""
        txt_phone.Text = ""
    End Sub

    Public Sub loadCustomer()
        DataGridView2.Rows.Clear()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT `cname`,`phone` FROM `customer`", conn)
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            DataGridView2.Rows.Add(dr.Item("cname").ToString(), dr.Item("phone").ToString())
                        End While
                    End Using
                End Using
            End Using
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub loadBills()
        DataGridView1.Rows.Clear()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT * FROM `customerbills`", conn)
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            DataGridView1.Rows.Add(dr.Item("billno"), dr.Item("cashier"), dr.Item("phone"), dr.Item("customer"), dr.Item("billdate"), dr.Item("time"), dr.Item("total"), dr.Item("paymentmode"))
                        End While
                    End Using
                End Using
            End Using
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then ' Check if the clicked cell is not a header
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            txtcname.Text = selectedRow.Cells(0).Value.ToString() ' Assuming the column index of cname is 0
            txt_phone.Text = selectedRow.Cells(1).Value.ToString() ' Assuming the column index of phone is 1
        End If
    End Sub
    Private Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        Dim name As String = txtcname.Text
        Dim phone As String = txt_phone.Text

        If String.IsNullOrWhiteSpace(name) OrElse String.IsNullOrWhiteSpace(phone) Then
            MessageBox.Show("Please enter both name and phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Check if the phone number already exists
                Dim query As String = "SELECT COUNT(*) FROM customer WHERE phone = @phone"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@phone", phone)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                    If count > 0 Then
                        ' If phone number exists, update the name
                        query = "UPDATE customer SET cname = @name WHERE phone = @phone"
                    Else
                        ' If phone number doesn't exist, insert new record
                        query = "INSERT INTO customer (cname, phone) VALUES (@name, @phone)"
                    End If

                    ' Execute the query
                    cmd.CommandText = query
                    cmd.Parameters.AddWithValue("@name", name)
                    cmd.Parameters.AddWithValue("@phone", phone)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Record added or updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Clear()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            loadCustomer()
            loadBills()
        End Try
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        DataGridView2.Rows.Clear()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT * FROM `customer` WHERE cname LIKE @searchText OR phone LIKE @searchText", conn)
                    cmd.Parameters.AddWithValue("@searchText", "%" & txtsearch.Text & "%")

                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            DataGridView2.Rows.Add(dr.Item("cname"), dr.Item("phone"))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message + " 1")
        End Try

        DataGridView1.Rows.Clear()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT * FROM `customerpurchases` WHERE customer LIKE @searchText OR phone LIKE @searchText", conn)
                    cmd.Parameters.AddWithValue("@searchText", "%" & txtsearch.Text & "%")

                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            DataGridView1.Rows.Add(dr.Item("billno"), dr.Item("cashier").ToString(), dr.Item("phone"), dr.Item("customer"), dr.Item("billdate"), dr.Item("time"), dr.Item("total"), dr.Item("paymentmode"))
                        End While
                    End Using
                End Using
            End Using
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message + " 2")
        Finally
            loadCustomer()
            loadBills()
        End Try
    End Sub

    Private Sub deleteCustomer()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand("DELETE FROM `customer` WHERE phone = @phone", conn)
                    cmd.Parameters.AddWithValue("@phone", txt_phone.Text)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    If i > 0 Then
                        MessageBox.Show("Customer Details Successfully Deleted", "Customer Operations", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Clear()
                    Else
                        MessageBox.Show("Customer Details Not Deleted", "Customer Operations", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
            Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            loadCustomer()
            loadBills()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Confirm To Delete", MsgBoxStyle.Question + vbYesNo, "Confirm") = vbYes Then
            deleteCustomer()
        End If
        loadCustomer()
        loadBills()
    End Sub
End Class