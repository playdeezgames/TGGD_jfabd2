Imports TGGD_jfabd2.Data
Public Class Item
    Private ReadOnly itemId As Integer
    Sub New(itemId As Integer)
        Me.itemId = itemId
    End Sub
    Function CanConsume() As Boolean
        Return InventoryData.ReadForItem(itemId).HasValue AndAlso ItemTypes.CanConsume(GetItemType())
    End Function
    Private Sub ConsumeFruit()
        Dim character As New Character(InventoryData.ReadForItem(itemId).Value)
        Dim satietyBuff = FruitTypes.GetSatietyBuff(FruitData.ReadFruitType(itemId).Value)
        Dim satiety As Integer = character.GetStatistic(CharacterStatisticType.Satiety)
        Dim oversatiation = satiety + satietyBuff - CharacterStatisticsTypes.MaximumValue(CharacterStatisticType.Satiety)
        character.ChangeStatistic(CharacterStatisticType.Satiety, satietyBuff)
        If oversatiation > 0 Then
            character.ChangeStatistic(CharacterStatisticType.Health, oversatiation)
        End If
        character.AddMessage(New CharacterMessage(Mood.Success, $"You eat the {GetName()}."))
        ItemData.Destroy(itemId)
    End Sub
    Sub Consume()
        If CanConsume() Then
            Select Case GetItemType()
                Case ItemType.Fruit
                    ConsumeFruit()
                Case Else
                    Throw New NotImplementedException()
            End Select
        End If
    End Sub
    Function GetItemType() As ItemType
        Return ItemData.ReadItemType(itemId)
    End Function
    Function GetName() As String
        Select Case GetItemType()
            Case ItemType.Fruit
                Return FruitTypes.GetName(FruitData.ReadFruitType(itemId))
            Case ItemType.Wallet
                Return $"Wallet(Size: {WalletData.Read(itemId).Value})"
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
    Sub PickUp(characterId As Integer)
        Dim locationId = GroundData.ReadForItem(itemId)
        If locationId.HasValue Then
            If Not New Character(characterId).GetInventory().IsFull() Then
                GroundData.Clear(itemId)
                InventoryData.Write(characterId, itemId)
            End If
        End If
    End Sub
End Class

