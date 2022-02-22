Imports TGGD_jfabd2.Game
Imports Terminal.Gui
Module PickFruit
    Private Sub OldRun()
        Dim character = New PlayerCharacter()
        If character.GetInventory().IsFull() Then
            ErrorMessage("Yer inventory is full!")
        Else
            Dim tree = character.GetLocation().GetTree()
            Dim fruit = tree.PickFruit()
            Game.Update()
            If fruit IsNot Nothing Then
                SuccessMessage($"You acquire {FruitTypes.GetName(fruit.GetFruitType())}")
                character.GetInventory().Add(fruit)
            Else
                ErrorMessage("You didn't manage to pick a fruit.")
            End If
        End If
    End Sub
    Sub Run()
        Dim character = New PlayerCharacter()
        If character.GetInventory().IsFull() Then
            MessageBox.Query("Overloaded!", "Yer inventory is full!", "Shucks!")
        Else
            Dim tree = character.GetLocation().GetTree()
            Dim fruit = tree.PickFruit()
            Game.Update()
            If fruit IsNot Nothing Then
                MessageBox.Query("Success!", $"You acquire {FruitTypes.GetName(fruit.GetFruitType())}", "Yay!")
                character.GetInventory().Add(fruit)
            Else
                MessageBox.Query("Fail!", "You didn't manage to pick a fruit.", "Dagnabbit!")
            End If
        End If
    End Sub
End Module
