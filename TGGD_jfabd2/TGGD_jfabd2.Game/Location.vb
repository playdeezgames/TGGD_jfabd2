Imports TGGD_jfabd2.Data
Public Class Location
    Private locationId As Integer 'TODO: this can be made readonly!
    Function GetLocationId() As Integer
        Return locationId
    End Function
    Private Sub FromXY(x As Integer, y As Integer)
        Dim id = LocationData.FindXY(x, y)
        If id.HasValue Then
            locationId = id.Value
        Else
            locationId = LocationData.CreateXY(x, y)
            'spawn stuff
            If random.Next(10) < 2 Then
                'spawn tree
                TreeData.Create(locationId, random.Next(1, 11), random.Next(25, 101), random.Next(0, 51), 0, random.Next(20, 101))
            End If
        End If
    End Sub
    Public Sub New(x As Integer, y As Integer)
        FromXY(x, y)
    End Sub
    Public Sub New(character As Character)
        FromXY(character.GetX(), character.GetY())
    End Sub
    Public Shared Sub Reset()
        LocationData.Clear()
    End Sub
    Public Function GetTree() As Tree
        If TreeData.ReadFruitType(locationId).HasValue Then
            Return New Tree(locationId)
        End If
        Return Nothing
    End Function
End Class
