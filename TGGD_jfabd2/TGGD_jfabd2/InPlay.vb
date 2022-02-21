Imports TGGD_jfabd2.Game
Imports Terminal.Gui
Module InPlay
    Sub ShowStatus(canPickFruit As Boolean, tree As Tree, hasGroundInventory As Boolean, hasVendor As Boolean, hasCritter As Boolean)
        ShowMenuTitle("Yer playin' the game!")
        If canPickFruit Then
            ShowInfo($"There is a {FruitTypes.GetName(tree.GetFruitType())} tree here.")
        End If
        If hasVendor Then
            ShowInfo("There is a vendor here.")
        End If
        If hasGroundInventory Then
            ShowInfo("There is some stuff on the ground.")
        End If
        If hasCritter Then
            ShowInfo("There is at least one critter here.")
        End If
    End Sub
    Function HandleInput(canPickFruit As Boolean, hasGroundInventory As Boolean, hasVendor As Boolean, hasCritter As Boolean) As Boolean
        Select Case Console.ReadLine()
            Case "0"
                If GameMenu.Run() Then
                    Return True
                End If
            Case "1"
                MoveMenu.Run()
            Case "2"
                TurnMenu.Run()
            Case "3"
                StatusMenu.Run()
            Case "4"
                If canPickFruit OrElse hasGroundInventory OrElse hasVendor OrElse hasCritter Then
                    InteractMenu.Run()
                Else
                    InvalidInput()
                End If
            Case Else
                InvalidInput()
        End Select
        Return False
    End Function
    Sub OldRun()
        Dim done As Boolean = False
        While Not done
            Dim character = New PlayerCharacter()
            If character.IsAlive() Then
                Dim location = character.GetLocation()
                Dim hasCritter = location.HasCritters()
                Dim tree = location.GetTree()
                Dim canPickFruit = tree IsNot Nothing
                Dim hasGroundInventory = Not location.GetInventory().IsEmpty()
                Dim vendor = location.GetVendor()
                Dim hasVendor = vendor IsNot Nothing
                ShowStatus(canPickFruit, tree, hasGroundInventory, hasVendor, hasCritter)
                ShowMenuItem("1) Move")
                ShowMenuItem("2) Turn")
                ShowMenuItem("3) Status...")
                If canPickFruit OrElse hasGroundInventory OrElse hasVendor OrElse hasCritter Then
                    ShowMenuItem("4) Interact...")
                End If
                ShowMenuItem("0) Menu")
                ShowPrompt()
                done = HandleInput(canPickFruit, hasGroundInventory, hasVendor, hasCritter)
            Else
                done = True
                ErrorMessage("Yer dead!") 'TODO: make a character message!
            End If
        End While
    End Sub
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
