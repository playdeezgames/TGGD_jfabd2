Imports TGGD_jfabd2.Game
Module Inventory
    Sub Run()
        Dim done As Boolean
        While Not done
            ShowMenuTitle("Yer Inventory:")
            Dim items = New PlayerCharacter().GetInventory().GetItems()
            Dim index = 1
            For Each item In items
                ShowMenuItem($"{index}) {item.GetName()}")
                index += 1
            Next
            ShowMenuItem("0) Never mind")
            ShowPrompt()
            Select Case Console.ReadLine()
                Case "0"
                    done = True
                Case Else
                    InvalidInput()
            End Select
        End While
    End Sub
End Module
