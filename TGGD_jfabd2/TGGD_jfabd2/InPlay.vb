Imports TGGD_jfabd2.Game

Module InPlay
    Sub ShowStatus(canPickFruit As Boolean, tree As Tree, hasGroundInventory As Boolean, hasVendor As Boolean, hasCritter As Boolean)
        ShowMenuTitle("Yer playin' the game!")
        If canPickFruit Then
            ShowInfo($"There is a {FruitTypes.GetName(tree.GetFruitType())} tree here.")
        End If
        If hasVendor Then
            ShowInfo("There is a vendor here.")
        End If
        If hasGroundInventory Then
            ShowInfo("There is some stuff on the ground.")
        End If
        If hasCritter Then
            ShowInfo("There is at least one critter here.")
        End If
    End Sub
    Function HandleInput(canPickFruit As Boolean, hasGroundInventory As Boolean, hasVendor As Boolean, hasCritter As Boolean) As Boolean
        Select Case Console.ReadLine()
            Case "0"
                If GameMenu.Run() Then
                    Return True
                End If
            Case "1"
                MoveMenu.Run()
            Case "2"
                TurnMenu.Run()
            Case "3"
                StatusMenu.Run()
            Case "4"
                If canPickFruit OrElse hasGroundInventory OrElse hasVendor OrElse hasCritter Then
                    InteractMenu.Run()
                Else
                    InvalidInput()
                End If
            Case Else
                InvalidInput()
        End Select
        Return False
    End Function
    Sub Run()
        Dim done As Boolean = False
        While Not done
            Dim character = New PlayerCharacter()
            ShowCharacterMessages(character)
            If character.IsAlive() Then
                Dim location = character.GetLocation()
                Dim hasCritter = location.HasCritters()
                Dim tree = location.GetTree()
                Dim canPickFruit = tree IsNot Nothing
                Dim hasGroundInventory = Not location.GetInventory().IsEmpty()
                Dim vendor = location.GetVendor()
                Dim hasVendor = vendor IsNot Nothing
                ShowStatus(canPickFruit, tree, hasGroundInventory, hasVendor, hasCritter)
                ShowMenuItem("1) Move")
                ShowMenuItem("2) Turn")
                ShowMenuItem("3) Status...")
                If canPickFruit OrElse hasGroundInventory OrElse hasVendor OrElse hasCritter Then
                    ShowMenuItem("4) Interact...")
                End If
                ShowMenuItem("0) Menu")
                ShowPrompt()
                done = HandleInput(canPickFruit, hasGroundInventory, hasVendor, hasCritter)
            Else
                done = True
                ErrorMessage("Yer dead!") 'TODO: make a character message!
            End If
        End While
    End Sub
End Module
