Imports MySql.Data.MySqlClient
Imports System.Net.NetworkInformation
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Mysqlx.XDevAPI.Relational
Imports Mysqlx
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox
Imports System.Data.SqlClient

Public Class Bill_Generator
    Dim empcode As Integer

    Public Sub New(code As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        empcode = code
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Dim connectionString As String = "Server=localhost;Database=inventory;User ID=root;Password=;"
    Dim conn As New MySqlConnection("server=localhost;username=root;password=;database=inventory;Convert Zero Datetime=True")
    Dim i As Integer
    Dim tempQty As Double
    Dim totalQty As Double
    Dim dr As MySqlDataReader
    Dim cmd As MySqlCommand


    'Data Grid View Loader
    Public Sub loadRecord()
        DataGridView1.Rows.Clear()
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT * FROM stock", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add(dr.Item("code"), dr.Item("pname"), dr.Item("type"), dr.Item("category"), dr.Item("quantity"), dr.Item("unit"), dr.Item("sprice"), dr.Item("discount"))
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        Finally
            conn.Close()
            dr.Close()
        End Try
    End Sub

    'Form Reset
    Private Sub formClear()
        txt_code.Clear()
        txt_pname.Clear()
        txt_type.Clear()
        txt_cat.Clear()
        txt_qty.Clear()
        txt_unit.Clear()
        txt_sprice.Clear()
        txt_dis.Clear()
    End Sub

    Private Sub Bill_Generator_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        loadRecord()
        formClear()
        cartNo.Text = GenerateNewCartNumber().ToString()
    End Sub

    'Refill Button
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Refill.ShowDialog()
    End Sub

    'Check Stock Existence
    Private Function existsInStock() As Boolean
        Try
            cmd = New MySqlCommand("SELECT * FROM stock WHERE `code`='" & txt_code.Text & "' AND `pname`='" & txt_pname.Text & "' AND `type`='" & txt_type.Text & "' AND `category`='" & txt_cat.Text & "'", conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dr.Close()
        End Try
        Return False
    End Function

    'Checking Refill Existence
    Private Function existsInStockRefill() As Boolean
        Try
            cmd = New MySqlCommand("SELECT * FROM stockrefill WHERE `code`='" & txt_code.Text & "'", conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dr.Close()
        End Try
        Return False
    End Function

    'Search Box 1
    Private Sub txt_search1_TextChanged(sender As Object, e As EventArgs)
        DataGridView1.Rows.Clear()
        Try
            conn.Open()
            cmd = New MySqlCommand("SELECT * FROM stock WHERE code like '%" & txt_search1.Text & "%' OR pname like '%" & txt_search1.Text & "%'", conn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add(dr.Item("code"), dr.Item("pname"), dr.Item("type"), dr.Item("category"), dr.Item("quantity"), dr.Item("unit"), dr.Item("sprice"), dr.Item("discount"))
            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        Finally
            conn.Close()
            dr.Close()
        End Try
    End Sub

    'DGV 1 Cell Click
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        txt_code.Text = DataGridView1.CurrentRow.Cells(0).Value
        txt_pname.Text = DataGridView1.CurrentRow.Cells(1).Value
        txt_type.Text = DataGridView1.CurrentRow.Cells(2).Value
        txt_cat.Text = DataGridView1.CurrentRow.Cells(3).Value
        txt_qty.Text = DataGridView1.CurrentRow.Cells(4).Value
        txt_unit.Text = DataGridView1.CurrentRow.Cells(5).Value
        txt_sprice.Text = DataGridView1.CurrentRow.Cells(6).Value
        txt_dis.Text = DataGridView1.CurrentRow.Cells(7).Value

        'Variables
        totalQty = CDec(txt_qty.Text)
        txt_qty.Text = 1
    End Sub

    'DGV 2 Cell Click
    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If e.RowIndex >= 0 Then
            ' Get the product code from the selected row in DataGridView2
            Dim productCode As String = DataGridView2.Rows(e.RowIndex).Cells(0).Value.ToString()

            ' Fetch records from the database using the cart number
            Dim cartNumber As String = cartNo.Text.Trim()
            If Not String.IsNullOrEmpty(cartNumber) Then
                FetchRecordsFromDatabase(e.RowIndex, productCode)
            Else
                MessageBox.Show("Please enter a valid Cart Number.")
            End If
        End If
    End Sub

    Private Sub FetchRecordsFromDatabase(ind As Integer, productCode As String)
        Dim connection As New MySqlConnection(connectionString)
        If connection.State <> 1 Then
            connection.Open()
        End If

        Dim query As String = "SELECT * FROM stock WHERE code = @ProductCode"
        Dim cmd As New MySqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@ProductCode", productCode)
        Dim reader As MySqlDataReader = cmd.ExecuteReader
        Try
            If reader.Read() Then
                ' Populate textboxes with the fetched data
                txt_code.Text = reader("code").ToString()
                txt_pname.Text = reader("pname").ToString()
                txt_type.Text = reader("type").ToString()
                txt_cat.Text = reader("category").ToString()
                txt_qty.Text = reader("quantity").ToString()
                txt_unit.Text = reader("unit").ToString()
                txt_sprice.Text = reader("sprice").ToString()
                txt_dis.Text = reader("discount").ToString()

                Dim DGV_qty As String = DataGridView2.Rows(ind).Cells(3).Value.ToString()

                txt_qty.Text = DGV_qty
            Else
                MessageBox.Show("No records found for the specified Cart Number and Product Code.")
            End If

        Catch ex As Exception
            Throw New Exception($"Error executing SQL query: {ex.Message}")
        Finally
            connection.Close()
            reader.Close()
        End Try
    End Sub



    'Total Calculating Code
    Private Function handleTotal() As Boolean
        Try
            Dim total As Double
            total = 0
            For index = 0 To DataGridView2.Rows.Count - 1
                total += DataGridView2.Rows(index).Cells(3).Value * DataGridView2.Rows(index).Cells(5).Value
            Next
            txt_total.Text = total
            Return True
        Catch ex As Exception
            MessageBox.Show("Total Mistake", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function


    'Code -> Product Generator
    Private Sub txt_code_TextChanged_1(sender As Object, e As EventArgs) Handles txt_code.TextChanged
        Try
            If conn.State <> 1 Then
                conn.Open()
            End If
            cmd = New MySqlCommand("SELECT * FROM stock WHERE code='" & txt_code.Text & "'", conn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                'txt_code.Text = dr.Item("code")
                txt_pname.Text = dr.Item("pname")
                txt_type.Text = dr.Item("type")
                txt_cat.Text = dr.Item("category")
                txt_qty.Text = dr.Item("quantity")
                txt_unit.Text = dr.Item("unit")
                txt_sprice.Text = dr.Item("sprice")
                txt_dis.Text = dr.Item("discount")

                'Variables
                totalQty = CDec(txt_qty.Text)
                txt_qty.Text = 1
            Else
                txt_pname.Clear()
                txt_type.Clear()
                txt_cat.Clear()
                txt_qty.Clear()
                txt_unit.Clear()
                txt_sprice.Clear()
                txt_dis.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show("Text Change " + vbNewLine + ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        Finally
            conn.Close()
            dr.Close()
        End Try
    End Sub



    'Proceed Button
    Private Sub ProcessButton_Click(sender As Object, e As EventArgs) Handles ProcessButton.Click
        If DataGridView2.Rows.Count > 0 Then
            If Not String.IsNullOrEmpty(cartNo.Text) Then
                Dim secondForm As New Bill_Proceed(cartNo.Text, empcode)
                secondForm.Show()
            End If
        Else
            MessageBox.Show("Please Add Some Items", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub newCart_Click(sender As Object, e As EventArgs) Handles newCart.Click
        Dim newCartNumber As Integer
        ' Check if cartNoTextBox is empty
        If String.IsNullOrEmpty(cartNo.Text) Then
            ' If empty, create a new cart number
            ' Generate a new cart number and display it in the cartNo TextBox
            newCartNumber = GenerateNewCartNumber()
            cartNo.Text = newCartNumber.ToString()
        Else
            ' If not empty, use the existing cart number
            Dim cartNumber As Integer = Convert.ToInt32(cartNo.Text)

            ' Check if the cart number exists in the customercart table
            If CartExistsInCustomerCart(cartNumber) Then
                newCartNumber = GenerateNewCartNumber()
                cartNo.Text = newCartNumber.ToString()
            End If
        End If


    End Sub

    Private Function CartExistsInCustomerCart(cartNumber As Integer) As Boolean
        ' Function to check if the cart number exists in the customercart table
        Dim connection As New MySqlConnection(connectionString)
        Try
            connection.Open()

            Dim query As String = "SELECT COUNT(*) FROM customercart WHERE cartno = @cartno"
            Dim command As New MySqlCommand(query, connection)
            command.Parameters.AddWithValue("@cartno", cartNumber)

            Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
            Return count > 0

        Catch ex As Exception
            MessageBox.Show("Error checking cart existence in customercart: " & ex.Message)
            Return False
        Finally
            connection.Close()
        End Try
    End Function

    Private Function GenerateNewCartNumber() As Integer
        ' Function to generate a new cart number and insert it into the database
        Dim newCartNumber As Integer = GetNextCartNumber()

        ' Insert the new cart number into the database
        Dim connection As New MySqlConnection(connectionString)
        Try
            connection.Open()
            Dim query As String = "INSERT INTO cart (cartno, empcode) VALUES (@cartno, @empcode)"
            Dim command As New MySqlCommand(query, connection)
            command.Parameters.AddWithValue("@cartno", newCartNumber)
            command.Parameters.AddWithValue("@empcode", 111)
            command.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Error inserting new cart number: " & ex.Message)
        Finally
            connection.Close()
            formClear()
            DataGridView2.Rows.Clear()
        End Try
        Return newCartNumber
    End Function


    Private Function GetNextCartNumber() As Integer
        ' Function to retrieve the next available cart number from the database
        Dim nextCartNumber As Integer = 1

        Dim connection As New MySqlConnection(connectionString)
        Try
            connection.Open()

            Dim query As String = "SELECT MAX(cartno) FROM cart"
            Dim command As New MySqlCommand(query, connection)
            Dim result As Object = command.ExecuteScalar()

            If result IsNot DBNull.Value Then
                nextCartNumber = Convert.ToInt32(result) + 1
            End If
        Catch ex As Exception
            MessageBox.Show("Error retrieving next cart number: " & ex.Message)
        Finally
            connection.Close()
        End Try

        Return nextCartNumber
    End Function

    Private Sub prevbtn_Click(sender As Object, e As EventArgs) Handles prevbtn.Click
        ' Navigate to the previous cart number
        cartNo.Text = GetPreviousCartNumber(cartNo.Text).ToString()
        DisplayCustomerCartData()
        handleTotal()
    End Sub

    Private Sub nextbtn_Click(sender As Object, e As EventArgs) Handles nextbtn.Click
        ' Navigate to the next cart number
        cartNo.Text = GetNextCartNumber(cartNo.Text).ToString()
        DisplayCustomerCartData()
        handleTotal()
    End Sub

    Private Function GetNextCartNumber(currentCart As Integer) As Integer
        ' Function to retrieve the next distinct cart number from the cart table for empcode 111
        Dim connection As New MySqlConnection(connectionString)
        Try
            If connection.State <> 1 Then
                connection.Open()
            End If

            Dim query As String = "SELECT MIN(cartno) FROM cart WHERE empcode = 111 AND cartno > @currentCart"
            Dim command As New MySqlCommand(query, connection)
            command.Parameters.AddWithValue("@currentCart", currentCart)
            Dim result As Object = command.ExecuteScalar()

            If result IsNot DBNull.Value Then
                Return Convert.ToInt32(result)
            Else
                MessageBox.Show("No next cart number found.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error retrieving next cart number: " & ex.Message)
        Finally
            connection.Close()
        End Try

        Return currentCart
    End Function

    Private Function GetPreviousCartNumber(currentCart As Integer) As Integer
        ' Function to retrieve the previous distinct cart number from the cart table for empcode 111
        Dim connection As New MySqlConnection(connectionString)
        Try
            If connection.State <> 1 Then
                connection.Open()
            End If

            Dim query As String = "SELECT MAX(cartno) FROM cart WHERE empcode = 111 AND cartno < @currentCart"
            Dim command As New MySqlCommand(query, connection)
            command.Parameters.AddWithValue("@currentCart", currentCart)

            Dim result As Object = command.ExecuteScalar()

            If result IsNot DBNull.Value Then
                Return Convert.ToInt32(result)
            Else
                MessageBox.Show("No previous cart number found.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error retrieving previous cart number: " & ex.Message)
        Finally
            connection.Close()
        End Try

        Return currentCart
    End Function

    Private Sub DisplayCustomerCartData()
        ' Display data from customercart table in DataGridView2 based on the current cart number

        ' Check if cartNoTextBox is not empty
        If Not String.IsNullOrEmpty(cartNo.Text) Then
            ' Fetch data from customercart table based on the current cart number
            Dim cartNumber As Integer = Convert.ToInt32(cartNo.Text)
            DataGridView2.Rows.Clear()
            Try
                conn.Open()
                cmd = New MySqlCommand("Select * FROM customercart WHERE cartno = @cartno", conn)
                cmd.Parameters.AddWithValue("@cartno", cartNumber)

                dr = cmd.ExecuteReader
                While dr.Read
                    DataGridView2.Rows.Add(dr.Item("pcode"), dr.Item("pname"), dr.Item("type"), dr.Item("quantity"), dr.Item("unit"), dr.Item("price"), dr.Item("discount"))
                End While
            Catch ex As Exception
                MessageBox.Show("Error fetching data from customercart: " & ex.Message)
            Finally
                conn.Close()
                dr.Close()
            End Try
        End If
    End Sub


    'Add button
    Private Sub addProduct_Click(sender As Object, e As EventArgs) Handles addProduct.Click

        If String.IsNullOrEmpty(cartNo.Text) Then
            ' If empty, create a new cart number
            Dim newCartNumber As Integer = GenerateNewCartNumber()
            cartNo.Text = newCartNumber.ToString()
        Else
            ' If not empty, use the existing cart number
            Dim cartNumber As Integer = Convert.ToInt32(cartNo.Text)

            ' Check if the product with the given pcode already exists in the customercart table for the current cart
            Dim pcode As String = txt_code.Text
            If ProductExistsInCustomerCart(cartNumber, pcode) Then
                ' If the product exists, update the existing record by increasing quantity and price
                UpdateProductInCustomerCart(cartNumber, pcode)
            Else
                ' If the product doesn't exist, insert a new record
                InsertProductIntoCustomerCart(cartNumber)
            End If
        End If
    End Sub

    Private Function ProductExistsInCustomerCart(cartNumber As Integer, pcode As String) As Boolean
        ' Function to check if the product with the given pcode already exists in the customercart table for the current cart
        Dim connection As New MySqlConnection(connectionString)
        Try
            connection.Open()

            Dim query As String = "SELECT COUNT(*) FROM customercart WHERE cartno = @cartno AND pcode = @pcode"
            Dim command As New MySqlCommand(query, connection)
            command.Parameters.AddWithValue("@cartno", cartNumber)
            command.Parameters.AddWithValue("@pcode", pcode)

            Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
            Return count > 0
        Catch ex As Exception
            MessageBox.Show("Error checking product existence in customercart: " & ex.Message)
            Return False
        Finally
            connection.Close()
        End Try
    End Function

    Private Sub UpdateProductInCustomerCart(cartNumber As Integer, pcode As String)
        ' Function to update the existing record in customercart by increasing quantity and price
        Dim connection As New MySqlConnection(connectionString)
        Try
            connection.Open()

            Dim productCode As Integer = Integer.Parse(pcode)

            ' Fetch stock quantity for the given product code
            Dim stockQuantity As Integer = GetStockQuantity(productCode, connection)

            ' Fetch current quantity in customercart for the given cart number and product code
            Dim currentQuantity As String = GetCurrentQuantity(cartNumber, productCode, connection)
            If Not Integer.TryParse(currentQuantity, Nothing) Then
                MessageBox.Show("Please enter a valid integer for the quantity.")
                Return
            End If

            Dim newCurrQuantity As Integer = Integer.Parse(currentQuantity)

            Dim enteredQuantity As String = txt_qty.Text

            If Not Integer.TryParse(enteredQuantity, Nothing) Then
                MessageBox.Show("Please enter a valid integer for the quantity.")
                Return
            End If

            Dim newEnterQuantity As Integer = Integer.Parse(enteredQuantity)

            Dim totalCustomerQty As Integer = newCurrQuantity + newEnterQuantity

            ' Check if the new quantity is valid
            If totalCustomerQty <= 0 Then
                MessageBox.Show("Quantity must be greater than zero.")
                Return
            ElseIf totalCustomerQty > stockQuantity Then
                MessageBox.Show("Quantity cannot exceed the available stock quantity.")
                Return
            Else
                Dim query As String = "UPDATE customercart SET quantity = @quantity, price = price + @price " &
                                  "WHERE cartno = @cartno AND pcode = @pcode"

                Dim command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@cartno", cartNumber)
                command.Parameters.AddWithValue("@pcode", productCode)
                command.Parameters.AddWithValue("@quantity", Convert.ToInt32(totalCustomerQty))
                command.Parameters.AddWithValue("@price", Convert.ToDecimal(txt_sprice.Text))

                command.ExecuteNonQuery()
                formClear()
            End If

        Catch ex As Exception
            MessageBox.Show("Error updating product in customercart: " & ex.Message)
        Finally
            connection.Close()
            DisplayCustomerCartData()
            handleTotal()
        End Try
    End Sub


    Private Sub InsertProductIntoCustomerCart(cartNumber As Integer)
        ' Function to insert a new record into customercart
        Dim connection As New MySqlConnection(connectionString)
        Try
            connection.Open()

            Dim productCode As Integer = Integer.Parse(txt_code.Text)

            ' Fetch stock quantity for the given product code
            Dim stockQuantity As Integer = GetStockQuantity(productCode, connection)

            Dim currentQuantity As String = txt_qty.Text

            If Not Integer.TryParse(currentQuantity, Nothing) Then
                MessageBox.Show("Please enter a valid integer for the quantity.")
                Return
            End If

            Dim newQuantity As Integer = Integer.Parse(currentQuantity)

            ' Check if the new quantity is valid
            If newQuantity <= 0 Then
                MessageBox.Show("Quantity must be greater than zero.")
                Return
            ElseIf newQuantity > stockQuantity Then
                MessageBox.Show("Quantity cannot exceed the available stock quantity.")
                Return
            Else
                Dim query As String = "INSERT INTO customercart (cartno, pcode, pname, type, quantity, unit, price,discount) " & "VALUES (@cartno, @pcode, @pname, @type, @quantity,@unit,@price,@discount)"

                Dim command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@cartno", cartNumber)
                command.Parameters.AddWithValue("@pcode", txt_code.Text)
                command.Parameters.AddWithValue("@pname", txt_pname.Text)
                command.Parameters.AddWithValue("@type", txt_type.Text)
                command.Parameters.AddWithValue("@quantity", Convert.ToInt32(newQuantity))
                command.Parameters.AddWithValue("@unit", txt_unit.Text)
                command.Parameters.AddWithValue("@price", Convert.ToDecimal(txt_sprice.Text))
                command.Parameters.AddWithValue("@discount", Convert.ToDecimal(txt_dis.Text))

                command.ExecuteNonQuery()
                formClear()
            End If


        Catch ex As Exception
            MessageBox.Show("Error inserting product into customercart: " & ex.Message)
        Finally
            connection.Close()
            DisplayCustomerCartData()
            handleTotal()
        End Try
    End Sub


    'Deleting cart items or Whole cart
    Private Sub btn_del_Click(sender As Object, e As EventArgs) Handles btn_del.Click
        Dim result As DialogResult = MessageBox.Show("Do you want to delete the whole cart (YES), want to delete the selected item (No)", "Delete Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Delete the whole cart
            Dim cartNumber As String = cartNo.Text.Trim()

            If Not String.IsNullOrEmpty(cartNumber) Then
                Try
                    DeleteWholeCart(cartNumber)
                Catch ex As Exception
                    MessageBox.Show($"An error occurred while deleting the whole cart: {ex.Message}")
                End Try
            Else
                MessageBox.Show("Please enter a valid Cart Number.")
            End If
        ElseIf result = DialogResult.No Then
            ' Delete the selected item
            Dim productCode As String = ""

            If DataGridView2.SelectedCells.Count > 0 Then
                Dim selectedRowIndex As Integer = DataGridView2.SelectedCells(0).RowIndex
                productCode = DataGridView2.Rows(selectedRowIndex).Cells(0).Value.ToString()
            End If

            If Not String.IsNullOrEmpty(productCode) Then
                Try
                    DeleteSelectedItem(cartNo.Text.Trim(), productCode)
                Catch ex As Exception
                    MessageBox.Show($"An error occurred while deleting the selected item: {ex.Message}")
                End Try
            Else
                MessageBox.Show("Please select an item to delete.")
            End If
        End If
    End Sub

    Private Sub DeleteWholeCart(cartNumber As String)
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "DELETE FROM customercart WHERE cartno = @CartNumber"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@CartNumber", cartNumber)

                cmd.ExecuteNonQuery()

                MessageBox.Show("Whole cart deleted successfully.")
                formClear()
                DisplayCustomerCartData()
                handleTotal()
            End Using
        End Using
    End Sub

    Private Sub DeleteSelectedItem(cartNumber As String, productCode As String)
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "DELETE FROM customercart WHERE cartno = @CartNumber AND pcode = @ProductCode"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@CartNumber", cartNumber)
                cmd.Parameters.AddWithValue("@ProductCode", productCode)

                cmd.ExecuteNonQuery()

                MessageBox.Show("Selected item deleted successfully.")
                formClear()
                DisplayCustomerCartData()
                handleTotal()
            End Using
        End Using
    End Sub

    'Update Button
    Private Sub btn_upd_Click(sender As Object, e As EventArgs) Handles btn_upd.Click
        Dim result As DialogResult = MessageBox.Show("Do you want to update the selected record?", "Update Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Update the selected record
            Dim cartNumber As String = cartNo.Text.Trim()
            Dim productCode As String = ""

            If DataGridView2.SelectedCells.Count > 0 Then
                Dim selectedRowIndex As Integer = DataGridView2.SelectedCells(0).RowIndex
                productCode = DataGridView2.Rows(selectedRowIndex).Cells(0).Value.ToString()
            End If

            If Not String.IsNullOrEmpty(cartNumber) AndAlso Not String.IsNullOrEmpty(productCode) Then
                Try
                    UpdateRecord(cartNumber, productCode)
                Catch ex As Exception
                    MessageBox.Show($"An error occurred while updating the record: {ex.Message}")
                End Try
            Else
                MessageBox.Show("Please select a record to update.")
            End If
        End If
    End Sub

    Private Sub UpdateRecord(cartNumber As String, productCode As String)
        Dim connection As New MySqlConnection(connectionString)
        connection.Open()

        ' Fetch stock quantity for the given product code
        Dim stockQuantity As Integer = GetStockQuantity(productCode, connection)

        ' Fetch current quantity in customercart for the given cart number and product code
        Dim currentQuantity As String = txt_qty.Text

        ' Ask user for the new quantity
        'Dim newQuantityStr As String = InputBox($"Enter the new quantity (Current: {currentQuantity}, Stock: {stockQuantity}):", "Update Quantity", currentQuantity.ToString())

        If Not Integer.TryParse(currentQuantity, Nothing) Then
            MessageBox.Show("Please enter a valid integer for the quantity.")
            Return
        End If

        Dim newQuantity As Integer = Integer.Parse(currentQuantity)

        ' Check if the new quantity is valid
        If newQuantity <= 0 Then
            MessageBox.Show("Quantity must be greater than zero.")
            Return
        ElseIf newQuantity > stockQuantity Then
            MessageBox.Show("Quantity cannot exceed the available stock quantity.")
            Return
        Else
            ' Update the quantity in customercart
            Dim query As String = "UPDATE customercart SET quantity = @quantity WHERE cartno = @cartno AND pcode = @pcode"

            Dim cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@quantity", newQuantity)
            cmd.Parameters.AddWithValue("@cartno", cartNumber)
            cmd.Parameters.AddWithValue("@pcode", productCode)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Record updated successfully.")
            DisplayCustomerCartData()
            handleTotal()
            formClear()
        End If

    End Sub

    Private Function GetStockQuantity(productCode As String, connection As MySqlConnection) As Integer
        Dim query As String = "SELECT quantity FROM stock WHERE code = @ProductCode"
        Dim cmd As New MySqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@ProductCode", productCode)

        Dim result As Object = cmd.ExecuteScalar()

        If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
            Return Convert.ToInt32(result)
        Else
            Return 0
        End If
    End Function

    Private Function GetCurrentQuantity(cartNumber As String, productCode As String, connection As MySqlConnection) As Integer
        Dim query As String = "SELECT quantity FROM customercart WHERE cartno = @CartNumber AND pcode = @ProductCode"
        Dim cmd As New MySqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@CartNumber", cartNumber)
        cmd.Parameters.AddWithValue("@ProductCode", productCode)

        Dim result As Object = cmd.ExecuteScalar()

        If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
            Return Convert.ToInt32(result)
        Else
            Return 0
        End If
    End Function
End Class