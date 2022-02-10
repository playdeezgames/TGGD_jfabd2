Imports TGGD_jfabd2.Data
Public Class Location
    Private locationId As Integer
    Function GetLocationId() As Integer
        Return locationId
    End Function
    Private Shared Function SpawnTree(locationId As Integer) As Boolean
        If random.Next(10) < 1 Then
            'spawn tree
            Dim fruitType = FruitTypes.GenerateFruitType()
            TreeData.Create(
                locationId,
                FruitTypes.GenerateFruitType(),
                FruitTypes.GenerateAvailable(fruitType),
                FruitTypes.GenerateDepletion(fruitType),
                FruitTypes.GenerateRegenerationCounter(fruitType),
                FruitTypes.GenerateRegenerationThreshold(fruitType))
            Return True
        End If
        Return False
    End Function
    Private Shared Function SpawnVendor(locationId As Integer) As Boolean
        If random.Next(10) < 1 Then
            'spawn vendor
            VendorData.Create(locationId)
            'pick some fruits to sell
            Dim fruits = random.Next(0, 5)
            While fruits > 0
                Dim fruitType = FruitTypes.GenerateFruitType()
                FruitPriceData.Write(locationId, fruitType, FruitTypes.GeneratePrice(fruitType))
                fruits -= 1
            End While
            Return True
        End If
        Return False
    End Function
    Private Shared Function SpawnCritter(locationId) As Boolean
        If random.Next(5) < 1 Then
            Dim critterId = CritterData.Create(locationId, CritterTypes.GenerateCritterType())
            'TODO: other stuff like health and whatnot?
            Return True
        End If
        Return False
    End Function
    Private Sub FromXY(x As Integer, y As Integer)
        Dim id = LocationData.FindXY(x, y)
        If id.HasValue Then
            locationId = id.Value
        Else
            locationId = LocationData.CreateXY(x, y)
            'spawn stuff
            Dim spawnedCritter =
                SpawnCritter(locationId)
            Dim spawnedSomething =
                SpawnTree(locationId) OrElse
                SpawnVendor(locationId)
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
    Public Function GetVendor() As Vendor
        If VendorData.HasVendor(locationId) Then
            Return New Vendor(locationId)
        End If
        Return Nothing
    End Function
    Public Function GetInventory() As GroundInventory
        Return New GroundInventory(locationId)
    End Function
    Public Function HasCritters() As Boolean
        Return GetCritters().Any() 'TODO: directly the ask the question of the data store
    End Function
    Public Function GetCritters() As List(Of Critter)
        Return CritterData.
            ReadForLocation(locationId).
            Select(Function(critterId)
                       Return New Critter(critterId)
                   End Function).
                   ToList()
    End Function
End Class
