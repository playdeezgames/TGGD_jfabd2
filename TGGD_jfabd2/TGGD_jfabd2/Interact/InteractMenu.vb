Imports Terminal.Gui
Imports TGGD_jfabd2.Game

Module InteractMenu
    Private Sub OldRun()
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
    Sub Run()
        Dim character = New PlayerCharacter()
        Dim location = character.GetLocation()
        Dim tree = location.GetTree()
        Dim canPickFruit = tree IsNot Nothing
        Dim vendor = location.GetVendor()
        Dim hasVendor = vendor IsNot Nothing
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim groundButton As New Button("Ground...")
        groundButton.Enabled = Not location.GetInventory().IsEmpty()
        AddHandler groundButton.Clicked, Sub()
                                             Ground.Run()
                                             groundButton.Enabled = Not location.GetInventory().IsEmpty()
                                         End Sub
        Dim treeButton As New Button("Tree")
        treeButton.Enabled = canPickFruit
        AddHandler treeButton.Clicked, Sub()
                                           PickFruit.Run()
                                       End Sub
        Dim vendorButton As New Button("Vendor...")
        vendorButton.Enabled = hasVendor
        AddHandler vendorButton.Clicked, Sub()

                                         End Sub
        Dim critterButton As New Button("Critter...")
        critterButton.Enabled = location.HasCritters()
        AddHandler critterButton.Clicked, Sub()
                                              CritterListMenu.Run()
                                              critterButton.Enabled = location.HasCritters()
                                          End Sub
        Dim dlg As New Dialog("Interact...", cancelButton, groundButton, treeButton, vendorButton, critterButton)
        Application.Run(dlg)
    End Sub
End Module
