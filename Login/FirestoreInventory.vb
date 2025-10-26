Imports Google.Cloud.Firestore

Public Module FirestoreInventory
    Private firestoreDb As FirestoreDb

    ' ✅ Initialize Firestore (no notification)
    Public Sub InitializeFirestore()
        Try
            Dim path As String = "C:\path\to\serviceAccountKey.json"
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path)
            firestoreDb = FirestoreDb.Create("mobile-inventory-95f33")
        Catch
            ' Silent fail — handled elsewhere if needed
        End Try
    End Sub

    ' ✅ Add a new inventory item (no notification)
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
        Catch
            ' Silent fail
        End Try
    End Sub

    ' ✅ Load all items into DataGridView (no notification)
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
        Catch
            ' Silent fail
        End Try
    End Sub

    ' ✅ Update an existing item (no notification)
    Public Async Sub UpdateInventoryItem(docId As String, name As String, dateValue As String, price As String)
        Try
            Dim docRef = firestoreDb.Collection("inventory").Document(docId)
            Dim updates As New Dictionary(Of String, Object) From {
                {"name", name},
                {"date", dateValue},
                {"price", price}
            }
            Await docRef.UpdateAsync(updates)
        Catch
            ' Silent fail
        End Try
    End Sub

    ' ✅ Delete an item (no notification)
    Public Async Sub DeleteInventoryItem(docId As String)
        Try
            Dim docRef = firestoreDb.Collection("inventory").Document(docId)
            Await docRef.DeleteAsync()
        Catch
            ' Silent fail
        End Try
    End Sub

    ' 🔹 Firestore database reference
    Public ReadOnly Property Db As FirestoreDb
        Get
            Return firestoreDb
        End Get
    End Property

End Module
