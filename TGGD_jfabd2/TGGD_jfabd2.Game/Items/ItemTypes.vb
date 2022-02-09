Public Module ItemTypes
    Function CanConsume(itemType As ItemType) As Boolean
        Select Case itemType
            Case ItemType.Fruit
                Return True
            Case ItemType.Wallet
                Return False
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(itemType))
        End Select
    End Function
    Function GetEquipSlots(itemType As ItemType) As List(Of EquipSlot)
        Select Case itemType
            Case ItemType.Fruit
                Return New List(Of EquipSlot)()
            Case ItemType.Wallet
                Return New List(Of EquipSlot) From {EquipSlot.Wallet}
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(itemType))
        End Select
    End Function
End Module
