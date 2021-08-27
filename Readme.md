<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128552432/13.2.7%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E5133)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
* [DockPanelPartial.cshtml](./CS/Views/Home/DockPanelPartial.cshtml)
* [Index.cshtml](./CS/Views/Home/Index.cshtml)
<!-- default file list end -->
# DockPanel - How to create DockPanels dynamically and persist their state to cookies
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e5133)**
<!-- run online end -->


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


