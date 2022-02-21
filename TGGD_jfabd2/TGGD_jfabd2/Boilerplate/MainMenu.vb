Imports Terminal.Gui

Module MainMenu
    Private Sub OldRun()
        Dim done As Boolean = False
        While Not done
            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.Magenta
            Console.WriteLine("A Game in VB about Fruits")
            Console.ForegroundColor = ConsoleColor.DarkMagenta
            Console.WriteLine("A production of TheGrumpyGameDev")
            ShowMenuTitle("Main Menu:")
            ShowMenuItem("1) Start")
            ShowMenuItem("2) Continue")
            ShowMenuItem("0) Quit")
            ShowPrompt()
            Select Case Console.ReadLine()
                Case "0"
                    done = Confirm.Run("Are you sure you want to quit?")
                Case "1"
                    Start.Run()
                Case "2"
                    LoadGame.Run()
                Case Else
                    InvalidInput()
            End Select
        End While
    End Sub
    Private Sub ConfirmQuit()
        If MessageBox.Query("Are you sure?", "Are you sure you want to quit?", "No", "Yes") = 1 Then
            Application.RequestStop()
        End If
    End Sub
    Sub Run()
        Dim startButton As New Button("Start")
        AddHandler startButton.Clicked, AddressOf Start.Run
        Dim continueButton As New Button("Continue...")
        AddHandler continueButton.Clicked, AddressOf LoadGame.Run
        Dim quitButton As New Button("Quit")
        AddHandler quitButton.Clicked, AddressOf ConfirmQuit
        Dim dlg As New Dialog("Main Menu", startButton, continueButton, quitButton)
        AddHandler dlg.KeyPress, Sub(args)
                                     If args.KeyEvent.Key = Key.Esc Then
                                         args.Handled = True
                                     End If
                                 End Sub
        'TODO: figure out the widths and positions
        dlg.Add(New Label(38, 10, "A Game in VB about Fruits"))
        dlg.Add(New Label(34, 12, "A production of TheGrumpyGameDev"))
        Application.Run(dlg)
    End Sub
End Module
