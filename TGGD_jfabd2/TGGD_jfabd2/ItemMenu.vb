Imports TGGD_jfabd2.Game
Module ItemMenu
    Sub Run(item As Item)
        Dim done = False
        While Not done
            ShowMenuTitle(item.GetName())
            ShowInfo(item.GetDescription())
            ShowMenuItem("1) Drop")
            'TODO: eat item
            ShowMenuItem("0) Never mind")
            ShowPrompt()
            Select Case Console.ReadLine()
                Case "0"
                    done = True
                Case "1"
                    item.Drop()
                    ShowInfo($"You drop the {item.GetName()}.")
                    done = True
            End Select
        End While
    End Sub
End Module
