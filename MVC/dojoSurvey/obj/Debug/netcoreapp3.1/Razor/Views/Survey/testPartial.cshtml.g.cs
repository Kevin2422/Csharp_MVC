#pragma checksum "/Users/kevinchen/Desktop/C#/MVC/dojoSurvey/Views/Survey/testPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2cf4d774aea29e95a5970233b5173646842df429"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Survey_testPartial), @"mvc.1.0.view", @"/Views/Survey/testPartial.cshtml")]
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
#line 1 "/Users/kevinchen/Desktop/C#/MVC/dojoSurvey/Views/_ViewImports.cshtml"
using dojoSurvey;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/kevinchen/Desktop/C#/MVC/dojoSurvey/Views/_ViewImports.cshtml"
using dojoSurvey.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2cf4d774aea29e95a5970233b5173646842df429", @"/Views/Survey/testPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be022f09196583f789ff747bacb319606a830b9e", @"/Views/_ViewImports.cshtml")]
    public class Views_Survey_testPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserData>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>");
#nullable restore
#line 2 "/Users/kevinchen/Desktop/C#/MVC/dojoSurvey/Views/Survey/testPartial.cshtml"
Write(Model.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserData> Html { get; private set; }
    }
}
#pragma warning restore 1591
