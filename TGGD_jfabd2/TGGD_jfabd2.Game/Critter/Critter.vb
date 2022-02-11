Imports TGGD_jfabd2.Data

Public Class Critter
    Private ReadOnly critterId As UInt64
    Sub New(critterId As UInt64)
        Me.critterId = critterId
    End Sub
    ReadOnly Property Name As String
        Get
            Return CritterTypes.GetName(CritterData.ReadCritterType(critterId))
        End Get
    End Property
    ReadOnly Property Tameness As Integer
        Get
            Return CritterData.ReadTameness(critterId)
        End Get
    End Property
    Sub Feed(item As Item)
        item.Destroy()
        CritterData.WriteTameness(critterId, CritterData.ReadTameness(critterId) + 1)
    End Sub
    Function GetCharacteristic(characteristic As Characteristic) As Integer
        Dim value = CritterCharacteristicData.Read(critterId, characteristic)
        If Not value.HasValue Then
            value = Characteristics.GenerateForCritter(characteristic, ReadCritterType(critterId))
            CritterCharacteristicData.Write(critterId, characteristic, value.Value)
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
End Class
