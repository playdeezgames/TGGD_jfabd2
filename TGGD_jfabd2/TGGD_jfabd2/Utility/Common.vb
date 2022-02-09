Imports TGGD_jfabd2.Game

Module Common
    Sub ErrorMessage(text As String)
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine()
        Console.WriteLine(text)
    End Sub
    Sub SuccessMessage(text As String)
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine()
        Console.WriteLine(text)
    End Sub
    Sub ShowMenuItem(text As String)
        Console.ForegroundColor = ConsoleColor.Yellow
        Console.WriteLine(text)
    End Sub
    Sub ShowInfo(text As String)
        Console.ForegroundColor = ConsoleColor.Gray
        Console.WriteLine(text)
    End Sub
    Sub InvalidInput()
        ErrorMessage("Invalid input!")
    End Sub
    Sub ShowPrompt()
        Console.WriteLine()
        Console.ForegroundColor = ConsoleColor.Gray
        Console.Write(">")
    End Sub
    Sub ShowMenuTitle(text As String)
        Console.WriteLine()
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.WriteLine(text)
        Console.ForegroundColor = ConsoleColor.Gray
    End Sub
    Sub ShowCharacterMessages(character As Character)
        Dim messages = character.GetMessages()
        For Each message In messages
            Select Case message.GetMood()
                Case Mood.Failure
                    Console.ForegroundColor = ConsoleColor.Red
                Case Mood.Info
                    Console.ForegroundColor = ConsoleColor.Gray
                Case Mood.Success
                    Console.ForegroundColor = ConsoleColor.Green
                Case Else
                    Throw New NotImplementedException()
            End Select
            Console.WriteLine(message.GetText())
        Next
        character.ClearMessages()
    End Sub
End Module
