Imports Terminal.Gui
Imports TGGD_jfabd2.Game

Module EquipSlotMenu
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
                                              If CritterItemMenu.Run(item) Then
                                                  Application.RequestStop()
                                              End If
                                          End Sub
        critterButton.Enabled = item.IsCritter
        Dim dlg As New Dialog(EquipSlots.GetName(equipSlot), cancelButton, unequipButton, critterButton)
        dlg.Add(New Label(1, 1, item.GetName()))
        dlg.Add(New Label(1, 2, item.GetDescription()))
        Application.Run(dlg)
    End Sub
End Module
