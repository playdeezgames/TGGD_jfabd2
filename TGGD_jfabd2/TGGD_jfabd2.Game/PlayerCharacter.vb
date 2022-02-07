Imports TGGD_jfabd2.Data
Public Class PlayerCharacter
    Inherits Character
    Shared Sub Reset()
        CharacterData.Reset()
        PlayerData.Reset()
        Dim characterId = CharacterData.Create(random.Next(100), random.Next(100), random.Next(4))
        PlayerData.SetCharacterId(characterId)
        Dim itemId = ItemData.Create(ItemType.Wallet)
        WalletData.Write(itemId, 50)
        CharacterEquipmentData.Write(characterId, EquipSlot.Wallet, itemId)
    End Sub
    Public Sub New()
        MyBase.New(PlayerData.GetCharacterId())
    End Sub
End Class
