Imports TGGD_jfabd2.Data
Public Class Item
    Private itemId As Integer
    Sub New(itemId As Integer)
        Me.itemId = itemId
    End Sub
    Function GetItemType() As ItemType
        Return ItemData.ReadItemType(itemId)
    End Function
End Class

