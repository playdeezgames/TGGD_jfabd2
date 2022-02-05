Public Class CharacterInventory
    Private characterId As Integer
    Sub New(characterId As Integer)
        Me.characterId = characterId
    End Sub
    Function IsFull() As Boolean
        Return False
    End Function
    Function IsEmpty() As Boolean
        Return True
    End Function
    Sub Add(fuit As Fruit)
        'TODO: stuff
    End Sub
End Class
