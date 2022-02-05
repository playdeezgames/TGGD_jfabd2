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
End Module
