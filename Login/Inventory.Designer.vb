<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Inventory
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
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Panel1 = New Panel()
        PictureBoxQR = New PictureBox()
        PictureBox1 = New PictureBox()
        out = New LinkLabel()
        btnvent = New Button()
        btnhome = New Button()
        PictureBoxQR = New PictureBox()
        Panel6 = New Panel()
        Label2 = New Label()
        TextSearch = New TextBox()
        Gen = New Button()
        search = New Button()
<<<<<<< HEAD
        update = New Button()
=======
>>>>>>> f5bef54 (Update VB.NET project)
        DataGridView1 = New DataGridView()
        Column1 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
<<<<<<< HEAD
        delete = New Button()
        TextPrice = New TextBox()
        TextDate = New TextBox()
        Textname = New TextBox()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        PictureBoxCamera = New PictureBox()
        btnScanQR = New Button()
=======
        Column4 = New DataGridViewTextBoxColumn()
>>>>>>> f5bef54 (Update VB.NET project)
        Panel1.SuspendLayout()
        CType(PictureBoxQR, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBoxQR, ComponentModel.ISupportInitialize).BeginInit()
        Panel6.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBoxCamera, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.AutoSize = True
        Panel1.BackColor = Color.SpringGreen
        Panel1.Controls.Add(PictureBoxQR)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(out)
        Panel1.Controls.Add(btnvent)
        Panel1.Controls.Add(btnhome)
        Panel1.Location = New Point(1, 38)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(212, 414)
        Panel1.TabIndex = 1
        ' 
        ' PictureBoxQR
        ' 
        PictureBoxQR.BackColor = Color.White
        PictureBoxQR.Location = New Point(9, 10)
        PictureBoxQR.Name = "PictureBoxQR"
        PictureBoxQR.Size = New Size(150, 150)
        PictureBoxQR.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBoxQR.TabIndex = 0
        PictureBoxQR.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.logo
        PictureBox1.Location = New Point(21, 19)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(113, 107)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 5
        PictureBox1.TabStop = False
        ' 
        ' out
        ' 
        out.AutoSize = True
        out.BackColor = Color.MediumAquamarine
        out.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        out.LinkBehavior = LinkBehavior.HoverUnderline
        out.LinkColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        out.LinkVisited = True
        out.Location = New Point(47, 354)
        out.Name = "out"
        out.Size = New Size(63, 21)
        out.TabIndex = 3
        out.TabStop = True
        out.Text = "Logout"
        out.VisitedLinkColor = Color.FromArgb(CByte(0), CByte(64), CByte(0))
        ' 
<<<<<<< HEAD
        ' btnrep
        ' 
        btnrep.BackColor = Color.Peru
        btnrep.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnrep.ForeColor = Color.Transparent
        btnrep.Location = New Point(12, 276)
        btnrep.Name = "btnrep"
        btnrep.Size = New Size(131, 32)
        btnrep.TabIndex = 1
        btnrep.Text = "Reports"
        btnrep.UseVisualStyleBackColor = False
        ' 
=======
>>>>>>> f5bef54 (Update VB.NET project)
        ' btnvent
        ' 
        btnvent.BackColor = Color.Peru
        btnvent.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnvent.ForeColor = Color.Transparent
        btnvent.Location = New Point(12, 223)
        btnvent.Name = "btnvent"
        btnvent.Size = New Size(131, 32)
        btnvent.TabIndex = 2
        btnvent.Text = "Inventory"
        btnvent.UseVisualStyleBackColor = False
        ' 
        ' btnhome
        ' 
        btnhome.BackColor = Color.Peru
        btnhome.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnhome.ForeColor = Color.Transparent
        btnhome.Location = New Point(12, 171)
        btnhome.Name = "btnhome"
        btnhome.Size = New Size(131, 32)
        btnhome.TabIndex = 0
        btnhome.Text = "Home"
        btnhome.UseVisualStyleBackColor = False
        ' 
        ' PictureBoxQR
        ' 
        PictureBoxQR.BackColor = Color.White
        PictureBoxQR.Location = New Point(624, 48)
        PictureBoxQR.Name = "PictureBoxQR"
        PictureBoxQR.Size = New Size(150, 150)
        PictureBoxQR.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBoxQR.TabIndex = 0
        PictureBoxQR.TabStop = False
        ' 
        ' Panel6
        ' 
        Panel6.AutoSize = True
        Panel6.BackColor = Color.DarkSlateGray
        Panel6.Controls.Add(Label2)
        Panel6.Location = New Point(1, -2)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(802, 44)
        Panel6.TabIndex = 10
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.ButtonHighlight
        Label2.Location = New Point(178, 9)
        Label2.Name = "Label2"
<<<<<<< HEAD
        Label2.Size = New Size(481, 25)
=======
        Label2.Size = New Size(468, 25)
>>>>>>> f5bef54 (Update VB.NET project)
        Label2.TabIndex = 10
        Label2.Text = "Double JDG Inventory Management System"
        ' 
        ' TextSearch
        ' 
        TextSearch.Location = New Point(226, 222)
        TextSearch.Multiline = True
        TextSearch.Name = "TextSearch"
        TextSearch.Size = New Size(223, 29)
        TextSearch.TabIndex = 11
        ' 
        ' Gen
        ' 
        Gen.BackColor = Color.Peru
        Gen.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Gen.ForeColor = Color.Transparent
        Gen.Location = New Point(624, 209)
        Gen.Name = "Gen"
        Gen.Size = New Size(153, 43)
        Gen.TabIndex = 14
        Gen.Text = "Generate"
        Gen.UseVisualStyleBackColor = False
        ' 
<<<<<<< HEAD
        ' Add
        ' 
        Add.BackColor = Color.Peru
        Add.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Add.ForeColor = Color.Transparent
        Add.Location = New Point(189, 97)
        Add.Name = "Add"
        Add.Size = New Size(131, 36)
        Add.TabIndex = 15
        Add.Text = "Add"
        Add.UseVisualStyleBackColor = False
        ' 
=======
>>>>>>> f5bef54 (Update VB.NET project)
        ' search
        ' 
        search.BackColor = Color.DarkSlateGray
        search.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        search.ForeColor = Color.Transparent
        search.Location = New Point(455, 222)
        search.Name = "search"
        search.Size = New Size(98, 32)
        search.TabIndex = 16
        search.Text = "Search"
        search.UseVisualStyleBackColor = False
        ' 
<<<<<<< HEAD
        ' update
        ' 
        update.BackColor = Color.LightSeaGreen
        update.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        update.ForeColor = Color.Transparent
        update.Location = New Point(564, 160)
        update.Name = "update"
        update.Size = New Size(83, 32)
        update.TabIndex = 17
        update.Text = "Update "
        update.UseVisualStyleBackColor = False
        ' 
=======
>>>>>>> f5bef54 (Update VB.NET project)
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.Anchor = AnchorStyles.None
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DataGridView1.BackgroundColor = Color.White
        DataGridView1.BorderStyle = BorderStyle.None
        DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None
<<<<<<< HEAD
        DataGridViewCellStyle2.BackColor = SystemColors.Control
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9.0F)
        DataGridViewCellStyle2.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3})
=======
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3, Column4})
>>>>>>> f5bef54 (Update VB.NET project)
        DataGridView1.GridColor = Color.White
        DataGridView1.Location = New Point(189, 260)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RightToLeft = RightToLeft.No
        DataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridView1.Size = New Size(588, 189)
        DataGridView1.TabIndex = 20
        ' 
        ' Column1
        ' 
        Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column1.DividerWidth = 3
        Column1.HeaderText = "Name"
        Column1.Name = "Column1"
        Column1.ReadOnly = True
        Column1.Resizable = DataGridViewTriState.False
        ' 
        ' Column2
        ' 
        Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column2.HeaderText = "Quantity"
        Column2.Name = "Column2"
        Column2.ReadOnly = True
        Column2.Resizable = DataGridViewTriState.False
        ' 
        ' Column3
        ' 
        Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column3.HeaderText = "Date"
        Column3.Name = "Column3"
        Column3.ReadOnly = True
        Column3.Resizable = DataGridViewTriState.False
        ' 
        ' Column4
        ' 
<<<<<<< HEAD
        delete.BackColor = Color.Crimson
        delete.Font = New Font("Segoe UI Semibold", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        delete.ForeColor = Color.Transparent
        delete.Location = New Point(694, 160)
        delete.Name = "delete"
        delete.Size = New Size(83, 32)
        delete.TabIndex = 21
        delete.Text = "Delete"
        delete.UseVisualStyleBackColor = False
        ' 
        ' TextPrice
        ' 
        TextPrice.Location = New Point(670, 97)
        TextPrice.Multiline = True
        TextPrice.Name = "TextPrice"
        TextPrice.Size = New Size(107, 29)
        TextPrice.TabIndex = 22
        ' 
        ' TextDate
        ' 
        TextDate.Location = New Point(512, 97)
        TextDate.Multiline = True
        TextDate.Name = "TextDate"
        TextDate.Size = New Size(107, 29)
        TextDate.TabIndex = 23
        ' 
        ' Textname
        ' 
        Textname.Location = New Point(354, 97)
        Textname.Multiline = True
        Textname.Name = "Textname"
        Textname.Size = New Size(110, 29)
        Textname.TabIndex = 24
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(384, 129)
        Label3.Name = "Label3"
        Label3.Size = New Size(49, 20)
        Label3.TabIndex = 25
        Label3.Text = "Name"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.Transparent
        Label4.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(542, 129)
        Label4.Name = "Label4"
        Label4.Size = New Size(41, 20)
        Label4.TabIndex = 26
        Label4.Text = "Date"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(707, 129)
        Label5.Name = "Label5"
        Label5.Size = New Size(41, 20)
        Label5.TabIndex = 27
        Label5.Text = "Price"
=======
        Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column4.HeaderText = "Price"
        Column4.Name = "Column4"
        Column4.ReadOnly = True
        Column4.Resizable = DataGridViewTriState.False
>>>>>>> f5bef54 (Update VB.NET project)
        ' 
        ' PictureBoxCamera
        ' 
        PictureBoxCamera.BackColor = Color.Black
        PictureBoxCamera.Location = New Point(354, 234)
        PictureBoxCamera.Name = "PictureBoxCamera"
        PictureBoxCamera.Size = New Size(200, 150)
        PictureBoxCamera.SizeMode = PictureBoxSizeMode.Zoom
        PictureBoxCamera.TabIndex = 0
        PictureBoxCamera.TabStop = False
        ' 
        ' btnScanQR
        ' 
        btnScanQR.BackColor = Color.Teal
        btnScanQR.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnScanQR.ForeColor = Color.White
        btnScanQR.Location = New Point(657, 201)
        btnScanQR.Name = "btnScanQR"
        btnScanQR.Size = New Size(120, 40)
        btnScanQR.TabIndex = 1
        btnScanQR.Text = "Scan QR"
        btnScanQR.UseVisualStyleBackColor = False
        ' 
        ' Inventory
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.PaleGreen
        ClientSize = New Size(800, 450)
<<<<<<< HEAD
        Controls.Add(PictureBoxCamera)
        Controls.Add(btnScanQR)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Textname)
        Controls.Add(TextDate)
        Controls.Add(TextPrice)
        Controls.Add(delete)
        Controls.Add(DataGridView1)
        Controls.Add(update)
=======
        Controls.Add(PictureBoxQR)
        Controls.Add(DataGridView1)
>>>>>>> f5bef54 (Update VB.NET project)
        Controls.Add(search)
        Controls.Add(Gen)
        Controls.Add(TextSearch)
        Controls.Add(Panel6)
        Controls.Add(Panel1)
        Name = "Inventory"
        Text = "Inventory"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBoxQR, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBoxQR, ComponentModel.ISupportInitialize).EndInit()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBoxCamera, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub


    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents out As LinkLabel
    Friend WithEvents btnvent As Button
    Friend WithEvents btnhome As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents TextSearch As TextBox
    Friend WithEvents Gen As Button
    Friend WithEvents PictureBoxQR As PictureBox
<<<<<<< HEAD
    Friend WithEvents btnScanQR As Button
    Friend WithEvents PictureBoxCamera As PictureBox
    Friend WithEvents Add As Button
    Friend WithEvents search As Button
    Friend WithEvents update As Button
=======
    Friend WithEvents search As Button
>>>>>>> f5bef54 (Update VB.NET project)
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn  ' Added
End Class