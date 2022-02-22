Imports Terminal.Gui
Imports TGGD_jfabd2.Game

Module CritterListMenu
    Private Sub OldRun()
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
            ShowPrompt()
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
    Private Function GetCritters() As IList
        Dim character = New PlayerCharacter()
        Dim location = character.GetLocation()
        Return location.GetCritters()
    End Function
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Critter...", cancelButton)
        Dim listView As New ListView(New Rect(1, 1, 40, 20), GetCritters())
        AddHandler listView.OpenSelectedItem, Sub(args)
                                                  CritterMenu.Run(CType(args.Value, Critter))
                                                  Dim critters = GetCritters()
                                                  If critters.Count() > 0 Then
                                                      listView.SetSource(critters)
                                                  Else
                                                      Application.RequestStop()
                                                  End If
                                              End Sub
        dlg.Add(listView)
        Application.Run(dlg)
    End Sub
End Module
