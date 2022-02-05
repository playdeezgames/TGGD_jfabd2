Imports TGGD_jfabd2.Data
Public Class Item
    Private ReadOnly itemId As Integer
    Sub New(itemId As Integer)
        Me.itemId = itemId
    End Sub
    Function GetItemType() As ItemType
        Return ItemData.ReadItemType(itemId)
    End Function
    Function GetName() As String
        Select Case GetItemType()
            Case ItemType.Fruit
                Return FruitTypes.GetFruitTypeName(FruitData.ReadFruitType(itemId))
            Case Else
                Throw New NotImplementedException()
        End Select
    End Function
End Class

