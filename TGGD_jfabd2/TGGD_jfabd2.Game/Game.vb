Imports TGGD_jfabd2.Data
Public Module Game
    Friend random As New Random()
    Public Sub Reset()
        Store.Reset()
        Location.Reset()
        PlayerCharacter.Reset()
    End Sub
    Public Sub Update()
        Tree.Update()
        Dim characterIds = CharacterData.ReadAll()
        For Each characterId In characterIds
            Dim character As New Character(characterId)
            character.Update()
        Next
        'upkeep critters
        Dim critterIds = CritterData.ReadAll()
        For Each critterId In critterIds
            Dim critter As New Critter(CLng(critterId))
            critter.Update()
        Next
    End Sub
    Public Function Roll(ByVal dieCount As Integer, ByVal dieSize As Integer) As Integer
        Dim result = dieCount
        While dieCount > 0
            result += random.Next(dieSize)
            dieCount -= 1
        End While
        Return result
    End Function
    Public Function CharacteristicCheck(value As Integer) As Double
        Dim percentile = Roll(1, 100)
        If percentile < value Then
            Return CDbl(value) / CDbl(percentile)
        Else
            Return 0.0
        End If
    End Function
End Module
