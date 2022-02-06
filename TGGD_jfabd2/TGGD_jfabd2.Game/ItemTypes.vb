Public Module ItemTypes
    Function CanConsume(itemType As ItemType) As Boolean
        Select Case itemType
            Case ItemType.Fruit
                Return True
            Case Else
                Throw New ArgumentOutOfRangeException(itemType)
        End Select
    End Function
End Module
