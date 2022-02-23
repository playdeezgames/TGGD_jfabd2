Imports Terminal.Gui
Imports TGGD_jfabd2.Game

Module VendorFruitListMenu
    Private Sub OldRun(vendor As Vendor)
        Dim done = False
        While Not done
            ShowMenuTitle("Fruits:")
            Dim fruits = vendor.GetFruitTypes()
            Dim index = 1
            For Each fruit In fruits
                ShowMenuItem($"{index}) {fruit.Name} (price:{fruit.BuyingPrice})")
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
                            VendorFruitMenu.Run(fruits(index))
                        Else
                            InvalidInput()
                        End If
                    Else
                        InvalidInput()
                    End If
            End Select

        End While
    End Sub
    Private Function GetFruits(vendor As Vendor) As IList
        Return CType(vendor.GetFruitTypes(), IList)
    End Function
    Sub Run(vendor As Vendor)
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Fruits:", cancelButton)
        Dim listView As New ListView(New Rect(1, 1, 40, 22), GetFruits(vendor))
        AddHandler listView.OpenSelectedItem, Sub(args)
                                                  VendorFruitMenu.Run(CType(args.Value, VendorFruit))
                                                  Dim inventory = GetFruits(vendor)
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
