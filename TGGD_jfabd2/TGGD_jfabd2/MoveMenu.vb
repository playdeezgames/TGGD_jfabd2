Imports TGGD_jfabd2.Game

Module MoveMenu
    Sub Run()
        Dim done As Boolean = False
        While Not done
            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("Move which way?")
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("1) Ahead")
            Console.WriteLine("2) Left")
            Console.WriteLine("3) Right")
            Console.WriteLine("3) Back")
            Console.WriteLine("0) Never mind")
            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.Gray
            Console.Write(">")
            Select Case Console.ReadLine()
                Case "0"
                    done = True
                Case "1"
                    Dim character = New PlayerCharacter()
                    character.MoveAhead()
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Gray
                    Console.WriteLine("You move ahead.")
                    done = True
                Case "2"
                    Dim character = New PlayerCharacter()
                    character.MoveLeft()
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Gray
                    Console.WriteLine("You move left.")
                    done = True
                Case "3"
                    Dim character = New PlayerCharacter()
                    character.MoveRight()
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Gray
                    Console.WriteLine("You move right.")
                    done = True
                Case "4"
                    Dim character = New PlayerCharacter()
                    character.MoveBack()
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Gray
                    Console.WriteLine("You move back.")
                    done = True
                Case Else
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.WriteLine("Invalid input!")
            End Select
        End While
    End Sub
End Module
