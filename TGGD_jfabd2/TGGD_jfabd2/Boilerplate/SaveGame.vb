Imports TGGD_jfabd2.Data

Module SaveGame
    Sub Run()
        ShowMenuTitle("Enter a save file name:")
        ShowPrompt()
        Dim input = Console.ReadLine()
        If Not String.IsNullOrWhiteSpace(input) Then
            Store.Save(input)
        End If
    End Sub
End Module
