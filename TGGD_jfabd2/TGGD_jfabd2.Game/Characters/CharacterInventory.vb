Imports TGGD_jfabd2.Data
Public Class CharacterInventory
    Private ReadOnly characterId As Integer
    Sub New(characterId As Integer)
        Me.characterId = characterId
    End Sub
    Function IsFull() As Boolean
        Return GetCount() >= New Character(characterId).GetStatistic(CharacterStatisticType.CarryingCapacity)
    End Function
    Function IsEmpty() As Boolean
        Return Not GetItems().Any() 'TODO: ask this question more directly from the store
    End Function
    Function GetItems() As List(Of Item)
        Return InventoryData.ReadForCharacter(characterId).Select(Of Item)(
            Function(itemId As Integer) As Item
                Return New Item(itemId)
            End Function).ToList()
    End Function
    Function GetItems(itemType As ItemType) As List(Of Item)
        Return GetItems().Where(Function(item)
                                    Return item.GetItemType() = itemType
                                End Function).ToList()
    End Function
    Sub Add(fruit As Fruit)
        If Not IsFull() Then
            Dim itemId = ItemData.Create(ItemType.Fruit)
            FruitData.WriteFruitType(itemId, fruit.GetFruitType())
            InventoryData.Write(characterId, itemId)
        End If
    End Sub
    Function GetCount() As Integer
        Return GetItems().Count() 'TODO: ask more directly
    End Function
    Function HasFruitType(fruitType As Integer) As Boolean
        Return GetItems().Any(Function(candidate)
                                  Dim candidateFruitType = candidate.GetFruitType()
                                  Return candidateFruitType.HasValue AndAlso candidateFruitType.Value = fruitType
                              End Function)
    End Function
    Function RemoveFruit(fruitType As Integer) As Boolean
        Dim item = GetItems().FirstOrDefault(Function(candidate)
                                                 Dim candidateFruitType = candidate.GetFruitType()
                                                 Return candidateFruitType.HasValue AndAlso candidateFruitType.Value = fruitType
                                             End Function)
        If item IsNot Nothing Then
            ItemData.Destroy(item.ItemId)
        End If
        Return False
    End Function
    Function HasItemType(itemType As ItemType) As Boolean
        Return GetItems().Any(Function(item)
                                  Return item.GetItemType = itemType
                              End Function)
    End Function
End Class
