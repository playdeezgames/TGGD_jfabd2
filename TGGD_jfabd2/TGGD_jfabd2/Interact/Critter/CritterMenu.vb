Imports Terminal.Gui
Imports TGGD_jfabd2.Game

Module CritterMenu
    Private Sub OldRun(critter As Critter)
        Dim done = False
        Dim character As New PlayerCharacter
        While Not done
            Dim hasFruit = character.GetInventory().HasItemType(ItemType.Fruit)
            ShowMenuTitle($"{critter.Name}:")
            If hasFruit Then
                ShowMenuItem("1) Feed...")
            End If
            ShowMenuItem("2) Capture!")
            ShowMenuItem("0) Never mind")
            ShowPrompt()
            Select Case Console.ReadLine
                Case "0"
                    done = True
                Case "1"
                    If hasFruit Then
                        CritterFeedMenu.Run(critter)
                    Else
                        InvalidInput()
                    End If
                Case "2"
                    done = CritterCapture.Run(critter)
                Case Else
                    InvalidInput()
            End Select
        End While
    End Sub
    Sub Run(critter As Critter)
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog(critter.Name, cancelButton)
        dlg.Add(New Label(1, 1, critter.Description))
        Application.Run(dlg)
    End Sub
End Module
