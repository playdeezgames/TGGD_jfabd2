Public Module FruitTypes
    Function GenerateFruitType() As Integer
        Return random.Next(1, 11)
    End Function
    Function GetName(fruitType As Integer) As String
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
    Function GetDescription(fruitType As Integer) As String
        Select Case fruitType
            Case 1
                Return "It is red."
            Case 2
                Return "It is pear shaped and yellow."
            Case 3
                Return "It is purple."
            Case 4
                Return "It is just peachy."
            Case 5
                Return "Guess what color it is?"
            Case 6
                Return "It looks like somebody shaved a peach."
            Case 7
                Return "It is lemony."
            Case 8
                Return "It is limey."
            Case 9
                Return "Nobody likes these."
            Case 10
                Return "It is mangoriffic."
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(fruitType))
        End Select
    End Function
    Function GetSatietyBuff(fruitType As Integer) As Integer
        Return 25 'TODO: give real values
    End Function
End Module
