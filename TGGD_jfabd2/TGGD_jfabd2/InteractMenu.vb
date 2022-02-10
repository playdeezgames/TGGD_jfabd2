Imports TGGD_jfabd2.Game

Module InteractMenu
    Sub Run()
        Dim done = False
        Dim character = New PlayerCharacter()
        Dim location = character.GetLocation()
        Dim tree = location.GetTree()
        Dim canPickFruit = tree IsNot Nothing
        Dim hasGroundInventory = Not location.GetInventory().IsEmpty()
        Dim vendor = location.GetVendor()
        Dim hasVendor = vendor IsNot Nothing
        While Not done
            ShowMenuTitle("Iteractions:")
            If hasGroundInventory Then
                ShowMenuItem("1) Ground")
            End If
            If canPickFruit Then
                ShowMenuItem("2) Tree")
            End If
            If hasVendor Then
                ShowMenuItem("3) Vendor")
            End If
            ShowMenuItem("0) Never mind")
            Select Case Console.ReadLine
                Case "0"
                    done = True
                Case "1"
                    If hasGroundInventory Then
                        Ground.Run()
                    Else
                        InvalidInput()
                    End If
                Case "2"
                    If canPickFruit Then
                        PickFruit.Run()
                    Else
                        InvalidInput()
                    End If
                Case "3"
                    If hasVendor Then
                        VendorMenu.Run()
                    Else
                        InvalidInput()
                    End If
                Case Else
                    InvalidInput()
            End Select
        End While
    End Sub
End Module
