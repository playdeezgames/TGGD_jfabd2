Imports TGGD_jfabd2.Game
Imports Terminal.Gui
Module InPlay
    Private Sub UpdateStatus(label As Label)
        Dim character = New PlayerCharacter()
        Dim location = character.GetLocation()
        Dim hasCritter = location.HasCritters()
        Dim tree = location.GetTree()
        Dim canPickFruit = tree IsNot Nothing
        Dim hasGroundInventory = Not location.GetInventory().IsEmpty()
        Dim vendor = location.GetVendor()
        Dim hasVendor = vendor IsNot Nothing
        label.Text = ""
        If character.IsAlive Then
            label.Text += "Yer alive!
"
            If canPickFruit Then
                label.Text += $"There is a {FruitTypes.GetName(tree.GetFruitType())} tree here.
"
            End If
            If hasVendor Then
                label.Text += "There is a vendor here.
"
            End If
            If hasGroundInventory Then
                label.Text += "There is some stuff on the ground.
"
            End If
            If hasCritter Then
                label.Text += "There is at least one critter here.
"
            End If
        Else
            label.Text += "Yer dead!"
        End If
    End Sub
    Sub Run()
        Dim menuButton As New Button("Menu")
        AddHandler menuButton.Clicked, Sub()
                                           If GameMenu.Run() Then
                                               Application.RequestStop()
                                           End If
                                       End Sub
        Dim moveButton As New Button("Move...")
        Dim turnButton As New Button("Turn...")
        Dim statusButton As New Button("Status...")
        Dim interactButton As New Button("Interact...")
        Dim statusLabel As New Label(New Rect(1, 1, 40, 5))
        AddHandler moveButton.Clicked, Sub()
                                           MoveMenu.Run()
                                           UpdateStatus(statusLabel)
                                           UpdateButtons(moveButton, turnButton, statusButton, interactButton)
                                       End Sub
        AddHandler turnButton.Clicked, Sub()
                                           TurnMenu.Run()
                                           UpdateStatus(statusLabel)
                                           UpdateButtons(moveButton, turnButton, statusButton, interactButton)
                                       End Sub
        Dim dlg As New Dialog("Yer playin' the game!", moveButton, turnButton, statusButton, interactButton, menuButton)
        AddHandler dlg.KeyPress, Sub(args)
                                     If args.KeyEvent.Key = Key.Esc Then
                                         args.Handled = True
                                     End If
                                 End Sub
        dlg.Add(statusLabel)
        UpdateStatus(statusLabel)
        UpdateButtons(moveButton, turnButton, statusButton, interactButton)
        Application.Run(dlg)
    End Sub

    Private Sub UpdateButtons(moveButton As Button, turnButton As Button, statusButton As Button, interactButton As Button)
        Dim character = New PlayerCharacter()
        Dim location = character.GetLocation()
        Dim hasCritter = location.HasCritters()
        Dim tree = location.GetTree()
        Dim canPickFruit = tree IsNot Nothing
        Dim hasGroundInventory = Not location.GetInventory().IsEmpty()
        Dim vendor = location.GetVendor()
        Dim hasVendor = vendor IsNot Nothing
        moveButton.Enabled = character.IsAlive
        turnButton.Enabled = character.IsAlive
        interactButton.Enabled = character.IsAlive AndAlso (canPickFruit OrElse hasGroundInventory OrElse hasVendor OrElse hasCritter)
    End Sub
End Module
