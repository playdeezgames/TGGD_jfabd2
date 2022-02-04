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
        End Using
    End Sub
End Module
