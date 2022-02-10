Imports TGGD_jfabd2.Game

Module CritterFeedMenu
    Sub Run(critter As Critter)
        Dim done = False
        Dim character As New PlayerCharacter
        While Not done
            ShowMenuTitle($"Feed the {critter.Name}:")
            Dim index As Integer = 1
            Dim fruits = character.GetInventory().GetItems(ItemType.Fruit)
            For Each fruit In fruits
                ShowMenuItem($"{index}) {fruit.GetName()}")
                index += 1
            Next
            ShowMenuItem("0) Never mind")
            Dim input = Console.ReadLine
            Select Case input
                Case "0"
                    done = True
                Case Else
                    InvalidInput()
            End Select
        End While
    End Sub
End Module
