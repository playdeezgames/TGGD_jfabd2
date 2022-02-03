Public Module CharacterData
    Sub Initialize()
        Using command = connection.CreateCommand()
            command.CommandText =
                "CREATE TABLE IF NOT EXISTS [Characters]
                (
                    [CharacterId] INTEGER PRIMARY KEY AUTOINCREMENT,
                    [X] INT NOT NULL,
                    [Y] INT NOT NULL,
                    [Direction] INT NOT NULL,
                    CHECK([Direction]>=0 AND [Direction]<=3)
                );"
            command.ExecuteNonQuery()
        End Using
    End Sub
    Sub Clear()
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "DELETE FROM [Characters];"
            command.ExecuteNonQuery()
        End Using
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
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT last_insert_rowid();"
            Return command.ExecuteScalar()
        End Using
    End Function
    Function ReadX(characterId As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [X] FROM [Characters] WHERE [CharacterId]=@CharacterId"
            command.Parameters.AddWithValue("@CharacterId", characterId)
            Dim reader = command.ExecuteReader()
            If reader.HasRows() Then
                reader.NextResult()
                Return reader.GetInt32("X")
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
                reader.NextResult()
                Return reader.GetInt32("Y")
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
                reader.NextResult()
                Return reader.GetInt32("Direction")
            End If
        End Using
        Return Nothing
    End Function
End Module
