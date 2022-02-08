Imports TGGD_jfabd2.Game

Module EquipItemMenu
    Function Run(item As Item) As Boolean
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
End Module
