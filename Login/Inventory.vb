<<<<<<< HEAD
﻿Imports System.Windows.Forms.VisualStyles
Imports Google.Cloud.Firestore
Imports QRCoder
Imports System.IO
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports ZXing
=======
﻿Imports System.Windows.Forms
Imports Google.Cloud.Firestore
Imports FirebaseAdmin
Imports Google.Apis.Auth.OAuth2
Imports System.IO
Imports QRCoder
>>>>>>> f5bef54 (Update VB.NET project)

Public Class Inventory
    Private videoDevices As FilterInfoCollection
    Private videoSource As VideoCaptureDevice
    Private qrReader As New BarcodeReader()
    Private scanActive As Boolean = False

    Public Shared dt As New DataTable()

<<<<<<< HEAD
    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' CRITICAL FIX: Set PictureBox properties for camera display
        PictureBoxCamera.SizeMode = PictureBoxSizeMode.Zoom
        PictureBoxCamera.Visible = False
        PictureBoxCamera.BackColor = Color.Black
        PictureBoxCamera.BringToFront() ' Ensure it's visible when active

        InitializeFirestore()
        LoadInventory(DataGridView1)
    End Sub

    Private Sub btnScanQR_Click(sender As Object, e As EventArgs) Handles btnScanQR.Click
        Try
            If Not scanActive Then
                ' Show camera box
                PictureBoxCamera.Visible = True
                PictureBoxCamera.Image = Nothing

                ' Get available cameras
                videoDevices = New FilterInfoCollection(FilterCategory.VideoInputDevice)
                If videoDevices.Count = 0 Then
                    MessageBox.Show("No camera detected!", "Camera Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    PictureBoxCamera.Visible = False
                    Return
                End If

                ' Initialize camera
                videoSource = New VideoCaptureDevice(videoDevices(0).MonikerString)

                ' FIX #1: Set video resolution explicitly (choose one that your camera supports)
                If videoSource.VideoCapabilities.Length > 0 Then
                    ' Try to find 640x480 or use the first available resolution
                    Dim capability = videoSource.VideoCapabilities.FirstOrDefault(Function(c) c.FrameSize.Width = 640 AndAlso c.FrameSize.Height = 480)
                    If capability Is Nothing Then
                        capability = videoSource.VideoCapabilities(0) ' Use first available
                    End If
                    videoSource.VideoResolution = capability
                End If

                ' Attach event handler
                AddHandler videoSource.NewFrame, AddressOf OnNewFrame

                ' Start camera
                videoSource.Start()

                scanActive = True
                btnScanQR.Text = "🛑 Stop Scan"

            Else
                StopCamera()
            End If
        Catch ex As Exception
            MessageBox.Show("Error initializing camera: " & ex.Message & vbCrLf & vbCrLf & "Stack: " & ex.StackTrace, "Camera Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            StopCamera()
        End Try
    End Sub

    Private Sub OnNewFrame(sender As Object, eventArgs As NewFrameEventArgs)
        Try
            ' Clone the frame to avoid memory issues
            Dim bitmap As Bitmap = DirectCast(eventArgs.Frame.Clone(), Bitmap)

            ' FIX #3: Properly invoke on UI thread with error handling
            If PictureBoxCamera.InvokeRequired Then
                PictureBoxCamera.Invoke(Sub()
                                            Try
                                                ' Dispose old image to prevent memory leak
                                                Dim oldImage = PictureBoxCamera.Image
                                                PictureBoxCamera.Image = DirectCast(bitmap.Clone(), Bitmap)
                                                If oldImage IsNot Nothing Then
                                                    oldImage.Dispose()
                                                End If
                                            Catch ex As Exception
                                                ' Handle UI update errors silently
                                            End Try
                                        End Sub)
            Else
                Dim oldImage = PictureBoxCamera.Image
                PictureBoxCamera.Image = DirectCast(bitmap.Clone(), Bitmap)
                If oldImage IsNot Nothing Then
                    oldImage.Dispose()
                End If
            End If

            ' Try to decode QR code
            Dim result = qrReader.Decode(bitmap)
            If result IsNot Nothing Then
                Dim parts() As String = result.Text.Split("|"c)
                If parts.Length = 3 Then
                    Invoke(Sub()
                               Textname.Text = parts(0)
                               TextDate.Text = parts(1)
                               TextPrice.Text = parts(2)
                               MessageBox.Show("✅ QR Code Scanned Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                               StopCamera()
                           End Sub)
                End If
            End If

            ' Clean up bitmap
            bitmap.Dispose()

        Catch ex As Exception
            ' Log errors silently or to debug console
            Debug.WriteLine("Frame processing error: " & ex.Message)
        End Try
    End Sub

    Private Sub StopCamera()
        Try
            If videoSource IsNot Nothing AndAlso videoSource.IsRunning Then
                ' Remove event handler first
                RemoveHandler videoSource.NewFrame, AddressOf OnNewFrame

                videoSource.SignalToStop()
                videoSource.WaitForStop()
                videoSource = Nothing
            End If

            ' Clean up UI
            If PictureBoxCamera.Image IsNot Nothing Then
                PictureBoxCamera.Image.Dispose()
                PictureBoxCamera.Image = Nothing
            End If

            PictureBoxCamera.Visible = False
            scanActive = False
            btnScanQR.Text = "📷 Scan QR"

        Catch ex As Exception
            MessageBox.Show("Error stopping camera: " & ex.Message)
        End Try
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        StopCamera()
        MyBase.OnFormClosing(e)
    End Sub

    ' Your other existing methods remain the same...
    Private Sub Add_Click(sender As Object, e As EventArgs) Handles Add.Click
        If Textname.Text = "" Or TextDate.Text = "" Or TextPrice.Text = "" Then
            MessageBox.Show("Please fill all fields before adding.")
            Return
        End If
        AddInventoryItem(Textname.Text, TextDate.Text, TextPrice.Text)
        LoadInventory(DataGridView1)
    End Sub

    Private Sub btnhome_Click(sender As Object, e As EventArgs) Handles btnhome.Click
        Dashboard.Show()
=======
    Private Async Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize Firebase and load inventory
        FirebaseHelper.Initialize()
        Await LoadInventoryItems()
>>>>>>> f5bef54 (Update VB.NET project)
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
<<<<<<< HEAD
        Dim found As Boolean = False

=======
>>>>>>> f5bef54 (Update VB.NET project)
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
<<<<<<< HEAD
=======

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
>>>>>>> f5bef54 (Update VB.NET project)
    End Sub

    Private Sub Gen_Click(sender As Object, e As EventArgs) Handles Gen.Click
        Try
            Dim nameValue As String = Textname.Text.Trim()
            Dim dateValue As String = TextDate.Text.Trim()
            Dim priceValue As String = TextPrice.Text.Trim()

            If String.IsNullOrEmpty(nameValue) OrElse String.IsNullOrEmpty(dateValue) OrElse String.IsNullOrEmpty(priceValue) Then
                MessageBox.Show("Please fill out all fields before generating a QR code.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim qrData As String = $"{nameValue}|{dateValue}|{priceValue}"
            Dim qrGen As New QRCodeGenerator()
            Dim qrCodeData = qrGen.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q)
            Dim qrCode As New QRCode(qrCodeData)
            Dim qrImage As Bitmap = qrCode.GetGraphic(10)

            PictureBoxQR.Image = qrImage

            Dim savePath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"{nameValue}_QR.png")
            qrImage.Save(savePath, Imaging.ImageFormat.Png)

            MessageBox.Show($"QR Code generated and saved to: {savePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error generating QR Code: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class