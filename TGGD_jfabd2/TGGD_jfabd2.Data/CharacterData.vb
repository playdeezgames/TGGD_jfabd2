Public Module CharacterData
    Sub Initialize()
        Using command = connection.CreateCommand()
            command.CommandText =
                "CREATE TABLE IF NOT EXISTS [Characters]
                (
                    [CharacterId] INTEGER PRIMARY KEY AUTOINCREMENT,
                    [X] INT NOT NULL,
                    [Y] INT NOT NULL
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
    Function Create(x As Integer, y As Integer) As Integer
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText =
                "INSERT INTO [Characters]
                (
                    [X],
                    [Y]
                ) 
                VALUES
                (
                    @X,
                    @Y
                );"
            command.Parameters.AddWithValue("@X", x)
            command.Parameters.AddWithValue("@Y", y)
            command.ExecuteNonQuery()
        End Using
        Using command = connection.CreateCommand()
            command.CommandText = "select last_insert_rowid()"
            Return command.ExecuteScalar()
        End Using
    End Function
End Module
