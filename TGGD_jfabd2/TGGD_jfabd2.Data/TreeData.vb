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
    Public Function Grow() As Boolean
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText =
                "UPDATE [Trees] 
                SET 
                    [RegenerationCounter]=[RegenerationCounter]+1 
                WHERE 
                    [Depletion]>0;"
            Return command.ExecuteNonQuery() > 0
        End Using
    End Function
    Public Function ReadRegenerating() As List(Of Integer)
        Dim result As List(Of Integer) = New List(Of Integer)
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [LocationId] FROM [Trees] WHERE [RegenerationCounter]>=[RegenerationThreshold];"
            Using reader = command.ExecuteReader()
                While reader.Read()
                    result.Add(reader.GetInt32(0))
                End While
            End Using
        End Using
        Return result
    End Function
    Public Sub SetRegenerationCounter(locationId As Integer, regenerationCounter As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "UPDATE [Trees] SET [RegenerationCounter]=@RegenerationCounter WHERE [LocationId]=@LocationId;"
            command.Parameters.AddWithValue("@LocationId", locationId)
            command.Parameters.AddWithValue("@RegenerationCounter", regenerationCounter)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Public Function GetAvailable(locationId As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [Available] FROM [Trees] WHERE [LocationId]=@LocationId;"
            command.Parameters.AddWithValue("@LocationId", locationId)
            Return command.ExecuteScalar()
        End Using
    End Function
    Public Function GetDepletion(locationId As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [Depletion] FROM [Trees] WHERE [LocationId]=@LocationId;"
            command.Parameters.AddWithValue("@LocationId", locationId)
            Return command.ExecuteScalar()
        End Using
    End Function
    Public Sub SetAvailable(locationId As Integer, available As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "UPDATE [Trees] SET [Available]=@Available WHERE [LocationId]=@LocationId;"
            command.Parameters.AddWithValue("@LocationId", locationId)
            command.Parameters.AddWithValue("@Available", available)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Public Sub SetDepletion(locationId As Integer, depletion As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "UPDATE [Trees] SET [Depletion]=@Depletion WHERE [LocationId]=@LocationId;"
            command.Parameters.AddWithValue("@LocationId", locationId)
            command.Parameters.AddWithValue("@Depletion", depletion)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module

