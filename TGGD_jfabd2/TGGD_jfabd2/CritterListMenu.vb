Imports TGGD_jfabd2.Game

Module CritterListMenu
    Sub Run()
        Dim done = False
        Dim character = New PlayerCharacter()
        Dim location = character.GetLocation()
        While Not done
            ShowMenuTitle("Critter:")
            Dim critters = location.GetCritters()
            Dim index = 1
            For Each critter In critters
                ShowMenuItem($"{index}) {critter.Name}")
                index += 1
            Next
            ShowMenuItem("0) Never mind")
            Dim input = Console.ReadLine()
            Select Case input
                Case "0"
                    done = True
                Case Else
                    If Integer.TryParse(input, index) Then
                        index -= 1
                        If index < critters.Count Then
                            CritterMenu.Run(critters(index))
                        Else
                            InvalidInput()
                        End If
                    Else
                        InvalidInput()
                    End If
            End Select
        End While
    End Sub
End Module
