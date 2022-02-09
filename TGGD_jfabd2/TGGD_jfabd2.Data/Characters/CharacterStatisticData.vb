Public Module CharacterStatisticData
    Sub Initialize()
        CharacterData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [CharacterStatistics]
            (
                [CharacterId] INT NOT NULL,
                [StatisticType] INT NOT NULL,
                [Value] INT NOT NULL,
                UNIQUE([CharacterId], [StatisticType]),
                FOREIGN KEY ([CharacterId]) REFERENCES [Characters]([CharacterId])
            );")
    End Sub
    Function Read(characterId As Integer, statisticType As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [Value] FROM [CharacterStatistics] WHERE [CharacterId]=@CharacterId AND [StatisticType]=@StatisticType;"
            command.Parameters.AddWithValue("@CharacterId", characterId)
            command.Parameters.AddWithValue("@StatisticType", statisticType)
            Return command.ExecuteScalar()
        End Using
    End Function
    Sub Write(characterId As Integer, statisticType As Integer, value As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "REPLACE INTO [CharacterStatistics]([CharacterId],[StatisticType],[Value]) VALUES(@CharacterId,@StatisticType,@Value);"
            command.Parameters.AddWithValue("@CharacterId", characterId)
            command.Parameters.AddWithValue("@StatisticType", statisticType)
            command.Parameters.AddWithValue("@Value", value)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
