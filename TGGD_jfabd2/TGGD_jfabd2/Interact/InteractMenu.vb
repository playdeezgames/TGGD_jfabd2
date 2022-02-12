Imports TGGD_jfabd2.Game

Module InteractMenu
    Sub Run()
        Dim done = False
        Dim character = New PlayerCharacter()
        Dim location = character.GetLocation()
        While Not done
            Dim tree = location.GetTree()
            Dim canPickFruit = tree IsNot Nothing
            Dim hasGroundInventory = Not location.GetInventory().IsEmpty()
            Dim vendor = location.GetVendor()
            Dim hasVendor = vendor IsNot Nothing
            Dim hasCritter = location.HasCritters()
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
            If hasCritter Then
                ShowMenuItem("4) Critter")
            End If
            ShowMenuItem("0) Never mind")
            ShowPrompt()
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
                Case "4"
                    If hasCritter Then
                        CritterListMenu.Run()
                    Else
                        InvalidInput()
                    End If
                Case Else
                    InvalidInput()
            End Select
        End While
    End Sub
End Module
