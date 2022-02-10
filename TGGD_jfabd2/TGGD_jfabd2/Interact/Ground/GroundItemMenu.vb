Imports TGGD_jfabd2.Game

Module GroundItemMenu
    Sub Run(item As Item, characterId As Integer)
        Dim done = False
        While Not done
            ShowMenuTitle(item.GetName())
            ShowInfo(item.GetDescription())
            ShowMenuItem("1) Pick up")
            ShowMenuItem("0) Never mind")
            ShowPrompt()
            Select Case Console.ReadLine()
                Case "0"
                    done = True
                Case "1"
                    item.PickUp(characterId)
                    ShowInfo($"You pick up the {item.GetName()}.")
                    done = True
            End Select
        End While
    End Sub

End Module
