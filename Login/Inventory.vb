Imports System.Windows.Forms
Imports Google.Cloud.Firestore
Imports FirebaseAdmin
Imports Google.Apis.Auth.OAuth2
Imports System.IO
Imports QRCoder

Public Class Inventory
    Public Shared dt As New DataTable()

    Private Async Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize Firebase and load inventory
        FirebaseHelper.Initialize()
        Await LoadInventoryItems()
    End Sub

    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnhome.Click
        Dim inv As New Dashboard()
        inv.Show()
        Me.Close() ' 🔹 This closes the Dashboard window
    End Sub

    Private Sub out_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles out.LinkClicked
        Application.Exit()
    End Sub

    Private Sub delete_Click(sender As Object, e As EventArgs)
        If DataGridView1.CurrentRow IsNot Nothing AndAlso Not DataGridView1.CurrentRow.IsNewRow Then
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        End If
    End Sub

    Private Sub search_Click(sender As Object, e As EventArgs) Handles search.Click
        Dim searchText As String = TextSearch.Text.Trim().ToLower()
        For Each row As DataGridViewRow In DataGridView1.Rows
            row.DefaultCellStyle.BackColor = Color.White
            For Each cell As DataGridViewCell In row.Cells
                If cell.Value IsNot Nothing AndAlso cell.Value.ToString().ToLower().Contains(searchText) Then
                    row.DefaultCellStyle.BackColor = Color.Yellow
                    Exit For
                End If
            Next
        Next
        TextSearch.Clear()
    End Sub

    ' ============================================
    ' Firebase Helper Class with Service Account
    ' ============================================
    Public Class FirebaseHelper
        Private Shared db As FirestoreDb
        Private Shared isInitialized As Boolean = False

        ' Initialize Firebase with Service Account (no messageboxes)
        Public Shared Sub Initialize()
            Try
                If db IsNot Nothing Then Exit Sub

                Dim pathToServiceAccountKey As String = Path.Combine(Application.StartupPath, "serviceAccountKey.json")
                If Not File.Exists(pathToServiceAccountKey) Then Exit Sub

                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", pathToServiceAccountKey)
                db = FirestoreDb.Create("mobile-inventory-95f33")
            Catch
                ' Silent fail
            End Try
        End Sub

        ' Add item to inventory collection
        Public Shared Async Function AddInventoryItem(itemName As String, quantity As Integer, price As Decimal) As Task(Of Boolean)
            Try
                Initialize()
                If db Is Nothing Then Return False

                Dim itemData As New Dictionary(Of String, Object) From {
                    {"name", itemName},
                    {"quantity", quantity},
                    {"price", CDbl(price)},
                    {"date", DateTime.Now.ToString("yyyy-MM-dd")},
                    {"createdAt", Timestamp.FromDateTime(DateTime.UtcNow)}
                }

                Dim collection = db.Collection("inventory")
                Await collection.AddAsync(itemData)
                Return True
            Catch
                Return False
            End Try
        End Function

        ' Get all inventory items
        Public Shared Async Function GetAllInventoryItems() As Task(Of List(Of InventoryItem))
            Try
                Initialize()
                If db Is Nothing Then Return New List(Of InventoryItem)()

                Dim items As New List(Of InventoryItem)()
                Dim collection = db.Collection("inventory")
                Dim snapshot = Await collection.GetSnapshotAsync()

                For Each document In snapshot.Documents
                    Dim data = document.ToDictionary()
                    Dim item As New InventoryItem With {
                        .Id = document.Id,
                        .Name = If(data.ContainsKey("name"), data("name").ToString(), ""),
                        .Quantity = If(data.ContainsKey("quantity"), CInt(data("quantity")), 0),
                        .Price = If(data.ContainsKey("price"), CDec(data("price")), 0D),
                        .DateAdded = If(data.ContainsKey("date"), data("date").ToString(), DateTime.Now.ToString("yyyy-MM-dd"))
                    }
                    items.Add(item)
                Next
                Return items
            Catch
                Return New List(Of InventoryItem)()
            End Try
        End Function

        ' Update an inventory item
        Public Shared Async Function UpdateInventoryItem(documentId As String, itemName As String, quantity As Integer, price As Decimal) As Task(Of Boolean)
            Try
                Initialize()
                If db Is Nothing Then Return False

                Dim docRef = db.Collection("inventory").Document(documentId)
                Dim updates As New Dictionary(Of String, Object) From {
                    {"name", itemName},
                    {"quantity", quantity},
                    {"price", CDbl(price)},
                    {"date", DateTime.Now.ToString("yyyy-MM-dd")}
                }
                Await docRef.UpdateAsync(updates)
                Return True
            Catch
                Return False
            End Try
        End Function

        ' Delete an inventory item
        Public Shared Async Function DeleteInventoryItem(documentId As String) As Task(Of Boolean)
            Try
                Initialize()
                If db Is Nothing Then Return False

                Dim docRef = db.Collection("inventory").Document(documentId)
                Await docRef.DeleteAsync()
                Return True
            Catch
                Return False
            End Try
        End Function

        ' Search inventory items by name
        Public Shared Async Function SearchInventoryItems(searchTerm As String) As Task(Of List(Of InventoryItem))
            Try
                Initialize()
                If db Is Nothing Then Return New List(Of InventoryItem)()

                Dim items As New List(Of InventoryItem)()
                Dim collection = db.Collection("inventory")
                Dim snapshot = Await collection.GetSnapshotAsync()

                For Each document In snapshot.Documents
                    Dim data = document.ToDictionary()
                    Dim name As String = If(data.ContainsKey("name"), data("name").ToString(), "")
                    If name.ToLower().Contains(searchTerm.ToLower()) Then
                        Dim item As New InventoryItem With {
                            .Id = document.Id,
                            .Name = name,
                            .Quantity = If(data.ContainsKey("quantity"), CInt(data("quantity")), 0),
                            .Price = If(data.ContainsKey("price"), CDec(data("price")), 0D),
                            .DateAdded = If(data.ContainsKey("date"), data("date").ToString(), DateTime.Now.ToString("yyyy-MM-dd"))
                        }
                        items.Add(item)
                    End If
                Next
                Return items
            Catch
                Return New List(Of InventoryItem)()
            End Try
        End Function
    End Class

    ' ============================================
    ' Data Model
    ' ============================================
    Public Class InventoryItem
        Public Property Id As String
        Public Property Name As String
        Public Property Quantity As Integer
        Public Property Price As Decimal
        Public Property DateAdded As String
    End Class

    ' ============================================
    ' Generate Button Click Event
    ' ============================================
    Private Async Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles Gen.Click
        Dim generateForm As New GenerateItemForm()
        generateForm.ShowDialog()

        If generateForm.DialogSuccess Then
            Dim itemName As String = generateForm.ItemName
            Dim itemQuantity As Integer = generateForm.ItemQuantity
            Dim itemPrice As Decimal = generateForm.ItemPrice

            ' Validation (silent)
            If itemPrice <= 0 OrElse itemQuantity < 0 OrElse String.IsNullOrWhiteSpace(itemName) Then Return

            Me.Cursor = Cursors.WaitCursor
            Dim success As Boolean = Await FirebaseHelper.AddInventoryItem(itemName, itemQuantity, itemPrice)
            Me.Cursor = Cursors.Default

            If success Then
                Try
                    ' Generate QR Code silently
                    Dim qrData As String = $"Item: {itemName} | Qty: {itemQuantity} | Price: ₱{itemPrice:N2}"
                    Dim qrGenerator As New QRCoder.QRCodeGenerator()
                    Dim qrCodeData = qrGenerator.CreateQrCode(qrData, QRCoder.QRCodeGenerator.ECCLevel.Q)
                    Dim qrCode As New QRCoder.QRCode(qrCodeData)
                    Dim qrImage As Bitmap = qrCode.GetGraphic(5)

                    PictureBoxQR.Image = qrImage
                    PictureBoxQR.SizeMode = PictureBoxSizeMode.Zoom

                    Dim savePath As String = Path.Combine(Application.StartupPath, $"{itemName}_QR.png")
                    qrImage.Save(savePath, Imaging.ImageFormat.Png)

                Catch
                    ' Silent fail for QR generation
                End Try

                ' Reload inventory
                Await LoadInventoryItems()
            End If
        End If
    End Sub

    ' Load inventory items into DataGridView
    Private Async Function LoadInventoryItems() As Task
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim items = Await FirebaseHelper.GetAllInventoryItems()

            Me.Invoke(Sub()
                          DataGridView1.Rows.Clear()
                          For Each item In items
                              DataGridView1.Rows.Add(item.Name, item.Quantity, item.DateAdded, "₱" & item.Price.ToString("N2"))
                          Next
                      End Sub)

            Me.Cursor = Cursors.Default
        Catch
            Me.Cursor = Cursors.Default
        End Try
    End Function

    ' Search button click
    Private Async Sub btnSearch_Click(sender As Object, e As EventArgs) Handles TextSearch.Click
        Dim searchTerm As String = TextSearch.Text.Trim()
        If String.IsNullOrWhiteSpace(searchTerm) Then
            Await LoadInventoryItems()
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim items = Await FirebaseHelper.SearchInventoryItems(searchTerm)

        Me.Invoke(Sub()
                      DataGridView1.Rows.Clear()
                      For Each item In items
                          DataGridView1.Rows.Add(item.Name, item.Quantity, item.DateAdded, "₱" & item.Price.ToString("N2"))
                      Next
                  End Sub)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TextSearch_TextChanged(sender As Object, e As EventArgs) Handles TextSearch.TextChanged
    End Sub
End Class
