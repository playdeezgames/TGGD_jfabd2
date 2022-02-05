Public Module GroundData
    Sub Initialize()
        LocationData.Initialize()
        ItemData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [GroundItems]
            (
                [ItemId] INT NOT NULL UNIQUE,
                [LocationId] INT NOT NULL,
                FOREIGN KEY ([ItemId]) REFERENCES [Items]([ItemId]),
                FOREIGN KEY ([LocationId]) REFERENCES [Locations]([LocationId])
            );")
    End Sub
    Sub Write(locationId As Integer, itemId As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "REPLACE INTO [GroundItems]([LocationId],[ItemId]) VALUES(@LocationId,@ItemId);"
            command.Parameters.AddWithValue("@LocationId", locationId)
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
