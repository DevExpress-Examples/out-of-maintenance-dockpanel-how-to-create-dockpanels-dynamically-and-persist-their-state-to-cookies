<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
* [DockPanelPartial.cshtml](./CS/Views/Home/DockPanelPartial.cshtml)
* [Index.cshtml](./CS/Views/Home/Index.cshtml)
<!-- default file list end -->
# DockPanel - How to create DockPanels dynamically and persist their state to cookies


<p>This example illustrates how to add <a href="http://documentation.devexpress.com/#AspNet/CustomDocument11439"><u>DockPanel</u></a> to the view dynamically and restore their layout from cookies when view page is reloaded. We are using the approach from the <a href="https://www.devexpress.com/Support/Center/p/E4063">How to use the jQuery.ajax function with DevExpress MVC Extensions</a> code example to generate a new DockPanel on the server side and add its resulting HTML to the view page:</p>

```js
        $.ajax({
            url: '@Url.Action("DockPanelPartial", "Home")',
            type: "POST",
            data: { index: count },
            success: function (response) {
                $(response).appendTo('#ajaxDiv');
                ASPxClientUtils.SetCookie("panelsCount", count + 1);
            }
        });
```

<p> </p><p>In addition, make a note of the code used to restore previously created DockPanels:</p>

```cs
<div id="ajaxDiv">
    @* Restore old panels: *@
    @if (Request.Cookies["panelsCount"] != null) {
        int panelsCount = Convert.ToInt32(Request.Cookies["panelsCount"].Value);

        for (int i = 0; i < panelsCount; i++) {
            Html.RenderAction("DockPanelPartial", "Home", new { index = i });
        }
    }
</div>
```

<p> </p><p></p>

<br/>


