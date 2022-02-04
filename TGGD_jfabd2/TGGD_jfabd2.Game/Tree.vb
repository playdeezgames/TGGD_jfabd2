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
                'TODO: check for regeneration chance: rand(avail + dep) < dep
                TreeData.SetAvailable(locationId, TreeData.GetAvailable(locationId))
                TreeData.SetDepletion(locationId, TreeData.GetDepletion(locationId))
                TreeData.SetRegenerationCounter(locationId, 0)
            Next
        End If
    End Sub
End Class
