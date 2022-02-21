Imports Terminal.Gui
Imports TGGD_jfabd2.Data

Module SaveGame
    Sub Run()
        Dim dlg As New SaveDialog()
        Application.Run(dlg)
        If dlg.FileName IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(dlg.FileName.ToString()) Then
            Store.Save(dlg.FileName.ToString())
        End If
    End Sub
End Module
