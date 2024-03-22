Imports MySql.Data.MySqlClient

Public Class Refill
    Dim conn As New MySqlConnection("server=localhost;username=root;password=;database=inventory;Convert Zero Datetime=True")
    Dim i As Integer
    Dim tempQty As Double
    Dim totalQty As Double
    Dim dr As MySqlDataReader
    Dim cmd As MySqlCommand


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



    Private Sub txt_code_TextChanged(sender As Object, e As EventArgs) Handles txt_code.TextChanged
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

                If txt_qty.Text < 99 Then
                    Label1.Text = "Refill Needed"
                    Button4.Visible = True
                Else
                    Label1.Text = "Refill Not Needed"
                    Button4.Visible = False
                End If
            Else
                txt_pname.Clear()
                txt_type.Clear()
                txt_cat.Clear()
                txt_qty.Clear()
                txt_unit.Clear()
                txt_sprice.Clear()
                txt_dis.Clear()

                Label1.Text = ""
                Button4.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show("Text Change " + vbNewLine + ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        Finally
            conn.Close()
            dr.Close()
        End Try
    End Sub

    Private Sub Refill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = ""
        Button4.Visible = False
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



    'Refill Button
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            conn.Open()
            If existsInStock() = True And existsInStockRefill() = False Then
                cmd = New MySqlCommand("INSERT INTO `stockrefill`(`code`, `pname`, `type`, `category`, `status`, `date`) VALUES (@code,@pname,@type,@category,@status,@date)", conn)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@code", CDec(txt_code.Text))
                cmd.Parameters.AddWithValue("@pname", txt_pname.Text)
                cmd.Parameters.AddWithValue("@type", txt_type.Text)
                cmd.Parameters.AddWithValue("@category", txt_cat.Text)
                cmd.Parameters.AddWithValue("@status", "Pending")
                cmd.Parameters.AddWithValue("@date", Now)

                i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MessageBox.Show("Restock Filed Successfully", "Manage Stock Refill", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    formClear()
                Else
                    MessageBox.Show("Restock Filing Unsuccessful", "Manage Stock Refill", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("May Be The Request Is Already Filed", "Manage Stock Refill", MessageBoxButtons.OK, MessageBoxIcon.Information)
                formClear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Manage Stock Refill", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub
End Class