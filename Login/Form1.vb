Imports Google.Cloud.Firestore

Public Class Form1
    ' Initialize Firestore when form loads
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FirestoreInventory.InitializeFirestore()
        Catch ex As Exception
            MessageBox.Show("Failed to initialize Firestore: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        ' Validation
        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter both username and password.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Ensure Firestore is initialized
            If FirestoreInventory.Db Is Nothing Then
                MessageBox.Show("Database not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Fetch user document
            Dim userDoc As DocumentReference = FirestoreInventory.Db.Collection("users").Document(username)
            Dim snapshot As DocumentSnapshot = Await userDoc.GetSnapshotAsync()

            If snapshot.Exists Then
                Dim storedPassword As String = snapshot.GetValue(Of String)("password")

                ' Compare passwords
                If password = storedPassword Then
                    ' ✅ Silent success — no MessageBox
                    Dashboard.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Invalid password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("User not found.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error during login: " & ex.Message, "Firestore Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
