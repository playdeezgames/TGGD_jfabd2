Imports Terminal.Gui
Imports TGGD_jfabd2.Game

Module Ground
    Private Sub OldRun()
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
    Private Function GetInventory() As IList
        Return CType(New PlayerCharacter().GetLocation().GetInventory().GetItems(), IList)
    End Function
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Ground", cancelButton)
        Dim listView As New ListView(New Rect(1, 1, 40, 22), GetInventory())
        AddHandler listView.OpenSelectedItem, Sub(args)
                                                  GroundItemMenu.Run(CType(args.Value, Item), New PlayerCharacter().GetCharacterId)
                                                  Dim inventory = GetInventory()
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
