Imports TGGD_jfabd2.Data
Public Module Game
    Friend random As New Random()
    Public Sub Reset()
        Store.Reset()
        Location.Reset()
        PlayerCharacter.Reset()
    End Sub
    Public Sub Update()
        Tree.Update()
    End Sub
End Module
