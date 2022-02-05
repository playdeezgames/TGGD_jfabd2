Imports TGGD_jfabd2.Data
Public Class Item
    Private ReadOnly itemId As Integer
    Sub New(itemId As Integer)
        Me.itemId = itemId
    End Sub
    Function GetItemType() As ItemType
        Return ItemData.ReadItemType(itemId)
    End Function
    Function GetName() As String
        Select Case GetItemType()
            Case ItemType.Fruit
                Return FruitTypes.GetName(FruitData.ReadFruitType(itemId))
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
    Function GetDescription() As String
        Select Case GetItemType()
            Case ItemType.Fruit
                Return FruitTypes.GetDescription(FruitData.ReadFruitType(itemId))
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
    Sub Drop()
        Dim characterId = InventoryData.ReadForItem(itemId)
        If characterId.HasValue Then
            InventoryData.Clear(itemId)
            Dim location = New Character(characterId.Value).GetLocation()
            GroundData.Write(location.GetLocationId(), itemId)
        End If
    End Sub
End Class

