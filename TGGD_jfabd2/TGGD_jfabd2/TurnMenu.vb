Imports TGGD_jfabd2.Game

Module TurnMenu
    Sub Run()
        Dim done As Boolean = False
        While Not done
            ShowMenuTitle("Turn which way?")
            ShowMenuItem("1) Left")
            ShowMenuItem("2) Right")
            ShowMenuItem("3) Around")
            ShowMenuItem("0) Never mind")
            ShowPrompt()
            Select Case Console.ReadLine()
                Case "0"
                    done = True
                Case "1"
                    Dim character = New PlayerCharacter()
                    character.TurnLeft()
                    done = True
                    ShowInfo("You turn left.")
                Case "2"
                    Dim character = New PlayerCharacter()
                    character.TurnRight()
                    done = True
                    ShowInfo("You turn right.")
                Case "3"
                    Dim character = New PlayerCharacter()
                    character.TurnAround()
                    done = True
                    ShowInfo("You turn around.")
                Case Else
                    InvalidInput()
            End Select
        End While
    End Sub
End Module
