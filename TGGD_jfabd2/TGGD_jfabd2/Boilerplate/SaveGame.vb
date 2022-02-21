Imports Terminal.Gui
Imports TGGD_jfabd2.Data

Module SaveGame
    Sub OldRun()
        ShowMenuTitle("Enter a save file name:")
        ShowPrompt()
        Dim input = Console.ReadLine()
        If Not String.IsNullOrWhiteSpace(input) Then
            Store.Save(input)
        End If
    End Sub
    Sub Run()
        Dim dlg As New SaveDialog()
        Application.Run(dlg)
        If dlg.FileName IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(dlg.FileName.ToString()) Then
            Store.Save(dlg.FileName.ToString())
        End If
    End Sub
End Module
