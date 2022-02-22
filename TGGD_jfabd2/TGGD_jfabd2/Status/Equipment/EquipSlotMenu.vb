Imports Terminal.Gui
Imports TGGD_jfabd2.Game

Module EquipSlotMenu
    Private Sub OldRun(equipSlot As EquipSlot)
        Dim done As Boolean = False
        While Not done
            Dim character As New PlayerCharacter()
            Dim equipment = character.GetEquipment()
            If equipment.ContainsKey(equipSlot) Then
                Dim item = equipment(equipSlot)
                ShowMenuTitle(item.GetName())
                ShowMenuItem("1) Unequip")
                If item.IsCritter() Then
                    ShowMenuItem("2) Critter...")
                End If
                ShowMenuItem("0) Never mind")
                ShowPrompt()
                Select Case Console.ReadLine()
                    Case "0"
                        done = True
                    Case "1"
                        item.Unequip()
                        done = True
                    Case "2"
                        If item.IsCritter() Then
                            done = CritterItemMenu.Run(item)
                        Else
                            InvalidInput()
                        End If
                    Case Else
                        InvalidInput()
                End Select
            End If
        End While
    End Sub
    Sub Run(equipSlot As EquipSlot)
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim character As New PlayerCharacter()
        Dim item = character.GetEquipment()(equipSlot)
        Dim unequipButton As New Button("Unequip")
        AddHandler unequipButton.Clicked, Sub()
                                              item.Unequip()
                                              Application.RequestStop()
                                          End Sub
        Dim critterButton As New Button("Critter...")
        AddHandler critterButton.Clicked, Sub()
                                              'TODO: go to critter item menu
                                          End Sub
        critterButton.Enabled = item.IsCritter
        Dim dlg As New Dialog(EquipSlots.GetName(equipSlot), cancelButton, unequipButton, critterButton)
        dlg.Add(New Label(1, 1, item.GetName()))
        dlg.Add(New Label(1, 2, item.GetDescription()))
        Application.Run(dlg)
    End Sub
End Module
