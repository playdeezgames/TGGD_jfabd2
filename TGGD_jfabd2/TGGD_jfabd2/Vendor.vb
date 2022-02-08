Module Vendor
    Sub Run()
        Dim done = False
        While Not done
            ShowMenuTitle("Vendor:")
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
