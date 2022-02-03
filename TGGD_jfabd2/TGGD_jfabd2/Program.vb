Imports TGGD_jfabd2.Data

Module Program
    Sub Main(args As String())
        Console.Title = "A Game in VB about Fruits"
        Console.WriteLine()
        Console.ForegroundColor = ConsoleColor.Magenta
        Console.WriteLine("A Game in VB about Fruits")
        Console.ForegroundColor = ConsoleColor.DarkMagenta
        Console.WriteLine("A production of TheGrumpyGameDev")
        MainMenu.Run()
        Store.CleanUp()
    End Sub
End Module
