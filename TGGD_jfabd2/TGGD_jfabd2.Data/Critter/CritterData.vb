Public Module CritterData
    Sub Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [Critters]
            (
                [CritterId] INTEGER PRIMARY KEY AUTOINCREMENT,
                [CritterType] INT NOT NULL,
                [Tameness] INT NOT NULL
            );")
    End Sub
    Function Create(critterType As Integer, tameness As Integer) As UInt64
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "INSERT INTO [Critters]([CritterType],[Tameness]) VALUES(@CritterType,@Tameness);"
            command.Parameters.AddWithValue("@CritterType", critterType)
            command.Parameters.AddWithValue("@Tameness", tameness)
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
    Function ReadTameness(critterId As UInt64) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [Tameness] FROM [Critters] WHERE [CritterId]=@CritterId"
            command.Parameters.AddWithValue("@CritterId", critterId)
            Return command.ExecuteScalar
        End Using
    End Function
    Sub WriteTameness(critterId As UInt64, tameness As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "UPDATE [Critters] SET [Tameness]=@Tameness WHERE [CritterId]=@CritterId;"
            command.Parameters.AddWithValue("@Tameness", tameness)
            command.Parameters.AddWithValue("@CritterId", critterId)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Function ReadAll() As List(Of Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [CritterId] FROM [Critters];"
            Using reader = command.ExecuteReader
                Dim result As New List(Of Integer)
                While reader.Read()
                    result.Add(reader("CritterId"))
                End While
                Return result
            End Using
        End Using
    End Function
    Sub Destroy(critterId As Integer)
        Initialize()
        CritterCharacteristicData.Clear(critterId)
        CritterStatisticData.Clear(critterId)
        CritterLocationData.Clear(critterId)
        Using command = connection.CreateCommand
            command.CommandText = "DELETE FROM [Critters] WHERE [CritterId]=@CritterId"
            command.Parameters.Add("@CritterId", critterId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
