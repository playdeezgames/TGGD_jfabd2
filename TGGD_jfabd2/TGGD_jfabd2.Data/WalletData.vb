Public Module WalletData
    Sub Initialize()
        ItemData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [WalletItems]
            (
                [ItemId] INT NOT NULL UNIQUE,
                [WalletSize] INT NOT NULL,
                FOREIGN KEY ([ItemId]) REFERENCES [Items]([ItemId])
            );")
    End Sub
    Sub Write(itemId As Integer, walletSize As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "REPLACE INTO [WalletItems]([ItemId],[WalletSize]) VALUES(@ItemId, @WalletSize);"
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.Parameters.AddWithValue("@WalletSize", walletSize)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Sub Destroy(itemId As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "DELETE FROM [WalletItems] WHERE [ItemId]=@ItemId;"
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
