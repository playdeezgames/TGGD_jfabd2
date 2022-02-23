Imports Terminal.Gui
Imports TGGD_jfabd2.Game

Module VendorFruitMenu
    Private Sub OldRun(vendorFruit As VendorFruit)
        Dim done = False
        Dim character = New PlayerCharacter()
        While Not done
            Dim jools = character.GetStatistic(CharacterStatisticType.Jools)
            ShowMenuTitle(vendorFruit.Name)
            ShowInfo($"You can buy for: {vendorFruit.BuyingPrice} jools")
            ShowInfo($"You can sell for: {vendorFruit.SellingPrice} jools")
            ShowInfo($"You have: {jools} jools")
            Dim canBuy = jools >= vendorFruit.BuyingPrice AndAlso Not character.GetInventory().IsFull
            Dim canSell = character.GetInventory().HasFruitType(vendorFruit.FruitType) AndAlso vendorFruit.SellingPrice > 0
            If canBuy Then
                ShowMenuItem("1) Buy")
            End If
            If canSell Then
                ShowMenuItem("2) Sell")
            End If
            ShowMenuItem("0) Never mind")
            ShowPrompt()
            Select Case Console.ReadLine()
                Case "0"
                    done = True
                Case "1"
                    If canBuy Then
                        character.GetInventory().Add(New Fruit(vendorFruit.FruitType))
                        character.ChangeStatistic(CharacterStatisticType.Jools, -vendorFruit.BuyingPrice)
                        vendorFruit.HandleBuy()
                    End If
                Case "2"
                    If canSell Then
                        character.GetInventory().RemoveFruit(vendorFruit.FruitType)
                        character.ChangeStatistic(CharacterStatisticType.Jools, vendorFruit.SellingPrice)
                        vendorFruit.HandleSale()
                    Else
                        InvalidInput()
                    End If
                Case Else
                    InvalidInput()
            End Select
        End While
    End Sub
    Sub Run(vendorFruit As VendorFruit)
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim buyForLabel As New Label(1, 1, "")
        Dim sellForLabel As New Label(1, 2, "")
        Dim joolsLabel As New Label(1, 3, "")
        Dim updateLabels = Sub()
                               Dim character = New PlayerCharacter()
                               Dim jools = character.GetStatistic(CharacterStatisticType.Jools)
                               buyForLabel.Text = $"You can buy for: {vendorFruit.BuyingPrice} jools"
                               sellForLabel.Text = $"You can sell for: {vendorFruit.SellingPrice} jools"
                               joolsLabel.Text = $"You have: {jools} jools"
                           End Sub
        updateLabels()
        Dim buyButton As New Button("Buy")
        Dim sellButton As New Button("Sell")
        Dim updateButtons = Sub()
                                Dim character = New PlayerCharacter()
                                Dim jools = character.GetStatistic(CharacterStatisticType.Jools)
                                buyButton.Enabled = jools >= vendorFruit.BuyingPrice AndAlso Not character.GetInventory().IsFull
                                sellButton.Enabled = character.GetInventory().HasFruitType(vendorFruit.FruitType) AndAlso vendorFruit.SellingPrice > 0
                            End Sub
        AddHandler buyButton.Clicked, Sub()
                                          Dim character = New PlayerCharacter()
                                          character.GetInventory().Add(New Fruit(vendorFruit.FruitType))
                                          character.ChangeStatistic(CharacterStatisticType.Jools, -vendorFruit.BuyingPrice)
                                          vendorFruit.HandleBuy()
                                          updateButtons()
                                          updateLabels()
                                      End Sub
        AddHandler sellButton.Clicked, Sub()
                                           Dim character = New PlayerCharacter()
                                           character.GetInventory().RemoveFruit(vendorFruit.FruitType)
                                           character.ChangeStatistic(CharacterStatisticType.Jools, vendorFruit.SellingPrice)
                                           vendorFruit.HandleSale()
                                           updateButtons()
                                           updateLabels()
                                       End Sub
        updateButtons()
        Dim dlg As New Dialog(vendorFruit.Name, cancelButton, buyButton, sellButton)
        dlg.Add(buyForLabel, sellForLabel, joolsLabel)
        Application.Run(dlg)
    End Sub
End Module
