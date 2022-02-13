Public Module LocationData
    Sub Initialize()
        Using command = connection.CreateCommand()
            command.CommandText =
                "CREATE TABLE IF NOT EXISTS [Locations]
                (
                    [LocationId] INTEGER PRIMARY KEY AUTOINCREMENT,
                    [X] INT NOT NULL,
                    [Y] INT NOT NULL,
                    UNIQUE([X],[Y])
                );"
            command.ExecuteNonQuery()
        End Using
    End Sub
    Public Sub Clear()
        Initialize()
        VendorData.Clear()
        TreeData.Clear()
        Using command = connection.CreateCommand()
            command.CommandText = "DELETE FROM [Locations];"
            command.ExecuteNonQuery()
        End Using
    End Sub
    Public Function FindXY(x As Integer, y As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT [LocationId] FROM [Locations] WHERE [X]=@X AND [Y]=@Y;"
            command.Parameters.AddWithValue("@X", x)
            command.Parameters.AddWithValue("@Y", y)
            Dim result = command.ExecuteScalar()
            If result IsNot Nothing Then
                Return CInt(result)
            End If
            Return Nothing
        End Using
        Return Nothing
    End Function
    Public Function CreateXY(x As Integer, y As Integer) As UInt64
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "INSERT INTO [Locations] ([X],[Y]) VALUES(@X,@Y);"
            command.Parameters.AddWithValue("@X", x)
            command.Parameters.AddWithValue("@Y", y)
            command.ExecuteNonQuery()
        End Using
        Return GetLastInsertRowId()
    End Function
End Module
