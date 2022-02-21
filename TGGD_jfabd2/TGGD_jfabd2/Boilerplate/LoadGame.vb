Imports Terminal.Gui
Imports TGGD_jfabd2.Data
Module LoadGame
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
