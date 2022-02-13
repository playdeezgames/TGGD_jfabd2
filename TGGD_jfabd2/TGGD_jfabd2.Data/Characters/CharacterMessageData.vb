Public Module CharacterMessageData
    Sub Initialize()
        CharacterData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [CharacterMessages]
            (
                [CharacterId],
                [Mood],
                [Text],
                FOREIGN KEY([CharacterId]) REFERENCES [Characters]([CharacterId])
            );")
    End Sub
    Sub Write(characterId As Integer, mood As Integer, text As String)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "INSERT INTO [CharacterMessages]([CharacterId],[Mood],[Text]) VALUES(@CharacterId, @Mood, @Text);"
            command.Parameters.AddWithValue("@CharacterId", characterId)
            command.Parameters.AddWithValue("@Mood", mood)
            command.Parameters.AddWithValue("@Text", text)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Function Read(characterId As Integer) As List(Of Tuple(Of Integer, String))
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [Mood],[Text] FROM [CharacterMessages] WHERE [CharacterId]=@CharacterId;"
            command.Parameters.AddWithValue("@CharacterId", characterId)
            Dim result As New List(Of Tuple(Of Integer, String))
            Using reader = command.ExecuteReader()
                While reader.Read()
                    result.Add(New Tuple(Of Integer, String)(CInt(reader("Mood")), CStr(reader("Text"))))
                End While
            End Using
            Return result
        End Using
    End Function
    Sub Clear(characterId As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "DELETE FROM [CharacterMessages] WHERE [CharacterId]=@CharacterId;"
            command.Parameters.AddWithValue("@CharacterId", characterId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
