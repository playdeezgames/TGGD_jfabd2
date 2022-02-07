Public Module CharacterEquipmentData
    Sub Initialize()
        CharacterData.Initialize()
        ItemData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [CharacterEquippedItems]
            (
                [CharacterId] INT NOT NULL,
                [EquipSlot] INT NOT NULL,
                [ItemId] INT NOT NULL,
                UNIQUE([CharacterId],[EquipSlot]),
                UNIQUE([ItemId]),
                FOREIGN KEY ([CharacterId]) REFERENCES [Characters]([CharacterId]),
                FOREIGN KEY ([ItemId]) REFERENCES [Items]([ItemId])
            );")
    End Sub
    Sub Write(characterId As Integer, equipSlot As Integer, itemId As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "REPLACE INTO [CharacterEquippedItems]([CharacterId],[EquipSlot],[ItemId]) VALUES(@CharacterId,@EquipSlot,@ItemId);"
            command.Parameters.AddWithValue("@CharacterId", characterId)
            command.Parameters.AddWithValue("@EquipSlot", equipSlot)
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Sub Clear(itemId As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "DELETE FROM [CharacterEquippedItems] WHERE [ItemId]=@ItemId;"
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
