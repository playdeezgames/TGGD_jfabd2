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
            Dim input = Console.ReadLine()
            Select Case input
                Case "0"
                    done = True
                Case Else
                    If Integer.TryParse(input, index) Then
                        index -= 1
                        If index < items.Count Then
                            ItemMenu.Run(items(index))
                        Else
                            InvalidInput()
                        End If
                    Else
                        InvalidInput()
                    End If
            End Select
        End While
    End Sub
End Module
