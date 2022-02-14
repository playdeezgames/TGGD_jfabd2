Imports TGGD_jfabd2.Game

Module StatusMenu
    Sub Run()
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
End Module
