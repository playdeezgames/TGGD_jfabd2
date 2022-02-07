Public Module StatisticsTypes
    Function InitialValue(statisticType As StatisticType) As Integer
        Select Case statisticType
            Case StatisticType.Health
                Return 100
            Case StatisticType.Satiety
                Return 50
            Case StatisticType.CarryingCapacity
                Return 2
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(statisticType))
        End Select
    End Function
    Function MinimumValue(statisticType As StatisticType) As Integer
        Select Case statisticType
            Case StatisticType.Health
                Return 0
            Case StatisticType.Satiety
                Return 0
            Case StatisticType.CarryingCapacity
                Return 2
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(statisticType))
        End Select
    End Function
    Function MaximumValue(statisticType As StatisticType) As Integer
        Select Case statisticType
            Case StatisticType.Health
                Return 100
            Case StatisticType.Satiety
                Return 100
            Case StatisticType.CarryingCapacity
                Return Integer.MaxValue
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(statisticType))
        End Select
    End Function
    Function ClampValue(statisticType As StatisticType, value As Integer) As Integer
        If value < MinimumValue(statisticType) Then
            Return MinimumValue(statisticType)
        ElseIf value > MaximumValue(statisticType) Then
            Return MaximumValue(statisticType)
        Else
            Return value
        End If
    End Function
End Module
