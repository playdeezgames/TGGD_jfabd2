﻿Imports TGGD_jfabd2.Game

Module InPlay
    Sub ShowStatus(canPickFruit As Boolean, tree As Tree, hasGroundInventory As Boolean, hasVendor As Boolean)
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
    End Sub
    Sub ShowMenu(canPickFruit As Boolean, hasGroundInventory As Boolean, hasVendor As Boolean)
        ShowMenuItem("1) Move")
        ShowMenuItem("2) Turn")
        If canPickFruit Then
            ShowMenuItem("3) Pick Fruit") 'interact with the tree
        End If
        If hasGroundInventory Then
            ShowMenuItem("5) Ground") 'interact with the ground
        End If
        If hasVendor Then
            ShowMenuItem("7) Trade") 'interact with a vendor
        End If
        ShowMenuItem("8) Status") 'TODO: becomes 3
        ShowMenuItem("0) Menu")
    End Sub
    Function HandleInput(canPickFruit As Boolean, hasGroundInventory As Boolean, hasVendor As Boolean) As Boolean
        Select Case Console.ReadLine()
            Case "0"
                If GameMenu.Run() Then
                    Return True
                End If
            Case "2"
                TurnMenu.Run()
            Case "1"
                MoveMenu.Run()
            Case "3"
                If canPickFruit Then
                    PickFruit.Run()
                Else
                    InvalidInput()
                End If
            Case "5"
                If hasGroundInventory Then
                    Ground.Run()
                Else
                    InvalidInput()
                End If
            Case "7"
                If hasVendor Then
                    VendorMenu.Run()
                Else
                    InvalidInput()
                End If
            Case "8"
                StatusMenu.Run()
            Case Else
                InvalidInput()
        End Select
        Return False
    End Function
    Sub Run()
        Dim done As Boolean = False
        While Not done
            Dim character = New PlayerCharacter()
            ShowCharacterMessages(character)
            If character.IsAlive() Then
                Dim location = character.GetLocation()
                Dim tree = location.GetTree()
                Dim canPickFruit = tree IsNot Nothing
                Dim hasGroundInventory = Not location.GetInventory().IsEmpty()
                Dim vendor = location.GetVendor()
                Dim hasVendor = vendor IsNot Nothing
                ShowStatus(canPickFruit, tree, hasGroundInventory, hasVendor)
                ShowMenu(canPickFruit, hasGroundInventory, hasVendor)
                ShowPrompt()
                done = HandleInput(canPickFruit, hasGroundInventory, hasVendor)
            Else
                done = True
                ErrorMessage("Yer dead!") 'TODO: make a character message!
            End If
        End While
    End Sub
End Module
