Public Module TreeData
    Sub Initialize()
        LocationData.Initialize()
        ExecuteNonQuery("CREATE TABLE IF NOT EXISTS [Trees]
                (
                    [LocationId] INT NOT NULL UNIQUE,
                    [FruitType] INT NOT NULL,
                    [Available] INT NOT NULL,
                    [Depletion] INT NOT NULL,
                    [RegenerationCounter] INT NOT NULL,
                    [RegenerationThreshold] INT NOT NULL
                );")
    End Sub
    Public Sub Clear()
        Initialize()
        ExecuteNonQuery("DELETE FROM [Trees];")
    End Sub
    Public Sub Create(locationId As Integer, fruitType As Integer, available As Integer, depletion As Integer, regenerationCounter As Integer, regenerationThreshold As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText =
                "REPLACE INTO [Trees]
                (
                    [LocationId],
                    [FruitType],
                    [Available],
                    [Depletion],
                    [RegenerationCounter],
                    [RegenerationThreshold]
                ) 
                VALUES
                (
                    @LocationId,
                    @FruitType,
                    @Available,
                    @Depletion,
                    @RegenerationCounter,
                    @RegenerationThreshold
                );"
            command.Parameters.AddWithValue("@LocationId", locationId)
            command.Parameters.AddWithValue("@FruitType", fruitType)
            command.Parameters.AddWithValue("@Available", available)
            command.Parameters.AddWithValue("@Depletion", depletion)
            command.Parameters.AddWithValue("@RegenerationCounter", regenerationCounter)
            command.Parameters.AddWithValue("@RegenerationThreshold", regenerationThreshold)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Public Function ReadFruitType(locationId As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [FruitType] FROM [Trees] WHERE [LocationId]=@LocationId;"
            command.Parameters.AddWithValue("@LocationId", locationId)
            Return command.ExecuteScalar()
        End Using
    End Function
End Module
