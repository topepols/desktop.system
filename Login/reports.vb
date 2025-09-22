Public Class reports
    Private Sub reports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim pic As New Drawing2D.GraphicsPath
        pic.AddEllipse(2, 2, 100, 100)
        PictureBox1.Region = New Region(pic)
    End Sub

    Private Sub btnvent_Click(sender As Object, e As EventArgs) Handles btnvent.Click
        Inventory.Show()
    End Sub

    Private Sub btnhome_Click(sender As Object, e As EventArgs) Handles btnhome.Click
        Dashboard.Show()
        Inventory.Hide()
    End Sub

    Private Sub outlog_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles outlog.LinkClicked
        Application.Exit()
    End Sub
End Class