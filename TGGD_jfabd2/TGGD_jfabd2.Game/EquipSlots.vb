Public Module EquipSlots
    Function GetName(equipSlot As EquipSlot) As String
        Select Case equipSlot
            Case EquipSlot.Wallet
                Return "Wallet"
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(equipSlot))
        End Select
    End Function
End Module
