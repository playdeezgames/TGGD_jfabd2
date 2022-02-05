Imports TGGD_jfabd2.Data
Module LoadGame
    Sub Run()
        ShowMenuTitle("Enter a saved file name:")
        ShowPrompt()
        Dim input = Console.ReadLine()
        If Not String.IsNullOrWhiteSpace(input) Then
            Store.Load(input)
            InPlay.Run()
        End If
    End Sub
End Module
