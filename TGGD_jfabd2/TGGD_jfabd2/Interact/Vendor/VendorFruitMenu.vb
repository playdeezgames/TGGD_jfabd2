Imports TGGD_jfabd2.Game

Module VendorFruitMenu
    Sub Run(vendorFruit As VendorFruit)
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
End Module
