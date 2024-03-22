<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EmployeeDetails
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.txt_pass = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DOB = New System.Windows.Forms.Label()
        Me.txt_address = New System.Windows.Forms.TextBox()
        Me.Hire = New System.Windows.Forms.Button()
        Me.txt_dob = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_user = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_code = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_name = New System.Windows.Forms.TextBox()
        Me.txt_doj = New System.Windows.Forms.DateTimePicker()
        Me.txt_city = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_phone = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_email = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_status = New System.Windows.Forms.TextBox()
        Me.txt_dol = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_role = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Button6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Button6.Location = New System.Drawing.Point(282, 14)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(139, 43)
        Me.Button6.TabIndex = 26
        Me.Button6.Text = "Clear"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(897, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(139, 43)
        Me.Button2.TabIndex = 24
        Me.Button2.Text = "Delete"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(752, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(139, 43)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "Update"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.Gray
        Me.DataGridView1.ColumnHeadersHeight = 50
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column8, Me.Column9, Me.Column10, Me.Column5, Me.Column6, Me.Column7})
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.No
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(3, 290)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1041, 401)
        Me.DataGridView1.TabIndex = 28
        '
        'Column1
        '
        Me.Column1.HeaderText = "Employee Code"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Employee Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Address"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "City"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "Date Of Birth"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Contact No. (Phone)"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column10
        '
        Me.Column10.HeaderText = "Email ( If Any )"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Date Of Joining"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Status"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Date Of Leaving"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'txt_search
        '
        Me.txt_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_search.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txt_search.Location = New System.Drawing.Point(12, 31)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.Size = New System.Drawing.Size(108, 22)
        Me.txt_search.TabIndex = 33
        '
        'txt_pass
        '
        Me.txt_pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_pass.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txt_pass.Location = New System.Drawing.Point(644, 95)
        Me.txt_pass.Name = "txt_pass"
        Me.txt_pass.Size = New System.Drawing.Size(193, 22)
        Me.txt_pass.TabIndex = 59
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(644, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Password"
        '
        'DOB
        '
        Me.DOB.AutoSize = True
        Me.DOB.BackColor = System.Drawing.Color.Transparent
        Me.DOB.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.DOB.ForeColor = System.Drawing.Color.Black
        Me.DOB.Location = New System.Drawing.Point(327, 128)
        Me.DOB.Name = "DOB"
        Me.DOB.Size = New System.Drawing.Size(30, 13)
        Me.DOB.TabIndex = 56
        Me.DOB.Text = "DOB"
        '
        'txt_address
        '
        Me.txt_address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_address.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txt_address.Location = New System.Drawing.Point(11, 144)
        Me.txt_address.Name = "txt_address"
        Me.txt_address.Size = New System.Drawing.Size(310, 22)
        Me.txt_address.TabIndex = 55
        '
        'Hire
        '
        Me.Hire.BackColor = System.Drawing.Color.White
        Me.Hire.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Hire.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Hire.Location = New System.Drawing.Point(137, 14)
        Me.Hire.Name = "Hire"
        Me.Hire.Size = New System.Drawing.Size(139, 43)
        Me.Hire.TabIndex = 54
        Me.Hire.Text = "Hire / Fire"
        Me.Hire.UseVisualStyleBackColor = False
        '
        'txt_dob
        '
        Me.txt_dob.CalendarFont = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txt_dob.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txt_dob.Location = New System.Drawing.Point(327, 144)
        Me.txt_dob.Name = "txt_dob"
        Me.txt_dob.Size = New System.Drawing.Size(152, 22)
        Me.txt_dob.TabIndex = 53
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(328, 79)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 52
        Me.Label8.Text = "User Name"
        '
        'txt_user
        '
        Me.txt_user.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_user.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txt_user.Location = New System.Drawing.Point(328, 95)
        Me.txt_user.Name = "txt_user"
        Me.txt_user.Size = New System.Drawing.Size(310, 22)
        Me.txt_user.TabIndex = 51
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(11, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Code"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(843, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 13)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "City"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(485, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "DOJ"
        '
        'txt_code
        '
        Me.txt_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_code.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txt_code.Location = New System.Drawing.Point(11, 95)
        Me.txt_code.Name = "txt_code"
        Me.txt_code.ReadOnly = True
        Me.txt_code.Size = New System.Drawing.Size(100, 22)
        Me.txt_code.TabIndex = 42
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(117, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(11, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Address"
        '
        'txt_name
        '
        Me.txt_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_name.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txt_name.Location = New System.Drawing.Point(117, 95)
        Me.txt_name.Name = "txt_name"
        Me.txt_name.Size = New System.Drawing.Size(205, 22)
        Me.txt_name.TabIndex = 43
        '
        'txt_doj
        '
        Me.txt_doj.CalendarFont = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txt_doj.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txt_doj.Location = New System.Drawing.Point(485, 144)
        Me.txt_doj.Name = "txt_doj"
        Me.txt_doj.Size = New System.Drawing.Size(153, 22)
        Me.txt_doj.TabIndex = 49
        '
        'txt_city
        '
        Me.txt_city.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_city.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txt_city.Location = New System.Drawing.Point(843, 95)
        Me.txt_city.Name = "txt_city"
        Me.txt_city.Size = New System.Drawing.Size(193, 22)
        Me.txt_city.TabIndex = 46
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(12, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Search"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(11, 239)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(589, 13)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "Note* - username and password gets automatically generated so no need to write it" &
    ", although you can update it."
        '
        'txt_phone
        '
        Me.txt_phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_phone.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txt_phone.Location = New System.Drawing.Point(644, 144)
        Me.txt_phone.Name = "txt_phone"
        Me.txt_phone.Size = New System.Drawing.Size(193, 22)
        Me.txt_phone.TabIndex = 63
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(644, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 62
        Me.Label9.Text = "Phone No."
        '
        'txt_email
        '
        Me.txt_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_email.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txt_email.Location = New System.Drawing.Point(843, 144)
        Me.txt_email.Name = "txt_email"
        Me.txt_email.Size = New System.Drawing.Size(193, 22)
        Me.txt_email.TabIndex = 65
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(843, 128)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "Email"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(159, 175)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 69
        Me.Label12.Text = "DOL"
        '
        'txt_status
        '
        Me.txt_status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_status.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txt_status.Location = New System.Drawing.Point(11, 191)
        Me.txt_status.Name = "txt_status"
        Me.txt_status.ReadOnly = True
        Me.txt_status.Size = New System.Drawing.Size(142, 22)
        Me.txt_status.TabIndex = 68
        '
        'txt_dol
        '
        Me.txt_dol.CalendarFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_dol.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.txt_dol.Location = New System.Drawing.Point(159, 191)
        Me.txt_dol.Name = "txt_dol"
        Me.txt_dol.Size = New System.Drawing.Size(162, 22)
        Me.txt_dol.TabIndex = 67
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(11, 175)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 13)
        Me.Label13.TabIndex = 66
        Me.Label13.Text = "Status"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(324, 175)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(131, 13)
        Me.Label15.TabIndex = 72
        Me.Label15.Text = "Designation (Post / role)"
        '
        'txt_role
        '
        Me.txt_role.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_role.FormattingEnabled = True
        Me.txt_role.Items.AddRange(New Object() {"employee", "manager", "admin"})
        Me.txt_role.Location = New System.Drawing.Point(327, 191)
        Me.txt_role.Name = "txt_role"
        Me.txt_role.Size = New System.Drawing.Size(152, 21)
        Me.txt_role.TabIndex = 73
        Me.txt_role.Text = "employee"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Button3.Location = New System.Drawing.Point(897, 209)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(139, 43)
        Me.Button3.TabIndex = 74
        Me.Button3.Text = "Employee History"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'EmployeeDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1048, 694)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.txt_role)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txt_status)
        Me.Controls.Add(Me.txt_dol)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txt_email)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txt_phone)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_pass)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DOB)
        Me.Controls.Add(Me.txt_address)
        Me.Controls.Add(Me.Hire)
        Me.Controls.Add(Me.txt_dob)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_user)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_code)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_name)
        Me.Controls.Add(Me.txt_doj)
        Me.Controls.Add(Me.txt_city)
        Me.Controls.Add(Me.txt_search)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "EmployeeDetails"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button6 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txt_search As TextBox
    Friend WithEvents txt_pass As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DOB As Label
    Friend WithEvents txt_address As TextBox
    Friend WithEvents Hire As Button
    Friend WithEvents txt_dob As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_user As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_code As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_name As TextBox
    Friend WithEvents txt_doj As DateTimePicker
    Friend WithEvents txt_city As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents txt_phone As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txt_email As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txt_status As TextBox
    Friend WithEvents txt_dol As DateTimePicker
    Friend WithEvents Label13 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txt_role As ComboBox
    Friend WithEvents Button3 As Button
End Class
