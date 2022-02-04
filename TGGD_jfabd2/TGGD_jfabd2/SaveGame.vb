Imports TGGD_jfabd2.Data

Module SaveGame
    Sub Run()
        Console.WriteLine()
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("Enter a save file name:")
        Console.WriteLine()
        Console.ForegroundColor = ConsoleColor.Gray
        Console.Write(">")
        Dim input = Console.ReadLine()
        If Not String.IsNullOrWhiteSpace(input) Then
            Store.Save(input)
        End If
    End Sub
End Module
