Public Module CharacterStatisticsTypes
    Function GetName(statisticType As CharacterStatisticType) As String
        Select Case statisticType
            Case CharacterStatisticType.Health
                Return "Health"
            Case CharacterStatisticType.Satiety
                Return "Satiety"
            Case CharacterStatisticType.Jools
                Return "Jools"
            Case CharacterStatisticType.CarryingCapacity
                Return "Carrying Capacity"
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(statisticType))
        End Select
    End Function
    Function InitialValue(character As Character, statisticType As CharacterStatisticType) As Integer
        Select Case statisticType
            Case CharacterStatisticType.Health
                Return MaximumValue(character, statisticType)
            Case CharacterStatisticType.Satiety
                Return MaximumValue(character, statisticType) / 2
            Case CharacterStatisticType.CarryingCapacity
                Return 2
            Case CharacterStatisticType.Jools
                Return 0
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(statisticType))
        End Select
    End Function
    Function MinimumValue(character As Character, statisticType As CharacterStatisticType) As Integer
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
    Function MaximumValue(character As Character, statisticType As CharacterStatisticType) As Integer
        Select Case statisticType
            Case CharacterStatisticType.Health
                Return (character.GetCharacteristic(Characteristic.Size) + character.GetCharacteristic(Characteristic.Constitution)) / 2
            Case CharacterStatisticType.Satiety
                Return character.GetCharacteristic(Characteristic.Constitution)
            Case CharacterStatisticType.CarryingCapacity
                Return Integer.MaxValue
            Case CharacterStatisticType.Jools
                Return Integer.MaxValue
            Case Else
                Throw New ArgumentOutOfRangeException(NameOf(statisticType))
        End Select
    End Function
    Function ClampValue(character As Character, statisticType As CharacterStatisticType, value As Integer) As Integer
        If value < MinimumValue(character, statisticType) Then
            Return MinimumValue(character, statisticType)
        ElseIf value > MaximumValue(character, statisticType) Then
            Return MaximumValue(character, statisticType)
        Else
            Return value
        End If
    End Function
End Module
