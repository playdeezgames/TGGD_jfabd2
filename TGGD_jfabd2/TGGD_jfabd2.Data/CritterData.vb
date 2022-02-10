Public Module CritterData
    Sub Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [Critters]
            (
                [CritterId] INTEGER PRIMARY KEY AUTOINCREMENT,
                [CritterType] INT NOT NULL
            );")
    End Sub
    Function Create(critterType As Integer) As UInt64
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "INSERT INTO [Critters]([CritterType]) VALUES(@CritterType);"
            command.Parameters.AddWithValue("@CritterType", critterType)
            command.ExecuteNonQuery()
            Return GetLastInsertRowId()
        End Using
    End Function
    Function ReadCritterType(critterId As UInt64) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [CritterType] FROM [Critters] WHERE [CritterId]=@CritterId"
            command.Parameters.AddWithValue("@CritterId", critterId)
            Return command.ExecuteScalar
        End Using
    End Function
End Module
