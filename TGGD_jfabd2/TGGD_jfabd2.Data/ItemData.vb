Public Module ItemData
    Sub Initialize()
        Store.ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [Items]
            (
                [ItemId] INTEGER PRIMARY KEY AUTOINCREMENT,
                [ItemType] INT NOT NULL
            );")
    End Sub
    Function Create(itemType As Integer) As Integer
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "INSERT INTO [Items]([ItemType]) VALUES(@ItemType);"
            command.Parameters.AddWithValue("@ItemType", itemType)
            command.ExecuteNonQuery()
        End Using
        Return GetLastInsertRowId()
    End Function
    Function ReadItemType(itemId As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [ItemType] FROM [Items] WHERE [ItemId]=@ItemId;"
            command.Parameters.AddWithValue("@ItemId", itemId)
            Return command.ExecuteScalar()
        End Using
    End Function
End Module
