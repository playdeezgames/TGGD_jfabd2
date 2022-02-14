Module CritterTypes
    Function GenerateCritterType() As Integer
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
    Private ReadOnly critterDescriptions As New Dictionary(Of Integer, String) From
        {
            {1, "It looks a bit sus."},
            {2, "It isn't blue."},
            {3, "It seems a bit neurotic."},
            {4, "It is wearing a red shirt with an 'A' on it."},
            {5, "It is looking for mushrooms."},
            {6, "What's up, Doc?"},
            {7, "It looks like it is about to go pop."},
            {8, "It is not saying anything."},
            {9, "Looks alive enough to you."},
            {10, "It reeks, but in a good way."}
        }
    Function GetName(critterType As Integer) As String
        Return critterNames(critterType)
    End Function
    Function GetDescription(critterType As Integer) As String
        Return critterDescriptions(critterType)
    End Function
End Module
