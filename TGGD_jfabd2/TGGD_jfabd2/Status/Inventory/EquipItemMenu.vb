Imports Terminal.Gui
Imports TGGD_jfabd2.Game
Class EquipItemListItem
    ReadOnly Property EquipSlot As EquipSlot
    Sub New(equipSlot As EquipSlot)
        Me.EquipSlot = equipSlot
    End Sub
    Public Overrides Function ToString() As String
        Return EquipSlots.GetName(EquipSlot)
    End Function
End Class
Module EquipItemMenu
    Private Function GetEquipSlots(item As Item) As IList
        Return ItemTypes.GetEquipSlots(item.GetItemType).Select(Function(slot)
                                                                    Return New EquipItemListItem(slot)
                                                                End Function).ToList()
    End Function
    Function Run(item As Item) As Boolean
        Dim result As Boolean = False
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog($"Equip {item.GetName}...", cancelButton)
        Dim listView As New ListView(New Rect(1, 1, 40, 20), GetEquipSlots(item))
        AddHandler listView.OpenSelectedItem, Sub(args)
                                                  item.Equip(CType(args.Value, EquipItemListItem).EquipSlot)
                                                  result = True
                                                  Application.RequestStop()
                                              End Sub
        dlg.Add(listView)
        Application.Run(dlg)
        Return result
    End Function
End Module
