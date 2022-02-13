Imports TGGD_jfabd2.Game

Module CritterStatistics
    Sub Run(critter As Critter)
        Dim stats = [Enum].GetValues(GetType(CritterStatisticType))
        ShowMenuTitle($"{critter.Name} statistics:")
        For Each stat In stats
            ShowInfo($"{CharacterStatisticsTypes.GetName(stat)}: {critter.GetStatistic(stat)}")
        Next
    End Sub
End Module
