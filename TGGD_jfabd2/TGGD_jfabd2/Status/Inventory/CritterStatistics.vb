Imports Terminal.Gui
Imports TGGD_jfabd2.Game

Module CritterStatistics
    Sub Run(critter As Critter)
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim dlg As New Dialog($"{critter.Name} statistics:", cancelButton)
        Dim stats = [Enum].GetValues(GetType(CritterStatisticType))
        Dim row As Integer = 1
        For Each stat In stats
            dlg.Add(New Label(1, row, $"{CritterStatisticTypes.GetName(CType(stat, CritterStatisticType))}: {critter.GetStatistic(CType(stat, CritterStatisticType))}"))
            row += 1
        Next
        Application.Run(dlg)
    End Sub
End Module
