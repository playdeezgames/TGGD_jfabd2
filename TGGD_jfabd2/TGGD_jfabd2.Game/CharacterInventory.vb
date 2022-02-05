Imports TGGD_jfabd2.Data
Public Class CharacterInventory
    Private characterId As Integer
    Sub New(characterId As Integer)
        Me.characterId = characterId
    End Sub
    Function IsFull() As Boolean
        Return False
    End Function
    Function IsEmpty() As Boolean
        Return True
    End Function
    Sub Add(fruit As Fruit)
        If Not IsFull() Then
            Dim itemId = ItemData.Create(ItemType.Fruit)
            FruitData.WriteFruitType(itemId, fruit.GetFruitType())
            InventoryData.Write(characterId, itemId)
        End If
    End Sub
End Class
