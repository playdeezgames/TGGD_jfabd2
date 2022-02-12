Imports TGGD_jfabd2.Game

Module FeedItemMenu
    Sub Run(item As Item)
        'TODO: stuff
        Dim done = False
        While Not done
            ShowMenuTitle($"Feed the {item.GetName()}:")
            ShowMenuItem("0) Never mind")
            ShowPrompt()
            Select Case Console.ReadLine()
                Case "0"
                    done = True
                Case Else
                    InvalidInput()
            End Select
        End While
    End Sub
End Module
