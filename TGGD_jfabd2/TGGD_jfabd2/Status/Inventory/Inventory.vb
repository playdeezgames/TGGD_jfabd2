Imports Terminal.Gui
Imports TGGD_jfabd2.Game
Module Inventory
    Private Function GetInventory() As IList
        Return CType(New PlayerCharacter().GetInventory().GetItems(), IList)
    End Function
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Inventory", cancelButton)
        Dim listView As New ListView(New Rect(1, 1, 40, 22), GetInventory())
        AddHandler listView.OpenSelectedItem, Sub(args)
                                                  ItemMenu.Run(CType(args.Value, Item))
                                                  Dim inventory = GetInventory()
                                                  If inventory.Count() > 0 Then
                                                      listView.SetSource(inventory)
                                                  Else
                                                      Application.RequestStop()
                                                  End If
                                              End Sub
        dlg.Add(listView)
        Application.Run(dlg)
    End Sub
End Module
