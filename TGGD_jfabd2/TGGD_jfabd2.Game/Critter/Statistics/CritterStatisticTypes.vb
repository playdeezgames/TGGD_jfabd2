Public Module CritterStatisticTypes
    Function GetName(statisticType As CritterStatisticType) As String
        Select Case statisticType
            Case CritterStatisticType.Health
                Return "Health"
            Case CritterStatisticType.Satiety
                Return "Satiety"
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(statisticType))
        End Select
    End Function
    Function InitialValue(critter As Critter, statisticType As CritterStatisticType) As Integer
        Select Case statisticType
            Case CritterStatisticType.Health
                Return 100
            Case CritterStatisticType.Satiety
                Return 50
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(statisticType))
        End Select
    End Function
    Function MinimumValue(critter As Critter, statisticType As CritterStatisticType) As Integer
        Select Case statisticType
            Case CritterStatisticType.Health
                Return 0
            Case CritterStatisticType.Satiety
                Return 0
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(statisticType))
        End Select
    End Function
    Function MaximumValue(critter As Critter, statisticType As CritterStatisticType) As Integer
        Select Case statisticType
            Case CritterStatisticType.Health
                Return 100
            Case CritterStatisticType.Satiety
                Return 100
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(statisticType))
        End Select
    End Function
    Function ClampValue(critter As Critter, statisticType As CritterStatisticType, value As Integer) As Integer
        If value < MinimumValue(critter, statisticType) Then
            Return MinimumValue(critter, statisticType)
        ElseIf value > MaximumValue(critter, statisticType) Then
            Return MaximumValue(critter, statisticType)
        Else
            Return value
        End If
    End Function
End Module
