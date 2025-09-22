Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class Form1
    Dim username As String
    Dim password As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim pic As New Drawing2D.GraphicsPath
        pic.AddEllipse(2, 2, 100, 100)
        PictureBox1.Region = New Region(pic)

    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()
        If username = "admin" And password = "admin" Then
        ElseIf username = "user" And password = "1234" Then
        Else
        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Dashboard.Show()
    End Sub

    Friend Shared Function dt() As Object
        Throw New NotImplementedException()
    End Function
End Class
