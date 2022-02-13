Public Module CritterCharacteristicData
    Sub Initialize()
        CritterData.Initialize()
        ExecuteNonQuery(
            "CREATE TABLE IF NOT EXISTS [CritterCharacteristics]
            (
                [CritterId] INT NOT NULL,
                [Characteristic] INT NOT NULL,
                [Value] INT NOT NULL,
                UNIQUE ([CritterId],[Characteristic]),
                FOREIGN KEY ([CritterId]) REFERENCES [Critters]([CritterId])
            );")
    End Sub
    Function Read(critterId As Integer, characteristic As Integer) As Integer?
        Initialize()
        Using command = connection.CreateCommand
            command.CommandText = "SELECT [Value] From [CritterCharacteristics] WHERE [CritterId]=@CritterId AND [Characteristic]=@Characteristic;"
            command.Parameters.AddWithValue("@CritterId", critterId)
            command.Parameters.AddWithValue("@Characteristic", characteristic)
            Dim result = command.ExecuteScalar()
            If result IsNot Nothing Then
                Return CInt(result)
            End If
            Return Nothing
        End Using
    End Function
    Sub Write(critterId As Integer, characteristic As Integer, value As Integer)
        Initialize()
        Using command = connection.CreateCommand
            command.CommandText = "REPLACE INTO [CritterCharacteristics]([CritterId],[Characteristic],[Value]) VALUES(@CritterId,@Characteristic,@Value);"
            command.Parameters.AddWithValue("@CritterId", critterId)
            command.Parameters.AddWithValue("@Characteristic", characteristic)
            command.Parameters.AddWithValue("@Value", value)
            command.ExecuteNonQuery()
        End Using
    End Sub
    Sub Clear(critterId As Integer)
        Initialize()
        Using command = connection.CreateCommand
            command.CommandText = "DELETE FROM [CritterCharacteristics] WHERE [CritterId]=@CritterId"
            command.Parameters.AddWithValue("@CritterId", critterId)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module
