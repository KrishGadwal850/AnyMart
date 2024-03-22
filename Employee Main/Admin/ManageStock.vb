Imports MySql.Data.MySqlClient
Public Class Manage_Stock

    Dim connectionString As String = "Server=localhost;Database=inventory;Uid=root;Pwd=;Convert Zero Datetime=True"
    Dim i As Integer

    'Data Grid View Loader
    Public Sub loadRecord()
        DataGridView1.Rows.Clear()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Using cmd As New MySqlCommand("SELECT * FROM stock", connection)
                    Using dr As MySqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            DataGridView1.Rows.Add(dr.Item("code"), dr.Item("pname"), dr.Item("type"), dr.Item("category"), dr.Item("quantity"), dr.Item("unit"), dr.Item("dos"), dr.Item("mprice"), dr.Item("tax"), dr.Item("sprice"), dr.Item("discount"), dr.Item("pprice"))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        Finally
            ' No need to explicitly close connections or readers when using Using statement
            ' They will be automatically disposed when exiting the Using blocks
            formClear()
        End Try
    End Sub

    'On Load
    Private Sub Manage_Stock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadRecord()
        'Load the Combobox Category
        PopulateComboBox()
    End Sub

    ' Cell Click Event
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        txt_code.Text = DataGridView1.CurrentRow.Cells(0).Value
        txt_pname.Text = DataGridView1.CurrentRow.Cells(1).Value
        combo_type.Text = DataGridView1.CurrentRow.Cells(2).Value
        combo_cat.Text = DataGridView1.CurrentRow.Cells(3).Value
        txt_qty.Text = DataGridView1.CurrentRow.Cells(4).Value
        combo_unit.Text = DataGridView1.CurrentRow.Cells(5).Value
        combo_dos.Text = DataGridView1.CurrentRow.Cells(6).Value
        txt_mprice.Text = DataGridView1.CurrentRow.Cells(7).Value
        txt_tax.Text = DataGridView1.CurrentRow.Cells(8).Value
        txt_sprice.Text = DataGridView1.CurrentRow.Cells(9).Value
        combo_dis.Text = DataGridView1.CurrentRow.Cells(10).Value
        txt_pprice.Text = DataGridView1.CurrentRow.Cells(11).Value

    End Sub

    'Form Reset
    Private Sub formClear()
        txt_code.Clear()
        txt_pname.Clear()
        combo_type.Text = ""
        combo_cat.Text = ""
        txt_qty.Clear()
        combo_unit.Text = ""
        combo_dos.Value = Now
        txt_mprice.Clear()
        txt_tax.Clear()
        txt_sprice.Clear()
        combo_dis.Text = ""
        txt_pprice.Clear()
    End Sub

    ' Clear Code
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        formClear()
    End Sub

    'Adding Code
    Public Sub handleAdd()
        profitCalculate()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Using cmd As New MySqlCommand("INSERT INTO `stock`(`code`, `pname`, `type`, `category`, `quantity`, `unit`, `dos`, `mprice`, `tax`, `sprice`, `discount`, `pprice`) VALUES (@code,@pname,@type,@category,@quantity,@unit,@dos,@mprice,@tax,@sprice,@discount,@pprice)", connection)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@code", CDec(txt_code.Text))
                    cmd.Parameters.AddWithValue("@pname", txt_pname.Text)
                    cmd.Parameters.AddWithValue("@type", combo_type.Text)
                    cmd.Parameters.AddWithValue("@category", combo_cat.Text.Trim)
                    cmd.Parameters.AddWithValue("@quantity", CDec(txt_qty.Text))
                    cmd.Parameters.AddWithValue("@unit", combo_unit.Text)
                    cmd.Parameters.AddWithValue("@dos", CDate(combo_dos.Text))
                    cmd.Parameters.AddWithValue("@mprice", CDec(txt_mprice.Text))
                    cmd.Parameters.AddWithValue("@tax", CDec(txt_tax.Text))
                    cmd.Parameters.AddWithValue("@sprice", CDec(txt_sprice.Text))
                    cmd.Parameters.AddWithValue("@discount", CDec(combo_dis.Text))
                    cmd.Parameters.AddWithValue("@pprice", CDec(txt_pprice.Text))

                    i = cmd.ExecuteNonQuery()
                    If i > 0 Then
                        If updateStockHistory("Inserted") = vbTrue Then
                            MessageBox.Show("Stock Insertion Successful", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Stock Insertion Incomplete", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    Else
                        MessageBox.Show("Stock Insertion Failed", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using

            formClear()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        loadRecord()
    End Sub

    ' Add Button
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        handleAdd()
    End Sub

    ' Calculate Profit Price
    Private Sub profitCalculate()
        Dim manufacturing As Double
        Dim discount As Double
        Dim profit As Double
        Try
            manufacturing = CDec(If(txt_mprice.Text.Trim = "", "0", txt_mprice.Text.Trim)) + (If(txt_mprice.Text.Trim = "", "0", txt_mprice.Text.Trim) * CDec(If(txt_tax.Text.Trim = "", "0", txt_tax.Text.Trim)) / 100)
            discount = CDec(If(txt_sprice.Text.Trim = "", "0", txt_sprice.Text.Trim)) * CDec(If(combo_dis.Text.Trim = "", "0", combo_dis.Text.Trim)) / 100
            profit = (CDec(If(txt_sprice.Text.Trim = "", "0", txt_sprice.Text.Trim)) - discount) - manufacturing
            txt_pprice.Text = profit * CDec(If(txt_qty.Text.Trim = "", "0", txt_qty.Text.Trim))
        Catch ex As Exception
        End Try
    End Sub

    'Refill Deletion
    Private Function handleRefillDeletion() As Boolean
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Using cmd As New MySqlCommand("DELETE FROM `stockrefill` WHERE `code`=@code", conn)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@code", CDec(txt_code.Text))

                    i = cmd.ExecuteNonQuery
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Select The Item First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return vbTrue

    End Function

    'Refill Updation
    Private Function handleRefillUpdation() As Boolean
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Using cmd As New MySqlCommand("UPDATE `stockrefill` SET `pname`=@pname,`type`=@type,`category`=@category,`date`=@date WHERE `code`=@code", connection)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@code", CDec(txt_code.Text))
                    cmd.Parameters.AddWithValue("@pname", txt_pname.Text)
                    cmd.Parameters.AddWithValue("@type", combo_type.Text)
                    cmd.Parameters.AddWithValue("@category", combo_cat.Text)
                    cmd.Parameters.AddWithValue("@date", CDate(combo_dos.Text))

                    i = cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return vbTrue
    End Function

    'Update Code
    Private Sub handleUpdate()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Using cmd As New MySqlCommand("UPDATE `stock` SET `pname`=@pname,`type`=@type,`category`=@category,`quantity`=@quantity,`unit`=@unit,`dos`=@dos,`mprice`=@mprice,`tax`=@tax,`sprice`=@sprice,`discount`=@discount,`pprice`=@pprice WHERE `code`=@code", connection)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@code", CDec(txt_code.Text))
                    cmd.Parameters.AddWithValue("@pname", txt_pname.Text)
                    cmd.Parameters.AddWithValue("@type", combo_type.Text)
                    cmd.Parameters.AddWithValue("@category", combo_cat.Text)
                    cmd.Parameters.AddWithValue("@quantity", CDec(txt_qty.Text))
                    cmd.Parameters.AddWithValue("@unit", combo_unit.Text)
                    cmd.Parameters.AddWithValue("@dos", CDate(combo_dos.Text))
                    cmd.Parameters.AddWithValue("@mprice", CDec(txt_mprice.Text))
                    cmd.Parameters.AddWithValue("@tax", CDec(txt_tax.Text))
                    cmd.Parameters.AddWithValue("@sprice", CDec(txt_sprice.Text))
                    cmd.Parameters.AddWithValue("@discount", CDec(combo_dis.Text))
                    cmd.Parameters.AddWithValue("@pprice", CDec(txt_pprice.Text))

                    i = cmd.ExecuteNonQuery()
                    If i > 0 Then
                        If updateStockHistory("Updated") = vbTrue And handleRefillUpdation() = vbTrue Then
                            MessageBox.Show("Stock Updation Successful", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Stock Updation Incomplete", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    Else
                        MessageBox.Show("Stock Updation Failed", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' No need to explicitly close the connection when using Using statement
            loadRecord()
        End Try

    End Sub

    ' Update Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Confirm To Update", MsgBoxStyle.Question + vbYesNo, "Confirm") = vbYes Then
            handleUpdate()
        Else
            Return
        End If
        loadRecord()
    End Sub


    'Deletion Code
    Private Sub handleDelete()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Using cmd As New MySqlCommand("DELETE FROM `stock` WHERE `code`=@code", conn)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@code", CDec(txt_code.Text))

                    i = cmd.ExecuteNonQuery

                    If i > 0 Then
                        If updateStockHistory("Deleted") = vbTrue And handleRefillDeletion() = vbTrue Then
                            MessageBox.Show("Stock Deleted Successful", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Stock Deletion Incomplete", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    Else
                        MessageBox.Show("Stock Not Exist", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' No need to explicitly close the connection when using Using statement
            loadRecord()
        End Try
    End Sub

    ' Deletion Button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("Confirm To Delete", MsgBoxStyle.Question + vbYesNo, "Confirm") = vbYes Then
            handleDelete()
        Else
            Return
        End If
        loadRecord()
    End Sub

    'Stock updation (Add, Delete, Update)
    Private Function updateStockHistory(val As String) As Integer
        Try
            Using connHistory As New MySqlConnection(connectionString)
                connHistory.Open()

                Using cmd As New MySqlCommand("INSERT INTO `stockhistory`(`code`, `pname`, `type`, `category`, `quantity`, `unit`, `status`, `date`, `mprice`, `sprice`) VALUES (@code,@pname,@type,@category,@quantity,@unit,@status,@Date,@mprice,@sprice)", connHistory)
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@code", CDec(txt_code.Text))
                    cmd.Parameters.AddWithValue("@pname", txt_pname.Text)
                    cmd.Parameters.AddWithValue("@type", combo_type.Text)
                    cmd.Parameters.AddWithValue("@category", combo_cat.Text.Trim)
                    cmd.Parameters.AddWithValue("@unit", combo_unit.Text)
                    cmd.Parameters.AddWithValue("@quantity", CDec(txt_qty.Text))
                    cmd.Parameters.AddWithValue("@status", val)
                    cmd.Parameters.AddWithValue("@Date", Now)
                    cmd.Parameters.AddWithValue("@mprice", CDec(txt_mprice.Text) + (CDec(txt_mprice.Text) * CDec(txt_tax.Text)) / 100)
                    cmd.Parameters.AddWithValue("@sprice", CDec(txt_sprice.Text) - (CDec(txt_sprice.Text) * CDec(combo_dis.Text)) / 100)

                    Dim i As Integer = cmd.ExecuteNonQuery()
                    If i > 0 Then
                        Return True
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return False


    End Function

    Private Function existsInStock() As Boolean
        If txt_code.Text.Trim = "" Or Not IsNumeric(txt_code.Text) Then
            Return False
        End If
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Using cmd As New MySqlCommand("Select * FROM stock WHERE `code`=@code And `pname`=@pname And `type`=@type And `category`=@category", connection)
                    cmd.Parameters.AddWithValue("@code", txt_code.Text)
                    cmd.Parameters.AddWithValue("@pname", txt_pname.Text)
                    cmd.Parameters.AddWithValue("@type", combo_type.Text)
                    cmd.Parameters.AddWithValue("@category", combo_cat.Text)

                    Using dr As MySqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            Return True
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' No need to explicitly close the connection or the reader when using Using statement
        End Try

        Return False

    End Function

    Private Function existsInStockRefill() As Boolean
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Using cmd As New MySqlCommand("Select * FROM stockrefill WHERE `code`=@code", connection)
                    cmd.Parameters.AddWithValue("@code", txt_code.Text)

                    Using dr As MySqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            Return True
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' No need to explicitly close the connection or the reader when using Using statement
        End Try

        Return False

    End Function

    'Refill Request
    Private Sub refillRequest()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim found As Boolean
                found = existsInStockRefill()

                If existsInStock() = True And found = False Then
                    Try
                        Using cmd As New MySqlCommand("INSERT INTO `stockrefill`(`code`, `pname`, `type`, `category`, `status`,`Date`) VALUES (@code,@pname,@type,@category,@status,@Date)", conn)
                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("@code", CDec(txt_code.Text))
                            cmd.Parameters.AddWithValue("@pname", txt_pname.Text)
                            cmd.Parameters.AddWithValue("@type", combo_type.Text)
                            cmd.Parameters.AddWithValue("@category", combo_cat.Text)
                            cmd.Parameters.AddWithValue("@status", "Pending")
                            cmd.Parameters.AddWithValue("@Date", Now)

                            i = cmd.ExecuteNonQuery
                            If i > 0 Then
                                MessageBox.Show("Refill Request Filed", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Refill Request Unsuccessful", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End Using

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    If found Then
                        MessageBox.Show("Refill Already Filed", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        MessageBox.Show("Stock Not Found", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Refill Button
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        refillRequest()
    End Sub


    'Search Box
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        DataGridView1.Rows.Clear()

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Using cmd As New MySqlCommand("Select * FROM stock WHERE code Like '%" & TextBox4.Text & "%' OR pname like '%" & TextBox4.Text & "%'", connection)
                    Using dr As MySqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            DataGridView1.Rows.Add(dr.Item("code"), dr.Item("pname"), dr.Item("type"), dr.Item("category"), dr.Item("quantity"), dr.Item("unit"), dr.Item("dos"), dr.Item("mprice"), dr.Item("tax"), dr.Item("sprice"), dr.Item("discount"), dr.Item("pprice"))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in first search", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Using cmd As New MySqlCommand("SELECT * FROM stock WHERE code like '%" & TextBox4.Text & "%' OR pname like '%" & TextBox4.Text & "%'", connection)

                    Using dr As MySqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            txt_code.Text = dr.Item("code")
                            txt_pname.Text = dr.Item("pname")
                            combo_type.Text = dr.Item("type")
                            combo_cat.Text = dr.Item("category")
                            txt_qty.Text = dr.Item("quantity")
                            combo_unit.Text = dr.Item("unit")
                            combo_dos.Text = dr.Item("dos")
                            txt_mprice.Text = dr.Item("mprice")
                            txt_tax.Text = dr.Item("tax")
                            txt_sprice.Text = dr.Item("sprice")
                            combo_dis.Text = dr.Item("discount")
                            txt_pprice.Text = dr.Item("pprice")
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in second search", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try

        profitCalculate()

    End Sub


    'Category Load Subroutine
    Private Sub PopulateComboBox()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Using cmd As New MySqlCommand("SELECT category FROM `tax`", conn)
                    Dim dt As New DataTable()
                    dt.Load(cmd.ExecuteReader())

                    ' Assign the DataTable as the data source for the ComboBox
                    combo_cat.DataSource = dt
                    combo_cat.DisplayMember = "category" ' Replace with the column name you want to display
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    'Private Sub combo_cat_SelectedIndexChanged(sender As Object, e As EventArgs)

    '    End Sub

    'Private Sub combo_type_SelectedIndexChanged(sender As Object, e As EventArgs)


    'End Sub

    Private Sub combo_cat_TextChanged(sender As Object, e As EventArgs) Handles combo_cat.TextChanged
        If combo_type.SelectedItem IsNot Nothing AndAlso combo_type.SelectedItem.ToString() = "Unpacked" Then
            txt_tax.Text = 0
            'txt_tax.ReadOnly = True
        Else
            Try
                Using conn As New MySqlConnection(connectionString)
                    conn.Open()

                    Using cmd As New MySqlCommand("SELECT tax FROM `tax` WHERE category = @category", conn)
                        cmd.Parameters.AddWithValue("@category", combo_cat.Text)
                        Using dr As MySqlDataReader = cmd.ExecuteReader()
                            If dr.Read Then
                                txt_tax.Text = dr("tax")
                                'txt_tax.ReadOnly = True
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        profitCalculate()

    End Sub

    Private Sub combo_type_TextChanged(sender As Object, e As EventArgs) Handles combo_type.TextChanged
        If combo_type.SelectedItem IsNot Nothing AndAlso combo_type.SelectedItem.ToString() = "Unpacked" Then
            txt_tax.Text = 0
        Else
            Try
                Using conn As New MySqlConnection(connectionString)
                    conn.Open()

                    Using cmd As New MySqlCommand("SELECT tax FROM `tax` WHERE category = @category", conn)
                        cmd.Parameters.AddWithValue("@category", combo_cat.Text)
                        Using dr As MySqlDataReader = cmd.ExecuteReader()
                            If dr.Read Then
                                txt_tax.Text = dr("tax")
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        profitCalculate()
    End Sub

    Private Sub txt_qty_TextChanged(sender As Object, e As EventArgs) Handles txt_qty.TextChanged
        profitCalculate()
    End Sub

    Private Sub txt_mprice_TextChanged(sender As Object, e As EventArgs) Handles txt_mprice.TextChanged
        profitCalculate()
    End Sub

    Private Sub txt_sprice_TextChanged(sender As Object, e As EventArgs) Handles txt_sprice.TextChanged
        profitCalculate()
    End Sub

    Private Sub combo_dis_TextChanged(sender As Object, e As EventArgs) Handles combo_dis.TextChanged
        profitCalculate()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim stockhis As New StockHistory
        stockhis.Show()
    End Sub




    Private Sub handleLoss()
        Try
            Dim code As String = CDec(txt_code.Text)
            Dim pname As String = txt_pname.Text
            Dim type As String = combo_type.Text
            Dim cat As String = combo_cat.Text
            Dim qty As Integer = Integer.Parse(txt_qty.Text)
            Dim unit As String = combo_unit.Text
            Dim dos As String = combo_dos.Text
            Dim mprice As Decimal = Decimal.Parse(txt_mprice.Text)
            Dim tax As Decimal = Decimal.Parse(txt_tax.Text)
            Dim sprice As Decimal = Decimal.Parse(txt_sprice.Text)
            Dim dis As Decimal = Decimal.Parse(combo_dis.Text)
            Dim pprice As Decimal = Decimal.Parse(txt_pprice.Text)

            ' Check if the product code already exists in the productloss table
            If ProductCodeExists(code) Then
                ' If it exists, update the quantity
                UpdateProductLossQuantity(code, qty)
            Else
                ' If it doesn't exist, insert a new record
                InsertProductLoss(code, pname, type, cat, qty, unit, dos, mprice, tax, sprice, dis, pprice)
            End If

            ' Update quantity in the stock table
            UpdateStockQuantity(code, qty)

            MessageBox.Show("Data inserted successfully and stock updated.")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            loadRecord()
            formClear()
        End Try

    End Sub

    Private Function ProductCodeExists(code As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM productloss WHERE code = @code"
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@code", code)
                connection.Open()
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function

    Private Sub UpdateProductLossQuantity(code As String, qty As Integer)
        Dim query As String = "UPDATE productloss SET quantity = quantity + @qty WHERE code = @code"
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@qty", qty)
                command.Parameters.AddWithValue("@code", code)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub InsertProductLoss(code As String, pname As String, type As String, cat As String, qty As Integer, unit As String, dos As String, mprice As Decimal, tax As Decimal, sprice As Decimal, dis As Decimal, pprice As Decimal)
        Dim query As String = "INSERT INTO productloss (code, pname, type, category, quantity, unit, dos, mprice, tax, sprice, discount, pprice) VALUES (@code, @pname, @type, @cat, @qty, @unit, @dos, @mprice, @tax, @sprice, @dis, @pprice)"
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@code", code)
                command.Parameters.AddWithValue("@pname", pname)
                command.Parameters.AddWithValue("@type", type)
                command.Parameters.AddWithValue("@cat", cat)
                command.Parameters.AddWithValue("@qty", qty)
                command.Parameters.AddWithValue("@unit", unit)
                command.Parameters.AddWithValue("@dos", dos)
                command.Parameters.AddWithValue("@mprice", mprice)
                command.Parameters.AddWithValue("@tax", tax)
                command.Parameters.AddWithValue("@sprice", sprice)
                command.Parameters.AddWithValue("@dis", dis)
                command.Parameters.AddWithValue("@pprice", pprice)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub UpdateStockQuantity(code As String, qty As Integer)
        ' Check if the stock item exists
        Dim stockQty As Integer = GetStockQuantity(code)

        ' If stock item exists and the required quantity exceeds stock quantity
        If stockQty = 0 OrElse stockQty < qty Then
            ' Initialize stock item quantity to zero
            InitializeStockQuantityToZero(code)
            ' Set qty to zero
            qty = stockQty
        End If

        Dim query As String = "UPDATE stock SET quantity = quantity - @qty WHERE code = @code"
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@qty", qty)
                command.Parameters.AddWithValue("@code", code)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Function GetStockQuantity(code As String) As Integer
        Dim query As String = "SELECT quantity FROM stock WHERE code = @code"
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@code", code)
                connection.Open()
                Dim result As Object = command.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    Return Convert.ToInt32(result)
                Else
                    Return 0
                End If
            End Using
        End Using
    End Function

    Private Sub InitializeStockQuantityToZero(code As String)
        Dim query As String = "UPDATE stock SET quantity = 0 WHERE code = @code"
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@code", code)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If MsgBox("Confirm to proceed....", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            handleLoss()
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        profitlossRepo.Show()
    End Sub
End Class