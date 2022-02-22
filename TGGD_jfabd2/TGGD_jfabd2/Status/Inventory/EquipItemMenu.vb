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
    Private Function OldRun(item As Item) As Boolean
        Dim equipSlots = ItemTypes.GetEquipSlots(item.GetItemType)
        Select Case equipSlots.Count
            Case 0
                Return False
            Case 1
                item.Equip(equipSlots.Single)
                Return True
            Case Else
                Dim done As Boolean = False
                While Not done
                    ShowMenuTitle($"Equip {item.GetName} on:")
                    Dim index = 1
                    For Each equipSlot In equipSlots
                        ShowMenuItem($"{index}) {Game.EquipSlots.GetName(equipSlot)}")
                        index += 1
                    Next
                    ShowMenuItem("0) Never mind")
                    Dim input = Console.ReadLine
                    Select Case input
                        Case "0"
                            done = True
                        Case Else
                            If Integer.TryParse(input, index) Then
                                index -= 1
                                If index < equipSlots.Count Then
                                    item.Equip(equipSlots(index))
                                    done = True
                                    Return True
                                Else
                                    InvalidInput()
                                End If
                            Else
                                InvalidInput()
                            End If
                    End Select
                End While
        End Select
        Return False
    End Function
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
