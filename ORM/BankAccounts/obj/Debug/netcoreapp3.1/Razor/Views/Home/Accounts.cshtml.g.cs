#pragma checksum "/Users/kevinchen/Desktop/C#/ORM/BankAccounts/Views/Home/Accounts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6d282a2690b998bfa138227a92988ae14532e71"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Accounts), @"mvc.1.0.view", @"/Views/Home/Accounts.cshtml")]
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
#line 1 "/Users/kevinchen/Desktop/C#/ORM/BankAccounts/Views/_ViewImports.cshtml"
using BankAccounts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/kevinchen/Desktop/C#/ORM/BankAccounts/Views/_ViewImports.cshtml"
using BankAccounts.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6d282a2690b998bfa138227a92988ae14532e71", @"/Views/Home/Accounts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59ab2bbabc92c6356fc62571bc80cd8c3b7b2f62", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Accounts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_TransactionPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<h1>Welcome, \"");
#nullable restore
#line 4 "/Users/kevinchen/Desktop/C#/ORM/BankAccounts/Views/Home/Accounts.cshtml"
         Write(ViewBag.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"</h1>\r\n<p>Current Balanace : \"");
#nullable restore
#line 5 "/Users/kevinchen/Desktop/C#/ORM/BankAccounts/Views/Home/Accounts.cshtml"
                  Write(ViewBag.CurrentBalance);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"</p>\r\n<p>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f6d282a2690b998bfa138227a92988ae14532e713814", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n\r\n<div>\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th scope=\"col\">Amount</th>\r\n                <th scope=\"col\">Date</th>\r\n            </tr>\r\n");
#nullable restore
#line 17 "/Users/kevinchen/Desktop/C#/ORM/BankAccounts/Views/Home/Accounts.cshtml"
             foreach(var x in ViewBag.User.MoneyTransfer)
            {
                string money = string.Format("{0:.##}", x.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n\r\n                    <td scope=\"col\">$ ");
#nullable restore
#line 22 "/Users/kevinchen/Desktop/C#/ORM/BankAccounts/Views/Home/Accounts.cshtml"
                                 Write(money);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td scope=\"col\">");
#nullable restore
#line 23 "/Users/kevinchen/Desktop/C#/ORM/BankAccounts/Views/Home/Accounts.cshtml"
                               Write(x.CreatedAt);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 25 "/Users/kevinchen/Desktop/C#/ORM/BankAccounts/Views/Home/Accounts.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </thead>\r\n        <tbody>\r\n\r\n        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User> Html { get; private set; }
    }
}
#pragma warning restore 1591