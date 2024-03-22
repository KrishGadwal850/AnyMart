Imports MySql.Data.MySqlClient
Imports Mysqlx

Public Class StockHistory


    Dim connectionString As String = "Server=localhost;Database=inventory;Uid=root;Pwd=;Convert Zero Datetime=True"

    Dim i As Integer
    Dim shrow As Integer
    Dim sqty As Integer
    Dim shqty As Integer
    Dim shstatus As String


    'Data Grid View Loader
    Public Sub loadRecord()
        DataGridView1.Rows.Clear() ' Clear the existing rows before populating
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Using cmd As New MySqlCommand("SELECT * FROM stockhistory", connection)
                    Using dr As MySqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            DataGridView1.Rows.Add(dr.Item("sno"), dr.Item("code"), dr.Item("pname"), dr.Item("type"), dr.Item("category"), dr.Item("quantity"), dr.Item("unit"), dr.Item("status"), dr.Item("date"), dr.Item("mprice"), dr.Item("sprice"))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            'MessageBox.Show("AA Gaya Error")
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        formClear()
    End Sub

    'On Load
    Private Sub StockHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadRecord()
    End Sub

    ' Cell Click Event
    Private Function GetStockQuantity() As Integer
        Dim quantity As Integer = 0

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim query As String = "SELECT quantity FROM stock WHERE code = @code"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@code", txt_code.Text) ' replace yourCodeValue with the actual value you want to fetch
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        quantity = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return quantity
    End Function
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        shrow = CDec(DataGridView1.CurrentRow.Cells(0).Value)
        txt_code.Text = DataGridView1.CurrentRow.Cells(1).Value
        txt_pname.Text = DataGridView1.CurrentRow.Cells(2).Value
        txt_type.Text = DataGridView1.CurrentRow.Cells(3).Value
        txt_cat.Text = DataGridView1.CurrentRow.Cells(4).Value
        txt_qty.Text = DataGridView1.CurrentRow.Cells(5).Value

        shqty = CDec(txt_qty.Text)

        txt_unit.Text = DataGridView1.CurrentRow.Cells(6).Value
        combo_status.Text = DataGridView1.CurrentRow.Cells(7).Value

        shstatus = combo_status.Text

        combo_date.Text = DataGridView1.CurrentRow.Cells(8).Value
        txt_mprice.Text = DataGridView1.CurrentRow.Cells(9).Value
        txt_sprice.Text = DataGridView1.CurrentRow.Cells(10).Value

        qty_no.Text = GetStockQuantity().ToString()

    End Sub

    'Form Reset
    Private Sub formClear()
        txt_code.Clear()
        txt_pname.Clear()
        txt_type.Clear()
        txt_cat.Clear()
        txt_qty.Clear()
        txt_unit.Clear()
        combo_date.Text = Date.Today
        combo_status.Text = ""
        txt_mprice.Clear()
        txt_sprice.Clear()

        qty_no.Text = "none"
    End Sub

    'Clear Button
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        formClear()

    End Sub

    'Check Stock
    Private Function existsInStock(vcode As Integer, vpname As String, vtype As String, vcat As String) As Boolean
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim selectQuery As String = "SELECT * FROM `stock` WHERE `code`='" & vcode & "' AND `pname`='" & vpname & "' AND `type`='" & vtype & "' AND `category`='" & vcat & "'"

                Using cmd As New MySqlCommand(selectQuery, connection)
                    cmd.Parameters.Clear()
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            sqty = dr.Item("quantity")
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

    'Check Stock History
    Private Function existsInStockHistory(vcode As Integer, vpname As String, vtype As String, vcat As String) As Boolean
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim selectQuery As String = "SELECT * FROM `stockhistory` WHERE `sno`='" & shrow & "' AND `code`='" & vcode & "' AND `pname`='" & vpname & "' AND `type`='" & vtype & "' AND `category`='" & vcat & "'"

                Using cmd As New MySqlCommand(selectQuery, connection)
                    cmd.Parameters.Clear()

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

    'Deletion Code
    Private Sub handleDeletion(vcode As Integer, vpname As String, vtype As String, vcat As String, qty As Integer)
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim ex1 As Boolean
                ex1 = existsInStockHistory(vcode, vpname, vtype, vcat)

                If ex1 Then

                    Using cmdDelete As New MySqlCommand("DELETE FROM `stockhistory` WHERE `sno`='" & shrow & "' AND `code`='" & vcode & "' AND `pname`='" & vpname & "' AND `type`='" & vtype & "' AND `category`='" & vcat & "'", conn)
                        cmdDelete.Parameters.Clear()

                        i = cmdDelete.ExecuteNonQuery()
                        If i > 0 Then
                            MessageBox.Show("Stock History Deletion Successful", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Stock History Deletion Unsuccessful", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End Using
                Else
                    MessageBox.Show("Process Unsuccessful", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            loadRecord()
        End Try

    End Sub

    'Delete Button
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not txt_code.Text.Trim = "" Then
            Try
                qty_no.Text = If(qty_no.Text.Trim = "", "0", qty_no.Text)
                handleDeletion(CDec(txt_code.Text), txt_pname.Text, txt_type.Text, txt_cat.Text, CDec(qty_no.Text))
            Catch ex As Exception
                MessageBox.Show("Please select correct values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub


    'Searching Code
    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        DataGridView1.Rows.Clear()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT * FROM stockhistory WHERE code Like '%" & TextBox4.Text & "%' OR pname like '%" & TextBox4.Text & "%' OR status like '%" & TextBox4.Text & "%'"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.Clear()

                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            DataGridView1.Rows.Add(dr.Item("sno"), dr.Item("code"), dr.Item("pname"), dr.Item("type"), dr.Item("category"), dr.Item("quantity"), dr.Item("unit"), dr.Item("status"), dr.Item("date"), dr.Item("mprice"), dr.Item("sprice"))
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'Update Code
    Private Sub handleUpdation(vcode As Integer, vpname As String, vtype As String, vcat As String, qty As Integer)
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim ex1 As Boolean
                Dim ex2 As Boolean
                ex1 = existsInStock(vcode, vpname, vtype, vcat)
                ex2 = existsInStockHistory(vcode, vpname, vtype, vcat)

                If ex1 AndAlso ex2 AndAlso CDec(txt_qty.Text) <= (sqty + shqty) AndAlso (CDec(txt_qty.Text) > 0) Then

                    Using cmdUpdate As New MySqlCommand("UPDATE `stockhistory` SET `quantity`='" & CDec(txt_qty.Text) & "', `date`='" & CDate(combo_date.Text) & "' ,`status`='" & (combo_status.Text) & "' WHERE `sno`='" & shrow & "' AND `code`='" & vcode & "' AND `pname`='" & vpname & "' AND `type`='" & vtype & "' AND `category`='" & vcat & "'", conn)
                        cmdUpdate.Parameters.Clear()

                        i = cmdUpdate.ExecuteNonQuery()
                        If i > 0 Then
                            MessageBox.Show("Stock History Updation Successful", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Stock History Updation Uusuccessful", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End Using

                ElseIf ex2 Then
                    MessageBox.Show("Only Exist In History So No Need To Update, Although You Can Delete It", "Tip", MessageBoxButtons.OK)

                Else
                    MessageBox.Show("Stock History Updation Unsuccessful" + vbNewLine + "Check For Quantity", "Manage Stock", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            loadRecord()
        End Try

    End Sub

    'Update Button
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            qty_no.Text = If(qty_no.Text = "none", "0", qty_no.Text)
            handleUpdation(CDec(txt_code.Text), txt_pname.Text, txt_type.Text, txt_cat.Text, CDec(qty_no.Text))
        Catch ex As Exception
            MessageBox.Show("Please select correct values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        'Me.Hide()
        'profitlossRepo.Show()
    End Sub


End Class