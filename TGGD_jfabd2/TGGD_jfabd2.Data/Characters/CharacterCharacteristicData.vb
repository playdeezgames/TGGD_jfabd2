Public Module CharacterCharacteristicData
    Sub Initialize()
        CharacterData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [CharacterCharacteristics]
            (
                [CharacterId] INT NOT NULL,
                [Characteristic] INT NOT NULL,
                [Value] INT NOT NULL,
                UNIQUE([CharacterId],[Characteristic]),
                FOREIGN KEY ([CharacterId]) REFERENCES [Characters]([CharacterId])
            );")
    End Sub
    Function Read(characterId As Integer, characteristic As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [Value] FROM [CharacterCharacteristics] WHERE [CharacterId]=@CharacterId AND [Characteristic]=@Characteristic;"
            command.Parameters.AddWithValue("@CharacterId", characterId)
            command.Parameters.AddWithValue("@Characteristic", characteristic)
            Return command.ExecuteScalar()
        End Using
    End Function
    Sub Write(characterId As Integer, characteristic As Integer, value As Integer)
        Initialize()
        Using command = connection.CreateCommand
            command.CommandText = "REPLACE INTO [CharacterCharacteristics]([CharacterId],[Characteristic],[Value]) VALUES(@CharacterId, @Characteristic, @Value);"
            command.Parameters.AddWithValue("@CharacterId", characterId)
            command.Parameters.AddWithValue("@Characteristic", characteristic)
            command.Parameters.AddWithValue("@Value", value)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
