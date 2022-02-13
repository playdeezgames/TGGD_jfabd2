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
    Function ReadForLocation(locationId As Integer) As List(Of Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [ItemId] FROM [GroundItems] WHERE [LocationId]=@LocationId;"
            command.Parameters.AddWithValue("@LocationId", locationId)
            Dim result As New List(Of Integer)
            Using reader = command.ExecuteReader()
                While reader.Read()
                    result.Add(CInt(reader("ItemId")))
                End While
            End Using
            Return result
        End Using
    End Function
    Function ReadForItem(itemId As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [LocationId] FROM [GroundItems] WHERE [ItemId]=@ItemId;"
            command.Parameters.AddWithValue("@ItemId", itemId)
            Dim result = command.ExecuteScalar()
            If result IsNot Nothing Then
                Return CInt(result)
            End If
            Return Nothing
        End Using
    End Function
    Sub Clear(itemId As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "DELETE FROM [GroundItems] WHERE [ItemId]=@ItemId;"
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
