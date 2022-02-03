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
End Module
