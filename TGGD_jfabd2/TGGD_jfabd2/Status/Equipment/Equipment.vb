Imports Terminal.Gui
Imports TGGD_jfabd2.Game
Class EquipmentListItem
    ReadOnly Property Item As Item
    ReadOnly Property EquipSlot As EquipSlot
    Sub New(equipSlot As EquipSlot, item As Item)
        Me.Item = item
        Me.EquipSlot = equipSlot
    End Sub
    Public Overrides Function ToString() As String
        Return $"{EquipSlots.GetName(EquipSlot)}: {Item.GetName()}"
    End Function
End Class

Module Equipment
    Function GetEquipmentList() As IList
        Return New PlayerCharacter().GetEquipment().Select(Function(entry)
                                                               Return New EquipmentListItem(entry.Key, entry.Value)
                                                           End Function).ToList()
    End Function
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Equipment", cancelButton)
        Dim listView As New ListView(New Rect(1, 1, 40, 22), GetEquipmentList())
        AddHandler listView.OpenSelectedItem, Sub(args)
                                                  EquipSlotMenu.Run(CType(args.Value, EquipmentListItem).EquipSlot)
                                                  Dim equipmentList = GetEquipmentList()
                                                  If equipmentList.Count() > 0 Then
                                                      listView.SetSource(equipmentList)
                                                  Else
                                                      Application.RequestStop()
                                                  End If
                                              End Sub
        dlg.Add(listView)
        Application.Run(dlg)
    End Sub
End Module
