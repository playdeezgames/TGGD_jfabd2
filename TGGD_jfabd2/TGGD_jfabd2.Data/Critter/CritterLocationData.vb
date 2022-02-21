Public Module CritterLocationData
    Sub Initialize()
        CritterData.Initialize()
        LocationData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [CritterLocations]
            (
                [CritterId] INT NOT NULL UNIQUE,
                [LocationId] INT NOT NULL,
                FOREIGN KEY ([CritterId]) REFERENCES [Critters]([CritterId]),
                FOREIGN KEY ([LocationId]) REFERENCES [Locations]([LocationId])
            );")
    End Sub
    Sub Write(critterId As Long, locationId As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "REPLACE INTO [CritterLocations]([CritterId],[LocationId]) VALUES(@CritterId,@LocationId);"
            command.Parameters.AddWithValue("@CritterId", critterId)
            command.Parameters.AddWithValue("@LocationId", locationId)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Function ReadForLocation(locationId As Integer) As List(Of Long)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [CritterId] FROM [CritterLocations] WHERE [LocationId]=@LocationId;"
            command.Parameters.AddWithValue("@LocationId", locationId)
            Using reader = command.ExecuteReader
                Dim result As New List(Of Long)
                While reader.Read()
                    result.Add(CLng(reader("CritterId")))
                End While
                Return result
            End Using
        End Using
    End Function
    Function ReadForCritter(critterId As Long) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [LocationId] FROM [CritterLocations] WHERE [CritterId]=@CritterId;"
            command.Parameters.AddWithValue("@CritterId", critterId)
            Dim result = command.ExecuteScalar
            If result IsNot Nothing Then
                Return CInt(result)
            End If
            Return Nothing
        End Using
    End Function
    Sub Clear(critterId As Long)
        Initialize()
        Using command = connection.CreateCommand
            command.CommandText = "DELETE FROM [CritterLocations] WHERE [CritterId]=@CritterId"
            command.Parameters.AddWithValue("@CritterId", critterId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
