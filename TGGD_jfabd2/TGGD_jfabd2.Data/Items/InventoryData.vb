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
    Function ReadForCharacter(characterId As Integer) As List(Of Integer)
        Initialize()
        Dim result As New List(Of Integer)
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [ItemId] FROM [CharacterItems] WHERE [CharacterId]=@CharacterId;"
            command.Parameters.AddWithValue("@CharacterId", characterId)
            Using reader = command.ExecuteReader()
                While reader.Read()
                    result.Add(reader.GetInt32(0))
                End While
            End Using
        End Using
        Return result
    End Function
    Function ReadForItem(itemId As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [CharacterId] FROM [CharacterItems] WHERE [ItemId]=@ItemId;"
            command.Parameters.AddWithValue("@ItemId", itemId)
            Return command.ExecuteScalar()
        End Using
    End Function
    Sub Clear(itemId As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "DELETE FROM [CharacterItems] WHERE [ItemId]=@ItemId"
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
