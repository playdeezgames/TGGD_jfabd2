Imports TGGD_jfabd2.Game
Imports Terminal.Gui
Module CritterCapture
    Function Run(critter As Critter) As Boolean
        Dim character As New PlayerCharacter
        If character.GetInventory().IsFull() Then
            MessageBox.Query("No room!", "Yer inventory is full!", "Ok")
        Else
            If character.DifficultyCheck(Characteristic.Dexterity, 2, critter.GetStatistic(CritterStatisticType.Tameness)) > critter.Check(Characteristic.Dexterity) Then
                critter.Capture(character.GetCharacterId())
                MessageBox.Query("Success!!", "Gotta catchem all!", "Ok")
                Return True
            Else
                MessageBox.Query("Fail!", "A slippery devil.", "Ok")
            End If
        End If
        Return False
    End Function
End Module
