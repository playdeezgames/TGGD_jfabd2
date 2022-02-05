Module Common
    Sub InvalidInput()
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine()
        Console.WriteLine("Invalid Input!")
    End Sub
    Sub ShowPrompt()
        Console.WriteLine()
        Console.ForegroundColor = ConsoleColor.Gray
        Console.Write(">")
    End Sub
    Sub ShowMenuTitle(text As String)
        Console.WriteLine()
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine(text)
        Console.ForegroundColor = ConsoleColor.Gray
    End Sub
End Module
