Imports Terminal.Gui
Imports TGGD_jfabd2.Data

Module Program
    Sub Main(args As String())
        Application.Init()
        Console.Title = "A Game in VB about Fruits"
        MainMenu.Run()
        Store.CleanUp()
    End Sub
End Module
