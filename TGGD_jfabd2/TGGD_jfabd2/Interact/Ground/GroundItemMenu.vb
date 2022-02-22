Imports Terminal.Gui
Imports TGGD_jfabd2.Game

Module GroundItemMenu
    Sub Run(item As Item, characterId As Integer)
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim pickUpButton As New Button("Pick Up")
        AddHandler pickUpButton.Clicked, Sub()
                                             item.PickUp(characterId)
                                             Application.RequestStop()
                                         End Sub
        Dim dlg As New Dialog(item.GetName(), cancelButton, pickUpButton)
        dlg.Add(New Label(1, 1, item.GetDescription))
        Application.Run(dlg)
    End Sub
End Module
