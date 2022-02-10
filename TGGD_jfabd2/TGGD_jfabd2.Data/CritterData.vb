Public Module CritterData
    Sub Initialize()
        LocationData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [Critters]
            (
                [CritterId] INTEGER PRIMARY KEY AUTOINCREMENT,
                [CritterType] INT NOT NULL,
                [LocationId] INT NOT NULL,
                FOREIGN KEY ([LocationId]) REFERENCES [Locations]([LocationId])
            );")
    End Sub
    Function Create(locationId As Integer, critterType As Integer) As UInt64
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "INSERT INTO [Critters]([CritterType],[LocationId]) VALUES(@CritterType,@LocationId);"
            command.Parameters.AddWithValue("@LocationId", locationId)
            command.Parameters.AddWithValue("@CritterType", critterType)
            command.ExecuteNonQuery()
            Return GetLastInsertRowId()
        End Using
    End Function
    Function ReadForLocation(locationId As Integer) As List(Of UInt64)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [CritterId] FROM [Critters] WHERE [LocationId]=@LocationId;"
            command.Parameters.AddWithValue("@LocationId", locationId)
            Using reader = command.ExecuteReader
                Dim result As New List(Of UInt64)
                While reader.Read()
                    result.Add(reader("CritterId"))
                End While
                Return result
            End Using
        End Using
    End Function
    Function ReadCritterType(critterId As UInt64) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [CritterType] FROM [Critters] WHERE [CritterId]=@CritterId"
            command.Parameters.AddWithValue("@CritterId", critterId)
            Return command.ExecuteScalar
        End Using
    End Function
End Module
