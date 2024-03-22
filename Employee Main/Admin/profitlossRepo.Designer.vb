<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class profitlossRepo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvprofit = New System.Windows.Forms.DataGridView()
        Me.txt_pmprice = New System.Windows.Forms.TextBox()
        Me.txt_sellingloss = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_psprice = New System.Windows.Forms.TextBox()
        Me.txt_manufactloss = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_grossprofit = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Grossloss = New System.Windows.Forms.TextBox()
        Me.txt_netproloss = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvloss = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvprofit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvloss, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvprofit
        '
        Me.dgvprofit.AllowUserToAddRows = False
        Me.dgvprofit.AllowUserToDeleteRows = False
        Me.dgvprofit.BackgroundColor = System.Drawing.Color.White
        Me.dgvprofit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvprofit.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column9, Me.Column7, Me.Column10, Me.Column8, Me.Column11})
        Me.dgvprofit.GridColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dgvprofit.Location = New System.Drawing.Point(12, 33)
        Me.dgvprofit.Name = "dgvprofit"
        Me.dgvprofit.ReadOnly = True
        Me.dgvprofit.Size = New System.Drawing.Size(538, 184)
        Me.dgvprofit.TabIndex = 60
        '
        'txt_pmprice
        '
        Me.txt_pmprice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_pmprice.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txt_pmprice.Location = New System.Drawing.Point(569, 59)
        Me.txt_pmprice.Name = "txt_pmprice"
        Me.txt_pmprice.ReadOnly = True
        Me.txt_pmprice.Size = New System.Drawing.Size(155, 29)
        Me.txt_pmprice.TabIndex = 64
        '
        'txt_sellingloss
        '
        Me.txt_sellingloss.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_sellingloss.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txt_sellingloss.Location = New System.Drawing.Point(569, 342)
        Me.txt_sellingloss.Name = "txt_sellingloss"
        Me.txt_sellingloss.ReadOnly = True
        Me.txt_sellingloss.Size = New System.Drawing.Size(155, 29)
        Me.txt_sellingloss.TabIndex = 65
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(566, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Buying Price"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(566, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = "Selling Price"
        '
        'txt_psprice
        '
        Me.txt_psprice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_psprice.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txt_psprice.Location = New System.Drawing.Point(569, 119)
        Me.txt_psprice.Name = "txt_psprice"
        Me.txt_psprice.ReadOnly = True
        Me.txt_psprice.Size = New System.Drawing.Size(155, 29)
        Me.txt_psprice.TabIndex = 68
        '
        'txt_manufactloss
        '
        Me.txt_manufactloss.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_manufactloss.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txt_manufactloss.Location = New System.Drawing.Point(569, 282)
        Me.txt_manufactloss.Name = "txt_manufactloss"
        Me.txt_manufactloss.ReadOnly = True
        Me.txt_manufactloss.Size = New System.Drawing.Size(155, 29)
        Me.txt_manufactloss.TabIndex = 70
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(566, 326)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 73
        Me.Label6.Text = "Selling Price"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(565, 266)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "Buying Price"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(566, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Gross Profit"
        '
        'txt_grossprofit
        '
        Me.txt_grossprofit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_grossprofit.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txt_grossprofit.Location = New System.Drawing.Point(569, 179)
        Me.txt_grossprofit.Name = "txt_grossprofit"
        Me.txt_grossprofit.ReadOnly = True
        Me.txt_grossprofit.Size = New System.Drawing.Size(155, 29)
        Me.txt_grossprofit.TabIndex = 74
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(566, 386)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Gross Loss"
        '
        'txt_Grossloss
        '
        Me.txt_Grossloss.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Grossloss.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txt_Grossloss.Location = New System.Drawing.Point(569, 402)
        Me.txt_Grossloss.Name = "txt_Grossloss"
        Me.txt_Grossloss.ReadOnly = True
        Me.txt_Grossloss.Size = New System.Drawing.Size(155, 29)
        Me.txt_Grossloss.TabIndex = 76
        '
        'txt_netproloss
        '
        Me.txt_netproloss.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_netproloss.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txt_netproloss.Location = New System.Drawing.Point(865, 214)
        Me.txt_netproloss.Name = "txt_netproloss"
        Me.txt_netproloss.ReadOnly = True
        Me.txt_netproloss.Size = New System.Drawing.Size(155, 29)
        Me.txt_netproloss.TabIndex = 82
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(865, 196)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 15)
        Me.Label10.TabIndex = 83
        Me.Label10.Text = "Net Profit / Loss"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Profit Report"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(12, 240)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "Loss Report"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(765, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 128)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "}"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(718, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(311, 13)
        Me.Label11.TabIndex = 87
        Me.Label11.Text = "* Positive value indicates profit and negative value indicates loss"
        '
        'Column1
        '
        Me.Column1.HeaderText = "Product Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Product Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Product Type"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Product Category"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Product Quantity"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Product Unit"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Product Buying Price"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "TAX"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "Product Selling Price"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "Product Discount"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "Product Profit"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'dgvloss
        '
        Me.dgvloss.AllowUserToAddRows = False
        Me.dgvloss.AllowUserToDeleteRows = False
        Me.dgvloss.BackgroundColor = System.Drawing.Color.White
        Me.dgvloss.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvloss.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21})
        Me.dgvloss.GridColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dgvloss.Location = New System.Drawing.Point(12, 256)
        Me.dgvloss.Name = "dgvloss"
        Me.dgvloss.ReadOnly = True
        Me.dgvloss.Size = New System.Drawing.Size(538, 184)
        Me.dgvloss.TabIndex = 88
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Product Code"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Product Name"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Product Type"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Product Category"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "Product Quantity"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "Product Unit"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "Product Buying Price"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.HeaderText = "TAX"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.HeaderText = "Product Selling Price"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.HeaderText = "Product Discount"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.HeaderText = "Product Profit"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        '
        'profitlossRepo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1041, 461)
        Me.Controls.Add(Me.dgvloss)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_netproloss)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_Grossloss)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_grossprofit)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_manufactloss)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_psprice)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_sellingloss)
        Me.Controls.Add(Me.txt_pmprice)
        Me.Controls.Add(Me.dgvprofit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "profitlossRepo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "profitlossRepo"
        CType(Me.dgvprofit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvloss, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvprofit As DataGridView
    Friend WithEvents txt_pmprice As TextBox
    Friend WithEvents txt_sellingloss As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_psprice As TextBox
    Friend WithEvents txt_manufactloss As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_grossprofit As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_Grossloss As TextBox
    Friend WithEvents txt_netproloss As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents dgvloss As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn
End Class
