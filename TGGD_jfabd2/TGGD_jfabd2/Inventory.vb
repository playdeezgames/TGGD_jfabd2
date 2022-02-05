Module Inventory
    Sub Run()
        Dim done As Boolean
        While Not done
            ShowMenuTitle("Yer Inventory:")
            ShowMenuItem("0) Never mind")
            ShowPrompt()
            Select Case Console.ReadLine()
                Case "0"
                    done = True
                Case Else
                    InvalidInput()
            End Select
        End While
    End Sub
End Module
