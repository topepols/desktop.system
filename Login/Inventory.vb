
Imports System.Windows.Forms.VisualStyles

Public Class Inventory
    Public Shared dt As New DataTable()
    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load, DataGridView1.DpiChangedAfterParent, DataGridView1.MarginChanged, DataGridView1.Resize
        Dim pic As New Drawing2D.GraphicsPath
        pic.AddEllipse(2, 2, 100, 100)
        PictureBox1.Region = New Region(pic)
    End Sub
    Private Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click
        Dim Name As String = Textname.Text
        Dim Petsa As String = TextDate.Text
        Dim Price As String = TextPrice.Text

        Dim v = DataGridView1.Rows.Add(Name, Petsa, Price)

        Textname.Clear()
        TextDate.Clear()
        TextPrice.Clear()
    End Sub
    Private Sub btnhome_Click(sender As Object, e As EventArgs) Handles btnhome.Click
        Dashboard.Show()
    End Sub

    Private Sub btnrep_Click(sender As Object, e As EventArgs) Handles btnrep.Click
        reports.Show()
        Dashboard.Close()
    End Sub

    Private Sub out_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles out.LinkClicked
        Application.Exit()
    End Sub

    Private Sub delete_Click(sender As Object, e As EventArgs) Handles delete.Click
        If DataGridView1.CurrentRow IsNot Nothing AndAlso Not DataGridView1.CurrentRow.IsNewRow Then
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        Else
            MessageBox.Show("Please select a row to delete.")
        End If
    End Sub

    Private Sub search_Click(sender As Object, e As EventArgs) Handles search.Click
        Dim searchText As String = TextSearch.Text.Trim().ToLower()
        Dim found As Boolean = False

        ' Loop through all rows
        For Each row As DataGridViewRow In DataGridView1.Rows
            row.DefaultCellStyle.BackColor = Color.White ' reset color

            ' Check each cell in the row
            For Each cell As DataGridViewCell In row.Cells
                If cell.Value IsNot Nothing AndAlso cell.Value.ToString().ToLower().Contains(searchText) Then
                    row.DefaultCellStyle.BackColor = Color.Yellow
                    found = True
                    Exit For
                End If
            Next
        Next
        TextSearch.Clear()
        If Not found Then
            MessageBox.Show("No match found.")
        End If

    End Sub
End Class
