<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GenerateItemForm
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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        txtName = New TextBox()
        txtQuantity = New TextBox()
        txtPrice = New TextBox()
        btnSubmit = New Button()
        btnCancel = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 12.0F)
        Label1.Location = New Point(47, 45)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(91, 20)
        Label1.TabIndex = 0
        Label1.Text = "Item Name:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft Sans Serif", 12.0F)
        Label2.Location = New Point(47, 98)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(72, 20)
        Label2.TabIndex = 1
        Label2.Text = "Quantity:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft Sans Serif", 12.0F)
        Label3.Location = New Point(47, 150)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(48, 20)
        Label3.TabIndex = 2
        Label3.Text = "Price:"
        ' 
        ' txtName
        ' 
        txtName.Font = New Font("Microsoft Sans Serif", 12.0F)
        txtName.Location = New Point(140, 43)
        txtName.Margin = New Padding(2, 2, 2, 2)
        txtName.Name = "txtName"
        txtName.Size = New Size(250, 26)
        txtName.TabIndex = 3
        ' 
        ' txtQuantity
        ' 
        txtQuantity.Font = New Font("Microsoft Sans Serif", 12.0F)
        txtQuantity.Location = New Point(140, 95)
        txtQuantity.Margin = New Padding(2, 2, 2, 2)
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(250, 26)
        txtQuantity.TabIndex = 4
        ' 
        ' txtPrice
        ' 
        txtPrice.Font = New Font("Microsoft Sans Serif", 12.0F)
        txtPrice.Location = New Point(140, 148)
        txtPrice.Margin = New Padding(2, 2, 2, 2)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(250, 26)
        txtPrice.TabIndex = 5
        ' 
        ' btnSubmit
        ' 
        btnSubmit.BackColor = Color.FromArgb(CByte(76), CByte(175), CByte(80))
        btnSubmit.FlatStyle = FlatStyle.Flat
        btnSubmit.Font = New Font("Microsoft Sans Serif", 11.0F, FontStyle.Bold)
        btnSubmit.ForeColor = Color.White
        btnSubmit.Location = New Point(117, 202)
        btnSubmit.Margin = New Padding(2, 2, 2, 2)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.Size = New Size(109, 34)
        btnSubmit.TabIndex = 6
        btnSubmit.Text = "Submit"
        btnSubmit.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.FromArgb(CByte(244), CByte(67), CByte(54))
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Microsoft Sans Serif", 11.0F, FontStyle.Bold)
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(249, 202)
        btnCancel.Margin = New Padding(2, 2, 2, 2)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(109, 34)
        btnCancel.TabIndex = 7
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' GenerateItemForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(532, 326)
        Controls.Add(btnCancel)
        Controls.Add(btnSubmit)
        Controls.Add(txtPrice)
        Controls.Add(txtQuantity)
        Controls.Add(txtName)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        MinimizeBox = False
        Name = "GenerateItemForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Generate New Item"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnCancel As Button
End Class
