Imports TGGD_jfabd2.Game

Module CritterFeedMenu
    Sub Run(critter As Critter)
        Dim done = False
        Dim character As New PlayerCharacter
        While Not done
            ShowMenuTitle($"Feed the {critter.Name}:")
            Dim index As Integer = 1
            Dim fruits = character.GetInventory().GetItems(ItemType.Fruit)
            For Each fruit In fruits
                ShowMenuItem($"{index}) {fruit.GetName()}")
                index += 1
            Next
            ShowMenuItem("0) Never mind")
            ShowPrompt()
            Dim input = Console.ReadLine
            Select Case input
                Case "0"
                    done = True
                Case Else
                    If Integer.TryParse(input, index) Then
                        index -= 1
                        If index < fruits.Count Then
                            'TODO: this should be in its own action module
                            If character.Check(Characteristic.Charisma) > critter.Check(Characteristic.Willpower) Then
                                critter.Feed(fruits(index))
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
