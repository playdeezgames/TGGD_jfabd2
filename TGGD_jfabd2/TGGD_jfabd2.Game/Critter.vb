Imports TGGD_jfabd2.Data

Public Class Critter
    Private ReadOnly critterId As UInt64
    Sub New(critterId As UInt64)
        Me.critterId = critterId
    End Sub
    ReadOnly Property Name() As String
        Get
            Return CritterTypes.GetName(CritterData.ReadCritterType(critterId))
        End Get
    End Property
End Class
