#pragma checksum "/Users/Guest/Desktop/CIRCLES_MVC_MASTER/CIRCLES_MVC/Views/Circles/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15012a05c79e66c287add55e1681febb1d710e0e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Circles_Index), @"mvc.1.0.view", @"/Views/Circles/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Circles/Index.cshtml", typeof(AspNetCore.Views_Circles_Index))]
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
#line 1 "/Users/Guest/Desktop/CIRCLES_MVC_MASTER/CIRCLES_MVC/Views/_ViewImports.cshtml"
using Circles_MVC;

#line default
#line hidden
#line 2 "/Users/Guest/Desktop/CIRCLES_MVC_MASTER/CIRCLES_MVC/Views/_ViewImports.cshtml"
using Circles_MVC.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15012a05c79e66c287add55e1681febb1d710e0e", @"/Views/Circles/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d864beb897ca847bc7b874ccfd52d6af1fe42f5", @"/Views/_ViewImports.cshtml")]
    public class Views_Circles_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Circles_MVC.Models.Circle>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 3, true);
            WriteLiteral("  \n");
            EndContext();
#line 2 "/Users/Guest/Desktop/CIRCLES_MVC_MASTER/CIRCLES_MVC/Views/Circles/Index.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(32, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(79, 30, true);
            WriteLiteral("\n<h2>All Circles</h2>\n<hr />\n\n");
            EndContext();
#line 11 "/Users/Guest/Desktop/CIRCLES_MVC_MASTER/CIRCLES_MVC/Views/Circles/Index.cshtml"
 foreach (var circle in Model)
{

#line default
#line hidden
            BeginContext(142, 27, true);
            WriteLiteral("    <ul>\n        <li>Name: ");
            EndContext();
            BeginContext(170, 73, false);
#line 14 "/Users/Guest/Desktop/CIRCLES_MVC_MASTER/CIRCLES_MVC/Views/Circles/Index.cshtml"
             Write(Html.ActionLink($"{circle.Name}", "Details", new { id = circle.CircleId}));

#line default
#line hidden
            EndContext();
            BeginContext(243, 16, true);
            WriteLiteral("</li>\n    </ul>\n");
            EndContext();
#line 16 "/Users/Guest/Desktop/CIRCLES_MVC_MASTER/CIRCLES_MVC/Views/Circles/Index.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Circles_MVC.Models.Circle>> Html { get; private set; }
    }
}
#pragma warning restore 1591
