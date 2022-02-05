Public Module InventoryData
    Sub Initialize()
        CharacterData.Initialize()
        ItemData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [CharacterItems]
            (
                [ItemId] INT NOT NULL UNIQUE,
                [CharacterId] INT NOT NULL,
                FOREIGN KEY ([ItemId]) REFERENCES [Items]([ItemId]),
                FOREIGN KEY ([CharacterId]) REFERENCES [Characters]([CharacterId])
            );")
    End Sub
    Sub Write(characterId As Integer, itemId As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "REPLACE INTO [CharacterItems]([CharacterId],[ItemId]) VALUES(@CharacterId, @ItemId);"
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.Parameters.AddWithValue("@CharacterId", characterId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
