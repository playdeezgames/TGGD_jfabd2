Public Module PetData
    Sub Initialize()
        ItemData.Initialize()
        CritterData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [CritterItems]
            (
                [CritterId] INT NOT NULL UNIQUE,
                [ItemId] INT NOT NULL UNIQUE,
                FOREIGN KEY ([CritterId]) REFERENCES [Critters]([CritterId]),
                FOREIGN KEY ([ItemId]) REFERENCES [Items]([ItemId])
            );")
    End Sub
    Sub Write(itemId As Integer, critterId As UInt64)
        Initialize()
        Using command = connection.CreateCommand
            command.CommandText = "REPLACE INTO [CritterItems]([CritterId],[ItemId]) VALUES(@CritterId,@ItemId);"
            command.Parameters.AddWithValue("@CritterId", critterId)
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Function ReadForItem(itemId As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand
            command.CommandText = "SELECT [CritterId] FROM [CritterItems] WHERE [ItemId]=@ItemId;"
            command.Parameters.AddWithValue("@ItemId", itemId)
            Return command.ExecuteScalar
        End Using
    End Function
    Sub ClearForCritter(critterId As Integer)
        Initialize()
        Using command = connection.CreateCommand
            command.CommandText = "DELETE FROM [CritterItems] WHERE [CritterId]=@CritterId;"
            command.Parameters.AddWithValue("@CritterId", critterId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
