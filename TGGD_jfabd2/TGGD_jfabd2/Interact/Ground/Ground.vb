Imports TGGD_jfabd2.Game

Module Ground
    Sub Run()
        Dim done As Boolean
        While Not done
            Dim character = New PlayerCharacter()
            Dim items = character.GetLocation().GetInventory().GetItems()
            If Not items.Any() Then
                Return
            End If
            ShowMenuTitle("On the ground:")
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
                            GroundItemMenu.Run(items(index), character.GetCharacterId())
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
