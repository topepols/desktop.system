<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dashboard
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Panel1 = New Panel()
        PictureBox1 = New PictureBox()
        logout = New LinkLabel()
        btnvent = New Button()
        btnhome = New Button()
        Label1 = New Label()
        Panel2 = New Panel()
        Panel3 = New Panel()
        Panel4 = New Panel()
        Panel5 = New Panel()
        Panel6 = New Panel()
        Label2 = New Label()
        Label3 = New Label()
        DataGridView2 = New DataGridView()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel6.SuspendLayout()
        CType(DataGridView2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.AutoSize = True
        Panel1.BackColor = Color.SpringGreen
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(logout)
        Panel1.Controls.Add(btnvent)
        Panel1.Controls.Add(btnhome)
        Panel1.Location = New Point(0, 43)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(162, 410)
        Panel1.TabIndex = 0
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
        ' logout
        ' 
        logout.AutoSize = True
        logout.BackColor = Color.MediumAquamarine
        logout.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        logout.LinkBehavior = LinkBehavior.HoverUnderline
        logout.LinkColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        logout.LinkVisited = True
        logout.Location = New Point(47, 354)
        logout.Name = "logout"
        logout.Size = New Size(63, 21)
        logout.TabIndex = 3
        logout.TabStop = True
        logout.Text = "Logout"
        logout.VisitedLinkColor = Color.FromArgb(CByte(0), CByte(64), CByte(0))
        ' 
        ' btnvent
        ' 
        btnvent.BackColor = Color.Peru
        btnvent.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
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
        btnhome.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnhome.ForeColor = Color.Transparent
        btnhome.Location = New Point(12, 171)
        btnhome.Name = "btnhome"
        btnhome.Size = New Size(131, 32)
        btnhome.TabIndex = 0
        btnhome.Text = "Home"
        btnhome.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(178, 62)
        Label1.Name = "Label1"
        Label1.Size = New Size(96, 21)
        Label1.TabIndex = 4
        Label1.Text = "Dasshboard"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.ActiveBorder
        Panel2.Location = New Point(178, 95)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(119, 92)
        Panel2.TabIndex = 5
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.ActiveBorder
        Panel3.Location = New Point(493, 95)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(119, 92)
        Panel3.TabIndex = 6
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = SystemColors.ActiveBorder
        Panel4.Location = New Point(335, 95)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(119, 92)
        Panel4.TabIndex = 7
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = SystemColors.ActiveBorder
        Panel5.Location = New Point(653, 95)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(119, 92)
        Panel5.TabIndex = 8
        ' 
        ' Panel6
        ' 
        Panel6.AutoSize = True
        Panel6.BackColor = Color.DarkSlateGray
        Panel6.Controls.Add(Label2)
        Panel6.Location = New Point(0, 0)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(802, 44)
        Panel6.TabIndex = 9
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.ButtonHighlight
        Label2.Location = New Point(178, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(468, 25)
        Label2.TabIndex = 10
        Label2.Text = "Double JDG Inventory Management System"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(178, 220)
        Label3.Name = "Label3"
        Label3.Size = New Size(72, 21)
        Label3.TabIndex = 10
        Label3.Text = "Reports "
        ' 
        ' DataGridView2
        ' 
        DataGridView2.AllowUserToAddRows = False
        DataGridView2.AllowUserToDeleteRows = False
        DataGridView2.AllowUserToResizeColumns = False
        DataGridView2.AllowUserToResizeRows = False
        DataGridView2.Anchor = AnchorStyles.None
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DataGridView2.BackgroundColor = Color.White
        DataGridView2.BorderStyle = BorderStyle.None
        DataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridView2.GridColor = Color.White
        DataGridView2.Location = New Point(184, 249)
        DataGridView2.Name = "DataGridView2"
        DataGridView2.ReadOnly = True
        DataGridView2.RightToLeft = RightToLeft.No
        DataGridView2.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        DataGridView2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridView2.Size = New Size(588, 189)
        DataGridView2.TabIndex = 21
        ' 
        ' Dashboard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.PaleGreen
        ClientSize = New Size(800, 450)
        Controls.Add(DataGridView2)
        Controls.Add(Label3)
        Controls.Add(Panel6)
        Controls.Add(Panel5)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Label1)
        Controls.Add(Panel1)
        Name = "Dashboard"
        Text = "Dashboard"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        CType(DataGridView2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents logout As LinkLabel
    Friend WithEvents btnvent As Button
    Friend WithEvents btnhome As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents DataGridView2 As DataGridView
End Class
