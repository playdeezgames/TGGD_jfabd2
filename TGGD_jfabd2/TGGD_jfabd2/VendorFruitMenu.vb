Imports TGGD_jfabd2.Game

Module VendorFruitMenu
    Sub Run(vendor As Vendor)
        Dim done = False
        While Not done
            ShowMenuTitle("Fruits:")
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
