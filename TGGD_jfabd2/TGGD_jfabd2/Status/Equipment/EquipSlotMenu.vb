Imports TGGD_jfabd2.Game

Module EquipSlotMenu
    Sub Run(equipSlot As EquipSlot)
        Dim done As Boolean = False
        While Not done
            Dim character As New PlayerCharacter()
            Dim equipment = character.GetEquipment()
            If equipment.ContainsKey(equipSlot) Then
                Dim item = equipment(equipSlot)
                ShowMenuTitle(item.GetName())
                ShowMenuItem("1) Unequip")
                If item.CanFeed() Then
                    ShowMenuItem("2) Feed")
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
                        If item.CanFeed() Then
                            FeedItemMenu.Run(item)
                        End If
                    Case Else
                        InvalidInput()
                End Select
            End If
        End While
    End Sub
End Module
