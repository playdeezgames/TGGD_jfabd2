Imports System.Data.SQLite
Public Module Store
    Friend connection As SQLiteConnection
    Public Sub Reset()
        connection = New SQLiteConnection("Data Source=:memory:;Version=3;New=True;")
        connection.Open()
    End Sub
    Public Sub CleanUp()
        If connection IsNot Nothing Then
            connection.Close()
            connection = Nothing
        End If
    End Sub
    Public Sub Save(filename As String)
        Using destination = New SQLiteConnection($"Data Source={filename}.db;Version=3;New=True;")
            destination.Open()
            connection.BackupDatabase(destination, "main", "main", -1, Nothing, 0)
            destination.Close()
        End Using
    End Sub
    Public Sub ExecuteNonQuery(sql As String)
        Using command = connection.CreateCommand()
            command.CommandText = sql
            command.ExecuteNonQuery()
        End Using
    End Sub
    Function GetLastInsertRowId()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT last_insert_rowid();"
            Return command.ExecuteScalar()
        End Using
    End Function
End Module
