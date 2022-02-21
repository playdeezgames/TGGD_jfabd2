Imports Terminal.Gui
Module GameMenu
    Function Run() As Boolean
        Dim result As Boolean = False
        Dim backButton As New Button("Back")
        AddHandler backButton.Clicked, AddressOf Application.RequestStop
        Dim abandonButton As New Button("Abandon Game")
        AddHandler abandonButton.Clicked, Sub()
                                              If MessageBox.Query("Are you sure?", "Are you sure you want to abandon the game?", "No", "Yes") = 1 Then
                                                  result = True
                                                  Application.RequestStop()
                                              End If
                                          End Sub
        Dim saveButton As New Button("Save Game...")
        AddHandler saveButton.Clicked, AddressOf SaveGame.Run
        Dim dlg As New Dialog("Game Menu", backButton, saveButton, abandonButton)
        Application.Run(dlg)
        Return result
    End Function
End Module
