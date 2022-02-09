Public Module CharacterStatisticsTypes
    Function InitialValue(statisticType As CharacterStatisticType) As Integer
        Select Case statisticType
            Case CharacterStatisticType.Health
                Return 100
            Case CharacterStatisticType.Satiety
                Return 50
            Case CharacterStatisticType.CarryingCapacity
                Return 2
            Case CharacterStatisticType.Jools
                Return 0
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(statisticType))
        End Select
    End Function
    Function MinimumValue(statisticType As CharacterStatisticType) As Integer
        Select Case statisticType
            Case CharacterStatisticType.Health
                Return 0
            Case CharacterStatisticType.Satiety
                Return 0
            Case CharacterStatisticType.CarryingCapacity
                Return 2
            Case CharacterStatisticType.Jools
                Return 0
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(statisticType))
        End Select
    End Function
    Function MaximumValue(statisticType As CharacterStatisticType) As Integer
        Select Case statisticType
            Case CharacterStatisticType.Health
                Return 100
            Case CharacterStatisticType.Satiety
                Return 100
            Case CharacterStatisticType.CarryingCapacity
                Return Integer.MaxValue
            Case CharacterStatisticType.Jools
                Return Integer.MaxValue
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(statisticType))
        End Select
    End Function
    Function ClampValue(statisticType As CharacterStatisticType, value As Integer) As Integer
        If value < MinimumValue(statisticType) Then
            Return MinimumValue(statisticType)
        ElseIf value > MaximumValue(statisticType) Then
            Return MaximumValue(statisticType)
        Else
            Return value
        End If
    End Function
End Module
