Imports TGGD_jfabd2.Data
Public Class Vendor
    Private ReadOnly locationId As Integer
    Sub New(locationId As Integer)
        Me.locationId = locationId
    End Sub
    Function HasFruits() As Boolean
        Return FruitPriceData.ReadCountForLocation(locationId) > 0
    End Function
    Function GetFruitTypes() As List(Of VendorFruit)
        Return FruitPriceData.ReadForLocation(locationId).Select(
            Function(entry)
                Return New VendorFruit(locationId, entry.Item1)
            End Function).ToList()
    End Function
End Class
