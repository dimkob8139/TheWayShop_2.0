#pragma checksum "C:\Users\dimko\source\repos\TheWayShop_2.0\Views\Admin\CreateCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "217d8c639f8872711c6c51b6641833a9a0a6d384"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_CreateCategory), @"mvc.1.0.view", @"/Views/Admin/CreateCategory.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\dimko\source\repos\TheWayShop_2.0\Views\_ViewImports.cshtml"
using TheWayShop_2._0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dimko\source\repos\TheWayShop_2.0\Views\_ViewImports.cshtml"
using TheWayShop_2._0.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"217d8c639f8872711c6c51b6641833a9a0a6d384", @"/Views/Admin/CreateCategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c616ce509915861a4d48592a4922b4510c9cda5", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_CreateCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TheWayShop_2._0.ViewModels.CategoryViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\dimko\source\repos\TheWayShop_2.0\Views\Admin\CreateCategory.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("=\"CreateCategory\"\r\n\r\n");
#nullable restore
#line 5 "C:\Users\dimko\source\repos\TheWayShop_2.0\Views\Admin\CreateCategory.cshtml"
 using (Html.BeginForm("CreateCategory", "Admin", FormMethod.Post, new { enctype = "multipart/form-data" }))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div asp - validation - summary=\"ModelOnly\" class=\"text-danger\"></div>\r\n    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 9 "C:\Users\dimko\source\repos\TheWayShop_2.0\Views\Admin\CreateCategory.cshtml"
   Write(Html.LabelFor(m => m.Category.name, "name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n        ");
#nullable restore
#line 10 "C:\Users\dimko\source\repos\TheWayShop_2.0\Views\Admin\CreateCategory.cshtml"
   Write(Html.EditorFor(m => m.Category.name, "name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n\r\n    </div>\r\n    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 14 "C:\Users\dimko\source\repos\TheWayShop_2.0\Views\Admin\CreateCategory.cshtml"
   Write(Html.LabelFor(m => m.Category.description, "description"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n        ");
#nullable restore
#line 15 "C:\Users\dimko\source\repos\TheWayShop_2.0\Views\Admin\CreateCategory.cshtml"
   Write(Html.EditorFor(m => m.Category.description, "description"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n\r\n    </div>\r\n    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 19 "C:\Users\dimko\source\repos\TheWayShop_2.0\Views\Admin\CreateCategory.cshtml"
   Write(Html.LabelFor(m => m.Category.categoryItemId, "categoryItemId"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n        ");
#nullable restore
#line 20 "C:\Users\dimko\source\repos\TheWayShop_2.0\Views\Admin\CreateCategory.cshtml"
   Write(Html.EditorFor(m => m.Category.categoryItemId, "categoryItemId"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n\r\n    </div>\r\n    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 24 "C:\Users\dimko\source\repos\TheWayShop_2.0\Views\Admin\CreateCategory.cshtml"
   Write(Html.LabelFor(m => m.Category.categoryItemId, "Select categoryItem"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n        ");
#nullable restore
#line 25 "C:\Users\dimko\source\repos\TheWayShop_2.0\Views\Admin\CreateCategory.cshtml"
   Write(Html.DropDownListFor(m => m.Category.categoryItemId, ViewBag.CategoryItems as SelectList));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <input type=\"submit\" value=\"Create Category\" class=\"btn btn-primary\" />\r\n    </div>\r\n");
            WriteLiteral("    <hr />\r\n");
#nullable restore
#line 34 "C:\Users\dimko\source\repos\TheWayShop_2.0\Views\Admin\CreateCategory.cshtml"
Write(Html.ActionLink("Back to Categories", "Categories", "Admin"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\dimko\source\repos\TheWayShop_2.0\Views\Admin\CreateCategory.cshtml"
                                                                 
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TheWayShop_2._0.ViewModels.CategoryViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
