Module MainMenu
    Sub Run()
        Dim done As Boolean = False
        While Not done
            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("Main Menu:")
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("0) Quit")
            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.Gray
            Console.Write(">")
            Dim input = Console.ReadLine()
            If input = "0" Then
                done = ConfirmQuit.Run()
            Else
                Console.WriteLine()
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Invalid input!")
            End If
        End While
    End Sub
End Module
