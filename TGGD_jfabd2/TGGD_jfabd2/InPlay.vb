Imports TGGD_jfabd2.Game

Module InPlay
    Sub ShowStatus(canPickFruit As Boolean, tree As Tree, hasGroundInventory As Boolean)
        ShowMenuTitle("Yer playin' the game!")
        If canPickFruit Then
            ShowInfo($"There is a {FruitTypes.GetName(tree.GetFruitType())} tree here.")
        End If
        If hasGroundInventory Then
            ShowInfo("There is some stuff on the ground.")
        End If
    End Sub
    Sub ShowMenu(canPickFruit As Boolean, hasInventory As Boolean, hasGroundInventory As Boolean)
        ShowMenuItem("1) Turn")
        ShowMenuItem("2) Move")
        If canPickFruit Then
            ShowMenuItem("3) Pick Fruit")
        End If
        If hasInventory Then
            ShowMenuItem("4) Inventory")
        End If
        If hasGroundInventory Then
            ShowMenuItem("5) Ground")
        End If
        ShowMenuItem("0) Menu")
    End Sub
    Function HandleInput(canPickFruit As Boolean, hasInventory As Boolean, hasGroundInventory As Boolean) As Boolean
        Select Case Console.ReadLine()
            Case "0"
                If GameMenu.Run() Then
                    Return True
                End If
            Case "1"
                TurnMenu.Run()
            Case "2"
                MoveMenu.Run()
            Case "3"
                If canPickFruit Then
                    PickFruit.Run()
                Else
                    InvalidInput()
                End If
            Case "4"
                If hasInventory Then
                    Inventory.Run()
                Else
                    InvalidInput()
                End If
            Case "5"
                If hasGroundInventory Then
                    'TODO: stuff on the ground
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
            Dim location = character.GetLocation()
            Dim tree = location.GetTree()
            Dim canPickFruit = tree IsNot Nothing
            Dim hasInventory = Not character.GetInventory().IsEmpty()
            Dim hasGroundInventory = Not location.GetInventory().IsEmpty()
            ShowStatus(canPickFruit, tree, hasGroundInventory)
            ShowMenu(canPickFruit, hasInventory, hasGroundInventory)
            ShowPrompt()
            done = HandleInput(canPickFruit, hasInventory, hasGroundInventory)
        End While
    End Sub
End Module
