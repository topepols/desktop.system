Imports ZXing.Common

Friend Class BarcodeReader
    Public Sub New()
    End Sub

    Public Property AutoRotate As Boolean
    Public Property Options As DecodingOptions

    Friend Function Decode(bitmap As Bitmap) As Object
        Throw New NotImplementedException()
    End Function
End Class
