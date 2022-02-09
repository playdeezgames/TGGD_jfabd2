Imports TGGD_jfabd2.Game

Module MoveMenu
    Sub Run()
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
End Module
