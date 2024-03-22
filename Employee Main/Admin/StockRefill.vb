Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Relational

Public Class StockRefill

    Dim connectionString As String = "Server=localhost;Database=inventory;Uid=root;Pwd=;Convert Zero Datetime=True"

    Dim i As Integer

    'Data Grid View Loader
    Public Sub loadRecord()
        DataGridView1.Rows.Clear()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT * FROM stockrefill", conn)
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            DataGridView1.Rows.Add(dr.Item("code"), dr.Item("pname"), dr.Item("type"), dr.Item("category"), dr.Item("status"), dr.Item("date"))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("AA Gaya Error")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Form Reset
    Private Sub formClear()
        txt_code.Clear()
        txt_pname.Clear()
        txt_type.Clear()
        txt_cat.Clear()
        combo_dof.Text = Date.Today
        combo_status.Text = ""
    End Sub

    'Cell Click Event

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        txt_code.Text = DataGridView1.CurrentRow.Cells(0).Value
        txt_pname.Text = DataGridView1.CurrentRow.Cells(1).Value
        txt_type.Text = DataGridView1.CurrentRow.Cells(2).Value
        txt_cat.Text = DataGridView1.CurrentRow.Cells(3).Value
        combo_status.Text = DataGridView1.CurrentRow.Cells(4).Value
        combo_dof.Text = DataGridView1.CurrentRow.Cells(5).Value
    End Sub

    Private Sub StockRefill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadRecord()
        formClear()
    End Sub

    Private Function existsInStock() As Boolean
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT * FROM stock WHERE `code`=@code AND `pname`=@pname AND `type`=@type AND `category`=@category", conn)
                    cmd.Parameters.AddWithValue("@code", txt_code.Text)
                    cmd.Parameters.AddWithValue("@pname", txt_pname.Text)
                    cmd.Parameters.AddWithValue("@type", txt_type.Text)
                    cmd.Parameters.AddWithValue("@category", txt_cat.Text)

                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            Return True
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

    Private Function existsInStockRefill() As Boolean
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT * FROM stockrefill WHERE `code`=@code", conn)
                    cmd.Parameters.AddWithValue("@code", txt_code.Text)

                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            Return True
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False

    End Function

    'clear button
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        formClear()
    End Sub


    'search
    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        DataGridView1.Rows.Clear()
        If TextBox6.Text.Trim = "" Then
            loadRecord()
        End If
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand("SELECT * FROM stockrefill WHERE code = @searchText OR pname = @searchText OR status = @searchText", conn)
                    cmd.Parameters.AddWithValue("@searchText", TextBox6.Text)

                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            DataGridView1.Rows.Add(dr.Item("code"), dr.Item("pname"), dr.Item("type"), dr.Item("category"), dr.Item("status"), dr.Item("date"))

                            txt_code.Text = dr.Item("code")
                            txt_pname.Text = dr.Item("pname")
                            txt_type.Text = dr.Item("type")
                            txt_cat.Text = dr.Item("category")
                            combo_status.Text = dr.Item("status")
                            combo_dof.Text = dr.Item("date")
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'delete code
    Private Sub handleDelete()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand("DELETE FROM `stockrefill` WHERE `code`=@code", conn)
                    cmd.Parameters.AddWithValue("@code", CDec(txt_code.Text))

                    Dim i As Integer = cmd.ExecuteNonQuery()
                    If i > 0 Then
                        MessageBox.Show("Refill Deleted Successful", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        formClear()
                    Else
                        MessageBox.Show("Refill Deletion Unsuccessful", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End Using
            End Using
            formClear()
        Catch ex As Exception
            MessageBox.Show("Select Values Properly", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            loadRecord()
        End Try
    End Sub

    'delete button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("Confirm To Delete", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            handleDelete()
        End If
    End Sub

    Private Sub UpdateStockQuantity(quantityToAdd As Integer)
        Try
            ' Open a connection to the MySQL database
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Define your SQL query to update the quantity
                Dim query As String = "UPDATE stock SET quantity = quantity + @quantityToAdd, pprice = ((sprice - (sprice * (discount/100))) - (mprice + (mprice * (tax/100)))) * (quantity)  where code = @code"

                Using cmd As New MySqlCommand(query, conn)
                    ' Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@quantityToAdd", quantityToAdd)
                    cmd.Parameters.AddWithValue("@code", txt_code.Text)

                    ' Execute the SQL command
                    cmd.ExecuteNonQuery()
                End Using

                query = "DELETE FROM stockrefill WHERE code = @code"
                Using cmd As New MySqlCommand(query, conn)
                    ' Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@code", txt_code.Text)

                    ' Execute the SQL command
                    cmd.ExecuteNonQuery()
                End Using


                MessageBox.Show("Quantity updated successfully.")
            End Using
            formClear()
        Catch ex As Exception
            ' Handle any errors
            MessageBox.Show("Error: " & ex.Message)
        End Try
        loadRecord()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Parse the quantity value from the text box
        Dim quantityToAdd As Integer
        If Integer.TryParse(txt_qty.Text, quantityToAdd) And existsInStock() Then
            ' Call the function to update the stock quantity
            UpdateStockQuantity(quantityToAdd)
        Else
            MessageBox.Show("Please enter a valid quantity or may be it is not available in stock table")
        End If
    End Sub



    'Updation
    Private Sub handleUpdate()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                If (existsInStock() = True) And (existsInStockRefill() = True) Then
                    Using cmd As New MySqlCommand("UPDATE `stockrefill` SET `status`=@status,`date`=@date WHERE `code`=@code", conn)
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("@code", CDec(txt_code.Text))
                        cmd.Parameters.AddWithValue("@status", combo_status.Text)
                        cmd.Parameters.AddWithValue("@date", CDate(combo_dof.Text))

                        Dim i As Integer = cmd.ExecuteNonQuery()
                        If i > 0 Then
                            MessageBox.Show("Refill Updation Successful", "Manage Stock Refill", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            formClear()
                        Else
                            MessageBox.Show("Stock Updation Unsuccessful", "Manage Stock Refill", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End Using
                Else
                    MessageBox.Show("Stock Updation Failed" + vbNewLine + "Stock Is Not Present In One Of The Table", "Manage Stock Refill", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
            formClear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            loadRecord()
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Confirm to update", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            handleUpdate()
        End If
    End Sub
End Class