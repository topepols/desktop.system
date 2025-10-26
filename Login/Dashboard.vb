Imports Google.Cloud.Firestore

Public Class Dashboard

    Private Async Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Round profile image
        Dim pic As New Drawing2D.GraphicsPath
        pic.AddEllipse(2, 2, 100, 100)
        PictureBox1.Region = New Region(pic)

        ' Load real-time Firestore reports
        Await LoadInventoryReports()
    End Sub

    ' Load data from "reports" collection like React
    Private Async Function LoadInventoryReports() As Task
        Try
            DataGridView2.Rows.Clear()
            DataGridView2.Columns.Clear()

            ' Define columns
            If DataGridView2.Columns.Count = 0 Then
                DataGridView2.Columns.Add("Action", "Action")
                DataGridView2.Columns.Add("Name", "Name")
                DataGridView2.Columns.Add("Quantity", "Quantity")
                DataGridView2.Columns.Add("Price", "Price")
                DataGridView2.Columns.Add("User", "User")
                DataGridView2.Columns.Add("Timestamp", "Timestamp")
            End If

            ' Get Firestore snapshot
            Dim snapshot = Await FirestoreInventory.Db.Collection("reports").GetSnapshotAsync()

            ' Fill rows
            For Each doc In snapshot.Documents
                Dim data = doc.ToDictionary()

                Dim action As String = If(data.ContainsKey("action"), data("action").ToString(), "")
                Dim name As String = If(data.ContainsKey("name"), data("name").ToString(), "")
                Dim quantity As String = If(data.ContainsKey("quantity"), data("quantity").ToString(), "0")
                Dim price As String = ""
                If data.ContainsKey("price") Then
                    Dim rawPrice = data("price")
                    If TypeOf rawPrice Is Double OrElse TypeOf rawPrice Is Decimal Then
                        price = "₱" & Convert.ToDouble(rawPrice).ToString("N2")
                    Else
                        price = rawPrice.ToString()
                    End If
                End If
                Dim user As String = If(data.ContainsKey("user"), data("user").ToString(), "Unknown")
                Dim timestamp As String = ""
                If data.ContainsKey("timestamp") Then
                    Dim ts = data("timestamp")
                    ' Firestore timestamp -> DateTime
                    If TypeOf ts Is Timestamp Then
                        timestamp = CType(ts, Timestamp).ToDateTime().ToLocalTime().ToString("MM/dd/yyyy hh:mm tt")
                    Else
                        timestamp = ts.ToString()
                    End If
                End If

                DataGridView2.Rows.Add(action, name, quantity, price, user, timestamp)
            Next

            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        Catch ex As Exception
            MessageBox.Show("Error loading report data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    ' Open Inventory form
    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnvent.Click
        Dim inv As New Inventory()
        inv.Show()
        Me.Close()
    End Sub

    ' Logout
    Private Sub logout_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles logout.LinkClicked
        Application.Exit()
    End Sub

<<<<<<< HEAD
    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        DataGridView2.DataSource = Form1
        DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
End Class
=======
End Class
>>>>>>> f5bef54 (Update VB.NET project)
