Imports Terminal.Gui
Imports TGGD_jfabd2.Game

Module VendorMenu
    Sub Run()
        Dim cancelButton As New Button("Never mind")
        AddHandler cancelButton.Clicked, AddressOf Application.RequestStop
        Dim vendor = New PlayerCharacter().GetLocation().GetVendor()
        Dim fruitsButton As New Button("Fruits...")
        fruitsButton.Enabled = vendor.HasFruits
        AddHandler fruitsButton.Clicked, Sub()
                                             VendorFruitListMenu.Run(vendor)
                                         End Sub
        Dim dlg As New Dialog("Vendor:", cancelButton, fruitsButton)
        Application.Run(dlg)
    End Sub
End Module
