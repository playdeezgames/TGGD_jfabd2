Imports TGGD_jfabd2.Data
Public Class VendorFruit
    Private ReadOnly locationId As Integer
    Private ReadOnly fruitType As Integer
    Sub New(locationId As Integer, fruitType As Integer)
        Me.locationId = locationId
        Me.fruitType = fruitType
    End Sub
    Public ReadOnly Property Name() As String
        Get
            Return FruitTypes.GetName(fruitType)
        End Get
    End Property
    Public ReadOnly Property Price() As Integer
        Get
            Return FruitPriceData.ReadForFruitType(locationId, fruitType).Value
        End Get
    End Property
End Class
