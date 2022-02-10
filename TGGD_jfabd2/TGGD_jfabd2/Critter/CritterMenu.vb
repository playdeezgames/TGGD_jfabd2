Imports TGGD_jfabd2.Game

Module CritterMenu
    Sub run(critter As Critter)
        Dim done = False
        While Not done
            ShowMenuTitle($"{critter.Name}:")
            ShowMenuItem("0) Never mind")
            Select Case Console.ReadLine
                Case "0"
                    done = True
                Case Else
                    InvalidInput()
            End Select
        End While
    End Sub
End Module
