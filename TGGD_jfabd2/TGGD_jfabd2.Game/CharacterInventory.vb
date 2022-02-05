﻿Imports TGGD_jfabd2.Data
Public Class CharacterInventory
    Private characterId As Integer
    Sub New(characterId As Integer)
        Me.characterId = characterId
    End Sub
    Function IsFull() As Boolean
        Return False
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
    Sub Add(fruit As Fruit)
        If Not IsFull() Then
            Dim itemId = ItemData.Create(ItemType.Fruit)
            FruitData.WriteFruitType(itemId, fruit.GetFruitType())
            InventoryData.Write(characterId, itemId)
        End If
    End Sub
End Class
