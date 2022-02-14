Imports TGGD_jfabd2.Game

Module CharacterStatistics
    Sub Run()
        Dim character As New PlayerCharacter
        Dim stats = [Enum].GetValues(GetType(CharacterStatisticType))
        ShowMenuTitle("Yer statistics:")
        For Each stat In stats
            ShowInfo($"{CharacterStatisticsTypes.GetName(CType(stat, CharacterStatisticType))}: {character.GetStatistic(CType(stat, CharacterStatisticType))}")
        Next
    End Sub
End Module
