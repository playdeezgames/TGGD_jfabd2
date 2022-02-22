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
    Private Sub OldRun()
        Dim done As Boolean
        While Not done
            Dim equipment = New PlayerCharacter().GetEquipment()
            If Not equipment.Any() Then
                Return
            End If
            ShowMenuTitle("Yer Equipment:")
            Dim index = 1
            Dim slots As New List(Of EquipSlot)
            For Each entry In equipment
                slots.Add(entry.Key)
                ShowMenuItem($"{index}) ({EquipSlots.GetName(entry.Key)}){entry.Value.GetName()}")
                index += 1
            Next
            ShowMenuItem("0) Never mind")
            ShowPrompt()
            Dim input = Console.ReadLine()
            Select Case input
                Case "0"
                    done = True
                Case Else
                    If Integer.TryParse(input, index) Then
                        index -= 1
                        If index < slots.Count Then
                            EquipSlotMenu.Run(slots(index))
                        Else
                            InvalidInput()
                        End If
                    Else
                        InvalidInput()
                    End If
            End Select
        End While
    End Sub
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
                                                  'TODO: go to equipment item screen
                                                  listView.SetSource(GetEquipmentList())
                                              End Sub
        dlg.Add(listView)
        Application.Run(dlg)
    End Sub
End Module
