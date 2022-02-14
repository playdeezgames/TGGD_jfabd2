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
            Dim result = command.ExecuteScalar()
            If result IsNot Nothing Then
                Return CInt(result)
            End If
            Return Nothing
        End Using
    End Function
    Function ReadAll() As List(Of Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [CritterId] FROM [Critters];"
            Using reader = command.ExecuteReader
                Dim result As New List(Of Integer)
                While reader.Read()
                    result.Add(CInt(reader("CritterId")))
                End While
                Return result
            End Using
        End Using
    End Function
    Sub Destroy(critterId As Integer)
        Initialize()
        CritterCharacteristicData.Clear(critterId)
        CritterStatisticData.Clear(critterId)
        CritterLocationData.Clear(CULng(critterId))
        Using command = connection.CreateCommand
            command.CommandText = "DELETE FROM [Critters] WHERE [CritterId]=@CritterId"
            command.Parameters.AddWithValue("@CritterId", critterId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
