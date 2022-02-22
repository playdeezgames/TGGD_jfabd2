Imports TGGD_jfabd2.Game
Imports Terminal.Gui
Module CharacterStatistics
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog("Statistics", cancelButton)
        Dim character As New PlayerCharacter
        Dim row As Integer = 1
        Dim stats = [Enum].GetValues(GetType(CharacterStatisticType))
        For Each stat In stats
            dlg.Add(New Label(1, row, $"{CharacterStatisticsTypes.GetName(CType(stat, CharacterStatisticType))}: {character.GetStatistic(CType(stat, CharacterStatisticType))}"))
            row += 1
        Next
        Application.Run(dlg)
    End Sub
End Module
