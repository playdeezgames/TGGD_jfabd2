Imports Terminal.Gui
Imports TGGD_jfabd2.Game

Module CritterItemMenu
    Private Function OldRun(item As Item) As Boolean
        Dim critter = item.GetCritter()
        If critter IsNot Nothing Then
            Dim done = False
            While Not done
                ShowMenuTitle(critter.Name)
                Dim stats = [Enum].GetValues(GetType(Characteristic))
                For Each stat In stats
                    ShowInfo($"{Characteristics.GetAbbreviation(CType(stat, Characteristic))} {critter.GetCharacteristic(CType(stat, Characteristic))}")
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
    Function Run(item As Item) As Boolean
        Dim critter = item.GetCritter()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim statisticsButton As New Button("Statistics...")
        AddHandler statisticsButton.Clicked, Sub()
                                                 CritterStatistics.Run(critter)
                                             End Sub
        Dim feedButton As New Button("Feed")
        feedButton.Enabled = item.CanFeed()
        AddHandler feedButton.Clicked, Sub()
                                           If item.CanFeed() Then
                                               FeedItemMenu.Run(item)
                                           End If
                                           feedButton.Enabled = item.CanFeed()
                                       End Sub
        Dim dlg As New Dialog(critter.Name, cancelButton, statisticsButton, feedButton)
        Dim stats = [Enum].GetValues(GetType(Characteristic))
        Dim row As Integer = 1
        For Each stat In stats
            dlg.Add(New Label(1, row, $"{Characteristics.GetAbbreviation(CType(stat, Characteristic))} {critter.GetCharacteristic(CType(stat, Characteristic))}"))
            row += 1
        Next
        Application.Run(dlg)
        Return False
    End Function
End Module
