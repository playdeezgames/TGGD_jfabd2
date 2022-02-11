Public Module Characteristics
    Function GenerateForCharacter(characteristic As Characteristic) As Integer
        Select Case characteristic
            Case Characteristic.Dexterity, Characteristic.Charisma, Characteristic.Willpower
                Return Roll(15, 6)
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
    Function GenerateForCritter(characteristic As Characteristic, critterType As Integer) As Integer
        Select Case characteristic
            Case Characteristic.Dexterity, Characteristic.Charisma, Characteristic.Willpower
                Return Roll(15, 6)
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
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Module
