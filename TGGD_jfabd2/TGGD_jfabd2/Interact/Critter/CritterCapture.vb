Imports TGGD_jfabd2.Game

Module CritterCapture
    Function Run(critter As Critter) As Boolean
        Dim character As New PlayerCharacter
        If character.GetInventory().IsFull() Then
            ErrorMessage("Yer inventory is full!")
        Else
            If character.DifficultyCheck(Characteristic.Dexterity, 2, critter.GetStatistic(CritterStatisticType.Tameness)) > critter.Check(Characteristic.Dexterity) Then
                critter.Capture(character.GetCharacterId())
                SuccessMessage("Success!!")
                Return True
            Else
                ErrorMessage("Fail.")
            End If
        End If
        Return False
    End Function
End Module
