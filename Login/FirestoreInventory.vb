Imports Google.Cloud.Firestore

Public Module FirestoreInventory
    Private firestoreDb As FirestoreDb

    ' ✅ Initialize Firestore
    Public Sub InitializeFirestore()
        Try
            ' Path to your Firebase service account key (JSON)
            Dim path As String = "C:\path\to\serviceAccountKey.json"
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path)

            firestoreDb = FirestoreDb.Create("mobile-inventory-95f33")
            MessageBox.Show("Firestore connected successfully!", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error connecting to Firestore: " & ex.Message)
        End Try
    End Sub

    ' ✅ Add a new inventory item
    Public Async Sub AddInventoryItem(name As String, dateValue As String, price As String)
        Try
            Dim docRef As DocumentReference = firestoreDb.Collection("inventory").Document()
            Dim data As New Dictionary(Of String, Object) From {
            {"id", docRef.Id},
            {"name", name},
            {"date", dateValue},
            {"price", price}
        }

            Await docRef.SetAsync(data)
            MessageBox.Show("Item added to Firestore!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error adding item: " & ex.Message)
        End Try
    End Sub


    ' ✅ Load all items into DataGridView
    Public Async Sub LoadInventory(dataGrid As DataGridView)
        Try
            dataGrid.Rows.Clear()
            Dim snapshot = Await firestoreDb.Collection("inventory").GetSnapshotAsync()
            For Each doc In snapshot.Documents
                Dim name = doc.GetValue(Of String)("name")
                Dim dateValue = doc.GetValue(Of String)("date")
                Dim price = doc.GetValue(Of String)("price")
                dataGrid.Rows.Add(name, dateValue, price)
            Next
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub


    ' ✅ Update an existing item
    Public Async Sub UpdateInventoryItem(docId As String, name As String, dateValue As String, price As String)
        Try
            Dim docRef = firestoreDb.Collection("inventory").Document(docId)
            Dim updates As New Dictionary(Of String, Object) From {
                {"name", name},
                {"date", dateValue},
                {"price", price}
            }

            Await docRef.UpdateAsync(updates)
            MessageBox.Show("Item updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error updating item: " & ex.Message)
        End Try
    End Sub

    ' ✅ Delete an item
    Public Async Sub DeleteInventoryItem(docId As String)
        Try
            Dim docRef = firestoreDb.Collection("inventory").Document(docId)
            Await docRef.DeleteAsync()
            MessageBox.Show("Item deleted from Firestore.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error deleting item: " & ex.Message)
        End Try
    End Sub
    ' 🔹 Add this at the end of the module (before End Module)
    Public ReadOnly Property Db As FirestoreDb
        Get
            Return firestoreDb
        End Get
    End Property

End Module
