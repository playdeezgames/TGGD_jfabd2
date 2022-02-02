Imports System

Module Program
    Function ConfirmQuit() As Boolean
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
    Sub MainMenu()
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
                done = ConfirmQuit()
            Else
                Console.WriteLine()
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine("Invalid input!")
            End If
        End While
    End Sub
    Sub Main(args As String())
        Console.Title = "A Game in VB about Fruits"
        Console.WriteLine()
        Console.ForegroundColor = ConsoleColor.Magenta
        Console.WriteLine("A Game in VB about Fruits")
        Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.WriteLine("A production of TheGrumpyGameDev")
        MainMenu()
    End Sub
End Module
