Public Module CritterStatisticTypes
    Function InitialValue(statisticType As CritterStatisticType) As Integer
        Select Case statisticType
            Case CritterStatisticType.Health
                Return 100
            Case CritterStatisticType.Satiety
                Return 50
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(statisticType))
        End Select
    End Function
    Function MinimumValue(statisticType As CritterStatisticType) As Integer
        Select Case statisticType
            Case CritterStatisticType.Health
                Return 0
            Case CritterStatisticType.Satiety
                Return 0
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(statisticType))
        End Select
    End Function
    Function MaximumValue(statisticType As CritterStatisticType) As Integer
        Select Case statisticType
            Case CritterStatisticType.Health
                Return 100
            Case CritterStatisticType.Satiety
                Return 100
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(statisticType))
        End Select
    End Function
    Function ClampValue(statisticType As CritterStatisticType, value As Integer) As Integer
        If value < MinimumValue(statisticType) Then
            Return MinimumValue(statisticType)
        ElseIf value > MaximumValue(statisticType) Then
            Return MaximumValue(statisticType)
        Else
            Return value
        End If
    End Function
End Module
