Module GameMenu
    Function Run() As Boolean
        Dim done As Boolean = False
        While Not done
            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("Game Menu:")
            Console.ForegroundColor = ConsoleColor.Gray
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("1) Abandon game")
            Console.WriteLine("0) Back")
            Console.WriteLine()
            Console.Write(">")
            Select Case Console.ReadLine()
                Case "0"
                    Return False
                Case "1"
                    If Confirm.Run("Are you sure you want to abandon the game?") Then
                        Return True
                    End If
            End Select
        End While
        Return False
    End Function
End Module
