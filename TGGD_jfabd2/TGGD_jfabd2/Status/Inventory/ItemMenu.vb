Imports TGGD_jfabd2.Game
Module ItemMenu
    Sub Run(item As Item)
        Dim done = False
        While Not done
            ShowMenuTitle(item.GetName())
            ShowInfo(item.GetDescription())
            ShowMenuItem("1) Drop")
            If item.CanConsume() Then
                ShowMenuItem("2) Consume")
            End If
            If item.CanEquip() Then
                ShowMenuItem("3) Equip")
            End If
            If item.IsCritter() Then
                ShowMenuItem("4) Critter...")
            End If
            ShowMenuItem("0) Never mind")
            ShowPrompt()
            Select Case Console.ReadLine()
                Case "0"
                    done = True
                Case "1"
                    ShowInfo($"You drop the {item.GetName()}.")
                    item.Drop()
                    done = True
                Case "2"
                    If item.CanConsume() Then
                        item.Consume()
                        done = True
                    Else
                        InvalidInput()
                    End If
                Case "3"
                    If item.CanEquip() Then
                        done = EquipItemMenu.Run(item)
                    Else
                        InvalidInput()
                    End If
                Case "4"
                    If item.IsCritter() Then
                        done = CritterItemMenu.Run(item)
                    Else
                        InvalidInput()
                    End If
            End Select
        End While
    End Sub
End Module
