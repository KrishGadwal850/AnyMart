<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Bill_Generator
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
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.addProduct = New System.Windows.Forms.Button()
        Me.txt_dis = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_sprice = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_unit = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_qty = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_cat = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_type = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_pname = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_code = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProcessButton = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btn_upd = New System.Windows.Forms.Button()
        Me.btn_del = New System.Windows.Forms.Button()
        Me.txt_search1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.newCart = New System.Windows.Forms.Button()
        Me.prevbtn = New System.Windows.Forms.Button()
        Me.nextbtn = New System.Windows.Forms.Button()
        Me.cartNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Column8
        '
        Me.Column8.HeaderText = "Discount"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Measurable Unit"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Product Quantity"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Product Category"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Product Type"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Product Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Product Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Selling Price"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'txt_total
        '
        Me.txt_total.Location = New System.Drawing.Point(949, 262)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.ReadOnly = True
        Me.txt_total.Size = New System.Drawing.Size(95, 22)
        Me.txt_total.TabIndex = 130
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(946, 246)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 129
        Me.Label12.Text = "Cart Total"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(924, 6)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(120, 43)
        Me.Button5.TabIndex = 127
        Me.Button5.Text = "Re-Stock"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'addProduct
        '
        Me.addProduct.Location = New System.Drawing.Point(510, 70)
        Me.addProduct.Name = "addProduct"
        Me.addProduct.Size = New System.Drawing.Size(120, 43)
        Me.addProduct.TabIndex = 124
        Me.addProduct.Text = "Add Product"
        Me.addProduct.UseVisualStyleBackColor = True
        '
        'txt_dis
        '
        Me.txt_dis.Location = New System.Drawing.Point(949, 189)
        Me.txt_dis.Name = "txt_dis"
        Me.txt_dis.ReadOnly = True
        Me.txt_dis.Size = New System.Drawing.Size(95, 22)
        Me.txt_dis.TabIndex = 123
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(946, 173)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 122
        Me.Label10.Text = "Discount"
        '
        'txt_sprice
        '
        Me.txt_sprice.Location = New System.Drawing.Point(754, 189)
        Me.txt_sprice.Name = "txt_sprice"
        Me.txt_sprice.ReadOnly = True
        Me.txt_sprice.Size = New System.Drawing.Size(189, 22)
        Me.txt_sprice.TabIndex = 121
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(751, 173)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 13)
        Me.Label9.TabIndex = 120
        Me.Label9.Text = "Selling Price"
        '
        'txt_unit
        '
        Me.txt_unit.Location = New System.Drawing.Point(580, 189)
        Me.txt_unit.Name = "txt_unit"
        Me.txt_unit.ReadOnly = True
        Me.txt_unit.Size = New System.Drawing.Size(168, 22)
        Me.txt_unit.TabIndex = 119
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(577, 173)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 118
        Me.Label7.Text = "Unit"
        '
        'txt_qty
        '
        Me.txt_qty.Location = New System.Drawing.Point(407, 189)
        Me.txt_qty.Name = "txt_qty"
        Me.txt_qty.Size = New System.Drawing.Size(167, 22)
        Me.txt_qty.TabIndex = 117
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(404, 173)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 116
        Me.Label6.Text = "Quantity"
        '
        'txt_cat
        '
        Me.txt_cat.Location = New System.Drawing.Point(823, 143)
        Me.txt_cat.Name = "txt_cat"
        Me.txt_cat.ReadOnly = True
        Me.txt_cat.Size = New System.Drawing.Size(221, 22)
        Me.txt_cat.TabIndex = 115
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(820, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 114
        Me.Label5.Text = "Category"
        '
        'txt_type
        '
        Me.txt_type.Location = New System.Drawing.Point(682, 143)
        Me.txt_type.Name = "txt_type"
        Me.txt_type.ReadOnly = True
        Me.txt_type.Size = New System.Drawing.Size(135, 22)
        Me.txt_type.TabIndex = 113
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(679, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 112
        Me.Label4.Text = "Type"
        '
        'txt_pname
        '
        Me.txt_pname.Location = New System.Drawing.Point(407, 143)
        Me.txt_pname.Name = "txt_pname"
        Me.txt_pname.ReadOnly = True
        Me.txt_pname.Size = New System.Drawing.Size(269, 22)
        Me.txt_pname.TabIndex = 111
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(404, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 110
        Me.Label3.Text = "Product Name"
        '
        'txt_code
        '
        Me.txt_code.Location = New System.Drawing.Point(407, 82)
        Me.txt_code.Name = "txt_code"
        Me.txt_code.Size = New System.Drawing.Size(97, 22)
        Me.txt_code.TabIndex = 109
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(404, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "Code"
        '
        'ProcessButton
        '
        Me.ProcessButton.Location = New System.Drawing.Point(924, 645)
        Me.ProcessButton.Name = "ProcessButton"
        Me.ProcessButton.Size = New System.Drawing.Size(120, 43)
        Me.ProcessButton.TabIndex = 107
        Me.ProcessButton.Text = "Proceed             >"
        Me.ProcessButton.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(660, 645)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 43)
        Me.Button2.TabIndex = 106
        Me.Button2.Text = "Clear"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btn_upd
        '
        Me.btn_upd.Location = New System.Drawing.Point(534, 645)
        Me.btn_upd.Name = "btn_upd"
        Me.btn_upd.Size = New System.Drawing.Size(120, 43)
        Me.btn_upd.TabIndex = 105
        Me.btn_upd.Text = "Update"
        Me.btn_upd.UseVisualStyleBackColor = True
        '
        'btn_del
        '
        Me.btn_del.Location = New System.Drawing.Point(408, 645)
        Me.btn_del.Name = "btn_del"
        Me.btn_del.Size = New System.Drawing.Size(120, 43)
        Me.btn_del.TabIndex = 104
        Me.btn_del.Text = "Delete"
        Me.btn_del.UseVisualStyleBackColor = True
        '
        'txt_search1
        '
        Me.txt_search1.Location = New System.Drawing.Point(7, 22)
        Me.txt_search1.Name = "txt_search1"
        Me.txt_search1.Size = New System.Drawing.Size(396, 22)
        Me.txt_search1.TabIndex = 103
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Search"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column10, Me.Column11, Me.Column12, Me.Column14, Me.Column15, Me.Column13, Me.Column9})
        Me.DataGridView2.Location = New System.Drawing.Point(408, 299)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.Size = New System.Drawing.Size(636, 340)
        Me.DataGridView2.TabIndex = 101
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8})
        Me.DataGridView1.Location = New System.Drawing.Point(7, 52)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(396, 636)
        Me.DataGridView1.TabIndex = 100
        '
        'newCart
        '
        Me.newCart.Location = New System.Drawing.Point(863, 246)
        Me.newCart.Name = "newCart"
        Me.newCart.Size = New System.Drawing.Size(72, 43)
        Me.newCart.TabIndex = 131
        Me.newCart.Text = "New Cart"
        Me.newCart.UseVisualStyleBackColor = True
        '
        'prevbtn
        '
        Me.prevbtn.Location = New System.Drawing.Point(757, 247)
        Me.prevbtn.Name = "prevbtn"
        Me.prevbtn.Size = New System.Drawing.Size(40, 40)
        Me.prevbtn.TabIndex = 132
        Me.prevbtn.Text = "<"
        Me.prevbtn.UseVisualStyleBackColor = True
        '
        'nextbtn
        '
        Me.nextbtn.Location = New System.Drawing.Point(803, 247)
        Me.nextbtn.Name = "nextbtn"
        Me.nextbtn.Size = New System.Drawing.Size(40, 40)
        Me.nextbtn.TabIndex = 133
        Me.nextbtn.Text = ">"
        Me.nextbtn.UseVisualStyleBackColor = True
        '
        'cartNo
        '
        Me.cartNo.Location = New System.Drawing.Point(661, 262)
        Me.cartNo.Name = "cartNo"
        Me.cartNo.ReadOnly = True
        Me.cartNo.Size = New System.Drawing.Size(75, 22)
        Me.cartNo.TabIndex = 135
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(658, 246)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 134
        Me.Label8.Text = "Cart No."
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(407, 262)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(233, 22)
        Me.TextBox2.TabIndex = 137
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(404, 246)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 13)
        Me.Label11.TabIndex = 136
        Me.Label11.Text = "Search"
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
        'Column9
        '
        Me.Column9.HeaderText = "Product Discount"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Bill_Generator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1048, 694)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cartNo)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.nextbtn)
        Me.Controls.Add(Me.prevbtn)
        Me.Controls.Add(Me.newCart)
        Me.Controls.Add(Me.txt_total)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.addProduct)
        Me.Controls.Add(Me.txt_dis)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txt_sprice)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_unit)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_qty)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txt_cat)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_type)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_pname)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_code)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ProcessButton)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btn_upd)
        Me.Controls.Add(Me.btn_del)
        Me.Controls.Add(Me.txt_search1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Bill_Generator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = " "
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents txt_total As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents addProduct As Button
    Friend WithEvents txt_dis As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txt_sprice As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txt_unit As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_qty As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_cat As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_type As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_pname As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_code As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ProcessButton As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents btn_upd As Button
    Friend WithEvents btn_del As Button
    Friend WithEvents txt_search1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents newCart As Button
    Friend WithEvents prevbtn As Button
    Friend WithEvents nextbtn As Button
    Friend WithEvents cartNo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
End Class
