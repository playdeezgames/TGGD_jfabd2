Public Module FruitPriceData
    Sub Initialize()
        LocationData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [FruitPrices]
            (
                [LocationId] INT NOT NULL,
                [FruitType] INT NOT NULL,
                [Price] INT NOT NULL,
                UNIQUE([LocationId],[FruitType]),
                FOREIGN KEY ([LocationId]) REFERENCES [Locations]([LocationId])
            );")
    End Sub
    Sub Write(locationId As Integer, fruitType As Integer, price As Integer)
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "REPLACE INTO [FruitPrices]([LocationId],[FruitType],[Price]) VALUES(@LocationId,@FruitType,@Price);"
            command.Parameters.AddWithValue("@LocationId", locationId)
            command.Parameters.AddWithValue("@FruitType", fruitType)
            command.Parameters.AddWithValue("@Price", price)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Function ReadCountForLocation(locationId As Integer) As Integer
        Initialize()
        Using command = connection.CreateCommand()
            command.CommandText = "SELECT COUNT(1) FROM [FruitPrices] WHERE [LocationId]=@LocationId;"
            command.Parameters.AddWithValue("@LocationId", locationId)
            Return CInt(command.ExecuteScalar)
        End Using
    End Function
    Function ReadForLocation(locationId As Integer) As List(Of Tuple(Of Integer, Integer))
        Initialize()
        Using command = connection.CreateCommand
            command.CommandText = "SELECT [FruitType],[Price] FROM [FruitPrices] WHERE [LocationId]=@LocationId;"
            command.Parameters.AddWithValue("@LocationId", locationId)
            Dim result As New List(Of Tuple(Of Integer, Integer))
            Using reader = command.ExecuteReader
                While reader.Read()
                    result.Add(New Tuple(Of Integer, Integer)(CInt(reader("FruitType")), CInt(reader("Price"))))
                End While
            End Using
            Return result
        End Using
    End Function
    Function ReadForFruitType(locationId As Integer, fruitType As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand
            command.CommandText = "SELECT [Price] FROM [FruitPrices] WHERE [LocationId]=@LocationId AND [FruitType]=@FruitType;"
            command.Parameters.AddWithValue("@LocationId", locationId)
            command.Parameters.AddWithValue("@FruitType", fruitType)
            Dim result = command.ExecuteScalar()
            If result IsNot Nothing Then
                Return CInt(result)
            End If
            Return Nothing
        End Using
    End Function
End Module
