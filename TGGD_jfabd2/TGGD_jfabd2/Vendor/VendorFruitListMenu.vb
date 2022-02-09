﻿Imports TGGD_jfabd2.Game

Module VendorFruitListMenu
    Sub Run(vendor As Vendor)
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
End Module