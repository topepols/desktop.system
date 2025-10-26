Imports Google.Cloud.Firestore

Public Class Form1
<<<<<<< HEAD
    ' ADD THIS - Initialize Firestore when form loads
=======
    ' Initialize Firestore when form loads
>>>>>>> f5bef54 (Update VB.NET project)
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

<<<<<<< HEAD
=======
        ' Validation
>>>>>>> f5bef54 (Update VB.NET project)
        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter both username and password.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
<<<<<<< HEAD
            ' ADD NULL CHECK
=======
            ' Ensure Firestore is initialized
>>>>>>> f5bef54 (Update VB.NET project)
            If FirestoreInventory.Db Is Nothing Then
                MessageBox.Show("Database not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

<<<<<<< HEAD
=======
            ' Fetch user document
>>>>>>> f5bef54 (Update VB.NET project)
            Dim userDoc As DocumentReference = FirestoreInventory.Db.Collection("users").Document(username)
            Dim snapshot As DocumentSnapshot = Await userDoc.GetSnapshotAsync()

            If snapshot.Exists Then
                Dim storedPassword As String = snapshot.GetValue(Of String)("password")

<<<<<<< HEAD
                If password = storedPassword Then
                    MessageBox.Show("Login successful!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information)
=======
                ' Compare passwords
                If password = storedPassword Then
                    ' ✅ Silent success — no MessageBox
>>>>>>> f5bef54 (Update VB.NET project)
                    Dashboard.Show()
                    Me.Hide()
                Else
                    MessageBox.Show("Invalid password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("User not found.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
<<<<<<< HEAD
=======

>>>>>>> f5bef54 (Update VB.NET project)
        Catch ex As Exception
            MessageBox.Show("Error during login: " & ex.Message, "Firestore Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
<<<<<<< HEAD
End Class
=======
End Class
>>>>>>> f5bef54 (Update VB.NET project)
