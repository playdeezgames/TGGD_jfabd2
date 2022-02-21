Imports Terminal.Gui
Imports TGGD_jfabd2.Game

Module MoveMenu
    Sub OldRun()
        Dim done As Boolean = False
        While Not done
            ShowMenuTitle("Move which way?")
            ShowMenuItem("1) Ahead")
            ShowMenuItem("2) Left")
            ShowMenuItem("3) Right")
            ShowMenuItem("4) Back")
            ShowMenuItem("0) Never mind")
            ShowPrompt()
            Select Case Console.ReadLine()
                Case "0"
                    done = True
                Case "1"
                    Dim character = New PlayerCharacter()
                    character.MoveAhead()
                    ShowInfo("You move ahead.")
                    done = True
                Case "2"
                    Dim character = New PlayerCharacter()
                    character.MoveLeft()
                    ShowInfo("You move left.")
                    done = True
                Case "3"
                    Dim character = New PlayerCharacter()
                    character.MoveRight()
                    ShowInfo("You move right.")
                    done = True
                Case "4"
                    Dim character = New PlayerCharacter()
                    character.MoveBack()
                    ShowInfo("You move back.")
                    done = True
                Case Else
                    InvalidInput()
            End Select
        End While
    End Sub
    Sub MoveAhead()
        Dim character = New PlayerCharacter()
        character.MoveAhead()
        Application.RequestStop()
    End Sub
    Sub MoveLeft()
        Dim character = New PlayerCharacter()
        character.MoveLeft()
        Application.RequestStop()
    End Sub
    Sub MoveRight()
        Dim character = New PlayerCharacter()
        character.MoveRight()
        Application.RequestStop()
    End Sub
    Sub MoveBack()
        Dim character = New PlayerCharacter()
        character.MoveBack()
        Application.RequestStop()
    End Sub
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim aheadButton As New Button("Ahead")
        AddHandler aheadButton.Clicked, AddressOf MoveAhead
        Dim leftButton As New Button("Left")
        AddHandler leftButton.Clicked, AddressOf MoveLeft
        Dim rightButton As New Button("Right")
        AddHandler rightButton.Clicked, AddressOf MoveRight
        Dim backButton As New Button("Back")
        AddHandler backButton.Clicked, AddressOf MoveBack
        Dim dlg As New Dialog("Move...", cancelButton, aheadButton, leftButton, rightButton, backButton)
        Application.Run(dlg)
    End Sub
End Module
