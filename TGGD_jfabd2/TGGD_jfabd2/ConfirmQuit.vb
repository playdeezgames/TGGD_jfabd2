Module ConfirmQuit
    Function Run() As Boolean
        Dim done = False
        While Not done
            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine("Are you sure you want to quit?")
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("1) Yes")
            Console.WriteLine("0) No")
            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.Gray
            Console.Write(">")
            Dim input = Console.ReadLine()
            Select Case input
                Case "1"
                    Return True
                Case "0"
                    Return False
                Case Else
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.WriteLine("Invalid input!")
            End Select
        End While
        Return False 'will not get here
    End Function
End Module
