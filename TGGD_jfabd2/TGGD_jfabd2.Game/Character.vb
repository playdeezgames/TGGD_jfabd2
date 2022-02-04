Imports TGGD_jfabd2.Data

Public Class Character
    Private characterId As Integer
    Public Sub New(characterId As Integer)
        Me.characterId = characterId
    End Sub
    Public Function GetX() As Integer
        Return CharacterData.ReadX(characterId).Value
    End Function
    Public Function GetY() As Integer
        Return CharacterData.ReadY(characterId).Value
    End Function
    Public Function GetDirection() As Integer
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
End Class
