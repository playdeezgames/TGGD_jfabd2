Module MainMenu
    Sub Run()
        Dim done As Boolean = False
        While Not done
            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("Main Menu:")
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("1) Start")
            Console.WriteLine("0) Quit")
            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.Gray
            Console.Write(">")
            Dim input = Console.ReadLine()
            Select Case input
                Case "0"
                    done = Confirm.Run("Are you sure you want to quit?")
                Case "1"
                    Start.Run()
                Case Else
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.WriteLine("Invalid input!")
            End Select
        End While
    End Sub
End Module
