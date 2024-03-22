<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class payment
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
        Me.btnCash = New System.Windows.Forms.Button()
        Me.btnOnline = New System.Windows.Forms.Button()
        Me.btnCard = New System.Windows.Forms.Button()
        Me.btnReceived = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.imgBox = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.imgBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCash
        '
        Me.btnCash.Location = New System.Drawing.Point(37, 287)
        Me.btnCash.Name = "btnCash"
        Me.btnCash.Size = New System.Drawing.Size(77, 51)
        Me.btnCash.TabIndex = 1
        Me.btnCash.Text = "CASH"
        Me.btnCash.UseVisualStyleBackColor = True
        '
        'btnOnline
        '
        Me.btnOnline.Location = New System.Drawing.Point(132, 287)
        Me.btnOnline.Name = "btnOnline"
        Me.btnOnline.Size = New System.Drawing.Size(77, 51)
        Me.btnOnline.TabIndex = 2
        Me.btnOnline.Text = "QR"
        Me.btnOnline.UseVisualStyleBackColor = True
        '
        'btnCard
        '
        Me.btnCard.Location = New System.Drawing.Point(228, 287)
        Me.btnCard.Name = "btnCard"
        Me.btnCard.Size = New System.Drawing.Size(77, 51)
        Me.btnCard.TabIndex = 3
        Me.btnCard.Text = "CARD"
        Me.btnCard.UseVisualStyleBackColor = True
        '
        'btnReceived
        '
        Me.btnReceived.Enabled = False
        Me.btnReceived.Location = New System.Drawing.Point(12, 358)
        Me.btnReceived.Name = "btnReceived"
        Me.btnReceived.Size = New System.Drawing.Size(320, 51)
        Me.btnReceived.TabIndex = 4
        Me.btnReceived.Text = "PAYMENT RECEIVED"
        Me.btnReceived.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 415)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(320, 51)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "PAYMENT NOT RECEIVED"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'imgBox
        '
        Me.imgBox.InitialImage = Global.Inventory.My.Resources.Resources.card
        Me.imgBox.Location = New System.Drawing.Point(68, 38)
        Me.imgBox.Name = "imgBox"
        Me.imgBox.Size = New System.Drawing.Size(204, 210)
        Me.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgBox.TabIndex = 0
        Me.imgBox.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(139, 251)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 6
        '
        'payment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 474)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnReceived)
        Me.Controls.Add(Me.btnCard)
        Me.Controls.Add(Me.btnOnline)
        Me.Controls.Add(Me.btnCash)
        Me.Controls.Add(Me.imgBox)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "payment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "payment"
        CType(Me.imgBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents imgBox As PictureBox
    Friend WithEvents btnCash As Button
    Friend WithEvents btnOnline As Button
    Friend WithEvents btnCard As Button
    Friend WithEvents btnReceived As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
End Class
