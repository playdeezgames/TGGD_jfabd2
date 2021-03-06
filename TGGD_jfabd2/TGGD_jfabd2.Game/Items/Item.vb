Imports TGGD_jfabd2.Data
Public Class Item
    Public ReadOnly ItemId As Integer
    Sub New(itemId As Integer)
        Me.ItemId = itemId
    End Sub
    Function CanConsume() As Boolean
        Return InventoryData.ReadForItem(ItemId).HasValue AndAlso ItemTypes.CanConsume(GetItemType())
    End Function
    Function GetCritter() As Critter
        If IsCritter() Then
            Return New Critter(CLng(PetData.ReadForItem(ItemId).Value))
        End If
        Return Nothing
    End Function
    Private Sub ConsumeFruit()
        Dim character As New Character(InventoryData.ReadForItem(ItemId).Value)
        Dim satietyBuff = FruitTypes.GetSatietyBuff(FruitData.ReadFruitType(ItemId).Value)
        Dim satiety As Integer = character.GetStatistic(CharacterStatisticType.Satiety)
        Dim oversatiation = satiety + satietyBuff - CharacterStatisticsTypes.MaximumValue(character, CharacterStatisticType.Satiety)
        character.ChangeStatistic(CharacterStatisticType.Satiety, satietyBuff)
        If oversatiation > 0 Then
            character.ChangeStatistic(CharacterStatisticType.Health, oversatiation)
        End If
        character.AddMessage(Mood.Success, $"You eat the {GetName()}.")
        ItemData.Destroy(ItemId)
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
        Dim value = ItemData.ReadItemType(ItemId)
        If value.HasValue Then
            Return CType(value.Value, ItemType)
        Else
            Return ItemType.None
        End If
    End Function
    Function GetName() As String
        Select Case GetItemType()
            Case ItemType.None
                Return ""
            Case ItemType.Fruit
                Return FruitTypes.GetName(FruitData.ReadFruitType(ItemId).Value)
            Case ItemType.Wallet
                Return $"Wallet(Size: {WalletData.Read(ItemId).Value})"
            Case ItemType.Critter
                Return CritterTypes.GetName(CritterData.ReadCritterType(CLng(PetData.ReadForItem(ItemId).Value)).Value)
            Case ItemType.CritterCorpse
                Return "dead " & CritterTypes.GetName(CorpseData.ReadForItem(ItemId).Value)
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
    Function GetDescription() As String
        Select Case GetItemType()
            Case ItemType.None
                Return ""
            Case ItemType.Fruit
                Return FruitTypes.GetDescription(FruitData.ReadFruitType(ItemId).Value)
            Case ItemType.Wallet
                Return "It's a wallet! It holds money!"
            Case ItemType.Critter
                Return CritterTypes.GetDescription(CritterData.ReadCritterType(CLng(PetData.ReadForItem(ItemId).Value)).Value)
            Case ItemType.CritterCorpse
                Return "Shhhh. It's 'sleeping'."
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
    Sub Drop()
        Dim characterId = InventoryData.ReadForItem(ItemId)
        If characterId.HasValue Then
            InventoryData.Clear(ItemId)
            Dim location = New Character(characterId.Value).GetLocation()
            If ItemData.ReadItemType(ItemId) = ItemType.Critter Then
                Dim critterId = PetData.ReadForItem(ItemId).Value
                PetData.ClearForCritter(critterId)
                CritterLocationData.Write(CLng(critterId), location.GetLocationId())
                ItemData.Destroy(ItemId)
            Else
                GroundData.Write(location.GetLocationId(), ItemId)
            End If

        End If
    End Sub
    Sub PickUp(characterId As Integer)
        Dim locationId = GroundData.ReadForItem(ItemId)
        If locationId.HasValue Then
            If Not New Character(characterId).GetInventory().IsFull() Then
                GroundData.Clear(ItemId)
                InventoryData.Write(characterId, ItemId)
            End If
        End If
    End Sub
    Sub Unequip()
        Dim equippedOn = CharacterEquipmentData.ReadForItem(ItemId)
        If equippedOn IsNot Nothing Then
            CharacterEquipmentData.Clear(ItemId)
            InventoryData.Write(equippedOn.Item1, ItemId)
        End If
    End Sub
    Sub Equip(equipSlot As EquipSlot)
        Dim equippedOn = CharacterEquipmentData.ReadForItem(ItemId)
        If equippedOn Is Nothing Then
            Dim characterId = InventoryData.ReadForItem(ItemId)
            If characterId.HasValue Then
                Dim equipSlots = ItemTypes.GetEquipSlots(GetItemType())
                If equipSlots.Contains(equipSlot) Then
                    Dim oldItemId = CharacterEquipmentData.ReadForEquipSlot(characterId.Value, equipSlot)
                    If oldItemId.HasValue Then
                        Dim x = New Item(oldItemId.Value)
                        x.Unequip()
                    End If
                    InventoryData.Clear(ItemId)
                    CharacterEquipmentData.Write(characterId.Value, equipSlot, ItemId)
                End If
            End If
        End If
    End Sub
    Function CanEquip() As Boolean
        Return ItemTypes.GetEquipSlots(GetItemType()).Any()
    End Function
    Function GetFruitType() As Integer?
        If GetItemType() = ItemType.Fruit Then
            Return FruitData.ReadFruitType(ItemId)
        End If
        Return Nothing
    End Function
    Function GetWalletSize() As Integer
        If GetItemType() = ItemType.Wallet Then
            Return WalletData.Read(ItemId).Value
        End If
        Return 0
    End Function
    Sub Destroy()
        ItemData.Destroy(ItemId)
    End Sub
    Function IsCritter() As Boolean
        Dim characterId = InventoryData.ReadForItem(ItemId)
        If Not characterId.HasValue Then
            Dim entry = CharacterEquipmentData.ReadForItem(ItemId)
            If entry IsNot Nothing Then
                characterId = entry.Item1
            End If
        End If
        If characterId.HasValue Then
            Return GetItemType() = ItemType.Critter
        End If
        Return False
    End Function
    Function CanFeed() As Boolean
        Dim characterId = InventoryData.ReadForItem(ItemId)
        If Not characterId.HasValue Then
            Dim entry = CharacterEquipmentData.ReadForItem(ItemId)
            If entry IsNot Nothing Then
                characterId = entry.Item1
            End If
        End If
        If characterId.HasValue Then
            Dim inventory = New CharacterInventory(characterId.Value)
            Return GetItemType() = ItemType.Critter AndAlso inventory.HasItemType(ItemType.Fruit)
        End If
        Return False
    End Function
    Function Feed(food As Item) As Boolean
        If CanFeed() Then
            Dim critter = New Critter(CLng(PetData.ReadForItem(ItemId).Value))
            critter.Feed(food)
            Return True
        End If
        Return False
    End Function
    Public Overrides Function ToString() As String
        Return GetName()
    End Function
End Class

