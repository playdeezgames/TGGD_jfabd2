Imports TGGD_jfabd2.Data

Public Class Character
    Private ReadOnly characterId As Integer
    Public Function GetCharacterId() As Integer
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
        CharacterData.WriteXY(characterId, CharacterData.ReadX(characterId).Value + deltaX, CharacterData.ReadY(characterId).Value + deltaY)
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
        Return GetStatistic(CharacterStatisticType.Health) > CharacterStatisticsTypes.MinimumValue(Me, CharacterStatisticType.Health)
    End Function
    Public Function GetStatistic(statisticType As CharacterStatisticType) As Integer
        Dim value = CharacterStatisticData.Read(characterId, statisticType)
        If value.HasValue Then
            Return value.Value
        Else
            Return CharacterStatisticsTypes.InitialValue(Me, statisticType)
        End If
    End Function
    Public Sub SetStatistic(statisticType As CharacterStatisticType, value As Integer)
        value = CharacterStatisticsTypes.ClampValue(Me, statisticType, value)
        CharacterStatisticData.Write(characterId, statisticType, value)
    End Sub
    Public Sub ChangeStatistic(statisticType As CharacterStatisticType, delta As Integer)
        SetStatistic(statisticType, GetStatistic(statisticType) + delta)
    End Sub
    Private Sub Metabolize()
        If GetStatistic(CharacterStatisticType.Satiety) > CharacterStatisticsTypes.MinimumValue(Me, CharacterStatisticType.Satiety) Then
            ChangeStatistic(CharacterStatisticType.Satiety, -1)
        Else
            ChangeStatistic(CharacterStatisticType.Health, -1)
            AddMessage(Mood.Failure, "Yer starvin'!")
        End If
    End Sub
    Private Sub UpKeepWallet()
        Dim jools = GetStatistic(CharacterStatisticType.Jools)
        Dim walletSize = GetEquipment().Sum(Function(entry)
                                                Return entry.Value.GetWalletSize()
                                            End Function)
        If jools > walletSize Then
            ChangeStatistic(CharacterStatisticType.Jools, walletSize - jools)
        End If
    End Sub
    Public Sub Update()
        Metabolize()
        UpKeepWallet()
    End Sub
    Public Sub AddMessage(mood As Mood, text As String)
        Select Case mood
            Case Mood.Failure
                Console.ForegroundColor = ConsoleColor.Red

            Case Mood.Success
                Console.ForegroundColor = ConsoleColor.Green
            Case Else
                Console.ForegroundColor = ConsoleColor.Gray
        End Select
        Console.WriteLine(text)
    End Sub
    Public Function GetEquipment() As Dictionary(Of EquipSlot, Item)
        Dim equipment = CharacterEquipmentData.ReadForCharacter(characterId)
        Dim result As New Dictionary(Of EquipSlot, Item)
        For Each entry In equipment
            result(CType(entry.Item1, EquipSlot)) = New Item(entry.Item2)
        Next
        Return result
    End Function
    Public Function GetCharacteristic(characteristic As Characteristic) As Integer
        Dim value = CharacterCharacteristicData.Read(characterId, characteristic)
        If Not value.HasValue Then
            value = Characteristics.GenerateForCharacter(characteristic)
            CharacterCharacteristicData.Write(characterId, characteristic, value.Value)
        End If
        Return value.Value
    End Function
    Function Check(characteristic As Characteristic, Optional delta As Integer = 0) As Double
        Return DifficultyCheck(characteristic, 1, delta)
    End Function
    Function DifficultyCheck(characteristic As Characteristic, difficulty As Integer, Optional delta As Integer = 0) As Double
        Return CharacteristicCheck(GetCharacteristic(characteristic) \ difficulty + delta)
    End Function
End Class
