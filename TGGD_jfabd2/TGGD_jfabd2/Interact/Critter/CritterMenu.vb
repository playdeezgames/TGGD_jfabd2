Imports TGGD_jfabd2.Game

Module CritterMenu
    Sub Run(critter As Critter)
        Dim done = False
        Dim character As New PlayerCharacter
        While Not done
            Dim hasFruit = character.GetInventory().HasItemType(ItemType.Fruit)
            ShowMenuTitle($"{critter.Name}:")
            If hasFruit Then
                ShowMenuItem("1) Feed...")
            End If
            ShowMenuItem("2) Capture!")
            ShowMenuItem("0) Never mind")
            Select Case Console.ReadLine
                Case "0"
                    done = True
                Case "1"
                    If hasFruit Then
                        CritterFeedMenu.Run(critter)
                    Else
                        InvalidInput()
                    End If
                Case "2"
                    done = CritterCapture.Run(critter)
                Case Else
                    InvalidInput()
            End Select
        End While
    End Sub
End Module
