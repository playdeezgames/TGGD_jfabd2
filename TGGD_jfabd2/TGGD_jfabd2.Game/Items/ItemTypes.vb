Public Module ItemTypes
    Function CanConsume(itemType As ItemType) As Boolean
        Select Case itemType
            Case ItemType.None
                Return False
            Case ItemType.Fruit
                Return True
            Case ItemType.Wallet
                Return False
            Case ItemType.Critter
                Return False
            Case ItemType.CritterCorpse
                Return False 'TODO: mebbe?
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(itemType))
        End Select
    End Function
    Function GetEquipSlots(itemType As ItemType) As List(Of EquipSlot)
        Select Case itemType
            Case ItemType.None
                Return New List(Of EquipSlot)()
            Case ItemType.Fruit
                Return New List(Of EquipSlot)()
            Case ItemType.Wallet
                Return New List(Of EquipSlot) From {EquipSlot.Wallet}
            Case ItemType.Critter, ItemType.CritterCorpse
                Return New List(Of EquipSlot) From {EquipSlot.LeftShoulder, EquipSlot.RightShoulder}
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(itemType))
        End Select
    End Function
End Module
