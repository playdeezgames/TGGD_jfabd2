Imports TGGD_jfabd2.Data

Public Class Character
    Shared Sub Reset()
        CharacterData.Reset()
        PlayerData.Reset()
        Dim characterId = CharacterData.Create(0, 0, 0)
        PlayerData.SetCharacterId(characterId)
    End Sub
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
End Class
