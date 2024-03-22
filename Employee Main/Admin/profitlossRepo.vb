Imports MySql.Data.MySqlClient
Public Class profitlossRepo
    Dim connectionString As String = "Server=localhost;Database=inventory;Uid=root;Pwd=;Convert Zero Datetime=True"
    Private Sub profitlossRepo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
        'cheking()
    End Sub

    Private Sub cheking()
        For Each column As DataGridViewColumn In dgvprofit.Columns
            Dim columnName As String = column.Name
            MessageBox.Show("Column Name: " & columnName)
        Next
    End Sub
    Private Sub LoadData()
        Dim mpriceTotal As Decimal = 0
        Dim spriceTotal As Decimal = 0

        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT cb.productcode, s.pname, s.type, s.category, cb.productquantity, s.unit, s.mprice, s.tax, s.sprice, s.discount FROM customerbills cb INNER JOIN stock s ON cb.productcode = s.code"
            Using command As New MySqlCommand(query, connection)
                Using reader As MySqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim code As String = reader("productcode").ToString()
                        Dim pname As String = reader("pname").ToString()
                        Dim type As String = reader("type").ToString()
                        Dim category As String = reader("category").ToString()
                        Dim qty As Integer = Convert.ToInt32(reader("productquantity"))
                        Dim unit As String = reader("unit").ToString()
                        Dim mprice As Decimal = Convert.ToDecimal(reader("mprice"))
                        Dim tax As Decimal = Convert.ToDecimal(reader("tax"))
                        Dim sprice As Decimal = Convert.ToDecimal(reader("sprice"))
                        Dim discount As Decimal = Convert.ToDecimal(reader("discount"))

                        Dim totalMPrice As Decimal = mprice * qty
                        Dim totalSPrice As Decimal = sprice * qty
                        Dim profit As Decimal = (sprice - mprice - discount) * qty

                        Dim dgvRowIndex As Integer = -1
                        For i As Integer = 0 To dgvprofit.Rows.Count - 1
                            If dgvprofit.Rows(i).Cells("Column1").Value.ToString() = code Then
                                dgvRowIndex = i
                                Exit For
                            End If
                        Next
                        If dgvRowIndex <> -1 Then
                            dgvprofit.Rows(dgvRowIndex).Cells("Column5").Value = Convert.ToInt32(dgvprofit.Rows(dgvRowIndex).Cells("Column5").Value) + qty
                            dgvprofit.Rows(dgvRowIndex).Cells("Column9").Value = Convert.ToDecimal(dgvprofit.Rows(dgvRowIndex).Cells("Column9").Value) + totalMPrice
                            dgvprofit.Rows(dgvRowIndex).Cells("Column10").Value = Convert.ToDecimal(dgvprofit.Rows(dgvRowIndex).Cells("Column10").Value) + totalSPrice
                            dgvprofit.Rows(dgvRowIndex).Cells("Column11").Value = Convert.ToDecimal(dgvprofit.Rows(dgvRowIndex).Cells("Column11").Value) + profit
                            'We have to add Tax also into this dgvprofit updation 
                        Else
                            dgvprofit.Rows.Add(code, pname, type, category, qty, unit, totalMPrice, tax, totalSPrice, discount, profit)
                        End If

                        mpriceTotal += totalMPrice
                        spriceTotal += totalSPrice
                    End While
                End Using
            End Using
        End Using

        txt_pmprice.Text = mpriceTotal.ToString()
        txt_psprice.Text = spriceTotal.ToString()
        txt_grossprofit.Text = spriceTotal - mpriceTotal

        Dim lmpriceTotal As Decimal = 0
        Dim lspriceTotal As Decimal = 0
        'Loss 
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT * from `productloss`"
            Using command As New MySqlCommand(query, connection)
                Using reader As MySqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim lcode As String = reader("code").ToString()
                        Dim lpname As String = reader("pname").ToString()
                        Dim ltype As String = reader("type").ToString()
                        Dim lcategory As String = reader("category").ToString()
                        Dim lqty As Integer = Convert.ToInt32(reader("quantity"))
                        Dim lunit As String = reader("unit").ToString()
                        Dim lmprice As Decimal = Convert.ToDecimal(reader("mprice"))
                        Dim ltax As Decimal = Convert.ToDecimal(reader("tax"))
                        Dim lsprice As Decimal = Convert.ToDecimal(reader("sprice"))
                        Dim ldiscount As Decimal = Convert.ToDecimal(reader("discount"))

                        Dim ltotalMPrice As Decimal = lmprice * lqty
                        Dim ltotalSPrice As Decimal = lsprice * lqty
                        Dim lprofit As Decimal = lmprice * lqty

                        Dim ldgvRowIndex As Integer = -1
                        For i As Integer = 0 To dgvloss.Rows.Count - 1
                            If dgvloss.Rows(i).Cells("DataGridViewTextBoxColumn11").Value.ToString() = lcode Then
                                ldgvRowIndex = i
                                Exit For
                            End If
                        Next
                        If ldgvRowIndex <> -1 Then
                            dgvloss.Rows(ldgvRowIndex).Cells("DataGridViewTextBoxColumn15").Value = Convert.ToInt32(dgvloss.Rows(ldgvRowIndex).Cells("DataGridViewTextBoxColumn15").Value) + lqty
                            dgvloss.Rows(ldgvRowIndex).Cells("DataGridViewTextBoxColumn17").Value = Convert.ToDecimal(dgvloss.Rows(ldgvRowIndex).Cells("DataGridViewTextBoxColumn17").Value) + ltotalMPrice
                            dgvloss.Rows(ldgvRowIndex).Cells("DataGridViewTextBoxColumn19").Value = Convert.ToDecimal(dgvloss.Rows(ldgvRowIndex).Cells("DataGridViewTextBoxColumn19").Value) + ltotalSPrice
                            dgvloss.Rows(ldgvRowIndex).Cells("DataGridViewTextBoxColumn19").Value = Convert.ToDecimal(dgvloss.Rows(ldgvRowIndex).Cells("DataGridViewTextBoxColumn19").Value) + lprofit
                            'We have to add Tax also into this dgvprofit updation 
                        Else
                            dgvloss.Rows.Add(lcode, lpname, ltype, lcategory, lqty, lunit, ltotalMPrice, ltax, ltotalSPrice, ldiscount, lprofit)
                        End If

                        lmpriceTotal += ltotalMPrice
                        lspriceTotal += ltotalSPrice
                    End While
                End Using
            End Using
        End Using

        txt_manufactloss.Text = lmpriceTotal
        txt_sellingloss.Text = lspriceTotal
        txt_Grossloss.Text = lspriceTotal - lmpriceTotal

        'final total
        txt_netproloss.Text = txt_grossprofit.Text - txt_Grossloss.Text
    End Sub
End Class