Imports Google.Protobuf.WellKnownTypes
Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class payment

    Dim connectionString As String = "Server=localhost;Database=inventory;User ID=root;Password=;"

    Dim paymentmode As String
    Dim cartno As Integer
    Dim billno As Integer
    Dim phoneno As Integer

    Dim cashier As Integer
    Dim customername As String
    Dim total As Double

    Public Sub New(cart As String, bill As String, phone As String, empcode As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        cartno = Integer.Parse(cart)
        billno = Integer.Parse(bill)
        phoneno = Integer.Parse(phone)
        cashier = empcode

    End Sub

    Private Sub btnCash_Click(sender As Object, e As EventArgs) Handles btnCash.Click
        btnReceived.Enabled = True
        paymentmode = "cash"
        Label1.Text = ""
    End Sub

    Private Sub btnOnline_Click(sender As Object, e As EventArgs) Handles btnOnline.Click
        btnReceived.Enabled = True
        paymentmode = "UPI"
        Label1.Text = "1234xxxxxx"

    End Sub

    Private Sub btnCard_Click(sender As Object, e As EventArgs) Handles btnCard.Click
        btnReceived.Enabled = True
        paymentmode = "Card"
        Label1.Text = ""

    End Sub

    Private Sub payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        imgBox.Image = My.Resources.online
    End Sub

    Private Function FetchRecordsByPhone(phoneNo As Integer) As Boolean
        Dim ans As Boolean = False
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT * FROM customer WHERE phone = @phoneNo"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@phoneNo", phoneNo)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Access the "customername" field and store it in the variable
                            customername = reader("cname").ToString()
                        Else
                            ' Handle the case where no records were found for the given phone number
                            MessageBox.Show("No records found for phone number " & phoneNo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
                ans = True
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching records: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return ans
    End Function

    ' Define a class to represent a cart record
    Class CartRecord
        Public Property CartNo As Integer
        Public Property PCode As String
        Public Property PName As String
        Public Property Type As String
        Public Property Quantity As Double
        Public Property Unit As String
        Public Property Price As Decimal
        Public Property Discount As Double
    End Class

    ' Function to fetch records from customercart and insert into customerbill
    Private Function FetchAndInsertRecords(cartNo As Integer, billNo As Integer) As Boolean
        Dim ans As Boolean = False
        Try
            ' Fetch records from customercart
            Dim cartRecords As New List(Of CartRecord)
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim cartQuery As String = "SELECT * FROM customercart WHERE cartno = @cartno"
                Using cartCmd As New MySqlCommand(cartQuery, connection)
                    cartCmd.Parameters.AddWithValue("@cartno", cartNo)
                    Using reader As MySqlDataReader = cartCmd.ExecuteReader()
                        While reader.Read()
                            ' Create a CartRecord object and add it to the list
                            Dim record As New CartRecord With {
                                    .CartNo = Convert.ToDecimal(reader("cartno")),
                                    .PCode = reader("pcode").ToString(),
                                    .PName = reader("pname").ToString(),
                                    .Type = reader("type").ToString(),
                                    .Quantity = Convert.ToDouble(reader("quantity")),
                                    .Unit = reader("unit").ToString(),
                                    .Price = Convert.ToDecimal(reader("price")),
                                    .Discount = Convert.ToDecimal(reader("discount").ToString())
                        }
                            cartRecords.Add(record)
                        End While
                    End Using
                End Using
            End Using


            ' Insert records into customerbill
            If cartRecords.Count > 0 Then
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()
                    ' Start a transaction for atomicity
                    Using transaction As MySqlTransaction = connection.BeginTransaction()
                        Try
                            For Each data As CartRecord In cartRecords
                                ' Insert into customerbill
                                Dim billQuery As String = "INSERT INTO customerbills (billno,productcode, productname, producttype, productquantity, productunit, productprice, productdiscount) VALUES (@billNo, @pCode, @pName, @type, @quantity, @unit, @price, @dis)"
                                Using billCmd As New MySqlCommand(billQuery, connection, transaction)
                                    billCmd.Parameters.AddWithValue("@billNo", billNo)
                                    billCmd.Parameters.AddWithValue("@pCode", data.PCode)
                                    billCmd.Parameters.AddWithValue("@pName", data.PName)
                                    billCmd.Parameters.AddWithValue("@type", data.Type)
                                    billCmd.Parameters.AddWithValue("@quantity", data.Quantity)
                                    billCmd.Parameters.AddWithValue("@unit", data.Unit)
                                    billCmd.Parameters.AddWithValue("@price", data.Price)
                                    billCmd.Parameters.AddWithValue("@dis", data.Discount)
                                    billCmd.ExecuteNonQuery()
                                End Using
                            Next

                            ' Commit the transaction if everything is successful
                            transaction.Commit()
                        Catch ex As Exception
                            MessageBox.Show("Error During cart transaction" & cartNo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ' Rollback the transaction in case of an error
                            transaction.Rollback()
                            Throw
                        End Try
                    End Using
                End Using
            Else
                MessageBox.Show("No records found for cart number " & cartNo, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ans = True
        Catch ex As Exception
            MessageBox.Show("Error fetching and inserting records: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return ans
    End Function

    ' Function to fetch records from cart table and calculate total value
    Private Function CalculateTotalValue(cartNo As Integer) As Boolean
        Dim ans As Boolean = False
        Try
            ' Reset total value
            total = 0
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT quantity, price FROM customercart WHERE cartno = @cartNo"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@cartNo", cartNo)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            ' Calculate the total value for each item and add to the overall total
                            Dim quantity As Integer = Convert.ToDouble(reader.Item("quantity"))
                            Dim price As Decimal = Convert.ToDecimal(reader.Item("price"))
                            total += (quantity * price)
                        End While
                    End Using
                End Using
                ans = True
            End Using

        Catch ex As Exception
            MessageBox.Show("Error calculating total value: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return ans
    End Function

    ' Function to insert records into customerpurchases table
    Private Function UpdateCustomerPurchases() As Boolean
        Try
            ' Get the current date and time
            Dim currentDate As String = DateTime.Now.ToString("yyyy-MM-dd")
            Dim currentTime As String = DateTime.Now.ToString("HH:mm:ss")
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Update records in customerpurchases
                Dim query As String = "UPDATE customerpurchases SET cashier = @empCode, phone = @phoneNo, customer = @customerName, billdate = @billDate, time = @time, total = @total, paymentmode = @paymentMode WHERE billno = @billNo"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@empCode", cashier)
                    cmd.Parameters.AddWithValue("@phoneNo", phoneno)
                    cmd.Parameters.AddWithValue("@customerName", customername)
                    cmd.Parameters.AddWithValue("@billDate", currentDate)
                    cmd.Parameters.AddWithValue("@time", currentTime)
                    cmd.Parameters.AddWithValue("@total", total)
                    cmd.Parameters.AddWithValue("@paymentMode", paymentmode)
                    cmd.Parameters.AddWithValue("@billNo", billno)
                    cmd.ExecuteNonQuery()
                End Using

                'MessageBox.Show("Records updated in customerpurchases table successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            End Using

        Catch ex As Exception
            MessageBox.Show("Error updating records in customerpurchases table: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

    Private Function DecreaseStockQuantity() As Boolean
        Dim ans As Boolean = False
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                ' Fetch records from customercart for the specified cart number
                Dim cartQuery As String = "SELECT pcode, quantity FROM customercart WHERE cartno = @cartNo"
                Using cartCmd As New MySqlCommand(cartQuery, connection)
                    cartCmd.Parameters.AddWithValue("@cartNo", cartno)

                    Using reader As MySqlDataReader = cartCmd.ExecuteReader()
                        While reader.Read()
                            ' Get the product code and quantity from customercart
                            Dim pCode As String = (reader.Item("pcode")).ToString()
                            Dim cartQuantity As Integer = Convert.ToDouble(reader.Item("quantity"))

                            ' Update the quantity in the stock table
                            Using connection1 As New MySqlConnection(connectionString)
                                connection1.Open()
                                Dim stockUpdateQuery As String = "UPDATE stock SET quantity = quantity - @cartQuantity WHERE code = @pCode"
                                Using stockUpdateCmd As New MySqlCommand(stockUpdateQuery, connection1)
                                    stockUpdateCmd.Parameters.AddWithValue("@cartQuantity", cartQuantity)
                                    stockUpdateCmd.Parameters.AddWithValue("@pCode", pCode)
                                    stockUpdateCmd.ExecuteNonQuery()
                                End Using
                            End Using
                        End While
                    End Using
                End Using
            End Using


            'MessageBox.Show("Stock quantities updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ans = True
        Catch ex As Exception
            MessageBox.Show("Error updating stock quantities: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return ans
    End Function


    ' Function to delete records from customercart table
    Private Function DeleteRecordsFromCustomercart() As Boolean
        Dim ans As Boolean = False
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Delete records from customercart for the specified cart number
                Dim deleteQuery As String = "DELETE FROM customercart WHERE cartno = @cartNo"
                Using cmd As New MySqlCommand(deleteQuery, connection)
                    cmd.Parameters.AddWithValue("@cartNo", cartno)
                    cmd.ExecuteNonQuery()
                End Using

                'MessageBox.Show("Records deleted from customercart successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ans = True
            End Using
        Catch ex As Exception
            MessageBox.Show("Error deleting records from customercart: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return ans
    End Function

    ' Function to delete a record from the cart table
    Private Function DeleteRecordFromCart() As Boolean
        Dim ans As Boolean
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Delete the record from the cart table for the specified cart number
                Dim deleteQuery As String = "DELETE FROM cart WHERE cartno = @cartNo"
                Using cmd As New MySqlCommand(deleteQuery, connection)
                    cmd.Parameters.AddWithValue("@cartNo", cartno)
                    cmd.ExecuteNonQuery()
                End Using

                'MessageBox.Show("Record deleted from cart successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ans = True
            End Using

        Catch ex As Exception
            MessageBox.Show("Error deleting record from cart: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return ans
    End Function

    Private Sub btnReceived_Click(sender As Object, e As EventArgs) Handles btnReceived.Click
        If MsgBox("Confirm Payment Received", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If FetchRecordsByPhone(phoneno) Then
                If FetchAndInsertRecords(cartno, billno) Then
                    If CalculateTotalValue(cartno) Then
                        If UpdateCustomerPurchases() Then
                            If DecreaseStockQuantity() Then
                                If DeleteRecordsFromCustomercart() Then
                                    If DeleteRecordFromCart() Then
                                        Dim imageForm As New receivedimage()
                                        imageForm.ShowDialog()
                                        printBill()
                                        Me.Close()
                                    End If
                                End If

                            End If

                        End If

                    End If

                End If

            End If

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub








    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim longpaper As Integer
    Private Function FetchProductDetails(billno As Integer) As List(Of ProductDetails)
        Dim detailsList As New List(Of ProductDetails)

        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' SQL query to fetch product details for the specified billno
            Dim query As String = "SELECT productname, productquantity, productprice FROM customerbills WHERE billno = @billno"

            Using command As New MySqlCommand(query, connection)
                ' Add parameter to the query
                command.Parameters.AddWithValue("@billno", billno)

                Using reader As MySqlDataReader = command.ExecuteReader()
                    ' Iterate through each row in the reader
                    While reader.Read()
                        ' Create a new ProductDetails object for each row and add it to the list
                        Dim details As New ProductDetails()
                        details.ProductName = reader("productname").ToString()
                        details.ProductQuantity = Convert.ToInt32(reader("productquantity"))
                        details.ProductPrice = Convert.ToDecimal(reader("productprice"))
                        detailsList.Add(details)
                    End While
                End Using
            End Using
        End Using

        Return detailsList
    End Function

    Private Function GetRecordCount(billno As String) As Integer
        Dim count As Integer = 0

        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' SQL query to count records with the specified billno
            Dim query As String = "SELECT COUNT(*) FROM customerbills WHERE billno = @billno"

            Using command As New MySqlCommand(query, connection)
                ' Add parameter to the query
                command.Parameters.AddWithValue("@billno", billno)

                ' Execute the query and get the count
                count = Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using

        Return count
    End Function

    Sub changelongpaper()
        Dim rowcount As Integer
        longpaper = 0
        rowcount = GetRecordCount(billno)
        longpaper = rowcount * 15
        longpaper = longpaper + 240
    End Sub

    Private Sub printBill()
        changelongpaper()
        PPD.Document = PD
        PPD.ShowDialog()
        'PD.Print()  'Direct Print

    End Sub

    Private Sub PD_BeginPrint(sender As Object, e As PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 250, 500) 'fixed size
        'pagesetup.PaperSize = New PaperSize("Custom", 250, longpaper)
        PD.DefaultPageSettings = pagesetup
    End Sub

    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        Dim f6 As New Font("Calibri", 6, FontStyle.Regular)
        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f14 As New Font("Calibri", 14, FontStyle.Bold)

        Dim leftmargin As Integer = PD.DefaultPageSettings.Margins.Left
        Dim centermargin As Integer = PD.DefaultPageSettings.PaperSize.Width / 2
        Dim rightmargin As Integer = PD.DefaultPageSettings.PaperSize.Width

        'font alignment
        Dim right As New StringFormat
        Dim center As New StringFormat

        right.Alignment = StringAlignment.Far
        center.Alignment = StringAlignment.Center

        Dim line As String
        line = "****************************************************************"

        'range from top
        'logo
        Dim logoImage As Image = My.Resources.ResourceManager.GetObject("Anymartlogo1")
        e.Graphics.DrawImage(logoImage, CInt((e.PageBounds.Width - 150) / 2), 5, 150, 35)

        'e.Graphics.DrawImage(logoImage, 0, 250, 150, 50)
        'e.Graphics.DrawImage(logoImage, CInt((e.PageBounds.Width - logoImage.Width) / 2), CInt((e.PageBounds.Height - logoImage.Height) / 2), logoImage.Width, logoImage.Height)

        'e.Graphics.DrawString("Store :", f14, Brushes.Black, centermargin, 5, center)
        e.Graphics.DrawString("ANYMART", f8, Brushes.Black, centermargin, 40, center)
        e.Graphics.DrawString("Tel +1763545473", f8, Brushes.Black, centermargin, 55, center)
        e.Graphics.DrawString("Ajmer,Rajasthan ,Unit no.", f8, Brushes.Black, centermargin, 70, center)
        e.Graphics.DrawString("FC/05,4th Floor,", f8, Brushes.Black, centermargin, 85, center)
        e.Graphics.DrawString("Mittal Mall,Rajasthan - 305001", f8, Brushes.Black, centermargin, 100, center)

        e.Graphics.DrawString("Invoice ID", f8, Brushes.Black, 0, 120)
        e.Graphics.DrawString(":", f8, Brushes.Black, 50, 120)
        e.Graphics.DrawString("DRW8555RE", f8, Brushes.Black, 70, 120)

        e.Graphics.DrawString("Cashier", f8, Brushes.Black, 0, 132)
        e.Graphics.DrawString(":", f8, Brushes.Black, 50, 132)
        e.Graphics.DrawString(cashier, f8, Brushes.Black, 70, 132)

        e.Graphics.DrawString("08/17/2021 | 15.34", f8, Brushes.Black, 0, 145)
        'DetailHeader
        e.Graphics.DrawString("Qty", f8, Brushes.Black, 0, 162)
        e.Graphics.DrawString("Item", f8, Brushes.Black, 25, 162)
        e.Graphics.DrawString("Tax", f8, Brushes.Black, 120, 162, right)
        e.Graphics.DrawString("Price", f8, Brushes.Black, 180, 162, right)
        e.Graphics.DrawString("Total", f8, Brushes.Black, rightmargin, 162, right)
        '
        e.Graphics.DrawString(line, f8, Brushes.Black, 0, 175)

        Dim height As Integer 'DGV Position
        Dim i As Long
        'DataGridView1.AllowUserToAddRows = False
        'If DataGridView1.CurrentCell.Value Is Nothing Then
        '    Exit Sub
        'Else

        Dim productList As List(Of ProductDetails) = FetchProductDetails(billno)

        For Each product As ProductDetails In productList
            height += 13
            e.Graphics.DrawString(product.ProductName, f8, Brushes.Black, 0, 175 + height)
            e.Graphics.DrawString(product.ProductQuantity, f8, Brushes.Black, 25, 175 + height)
            Dim quantity As Integer = product.ProductQuantity
            Dim formattedQuantity As String = quantity.ToString("##,##0")
            e.Graphics.DrawString(formattedQuantity, f8, Brushes.Black, 180, 175 + height, right)

            ' Calculate total price
            'Dim totalPrice As Long = product.ProductPrice * quantity
        Next
        'End If

        Dim totalQuantity As Integer = 0
        Dim totalPrice As Decimal = 0

        For Each product As ProductDetails In productList
            totalQuantity += product.ProductQuantity
            totalPrice += product.ProductPrice * product.ProductQuantity
        Next

        e.Graphics.DrawString(totalPrice.ToString("##,##0"), f8, Brushes.Black, rightmargin, 175 + height, right)



        Dim height2 As Integer
        height2 = 190 + height
        'sumprice() 'call sum
        e.Graphics.DrawString(line, f8, Brushes.Black, 0, height2)
        e.Graphics.DrawString("Total: " & Format(totalPrice, "##,##0"), f10b, Brushes.Black, rightmargin, 10 + height2, right)
        e.Graphics.DrawString(totalQuantity, f10b, Brushes.Black, 0, 10 + height2)
        'Barcode
        'Dim gbarcode As New MessagingToolkit.Barcode.BarcodeEncoder
        'Try
        'Dim barcodeimage As Image
        'barcodeimage = New Bitmap(gbarcode.Encode(MessagingToolkit.Barcode.BarcodeFormat.Code128, "DRW8555RE"))
        'e.Graphics.DrawImage(barcodeimage, CInt((e.PageBounds.Width - 150) / 2), 35 + height2, 150, 35)
        'Catch ex As Exception
        'MsgBox(ex.Message)
        'End Try

        e.Graphics.DrawString("Service Category : Grocery Services", f8, Brushes.Black, centermargin, 30 + height2, center)
        e.Graphics.DrawString("SAC/HSN CODE 996331", f8, Brushes.Black, centermargin, 40 + height2, center)
        e.Graphics.DrawString("FSSAI License No. :12223009000699", f8, Brushes.Black, centermargin, 50 + height2, center)
        e.Graphics.DrawString("Disclaimer : For Cash-transactions, the", f8, Brushes.Black, centermargin, 60 + height2, center)
        e.Graphics.DrawString("invoice  amount is rounded off to the next", f8, Brushes.Black, centermargin, 70 + height2, center)
        e.Graphics.DrawString("nearest rupee if the value is equal to", f8, Brushes.Black, centermargin, 80 + height2, center)
        e.Graphics.DrawString("or more than 50 paisa.", f8, Brushes.Black, centermargin, 90 + height2, center)
        e.Graphics.DrawString(" --- Check Closed ---", f8, Brushes.Black, centermargin, 100 + height2, center)
        e.Graphics.DrawString("share your feedback & get 10% of f", f8, Brushes.Black, centermargin, 110 + height2, center)
        e.Graphics.DrawString("Visit: www.anymart.com", f8, Brushes.Black, centermargin, 120 + height2, center)
        e.Graphics.DrawString("store ID:31888", f8, Brushes.Black, centermargin, 130 + height2, center)
        e.Graphics.DrawString("Code:068-111-031-028-214-8", f8, Brushes.Black, centermargin, 140 + height2, center)
        e.Graphics.DrawString("Write Discount code after survey below", f8, Brushes.Black, centermargin, 150 + height2, center)
        e.Graphics.DrawString("Code:_________", f8, Brushes.Black, centermargin, 160 + height2, center)
        e.Graphics.DrawString("Handover the bill for Discount", f8, Brushes.Black, centermargin, 170 + height2, center)
        e.Graphics.DrawString("Discount valid for 30 days", f8, Brushes.Black, centermargin, 180 + height2, center)

        e.Graphics.DrawString("~ Thanks for shopping ~", f10, Brushes.Black, centermargin, 210 + height2, center)
        e.Graphics.DrawString("~ Visit Again ~", f10, Brushes.Black, centermargin, 225 + height2, center)

    End Sub



End Class
Public Class ProductDetails
    Public Property ProductName As String
    Public Property ProductQuantity As Integer
    Public Property ProductPrice As Decimal
End Class