Imports Terminal.Gui
Imports TGGD_jfabd2.Game

Module CritterFeedMenu
    Private Sub OldRun(critter As Critter)
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
    Private Function GetFruits() As IList
        Return CType(New PlayerCharacter().GetInventory().GetItems(ItemType.Fruit), IList)
    End Function
    Private Sub Feed(critter As Critter, character As Character, fruit As Item)
        If character.Check(Characteristic.Charisma) > critter.Check(Characteristic.Willpower) Then
            critter.Feed(fruit)
            MessageBox.Query("Success!!", "It takes the fruit, and seems less afraid of you.", "Ok")
        Else
            MessageBox.Query("Fail!", "It is cautious.", "Ok")
        End If
    End Sub

    Sub Run(critter As Critter)
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog($"Feed the {critter.Name}:", cancelButton)
        Dim listView As New ListView(New Rect(1, 1, 40, 22), GetFruits())
        AddHandler listView.OpenSelectedItem, Sub(args)
                                                  Feed(critter, New PlayerCharacter(), CType(args.Value, Item))
                                                  Dim inventory = GetFruits()
                                                  If inventory.Count() > 0 Then
                                                      listView.SetSource(inventory)
                                                  Else
                                                      Application.RequestStop()
                                                  End If
                                              End Sub
        dlg.Add(listView)
        Application.Run(dlg)
    End Sub

End Module
