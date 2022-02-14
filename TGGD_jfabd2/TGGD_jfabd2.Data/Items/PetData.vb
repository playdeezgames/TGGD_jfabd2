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
            Dim result = command.ExecuteScalar()
            If result IsNot Nothing Then
                Return CInt(result)
            End If
            Return Nothing
        End Using
    End Function
    Function ReadForCritter(critterId As ULong) As Integer?
        Initialize()
        Using command = connection.CreateCommand
            command.CommandText = "SELECT [ItemId] FROM [CritterItems] WHERE [CritterId]=@CritterId;"
            command.Parameters.AddWithValue("@CritterId", critterId)
            Dim result = command.ExecuteScalar()
            If result IsNot Nothing Then
                Return CInt(result)
            End If
            Return Nothing
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
    Sub Destroy(itemId As Integer)
        Initialize()
        Using command = connection.CreateCommand
            command.CommandText = "DELETE FROM [CritterItems] WHERE [ItemId]=@ItemId;"
            command.Parameters.AddWithValue("@ItemId", itemId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
