Imports TGGD_jfabd2.Game

Module InPlay
    Sub ShowStatus(canPickFruit As Boolean, tree As Tree)
        ShowMenuTitle("Yer playin' the game!")
        Console.ForegroundColor = ConsoleColor.Gray
        If canPickFruit Then
            Console.WriteLine($"There is a {FruitTypes.GetFruitTypeName(tree.GetFruitType())} tree here.")
        End If
    End Sub
    Sub ShowMenu(canPickFruit As Boolean)
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine("1) Turn")
        Console.WriteLine("2) Move")
        If canPickFruit Then
            Console.WriteLine("3) Pick Fruit")
        End If
        Console.WriteLine("0) Menu")
    End Sub
    Function HandleInput(canPickFruit As Boolean) As Boolean
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
            ShowStatus(canPickFruit, tree)
            ShowMenu(canPickFruit)
            ShowPrompt()
            done = HandleInput(canPickFruit)
        End While
    End Sub
End Module
