<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class reports
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
        Panel1 = New Panel()
        PictureBox1 = New PictureBox()
        outlog = New LinkLabel()
        btnrep = New Button()
        btnvent = New Button()
        btnhome = New Button()
        Panel6 = New Panel()
        Label2 = New Label()
        Panel5 = New Panel()
        Panel4 = New Panel()
        Panel3 = New Panel()
        Panel2 = New Panel()
        Label1 = New Label()
        Panel7 = New Panel()
        Label3 = New Label()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel6.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.AutoSize = True
        Panel1.BackColor = Color.SpringGreen
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(outlog)
        Panel1.Controls.Add(btnrep)
        Panel1.Controls.Add(btnvent)
        Panel1.Controls.Add(btnhome)
        Panel1.Location = New Point(0, 43)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(162, 410)
        Panel1.TabIndex = 1
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
        ' outlog
        ' 
        outlog.AutoSize = True
        outlog.BackColor = Color.MediumAquamarine
        outlog.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        outlog.LinkBehavior = LinkBehavior.HoverUnderline
        outlog.LinkColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        outlog.LinkVisited = True
        outlog.Location = New Point(47, 354)
        outlog.Name = "outlog"
        outlog.Size = New Size(63, 21)
        outlog.TabIndex = 3
        outlog.TabStop = True
        outlog.Text = "Logout"
        outlog.VisitedLinkColor = Color.FromArgb(CByte(0), CByte(64), CByte(0))
        ' 
        ' btnrep
        ' 
        btnrep.BackColor = Color.Peru
        btnrep.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnrep.ForeColor = Color.Transparent
        btnrep.Location = New Point(12, 276)
        btnrep.Name = "btnrep"
        btnrep.Size = New Size(131, 32)
        btnrep.TabIndex = 1
        btnrep.Text = "Reports"
        btnrep.UseVisualStyleBackColor = False
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
        ' Panel6
        ' 
        Panel6.AutoSize = True
        Panel6.BackColor = Color.DarkSlateGray
        Panel6.Controls.Add(Label2)
        Panel6.Location = New Point(0, -1)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(802, 47)
        Panel6.TabIndex = 10
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Arial Narrow", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.ButtonHighlight
        Label2.Location = New Point(178, 9)
        Label2.Name = "Label2"
        Label2.Size = New Size(389, 25)
        Label2.TabIndex = 10
        Label2.Text = "Double JDG Inventory Management Systeem"
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = SystemColors.ActiveBorder
        Panel5.Location = New Point(653, 95)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(119, 92)
        Panel5.TabIndex = 15
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = SystemColors.ActiveBorder
        Panel4.Location = New Point(335, 95)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(119, 92)
        Panel4.TabIndex = 14
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.ActiveBorder
        Panel3.Location = New Point(493, 95)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(119, 92)
        Panel3.TabIndex = 13
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.ActiveBorder
        Panel2.Location = New Point(178, 95)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(119, 92)
        Panel2.TabIndex = 12
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(178, 62)
        Label1.Name = "Label1"
        Label1.Size = New Size(96, 21)
        Label1.TabIndex = 11
        Label1.Text = "Dasshboard"
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = SystemColors.ActiveBorder
        Panel7.Location = New Point(178, 245)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(594, 187)
        Panel7.TabIndex = 17
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(178, 214)
        Label3.Name = "Label3"
        Label3.Size = New Size(72, 21)
        Label3.TabIndex = 16
        Label3.Text = "Reports "
        ' 
        ' reports
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.PaleGreen
        ClientSize = New Size(800, 450)
        Controls.Add(Panel7)
        Controls.Add(Label3)
        Controls.Add(Panel5)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Label1)
        Controls.Add(Panel6)
        Controls.Add(Panel1)
        Name = "reports"
        Text = "reports"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents outlog As LinkLabel
    Friend WithEvents btnrep As Button
    Friend WithEvents btnvent As Button
    Friend WithEvents btnhome As Button
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label3 As Label
End Class
