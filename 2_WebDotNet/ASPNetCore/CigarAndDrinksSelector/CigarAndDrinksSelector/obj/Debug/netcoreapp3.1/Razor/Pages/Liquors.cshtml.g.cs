#pragma checksum "C:\Users\sajan\source\repos\CodeShip\2_HTML\CigarAndDrinksSelector\CigarAndDrinksSelector\Pages\Liquors.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d20cb99db7e742306a15475ab29cc4a94ad80f3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CigarAndDrinksSelector.Pages.Pages_Liquors), @"mvc.1.0.razor-page", @"/Pages/Liquors.cshtml")]
namespace CigarAndDrinksSelector.Pages
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
#line 1 "C:\Users\sajan\source\repos\CodeShip\2_HTML\CigarAndDrinksSelector\CigarAndDrinksSelector\Pages\_ViewImports.cshtml"
using CigarAndDrinksSelector;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d20cb99db7e742306a15475ab29cc4a94ad80f3e", @"/Pages/Liquors.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31e15f6ef00ec290daa42f599f0bdc8cd661c5df", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Liquors : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\sajan\source\repos\CodeShip\2_HTML\CigarAndDrinksSelector\CigarAndDrinksSelector\Pages\Liquors.cshtml"
  
    ViewData["Title"] = "Liqors 90 Pluse Rated 2020";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d20cb99db7e742306a15475ab29cc4a94ad80f3e3381", async() => {
                WriteLiteral("\r\n    <label>Find your Poison</label>\r\n    <div class=\"form-group\">\r\n        <div class=\"input-group\">\r\n            <input type=\"search\" class=\"form-control\"");
                BeginWriteAttribute("value", " value=\"", 286, "\"", 294, 0);
                EndWriteAttribute();
                WriteLiteral(" name=\"searchLiqors\"/>\r\n            <span class=\"input-group-btn\">\r\n                <button class=\"btn btn-danger\">\r\n                    Search for Poisons\r\n                </button>\r\n            </span>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Staff Pick Alcohols 2020</h1>\r\n    ");
#nullable restore
#line 24 "C:\Users\sajan\source\repos\CodeShip\2_HTML\CigarAndDrinksSelector\CigarAndDrinksSelector\Pages\Liquors.cshtml"
Write(Model.CustomMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br>\r\n    ");
#nullable restore
#line 25 "C:\Users\sajan\source\repos\CodeShip\2_HTML\CigarAndDrinksSelector\CigarAndDrinksSelector\Pages\Liquors.cshtml"
Write(Model.Brands);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n    <table class=\"table\">\r\n");
#nullable restore
#line 27 "C:\Users\sajan\source\repos\CodeShip\2_HTML\CigarAndDrinksSelector\CigarAndDrinksSelector\Pages\Liquors.cshtml"
     foreach (var liq in Model.Liqors)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 30 "C:\Users\sajan\source\repos\CodeShip\2_HTML\CigarAndDrinksSelector\CigarAndDrinksSelector\Pages\Liquors.cshtml"
           Write(liq.Company);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 31 "C:\Users\sajan\source\repos\CodeShip\2_HTML\CigarAndDrinksSelector\CigarAndDrinksSelector\Pages\Liquors.cshtml"
           Write(liq.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 32 "C:\Users\sajan\source\repos\CodeShip\2_HTML\CigarAndDrinksSelector\CigarAndDrinksSelector\Pages\Liquors.cshtml"
           Write(liq.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 33 "C:\Users\sajan\source\repos\CodeShip\2_HTML\CigarAndDrinksSelector\CigarAndDrinksSelector\Pages\Liquors.cshtml"
           Write(liq.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 35 "C:\Users\sajan\source\repos\CodeShip\2_HTML\CigarAndDrinksSelector\CigarAndDrinksSelector\Pages\Liquors.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n    <p>Learn about <a href=\"https://www.acespirits.com\">Shop for these here</a>.</p>\r\n</div>\r\n\r\n\r\n    \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CigarAndDrinksSelector.Pages.LiquorsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CigarAndDrinksSelector.Pages.LiquorsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CigarAndDrinksSelector.Pages.LiquorsModel>)PageContext?.ViewData;
        public CigarAndDrinksSelector.Pages.LiquorsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591