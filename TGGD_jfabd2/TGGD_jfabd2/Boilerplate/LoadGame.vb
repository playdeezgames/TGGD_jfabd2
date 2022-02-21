Imports Terminal.Gui
Imports TGGD_jfabd2.Data
Module LoadGame
    Sub OldRun()
        ShowMenuTitle("Enter a saved file name:")
        ShowPrompt()
        Dim input = Console.ReadLine()
        If Not String.IsNullOrWhiteSpace(input) Then
            Store.Load(input)
            InPlay.Run()
        End If
    End Sub
    Sub Run()
        Dim dlg As New OpenDialog()
        Application.Run(dlg)
        Dim filePath = dlg.FilePaths.FirstOrDefault
        If Not String.IsNullOrWhiteSpace(filePath) Then
            Store.Load(filePath)
            InPlay.Run()
        End If
    End Sub
End Module
