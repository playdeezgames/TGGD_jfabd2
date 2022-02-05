Module Confirm
    Function Run(prompt As String) As Boolean
        Dim done = False
        While Not done
            ShowMenuTitle(prompt)
            ShowMenuItem("1) Yes")
            ShowMenuItem("0) No")
            ShowPrompt()
            Select Case Console.ReadLine()
                Case "1"
                    Return True
                Case "0"
                    Return False
                Case Else
                    InvalidInput()
            End Select
        End While
        Return False 'will not get here
    End Function
End Module
