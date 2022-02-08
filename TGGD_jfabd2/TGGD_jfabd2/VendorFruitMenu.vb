Imports TGGD_jfabd2.Game

Module VendorFruitMenu
    Sub Run(vendor As Vendor)
        Dim done = False
        While Not done
            ShowMenuTitle("Fruits:")
            Dim fruits = vendor.GetFruitTypes()
            Dim index = 1
            For Each fruit In fruits
                ShowMenuItem($"{index}) {fruit.Name} (price:{fruit.Price})")
                index += 1
            Next
            ShowMenuItem("0) Never mind")
            Select Case Console.ReadLine()
                Case "0"
                    done = True
                Case Else
                    InvalidInput()
            End Select

        End While
    End Sub
End Module
