Imports Terminal.Gui
Module GameMenu
    Function OldRun() As Boolean
        Dim done As Boolean = False
        While Not done
            ShowMenuTitle("Game Menu:")
            ShowMenuItem("1) Abandon game")
            ShowMenuItem("2) Save game...")
            ShowMenuItem("0) Back")
            ShowPrompt()
            Select Case Console.ReadLine()
                Case "0"
                    Return False
                Case "1"
                    If Confirm.Run("Are you sure you want to abandon the game?") Then
                        Return True
                    End If
                Case "2"
                    SaveGame.Run()
                Case Else
                    InvalidInput()
            End Select
        End While
        Return False
    End Function
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
