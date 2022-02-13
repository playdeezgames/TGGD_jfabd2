Public Module VendorData
    Sub Initialize()
        LocationData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [Vendors]
            (
                [LocationId] INT NOT NULL UNIQUE,
                FOREIGN KEY ([LocationId]) REFERENCES [Locations]([LocationId])
            );")
    End Sub
    Sub Create(locationId As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "REPLACE INTO [Vendors]([LocationId]) VALUES(@LocationId);"
            command.Parameters.AddWithValue("@LocationId", locationId)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Sub Clear()
        Initialize()
        ExecuteNonQuery("DELETE FROM [Vendors]")
    End Sub
    Function HasVendor(locationId As Integer) As Boolean
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT COUNT(1) FROM [Vendors] WHERE [LocationId]=@LocationId;"
            command.Parameters.AddWithValue("@LocationId", locationId)
            Return CBool(command.ExecuteScalar())
        End Using
    End Function
End Module
