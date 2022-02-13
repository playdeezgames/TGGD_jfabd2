Public Module CharacterData
    Sub Initialize()
        ExecuteNonQuery("CREATE TABLE IF NOT EXISTS [Characters]
                (
                    [CharacterId] INTEGER PRIMARY KEY AUTOINCREMENT,
                    [X] INT NOT NULL,
                    [Y] INT NOT NULL,
                    [Direction] INT NOT NULL,
                    CHECK([Direction]>=0 AND [Direction]<=3)
                );")
    End Sub
    Sub Clear()
        Initialize()
        ExecuteNonQuery("DELETE FROM [Characters];")
    End Sub
    Public Sub Reset()
        Initialize()
        Clear()
    End Sub
    Function Create(x As Integer, y As Integer, direction As Integer) As Integer
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText =
                "INSERT INTO [Characters]
                (
                    [X],
                    [Y],
                    [Direction]
                ) 
                VALUES
                (
                    @X,
                    @Y,
                    @Direction
                );"
            command.Parameters.AddWithValue("@X", x)
            command.Parameters.AddWithValue("@Y", y)
            command.Parameters.AddWithValue("@Direction", direction)
            command.ExecuteNonQuery()
        End Using
        Return GetLastInsertRowId()
    End Function
    Function ReadX(characterId As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [X] FROM [Characters] WHERE [CharacterId]=@CharacterId"
            command.Parameters.AddWithValue("@CharacterId", characterId)
            Dim reader = command.ExecuteReader()
            If reader.HasRows() Then
                reader.Read()
                Return reader.GetInt32(0)
            End If
        End Using
        Return Nothing
    End Function
    Function ReadY(characterId As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [Y] FROM [Characters] WHERE [CharacterId]=@CharacterId"
            command.Parameters.AddWithValue("@CharacterId", characterId)
            Dim reader = command.ExecuteReader()
            If reader.HasRows() Then
                reader.Read()
                Return reader.GetInt32(0)
            End If
        End Using
        Return Nothing
    End Function
    Function ReadDirection(characterId As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [Direction] FROM [Characters] WHERE [CharacterId]=@CharacterId"
            command.Parameters.AddWithValue("@CharacterId", characterId)
            Dim reader = command.ExecuteReader()
            If reader.HasRows() Then
                reader.Read()
                Return reader.GetInt32(0)
            End If
        End Using
        Return Nothing
    End Function
    Sub WriteDirection(characterId As Integer, direction As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "UPDATE [Characters] SET [Direction]=@Direction WHERE [CharacterId]=@CharacterId;"
            command.Parameters.AddWithValue("@CharacterId", characterId)
            command.Parameters.AddWithValue("@Direction", direction)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Sub WriteXY(characterId As Integer, x As Integer, y As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "UPDATE [Characters] SET [X]=@X, [Y]=@Y WHERE [CharacterId]=@CharacterId;"
            command.Parameters.AddWithValue("@CharacterId", characterId)
            command.Parameters.AddWithValue("@X", x)
            command.Parameters.AddWithValue("@Y", y)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Function ReadAll() As List(Of Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [CharacterId] FROM [Characters];"
            Using reader = command.ExecuteReader
                Dim result As New List(Of Integer)
                While reader.Read()
                    result.Add(reader("CharacterId"))
                End While
                Return result
            End Using
        End Using
    End Function
End Module
