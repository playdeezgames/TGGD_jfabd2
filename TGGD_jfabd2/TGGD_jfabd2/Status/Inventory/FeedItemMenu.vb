Imports TGGD_jfabd2.Game

Module FeedItemMenu
    Sub Run(item As Item)
        'TODO: stuff
        Dim done = False
        Dim character As New PlayerCharacter
        While Not done
            ShowMenuTitle($"Feed the {item.GetName()}:")
            Dim fruits = character.GetInventory().GetItems(ItemType.Fruit)
            Dim index = 1
            For Each fruit In fruits
                ShowMenuItem($"{index}) {fruit.GetName()}")
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
                        If index < fruits.Count Then
                            If item.Feed(fruits(index)) Then
                                SuccessMessage("Success!!")
                            Else
                                ErrorMessage("Fail.")
                            End If
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
