Public Module Characteristics
    Function GenerateForCharacter(characteristic As Characteristic) As Integer
        Select Case characteristic
            Case Characteristic.Dexterity, Characteristic.Charisma, Characteristic.Willpower, Characteristic.Constitution, Characteristic.Intelligence
                Return Roll(15, 6)
            Case Characteristic.Size
                Return 30 + Roll(10, 6)
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
    Function GenerateForCritter(characteristic As Characteristic, critterType As Integer) As Integer
        Select Case characteristic
            Case Characteristic.Dexterity, Characteristic.Charisma, Characteristic.Willpower, Characteristic.Constitution, Characteristic.Intelligence
                Return Roll(15, 6)
            Case Characteristic.Size
                Return 15 + Roll(10, 3)
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
    Function GetAbbreviation(characteristic As Characteristic) As String
        Select Case characteristic
            Case Characteristic.Dexterity
                Return "DEX"
            Case Characteristic.Charisma
                Return "CHA"
            Case Characteristic.Willpower
                Return "POW"
            Case Characteristic.Constitution
                Return "CON"
            Case Characteristic.Size
                Return "SIZ"
            Case Characteristic.Intelligence
                Return "INT"
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module
