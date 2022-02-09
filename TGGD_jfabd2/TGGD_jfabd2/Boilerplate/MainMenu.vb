Module MainMenu
    Sub Run()
        Dim done As Boolean = False
        While Not done
            ShowMenuTitle("Main Menu:")
            ShowMenuItem("1) Start")
            ShowMenuItem("2) Continue")
            ShowMenuItem("0) Quit")
            ShowPrompt()
            Select Case Console.ReadLine()
                Case "0"
                    done = Confirm.Run("Are you sure you want to quit?")
                Case "1"
                    Start.Run()
                Case "2"
                    LoadGame.Run()
                Case Else
                    InvalidInput()
            End Select
        End While
    End Sub
End Module
