Imports Terminal.Gui
Imports TGGD_jfabd2.Game
Module ItemMenu
    Private Sub OldRun(item As Item)
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
    Sub Run(item As Item)
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dropButton As New Button("Drop")
        AddHandler dropButton.Clicked, Sub()
                                           item.Drop()
                                           Application.RequestStop()
                                       End Sub
        Dim consumeButton As New Button("Consume")
        consumeButton.Enabled = item.CanConsume
        AddHandler consumeButton.Clicked, Sub()
                                              item.Consume()
                                              Application.RequestStop()
                                          End Sub
        Dim equipButton As New Button("Equip")
        equipButton.Enabled = item.CanEquip
        AddHandler equipButton.Clicked, Sub()
                                            If EquipItemMenu.Run(item) Then
                                                Application.RequestStop()
                                            End If
                                        End Sub
        Dim critterButton As New Button("Critter...")
        critterButton.Enabled = item.IsCritter
        AddHandler critterButton.Clicked, Sub()
                                              'TODO: critter item menu
                                          End Sub
        Dim dlg As New Dialog(item.GetName(), cancelButton, dropButton, consumeButton, equipButton, critterButton)
        dlg.Add(New Label(1, 1, item.GetDescription()))
        Application.Run(dlg)
    End Sub
End Module
