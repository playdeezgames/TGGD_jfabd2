Imports System.Data.SQLite
Public Module Store
    Private connection As SQLiteConnection
    Sub Reset()
        connection = New SQLiteConnection("Data Source=:memory:;Version=3;New=True;")
    End Sub
End Module
