Module GameMenu
    Function Run() As Boolean
        Dim done As Boolean = False
        While Not done
            ShowMenuTitle("Game Menu:")
            ShowMenuItem("1) Abandon game")
            ShowMenuItem("2) Save game...")
            ShowMenuItem("0) Back")
            ShowPrompt()
            Select Case Console.ReadLine()
                Case "0"
                    Return False
                Case "1"
                    If Confirm.Run("Are you sure you want to abandon the game?") Then
                        Return True
                    End If
                Case "2"
                    SaveGame.Run()
                Case Else
                    InvalidInput()
            End Select
        End While
        Return False
    End Function
End Module
