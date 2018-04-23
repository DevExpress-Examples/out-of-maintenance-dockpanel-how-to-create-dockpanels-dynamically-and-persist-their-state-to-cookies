@Html.DevExpress().DockPanel( _
    Sub(settings)
            Dim indexPart As String = ViewData("index").ToString()
            settings.Name = "DockPanel" + indexPart
            settings.HeaderText = "Dock Panel " + indexPart
            settings.Width = 200
            settings.Height = 100
            'settings.OwnerZoneUID = "Zone";
    End Sub).GetHtml()