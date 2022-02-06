Imports TGGD_jfabd2.Data
Public Class GroundInventory
    Private ReadOnly locationId As Integer
    Sub New(locationId As Integer)
        Me.locationId = locationId
    End Sub
    Function IsEmpty() As Boolean
        Return Not GetItems().Any() 'TODO: ask this question more directly from the store
    End Function
    Function GetItems() As List(Of Item)
        Return GroundData.ReadForLocation(locationId).Select(Of Item)(
            Function(itemId As Integer) As Item
                Return New Item(itemId)
            End Function).ToList()
    End Function
End Class
