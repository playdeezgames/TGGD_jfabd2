Imports TGGD_jfabd2.Data
Public Module Game
    Friend random As Random = New Random()
    Public Sub Reset()
        Store.Reset()
        Location.Reset()
        PlayerCharacter.Reset()
    End Sub
End Module
