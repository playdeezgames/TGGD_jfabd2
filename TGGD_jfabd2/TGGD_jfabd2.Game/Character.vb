﻿Imports TGGD_jfabd2.Data

Public Class Character
    Private ReadOnly characterId As Integer
    Public Function GetCharacterId()
        Return characterId
    End Function
    Public Sub New(characterId As Integer)
        Me.characterId = characterId
    End Sub
    Public Function GetLocation() As Location
        Return New Location(Me)
    End Function
    Public Function GetX() As Integer
        Return CharacterData.ReadX(characterId).Value
    End Function
    Public Function GetY() As Integer
        Return CharacterData.ReadY(characterId).Value
    End Function
    Private Function GetDirection() As Integer
        Return CharacterData.ReadDirection(characterId).Value
    End Function
    Public Sub TurnLeft()
        CharacterData.WriteDirection(characterId, (GetDirection() + 3) Mod 4)
    End Sub
    Public Sub TurnRight()
        CharacterData.WriteDirection(characterId, (GetDirection() + 1) Mod 4)
    End Sub
    Public Sub TurnAround()
        CharacterData.WriteDirection(characterId, (GetDirection() + 2) Mod 4)
    End Sub
    Public Sub MoveAhead()
        Dim deltaX As Integer = 0
        Dim deltaY As Integer = 0
        Select Case GetDirection()
            Case 0
                deltaY = -1
            Case 1
                deltaX = 1
            Case 2
                deltaY = 1
            Case Else 'assume all other directions are west, i suppose
                deltaX = -1
        End Select
        CharacterData.WriteXY(characterId, CharacterData.ReadX(characterId) + deltaX, CharacterData.ReadY(characterId) + deltaY)
        Metabolize()
        Game.Update()
    End Sub
    Public Sub MoveLeft()
        TurnLeft()
        MoveAhead()
        TurnRight()
    End Sub
    Public Sub MoveRight()
        TurnRight()
        MoveAhead()
        TurnLeft()
    End Sub
    Public Sub MoveBack()
        TurnAround()
        MoveAhead()
        TurnAround()
    End Sub
    Public Function GetInventory() As CharacterInventory
        Return New CharacterInventory(characterId)
    End Function
    Public Function IsAlive() As Boolean
        Return GetStatistic(StatisticType.Health) > StatisticsTypes.MinimumValue(StatisticType.Health)
    End Function
    Public Function GetStatistic(statisticType As StatisticType) As Integer
        Dim value = CharacterStatisticData.Read(characterId, statisticType)
        If value.HasValue Then
            Return value.Value
        Else
            Return StatisticsTypes.InitialValue(statisticType)
        End If
    End Function
    Public Sub SetStatistic(statisticType As StatisticType, value As Integer)
        value = StatisticsTypes.ClampValue(statisticType, value)
        CharacterStatisticData.Write(characterId, statisticType, value)
    End Sub
    Public Sub ChangeStatistic(statisticType As StatisticType, delta As Integer)
        SetStatistic(statisticType, GetStatistic(statisticType) + delta)
    End Sub
    Public Sub Metabolize()
        If GetStatistic(StatisticType.Satiety) > StatisticsTypes.MinimumValue(StatisticType.Satiety) Then
            ChangeStatistic(StatisticType.Satiety, -1)
        Else
            ChangeStatistic(StatisticType.Health, -1)
            AddMessage(New CharacterMessage(Mood.Failure, "Yer starvin'!"))
        End If
    End Sub
    Public Sub AddMessage(message As CharacterMessage)
        CharacterMessageData.Write(characterId, message.GetMood(), message.GetText())
    End Sub
    Public Function GetMessages() As List(Of CharacterMessage)
        Return CharacterMessageData.Read(characterId).Select(
            Function(x As Tuple(Of Integer, String))
                Return New CharacterMessage(x.Item1, x.Item2)
            End Function).ToList()
    End Function
    Public Sub ClearMessages()
        CharacterMessageData.Clear(characterId)
    End Sub
End Class
