Imports TGGD_jfabd2.Data

Public Class Critter
    Private ReadOnly critterId As UInt64
    Sub New(critterId As UInt64)
        Me.critterId = critterId
    End Sub
    ReadOnly Property Name() As String
        Get
            Return CritterTypes.GetName(CritterData.ReadCritterType(critterId))
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
End Class
