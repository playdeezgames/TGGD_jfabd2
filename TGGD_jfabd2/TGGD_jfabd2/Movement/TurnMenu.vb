Imports Terminal.Gui
Imports TGGD_jfabd2.Game

Module TurnMenu
    Private Sub TurnLeft()
        Dim character = New PlayerCharacter()
        character.TurnLeft()
        Application.RequestStop()
    End Sub
    Private Sub TurnRight()
        Dim character = New PlayerCharacter()
        character.TurnRight()
        Application.RequestStop()
    End Sub
    Private Sub TurnAround()
        Dim character = New PlayerCharacter()
        character.TurnAround()
        Application.RequestStop()
    End Sub
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim leftButton As New Button("Left")
        AddHandler leftButton.Clicked, AddressOf TurnLeft
        Dim rightButton As New Button("Right")
        AddHandler rightButton.Clicked, AddressOf TurnRight
        Dim aroundButton As New Button("Around")
        AddHandler aroundButton.Clicked, AddressOf TurnAround
        Dim dlg As New Dialog("Turn...", cancelButton, leftButton, rightButton, aroundButton)
        Application.Run(dlg)
    End Sub
End Module
