Imports System.Data.SQLite
Public Module Store
    Friend connection As SQLiteConnection
    Public Sub Reset()
        If connection IsNot Nothing Then
            connection.Close()
            connection = Nothing
        End If
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
    Public Sub Load(filename As String)
        Using source = New SQLiteConnection($"Data Source={filename}.db;Version=3;New=True;")
            source.Open()
            Reset()
            source.BackupDatabase(connection, "main", "main", -1, Nothing, 0)
            source.Close()
        End Using
    End Sub
    Public Sub ExecuteNonQuery(sql As String)
        Using command = connection.CreateCommand()
            command.CommandText = sql
            command.ExecuteNonQuery()
        End Using
    End Sub
    ReadOnly Property LastInsertRowId() As Long
        Get
            Using command = connection.CreateCommand()
                command.CommandText = "SELECT last_insert_rowid();"
                Return CLng(command.ExecuteScalar())
            End Using
        End Get
    End Property
    Function CreateCommand(query As String, ParamArray parameters() As SQLiteParameter) As SQLiteCommand
        Dim command = connection.CreateCommand()
        command.CommandText = query
        For Each parameter In parameters
            command.Parameters.Add(parameter)
        Next
        Return command
    End Function
    Function MakeParameter(name As String, value As Object) As SQLiteParameter
        Return New SQLiteParameter(name, value)
    End Function
End Module
