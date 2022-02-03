﻿Public Module PlayerData
    Sub Initialize()
        CharacterData.Initialize()
        Using command = connection.CreateCommand()
            command.CommandText =
                "CREATE TABLE IF NOT EXISTS [Players]
                (
                    [PlayerId] INT NOT NULL,
                    [CharacterId] INT NOT NULL,
                    CHECK([PlayerId]=1),
                    FOREIGN KEY ([CharacterId]) REFERENCES [Characters]([CharacterId])
                );"
            command.ExecuteNonQuery()
        End Using
    End Sub
    Sub Clear()
        Initialize()
        CharacterData.Clear()
        Using command = connection.CreateCommand()
            command.CommandText = "DELETE FROM [Players];"
            command.ExecuteNonQuery()
        End Using
    End Sub
    Sub Reset()
        Clear()
    End Sub
    Sub SetCharacterId(characterId As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText =
                $"REPLACE INTO [Players]
                (
                    [PlayerId],
                    [CharacterId]
                ) 
                VALUES
                (
                    @PlayerId,
                    @CharacterId
                );"
            command.Parameters.AddWithValue("@PlayerId", 1)
            command.Parameters.AddWithValue("@CharacterId", characterId)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Function GetCharacterId() As Integer
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [CharacterId] FROM [Players] WHERE [PlayerId]=@PlayerId;"
            command.Parameters.AddWithValue("@PlayerId", 1)
            Return command.ExecuteScalar()
        End Using
    End Function
End Module