Imports TGGD_jfabd2.Game

Module EquipSlotMenu
    Sub Run(equipSlot As EquipSlot)
        'TODO: the stuff
        Dim done As Boolean = False
        While Not done
            Dim character As New PlayerCharacter()
            Dim equipment = character.GetEquipment()
            If equipment.ContainsKey(equipSlot) Then
                Dim item = equipment(equipSlot)
                ShowMenuTitle(item.GetName())
                ShowMenuItem("0) Never mind")
                ShowPrompt()
                Select Case Console.ReadLine()
                    Case "0"
                        done = True
                    Case Else
                        InvalidInput()
                End Select
            End If
        End While
    End Sub
End Module
