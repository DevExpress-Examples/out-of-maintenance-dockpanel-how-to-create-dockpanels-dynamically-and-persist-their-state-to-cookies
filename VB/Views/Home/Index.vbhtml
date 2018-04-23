<script type="text/javascript">
    function OnAdd(s, e) {
        var count = parseInt(ASPxClientUtils.GetCookie("panelsCount"));

        if (isNaN(count))
            count = 0;

        $.ajax({
            url: '@Url.Action("DockPanelPartial", "Home")',
            type: "POST",
            data: { index: count },
            success: function (response) {
                //Use this line until we fix the B254332 issue
                //if (DockManager.layoutStateLoaded) DockManager.layoutStateLoaded = false;

                $(response).appendTo('#ajaxDiv');
                ASPxClientUtils.SetCookie("panelsCount", count + 1);
            }
        });
    }

    function OnClear(s, e) {
        var count = parseInt(ASPxClientUtils.GetCookie("panelsCount"));

        if (isNaN(count))
            count = 0;

        ASPxClientUtils.DeleteCookie("panelsCount");
        ASPxClientUtils.DeleteCookie("panelsState");

        window.location = "";
    }
</script>

@Html.DevExpress().Button( _
    Sub(settings)
            settings.Name = "btnAdd"
            settings.Text = "Add"
            settings.ClientSideEvents.Click = "OnAdd"
    End Sub).GetHtml()

@Html.DevExpress().Button( _
    Sub(settings)
            settings.Name = "btnClear"
            settings.Text = "Clear"
            settings.ClientSideEvents.Click = "OnClear"
    End Sub).GetHtml()

@Html.DevExpress().DockZone( _
    Sub(settings)
            settings.Name = "DockZone"
            settings.ZoneUID = "Zone"
            settings.ControlStyle.BackColor = System.Drawing.Color.LightBlue
    End Sub).GetHtml()

<div id="ajaxDiv">
@* Restore old panels: *@
@Code
    If Request.Cookies("panelsCount") IsNot Nothing Then
        Dim panelsCount As Integer = Convert.ToInt32(Request.Cookies("panelsCount").Value)

        For i As Integer = 0 To panelsCount - 1
            Html.RenderAction("DockPanelPartial", "Home", New With {Key .index = i})
        Next i
    End If
end code
</div>

@* DockManager should be rendered after all dock panels/zones to ensure correct layout management: *@
@Html.DevExpress().DockManager( _
    Sub(settings)
        settings.Name = "DockManager"
        settings.SaveStateToCookies = True
        settings.SaveStateToCookiesID = "panelsState"
    End Sub).GetHtml()