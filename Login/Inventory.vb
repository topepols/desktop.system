Imports System.Windows.Forms.VisualStyles
Imports Google.Cloud.Firestore
Imports QRCoder
Imports System.IO
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports ZXing

Public Class Inventory
    Private videoDevices As FilterInfoCollection
    Private videoSource As VideoCaptureDevice
    Private qrReader As New BarcodeReader()
    Private scanActive As Boolean = False

    Public Shared dt As New DataTable()

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

        For Each row As DataGridViewRow In DataGridView1.Rows
            row.DefaultCellStyle.BackColor = Color.White
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