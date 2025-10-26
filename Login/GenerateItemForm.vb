Imports System.IO
Imports QRCoder
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class GenerateItemForm
    ' Properties to store the input values
    Public Property ItemName As String
    Public Property ItemQuantity As Integer
    Public Property ItemPrice As Decimal
    Public Property DialogSuccess As Boolean = False

    Private ReadOnly qrSavePath As String = "C:\Users\kristopher\Documents\qr"

    Private Sub GenerateItemForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Center and lock the form
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Text = "Generate New Item"
        Me.Size = New Size(400, 250)

        ' Ensure QR directory exists
        If Not Directory.Exists(qrSavePath) Then
            Directory.CreateDirectory(qrSavePath)
        End If

        ' Focus on name input
        txtName.Focus()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' ✅ Input validation (silent)
        If String.IsNullOrWhiteSpace(txtName.Text) Then
            txtName.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtQuantity.Text) Then
            txtQuantity.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPrice.Text) Then
            txtPrice.Focus()
            Return
        End If

        ' Validate quantity
        Dim quantity As Integer
        If Not Integer.TryParse(txtQuantity.Text, quantity) OrElse quantity <= 0 Then
            txtQuantity.Focus()
            Return
        End If

        ' Validate price
        Dim price As Decimal
        If Not Decimal.TryParse(txtPrice.Text, price) OrElse price < 0 Then
            txtPrice.Focus()
            Return
        End If

        ' ✅ Store values
        ItemName = txtName.Text.Trim()
        ItemQuantity = quantity
        ItemPrice = price
        DialogSuccess = True

        ' ✅ Generate and save QR code
        SaveItemQr(ItemName, ItemQuantity, ItemPrice)

        ' ✅ Close the form — QR will be handled in Inventory form
        Me.Close()
    End Sub

    Private Sub SaveItemQr(name As String, qty As Integer, price As Decimal)
        Try
            ' Compose QR data content (customize as needed)
            Dim qrData As String = $"Item: {name}{Environment.NewLine}Qty: {qty}{Environment.NewLine}Price: {price:C}{Environment.NewLine}CreatedAt: {DateTime.Now}"

            ' Generate QR
            Dim qrGen As New QRCodeGenerator()
            Dim qrCodeData = qrGen.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q)
            Dim qrCode As New QRCode(qrCodeData)
            Dim qrImage As Bitmap = qrCode.GetGraphic(20)

            ' File path
            Dim safeFileName As String = String.Join("_", name.Split(Path.GetInvalidFileNameChars()))
            Dim filePath As String = Path.Combine(qrSavePath, $"{safeFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.png")

            ' Save QR as PNG
            qrImage.Save(filePath, ImageFormat.Png)
            qrImage.Dispose()

        Catch ex As Exception
            MessageBox.Show($"Error saving QR: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogSuccess = False
        Me.Close()
    End Sub

    ' Allow pressing Enter to submit
    Private Sub txtBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice.KeyPress, txtQuantity.KeyPress, txtName.KeyPress
        If e.KeyChar = ChrW(13) Then
            btnSubmit_Click(sender, e)
        End If
    End Sub
End Class
