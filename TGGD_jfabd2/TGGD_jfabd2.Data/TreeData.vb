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
End Module
