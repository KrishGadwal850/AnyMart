<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Bill_Proceed
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_cname = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_phone = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Total = New System.Windows.Forms.Label()
        Me.TLabel = New System.Windows.Forms.Label()
        Me.AddLabel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PnoLabel = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.billNo = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DateLabel = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TimeLabel = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column10, Me.Column11, Me.Column12, Me.Column14, Me.Column15, Me.Column13})
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(636, 340)
        Me.DataGridView1.TabIndex = 102
        '
        'Column10
        '
        Me.Column10.HeaderText = "Product Code"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "Product Name"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.HeaderText = "Product Type"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.HeaderText = "Product Quantity"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'Column15
        '
        Me.Column15.HeaderText = "Measurable Unit"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.HeaderText = "Product Price"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'txt_cname
        '
        Me.txt_cname.Location = New System.Drawing.Point(299, 526)
        Me.txt_cname.Name = "txt_cname"
        Me.txt_cname.Size = New System.Drawing.Size(325, 22)
        Me.txt_cname.TabIndex = 132
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(296, 510)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Customer Name"
        '
        'txt_phone
        '
        Me.txt_phone.Location = New System.Drawing.Point(12, 526)
        Me.txt_phone.Name = "txt_phone"
        Me.txt_phone.Size = New System.Drawing.Size(281, 22)
        Me.txt_phone.TabIndex = 130
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 510)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "Phone No."
        '
        'PrintDocument1
        '
        '
        'Total
        '
        Me.Total.AutoSize = True
        Me.Total.Location = New System.Drawing.Point(508, 343)
        Me.Total.Name = "Total"
        Me.Total.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Total.Size = New System.Drawing.Size(41, 13)
        Me.Total.TabIndex = 134
        Me.Total.Text = "Total : "
        '
        'TLabel
        '
        Me.TLabel.AutoSize = True
        Me.TLabel.Location = New System.Drawing.Point(546, 343)
        Me.TLabel.Name = "TLabel"
        Me.TLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TLabel.Size = New System.Drawing.Size(58, 13)
        Me.TLabel.TabIndex = 135
        Me.TLabel.Text = "Loading..."
        '
        'AddLabel
        '
        Me.AddLabel.AutoSize = True
        Me.AddLabel.Location = New System.Drawing.Point(57, 400)
        Me.AddLabel.Name = "AddLabel"
        Me.AddLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.AddLabel.Size = New System.Drawing.Size(58, 13)
        Me.AddLabel.TabIndex = 137
        Me.AddLabel.Text = "Loading..."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 400)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 136
        Me.Label5.Text = "Address : "
        '
        'PnoLabel
        '
        Me.PnoLabel.AutoSize = True
        Me.PnoLabel.Location = New System.Drawing.Point(94, 423)
        Me.PnoLabel.Name = "PnoLabel"
        Me.PnoLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PnoLabel.Size = New System.Drawing.Size(58, 13)
        Me.PnoLabel.TabIndex = 139
        Me.PnoLabel.Text = "Loading..."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 423)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(93, 13)
        Me.Label7.TabIndex = 138
        Me.Label7.Text = "Phone Number : "
        '
        'billNo
        '
        Me.billNo.AutoSize = True
        Me.billNo.Location = New System.Drawing.Point(75, 448)
        Me.billNo.Name = "billNo"
        Me.billNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.billNo.Size = New System.Drawing.Size(58, 13)
        Me.billNo.TabIndex = 141
        Me.billNo.Text = "Loading..."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 448)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 140
        Me.Label9.Text = "Bill Number : "
        '
        'DateLabel
        '
        Me.DateLabel.AutoSize = True
        Me.DateLabel.Location = New System.Drawing.Point(323, 448)
        Me.DateLabel.Name = "DateLabel"
        Me.DateLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DateLabel.Size = New System.Drawing.Size(58, 13)
        Me.DateLabel.TabIndex = 145
        Me.DateLabel.Text = "Loading..."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(268, 448)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(58, 13)
        Me.Label11.TabIndex = 144
        Me.Label11.Text = "Bill Date : "
        '
        'TimeLabel
        '
        Me.TimeLabel.AutoSize = True
        Me.TimeLabel.Location = New System.Drawing.Point(566, 448)
        Me.TimeLabel.Name = "TimeLabel"
        Me.TimeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TimeLabel.Size = New System.Drawing.Size(58, 13)
        Me.TimeLabel.TabIndex = 147
        Me.TimeLabel.Text = "Loading..."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(528, 448)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 146
        Me.Label13.Text = "Time : "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(55, 343)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(58, 13)
        Me.Label14.TabIndex = 149
        Me.Label14.Text = "Loading..."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(4, 343)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 148
        Me.Label15.Text = "Cashier : "
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 554)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(612, 39)
        Me.Button1.TabIndex = 150
        Me.Button1.Text = "Proceed To Payment"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Bill_Proceed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(636, 605)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TimeLabel)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.DateLabel)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.billNo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PnoLabel)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.AddLabel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TLabel)
        Me.Controls.Add(Me.Total)
        Me.Controls.Add(Me.txt_cname)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_phone)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Bill_Proceed"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bill_Proceed"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents txt_cname As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_phone As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Total As Label
    Friend WithEvents TLabel As Label
    Friend WithEvents AddLabel As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PnoLabel As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents billNo As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents DateLabel As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TimeLabel As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Button1 As Button
End Class
