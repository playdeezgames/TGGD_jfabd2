Public Module CritterStatisticData
    Sub Initialize()
        CritterData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [CritterStatistics]
            (
                [CritterId] INT NOT NULL,
                [StatisticType] INT NOT NULL,
                [Value] INT NOT NULL,
                UNIQUE([CritterId], [StatisticType]),
                FOREIGN KEY ([CritterId]) REFERENCES [Critters]([CritterId])
            );")
    End Sub
    Function Read(critterId As Integer, statisticType As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [Value] FROM [CritterStatistics] WHERE [CritterId]=@CritterId AND [StatisticType]=@StatisticType;"
            command.Parameters.AddWithValue("@CritterId", critterId)
            command.Parameters.AddWithValue("@StatisticType", statisticType)
            Dim result = command.ExecuteScalar()
            If result IsNot Nothing Then
                Return CInt(result)
            End If
            Return Nothing
        End Using
    End Function
    Sub Write(critterId As Integer, statisticType As Integer, value As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "REPLACE INTO [CritterStatistics]([CritterId],[StatisticType],[Value]) VALUES(@CritterId,@StatisticType,@Value);"
            command.Parameters.AddWithValue("@CritterId", critterId)
            command.Parameters.AddWithValue("@StatisticType", statisticType)
            command.Parameters.AddWithValue("@Value", value)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Sub Clear(critterId As Integer)
        Initialize()
        Using command = connection.CreateCommand
            command.CommandText = "DELETE FROM [CritterStatistics] WHERE [CritterId]=@CritterId"
            command.Parameters.AddWithValue("@CritterId", critterId)
            command.ExecuteNonQuery()
        End Using
    End Sub

End Module
