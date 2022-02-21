Imports Terminal.Gui
Imports TGGD_jfabd2.Game

Module MoveMenu
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
