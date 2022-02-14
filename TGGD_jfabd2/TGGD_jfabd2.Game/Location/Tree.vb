Imports TGGD_jfabd2.Data

Public Class Tree
    Private ReadOnly locationId As Integer
    Public Sub New(locationId As Integer)
        Me.locationId = locationId
    End Sub
    Public Function GetFruitType() As Integer
        Return TreeData.ReadFruitType(locationId).Value
    End Function
    Public Shared Sub Update()
        If TreeData.Grow() Then
            Dim regenerating = TreeData.ReadRegenerating()
            For Each locationId As Integer In regenerating
                Dim available = TreeData.ReadAvailable(locationId).Value
                Dim depletion = TreeData.ReadDepletion(locationId).Value
                If random.Next(available + depletion) < depletion Then
                    TreeData.WriteAvailable(locationId, available + 1)
                    TreeData.WriteDepletion(locationId, depletion - 1)
                End If
                TreeData.WriteRegenerationCounter(locationId, 0)
            Next
        End If
    End Sub
    Public Function PickFruit() As Fruit
        Dim available = TreeData.ReadAvailable(locationId).Value
        Dim depletion = TreeData.ReadDepletion(locationId).Value
        If random.Next(available + depletion) < available Then
            TreeData.WriteAvailable(locationId, available - 1)
            TreeData.WriteDepletion(locationId, depletion + 1)
            Return New Fruit(TreeData.ReadFruitType(locationId).Value)
        End If
        Return Nothing
    End Function
End Class
