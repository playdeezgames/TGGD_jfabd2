Public Module CorpseData
    Sub Initialize()
        ItemData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [CorpseItems]
            (
                [ItemId] INT NOT NULL UNIQUE,
                [CritterType] INT NOT NULL,
                FOREIGN KEY ([ItemId]) REFERENCES [Items]([ItemId])
            );")
    End Sub
    Sub Write(itemId As Integer, critterType As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "REPLACE INTO [CorpseItems]([ItemId],[CritterType]) VALUES(@ItemId,@CritterType);"
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.Parameters.AddWithValue("@CritterType", critterType)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Function ReadForItem(itemId As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand
            command.CommandText = "SELECT [CritterType] FROM [CorpseItems] WHERE [ItemId]=@ItemId;"
            command.Parameters.AddWithValue("@ItemId", itemId)
            Dim result = command.ExecuteScalar()
            If result IsNot Nothing Then
                Return CInt(result)
            End If
            Return Nothing
        End Using
    End Function
    Sub Destroy(itemId As Integer)
        Initialize()
        Using command = connection.CreateCommand
            command.CommandText = "DELETE FROM [CorpseItems] WHERE [ItemId]=@ItemId;"
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
