Imports TGGD_jfabd2.Game
Module ItemMenu
    Sub Run(item As Item)
        Dim done = False
        While Not done
            ShowMenuTitle(item.GetName())
            ShowInfo(item.GetDescription())
            'TODO: drop item
            'TODO: eat item
            ShowMenuItem("0) Never mind")
            ShowPrompt()
            Select Case Console.ReadLine()
                Case "0"
                    done = True
            End Select
        End While
    End Sub
End Module
