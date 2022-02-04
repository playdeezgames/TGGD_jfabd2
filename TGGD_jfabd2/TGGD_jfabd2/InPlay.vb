Imports TGGD_jfabd2.Game

Module InPlay
    Sub Run()
        Dim done As Boolean = False
        While Not done
            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("Yer playin' the game!")
            Console.ForegroundColor = ConsoleColor.Gray
            Dim character = New PlayerCharacter()
            Dim location = New Location(character)
            Dim tree = location.GetTree()
            If tree IsNot Nothing Then
                Console.WriteLine("There is a tree here.")
            End If
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("1) Turn")
            Console.WriteLine("2) Move")
            Console.WriteLine("0) Menu")
            Console.WriteLine()
            Console.Write(">")
            Select Case Console.ReadLine()
                Case "0"
                    If GameMenu.Run() Then
                        Return
                    End If
                Case "1"
                    TurnMenu.Run()
                Case "2"
                    MoveMenu.Run()
                Case Else
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.WriteLine()
                    Console.WriteLine("Invalid Input!")
            End Select
        End While
    End Sub
End Module
