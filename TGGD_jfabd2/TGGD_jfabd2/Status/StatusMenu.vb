Imports Terminal.Gui
Imports TGGD_jfabd2.Game

Module StatusMenu
    Private Sub OldRun()
        Dim done = False
        Dim character = New PlayerCharacter()
        While Not done
            ShowMenuTitle("Status:")
            Dim stats = [Enum].GetValues(GetType(Characteristic))
            For Each stat In stats
                ShowInfo($"{Characteristics.GetAbbreviation(CType(stat, Characteristic))} {character.GetCharacteristic(CType(stat, Characteristic))}")
            Next
            ShowMenuItem("1) Statististics")
            If Not character.GetInventory().IsEmpty() Then
                ShowMenuItem($"2) Inventory")
            End If
            If character.GetEquipment().Any() Then
                ShowMenuItem("3) Equipment")
            End If
            ShowMenuItem("0) Never mind")
            ShowPrompt()
            Select Case Console.ReadLine()
                Case "0"
                    done = True
                Case "1"
                    CharacterStatistics.Run()
                Case "2"
                    If Not character.GetInventory().IsEmpty() Then
                        Inventory.Run()
                    Else
                        InvalidInput()
                    End If
                Case "3"
                    If character.GetEquipment().Any() Then
                        Equipment.Run()
                    Else
                        InvalidInput()
                    End If
                Case Else
                    InvalidInput()
            End Select
        End While
    End Sub
    Private Sub AddCharacteristics(dlg As Dialog)
        Dim character = New PlayerCharacter()
        Dim stats = [Enum].GetValues(GetType(Characteristic))
        Dim row = 1
        For Each stat In stats
            dlg.Add(New Label(1, row, $"{Characteristics.GetAbbreviation(CType(stat, Characteristic))} {character.GetCharacteristic(CType(stat, Characteristic))}"))
            row += 1
        Next
    End Sub
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim statisticsButton As New Button("Statistics...")
        AddHandler statisticsButton.Clicked, Sub()
                                                 CharacterStatistics.Run()
                                             End Sub
        Dim inventoryButton As New Button("Inventory...")
        Dim equipmentButton As New Button("Equipment...")
        Dim dlg As New Dialog("Status", cancelButton, statisticsButton, inventoryButton, equipmentButton)
        Dim updateButtons = Sub()
                                Dim character = New PlayerCharacter()
                                inventoryButton.Enabled = Not character.GetInventory().IsEmpty()
                                equipmentButton.Enabled = character.GetEquipment().Any()
                            End Sub
        AddHandler inventoryButton.Clicked, Sub()
                                                Inventory.Run()
                                                updateButtons()
                                            End Sub
        AddHandler equipmentButton.Clicked, Sub()
                                                Equipment.Run()
                                                updateButtons()
                                            End Sub
        updateButtons()
        AddCharacteristics(dlg)
        Application.Run(dlg)
    End Sub
End Module
