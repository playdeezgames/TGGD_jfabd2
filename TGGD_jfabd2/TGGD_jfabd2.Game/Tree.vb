Imports TGGD_jfabd2.Data

Public Class Tree
    Private locationId As Integer
    Public Sub New(locationId As Integer)
        Me.locationId = locationId
    End Sub
    Public Shared Sub Update()
        If TreeData.Grow() Then
            Dim regenerating = TreeData.ReadRegenerating()
            For Each locationId As Integer In regenerating
                Dim available = TreeData.GetAvailable(locationId)
                Dim depletion = TreeData.GetDepletion(locationId)
                If random.Next(available + depletion) < depletion Then
                    TreeData.SetAvailable(locationId, available + 1)
                    TreeData.SetDepletion(locationId, depletion + 1)
                End If
                TreeData.SetRegenerationCounter(locationId, 0)
            Next
        End If
    End Sub
End Class
