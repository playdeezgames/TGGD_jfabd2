Imports TGGD_jfabd2.Game

Module TurnMenu
    Sub Run()
        Dim done As Boolean = False
        While Not done
            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.Green
            Console.WriteLine("Turn which way?")
            Console.ForegroundColor = ConsoleColor.Yellow
            Console.WriteLine("1) Left")
            Console.WriteLine("2) Right")
            Console.WriteLine("3) Around")
            Console.WriteLine("0) Never mind")
            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.Gray
            Console.Write(">")
            Select Case Console.ReadLine()
                Case "0"
                    done = True
                Case "1"
                    Dim character = New PlayerCharacter()
                    character.TurnLeft()
                    done = True
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Gray
                    Console.WriteLine("You turn left.")
                Case "2"
                    Dim character = New PlayerCharacter()
                    character.TurnRight()
                    done = True
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Gray
                    Console.WriteLine("You turn right.")
                Case "3"
                    Dim character = New PlayerCharacter()
                    character.TurnAround()
                    done = True
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Gray
                    Console.WriteLine("You turn around.")
                Case Else
                    Console.WriteLine()
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.WriteLine("Invalid input!")
            End Select
        End While
    End Sub
End Module
