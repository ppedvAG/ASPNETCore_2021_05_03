#pragma checksum "C:\Aktueller Kurs\ASPNETCore_2021_05_03\ASPNETCore_Grundlagen2021_05_03\StateManagementSamples\Views\Home\TempDataSecondSample.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea6e7473184b0d0a8681028242059499dd810c94"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_TempDataSecondSample), @"mvc.1.0.view", @"/Views/Home/TempDataSecondSample.cshtml")]
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
#line 1 "C:\Aktueller Kurs\ASPNETCore_2021_05_03\ASPNETCore_Grundlagen2021_05_03\StateManagementSamples\Views\_ViewImports.cshtml"
using StateManagementSamples;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Aktueller Kurs\ASPNETCore_2021_05_03\ASPNETCore_Grundlagen2021_05_03\StateManagementSamples\Views\_ViewImports.cshtml"
using StateManagementSamples.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea6e7473184b0d0a8681028242059499dd810c94", @"/Views/Home/TempDataSecondSample.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec58888ceac210e84d37e441303e5c92650fca82", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_TempDataSecondSample : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Aktueller Kurs\ASPNETCore_2021_05_03\ASPNETCore_Grundlagen2021_05_03\StateManagementSamples\Views\Home\TempDataSecondSample.cshtml"
  
    ViewData["Title"] = "TempDataSecondSample";

    string msg = TempData["Msg"].ToString();
    string wetter = TempData["Wetter"].ToString();
    TempData.Keep();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>TempDataSecondSample</h1>\r\n\r\n");
#nullable restore
#line 12 "C:\Aktueller Kurs\ASPNETCore_2021_05_03\ASPNETCore_Grundlagen2021_05_03\StateManagementSamples\Views\Home\TempDataSecondSample.cshtml"
Write(msg);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n");
#nullable restore
#line 14 "C:\Aktueller Kurs\ASPNETCore_2021_05_03\ASPNETCore_Grundlagen2021_05_03\StateManagementSamples\Views\Home\TempDataSecondSample.cshtml"
Write(wetter);

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591