Imports TGGD_jfabd2.Data

Public Class Critter
    Private ReadOnly critterId As UInt64
    Sub New(critterId As UInt64)
        Me.critterId = critterId
    End Sub
    Sub Update()
        'TODO: hungry!
        Dim satiety = GetStatistic(CritterStatisticType.Satiety)
        If satiety > CritterStatisticTypes.MinimumValue(Me, CritterStatisticType.Satiety) Then
            CritterStatisticData.Write(CInt(critterId), CritterStatisticType.Satiety, satiety - 1)
        Else
            Dim health = GetStatistic(CritterStatisticType.Health)
            health -= 1
            If health > CritterStatisticTypes.MinimumValue(Me, CritterStatisticType.Health) Then
                CritterStatisticData.Write(CInt(critterId), CritterStatisticType.Health, health)
            Else
                Dim critterType = CritterData.ReadCritterType(critterId)
                Dim locationId = CritterLocationData.ReadForCritter(critterId)
                CritterData.Destroy(CInt(critterId))
                Dim itemId = ItemData.Create(ItemType.CritterCorpse)
                CorpseData.Write(itemId, CInt(critterType))
                GroundData.Write(CInt(locationId), itemId)
            End If
        End If
    End Sub
    ReadOnly Property Name As String
        Get
            Return CritterTypes.GetName(CritterData.ReadCritterType(critterId).Value)
        End Get
    End Property
    Sub Feed(item As Item)
        Dim fruitType = item.GetFruitType()
        If fruitType.HasValue Then
            Dim satietyBuff = FruitTypes.GetSatietyBuff(fruitType.Value)
            Dim satiety As Integer = GetStatistic(CritterStatisticType.Satiety)
            Dim oversatiation = satiety + satietyBuff - CritterStatisticTypes.MaximumValue(Me, CritterStatisticType.Satiety)
            ChangeStatistic(CritterStatisticType.Satiety, satietyBuff)
            If oversatiation > 0 Then
                ChangeStatistic(CritterStatisticType.Health, oversatiation)
            End If
            item.Destroy()
            ChangeStatistic(CritterStatisticType.Tameness, 1)
        End If
    End Sub
    Function GetCharacteristic(characteristic As Characteristic) As Integer
        Dim value = CritterCharacteristicData.Read(CInt(critterId), characteristic)
        If Not value.HasValue Then
            value = Characteristics.GenerateForCritter(characteristic, ReadCritterType(critterId).Value)
            CritterCharacteristicData.Write(CInt(critterId), characteristic, value.Value)
        End If
        Return value.Value
    End Function
    Function Check(characteristic As Characteristic) As Double
        Return CharacteristicCheck(GetCharacteristic(characteristic))
    End Function
    Sub Capture(characterId As Integer)
        Dim locationId = CritterLocationData.ReadForCritter(critterId)
        If locationId.HasValue Then
            CritterLocationData.Clear(critterId)
            Dim itemId = ItemData.Create(ItemType.Critter)
            PetData.Write(itemId, critterId)
            InventoryData.Write(characterId, itemId)
        End If
    End Sub
    Function GetStatistic(statisticType As CritterStatisticType) As Integer
        Dim value = CritterStatisticData.Read(CInt(critterId), statisticType)
        If Not value.HasValue Then
            value = CritterStatisticTypes.InitialValue(Me, statisticType)
        End If
        Return value.Value
    End Function
    Public Sub SetStatistic(statisticType As CritterStatisticType, value As Integer)
        value = CritterStatisticTypes.ClampValue(Me, statisticType, value)
        CritterStatisticData.Write(CInt(critterId), statisticType, value)
    End Sub
    Public Sub ChangeStatistic(statisticType As CritterStatisticType, delta As Integer)
        SetStatistic(statisticType, GetStatistic(statisticType) + delta)
    End Sub
End Class
