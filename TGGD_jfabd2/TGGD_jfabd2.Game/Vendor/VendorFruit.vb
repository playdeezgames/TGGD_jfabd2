Imports TGGD_jfabd2.Data
Public Class VendorFruit
    Private ReadOnly locationId As Integer
    Public ReadOnly FruitType As Integer
    Sub New(locationId As Integer, fruitType As Integer)
        Me.locationId = locationId
        Me.fruitType = fruitType
    End Sub
    Public ReadOnly Property Name() As String
        Get
            Return FruitTypes.GetName(FruitType)
        End Get
    End Property
    Public ReadOnly Property BuyingPrice() As Integer
        Get
            Return FruitPriceData.ReadForFruitType(locationId, FruitType).Value
        End Get
    End Property
    Public ReadOnly Property SellingPrice() As Integer
        Get
            Return BuyingPrice \ 2
        End Get
    End Property
    Sub HandleSale()
        If FruitTypes.GeneratePrice(FruitType) < BuyingPrice Then
            FruitPriceData.Write(locationId, FruitType, FruitPriceData.ReadForFruitType(locationId, FruitType) - 1)
        End If
    End Sub
    Sub HandleBuy()
        If FruitTypes.GeneratePrice(FruitType) > BuyingPrice Then
            FruitPriceData.Write(locationId, FruitType, FruitPriceData.ReadForFruitType(locationId, FruitType) + 1)
        End If
    End Sub
End Class
