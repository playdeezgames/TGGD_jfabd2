Imports TGGD_jfabd2.Game

Module VendorMenu
    Sub Run()
        Dim done = False
        Dim vendor = New PlayerCharacter().GetLocation().GetVendor()
        While Not done
            ShowMenuTitle("Vendor:")
            Dim hasFruits = vendor.HasFruits()
            If hasFruits Then
                ShowMenuItem("1) Fruits")
            End If
            ShowMenuItem("0) Never mind")
            ShowPrompt()
            Select Case Console.ReadLine
                Case "0"
                    done = True
                Case "1"
                    If hasFruits Then
                        VendorFruitListMenu.Run(vendor)
                    Else
                        InvalidInput()
                    End If
                Case Else
                    InvalidInput()
            End Select
        End While
    End Sub
End Module
