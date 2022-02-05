Public Class Fruit
    Private fruitType As Integer
    Sub New(fruitType As Integer)
        Me.fruitType = fruitType
    End Sub
    Function GetFruitType() As Integer
        Return fruitType
    End Function
    Function GetName() As String
        Return FruitTypes.GetName(GetFruitType())
    End Function
End Class
