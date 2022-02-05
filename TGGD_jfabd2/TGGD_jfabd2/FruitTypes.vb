Module FruitTypes
    Function GetFruitTypeName(fruitType As Integer) As String
        Select Case fruitType
            Case 1
                Return "apple"
            Case 2
                Return "pear"
            Case 3
                Return "plum"
            Case 4
                Return "peach"
            Case 5
                Return "orange"
            Case 6
                Return "nectarine"
            Case 7
                Return "lemon"
            Case 8
                Return "lime"
            Case 9
                Return "grapefruit"
            Case 10
                Return "mango"
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(fruitType))
        End Select
    End Function
End Module
