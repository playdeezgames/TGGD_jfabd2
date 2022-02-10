Module CritterTypes
    Function GenerateCritterType()
        Return random.Next(1, 11)
    End Function
    Private ReadOnly critterNames As New Dictionary(Of Integer, String) From
        {
            {1, "raccoon"},
            {2, "hedgehog"},
            {3, "squirrel"},
            {4, "chipmunk"},
            {5, "badger"},
            {6, "hare"},
            {7, "weasel"},
            {8, "fox"},
            {9, "possum"},
            {10, "skunk"}
        }
    Function GetName(critterType As Integer) As String
        Return critterNames(critterType)
    End Function
    Function GenerateTameness(critterType As Integer) As Integer
        Return 0
    End Function
End Module
