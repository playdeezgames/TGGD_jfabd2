Imports TGGD_jfabd2.Game

Module PickFruit
    Sub Run()
        Dim character = New PlayerCharacter()
        If character.GetInventory().IsFull() Then
            ErrorMessage("Yer inventory is full!")
        Else
            Dim tree = character.GetLocation().GetTree()
            Dim fruit = tree.PickFruit()
            character.UpKeep()
            If fruit IsNot Nothing Then
                SuccessMessage($"You acquire {FruitTypes.GetName(fruit.GetFruitType())}")
                character.GetInventory().Add(fruit)
            Else
                ErrorMessage("You didn't manage to pick a fruit.")
            End If
        End If
    End Sub
End Module
