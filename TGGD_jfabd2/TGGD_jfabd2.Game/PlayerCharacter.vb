Imports TGGD_jfabd2.Data

Public Class PlayerCharacter
    Inherits Character
    Public Sub New()
        MyBase.New(PlayerData.GetCharacterId())
    End Sub

End Class
