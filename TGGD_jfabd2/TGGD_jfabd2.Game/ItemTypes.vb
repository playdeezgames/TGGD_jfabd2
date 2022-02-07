Public Module ItemTypes
    Function CanConsume(itemType As ItemType) As Boolean
        Select Case itemType
            Case ItemType.Fruit
                Return True
            Case ItemType.Wallet
                Return False
            Case Else
                Throw New ArgumentOutOfRangeException(itemType)
        End Select
    End Function
End Module
