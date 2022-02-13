Imports TGGD_jfabd2.Game

Module CritterItemMenu
    Function Run(item As Item) As Boolean
        Dim critter = item.GetCritter()
        If critter IsNot Nothing Then
            Dim done = False
            While Not done
                ShowMenuTitle(critter.Name)
                Dim stats = [Enum].GetValues(GetType(Characteristic))
                For Each stat In stats
                    ShowInfo($"{Characteristics.GetAbbreviation(stat)} {critter.GetCharacteristic(stat)}")
                Next
                ShowMenuItem("1) Statistics")
                If item.CanFeed() Then
                    ShowMenuItem("2) Feed")
                End If
                ShowMenuItem("0) Never mind")
                ShowPrompt()
                Select Case Console.ReadLine
                    Case "0"
                        done = True
                    Case "1"
                        CritterStatistics.Run(critter)
                    Case "2"
                        If item.CanFeed() Then
                            FeedItemMenu.Run(item)
                        Else
                            InvalidInput()
                        End If
                    Case Else
                        InvalidInput()
                End Select
            End While
        End If
        Return False
    End Function
End Module
