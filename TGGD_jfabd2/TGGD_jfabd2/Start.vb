Imports TGGD_jfabd2.Game
Module Start
    Sub Run()
        Game.Reset()
        Dim done As Boolean = False
        While Not done
            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("Yer playin' the game!")
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("0) Abandon game")
            Console.WriteLine()
            Console.Write(">")
            Dim input = Console.ReadLine()
            Select Case input
                Case "0"
                    If Confirm.Run("Are you sure you want to abandon the game?") Then
                        Return
                    End If
                Case Else
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.WriteLine()
                    Console.WriteLine("Invalid Input!")
            End Select
        End While
    End Sub
End Module
