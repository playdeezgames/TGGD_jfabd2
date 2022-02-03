Module Confirm
    Function Run(prompt As String) As Boolean
        Dim done = False
        While Not done
            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine(prompt)
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("1) Yes")
            Console.WriteLine("0) No")
            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.Gray
            Console.Write(">")
            Select Case Console.ReadLine()
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
