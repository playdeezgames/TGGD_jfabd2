Public Module FruitData
    Sub Initialize()
        ItemData.Initialize()
        Store.ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [FruitItems]
            (
                [ItemId] INT NOT NULL UNIQUE,
                [FruitType] INT NOT NULL,
                FOREIGN KEY ([ItemId]) REFERENCES [Items]([ItemId])
            );")
    End Sub
    Sub WriteFruitType(itemId As Integer, fruitType As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "REPLACE INTO [FruitItems]([ItemId],[FruitType]) VALUES(@ItemId,@FruitType);"
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.Parameters.AddWithValue("@FruitType", fruitType)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Function ReadFruitType(itemId As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [FruitType] FROM [FruitItems] WHERE [ItemId]=@ItemId;"
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
        Using command = connection.CreateCommand()
            command.CommandText = "DELETE FROM [FruitItems] WHERE [ItemId]=@ItemId;"
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
