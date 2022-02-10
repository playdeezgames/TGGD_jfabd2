Imports TGGD_jfabd2.Game

Module StatusMenu
    Sub Run()
        Dim done = False
        Dim character = New PlayerCharacter()
        While Not done
            ShowMenuTitle("Status:")
            If Not character.GetInventory().IsEmpty() Then
                ShowMenuItem($"1) Inventory")
            End If
            If character.GetEquipment().Any() Then
                ShowMenuItem("2) Equipment")
            End If
            ShowMenuItem("0) Never mind")
            ShowPrompt()
            Select Case Console.ReadLine()
                Case "0"
                    done = True
                Case "1"
                    If Not character.GetInventory().IsEmpty() Then
                        Inventory.Run()
                    Else
                        InvalidInput()
                    End If
                Case "2"
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
