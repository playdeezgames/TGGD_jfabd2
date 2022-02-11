Public Module EquipSlots
    Function GetName(equipSlot As EquipSlot) As String
        Select Case equipSlot
            Case EquipSlot.Wallet
                Return "Wallet"
            Case EquipSlot.LeftShoulder
                Return "Left Shoulder"
            Case EquipSlot.RightShoulder
                Return "Right Shoulder"
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(equipSlot))
        End Select
    End Function
End Module
