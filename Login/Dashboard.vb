Public Class Dashboard
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim pic As New Drawing2D.GraphicsPath
        pic.AddEllipse(2, 2, 100, 100)
        PictureBox1.Region = New Region(pic)
    End Sub

    Private Sub btnvent_Click(sender As Object, e As EventArgs) Handles btnvent.Click
        Inventory.Show()
    End Sub

    Private Sub btnrep_Click(sender As Object, e As EventArgs) Handles btnrep.Click
        reports.Show()
    End Sub

    Private Sub logout_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles logout.LinkClicked
        Application.Exit()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        DataGridView2.DataSource = Form1.dt
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
End Class