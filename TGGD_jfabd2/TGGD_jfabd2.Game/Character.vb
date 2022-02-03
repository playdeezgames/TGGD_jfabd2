Imports TGGD_jfabd2.Data

Module Character
    Sub Reset()
        CharacterData.Reset()
        PlayerData.Reset()
        Dim characterId = CharacterData.Create(0, 0, 0)
        PlayerData.SetCharacterId(characterId)
    End Sub
End Module
