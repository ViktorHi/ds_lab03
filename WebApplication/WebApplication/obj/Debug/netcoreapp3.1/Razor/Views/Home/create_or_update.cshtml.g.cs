#pragma checksum "D:\Studies\3 course\ds02\lab03\project\WebApplication\WebApplication\Views\Home\create_or_update.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d0b0d119722062f8564b3ae49e9794954f118326"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_create_or_update), @"mvc.1.0.view", @"/Views/Home/create_or_update.cshtml")]
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
#line 1 "D:\Studies\3 course\ds02\lab03\project\WebApplication\WebApplication\Views\_ViewImports.cshtml"
using WebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Studies\3 course\ds02\lab03\project\WebApplication\WebApplication\Views\_ViewImports.cshtml"
using WebApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0b0d119722062f8564b3ae49e9794954f118326", @"/Views/Home/create_or_update.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa0ef8da47a84ffb33e8bc853509aa4fa5703a26", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_create_or_update : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Home/AppllyUpdate"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Studies\3 course\ds02\lab03\project\WebApplication\WebApplication\Views\Home\create_or_update.cshtml"
  
    ViewData["Title"] = "Create page";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"content\">\r\n\r\n    <h1>Модификация записи</h1>\r\n    <img src=\"/policlinic.jpg\">\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d0b0d119722062f8564b3ae49e9794954f1183264349", async() => {
                WriteLiteral("\r\n\r\n        <table>\r\n\r\n            <tr>\r\n                <td>\r\n                    <p>ID Визита</p>\r\n                </td>\r\n                <td>\r\n                    <input type=\"number\" hidden readonly name=\"Id\"");
                BeginWriteAttribute("value", " value=\"", 410, "\"", 435, 1);
#nullable restore
#line 21 "D:\Studies\3 course\ds02\lab03\project\WebApplication\WebApplication\Views\Home\create_or_update.cshtml"
WriteAttributeValue("", 418, ViewBag.visit.Id, 418, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n\r\n            <tr>\r\n                <td>\r\n                    <p>ФИО Врача</p>\r\n                </td>\r\n                <td>\r\n                    <input type=\"text\" name=\"doctor_fio\"");
                BeginWriteAttribute("value", " value=\"", 664, "\"", 696, 1);
#nullable restore
#line 30 "D:\Studies\3 course\ds02\lab03\project\WebApplication\WebApplication\Views\Home\create_or_update.cshtml"
WriteAttributeValue("", 672, ViewBag.visit.DoctorFio, 672, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n\r\n            <tr>\r\n                <td>\r\n                    <p>ФИО Пациента</p>\r\n                </td>\r\n                <td>\r\n                    <input type=\"text\" name=\"patient_fio\"");
                BeginWriteAttribute("value", " value=\"", 929, "\"", 962, 1);
#nullable restore
#line 39 "D:\Studies\3 course\ds02\lab03\project\WebApplication\WebApplication\Views\Home\create_or_update.cshtml"
WriteAttributeValue("", 937, ViewBag.visit.PatientFio, 937, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n\r\n            <tr>\r\n                <td>\r\n                    <p>Время приема</p>\r\n                </td>\r\n                <td>\r\n                    <input type=\"datetime-local\" name=\"day_time\"");
                BeginWriteAttribute("value", " value=\"", 1202, "\"", 1258, 1);
#nullable restore
#line 48 "D:\Studies\3 course\ds02\lab03\project\WebApplication\WebApplication\Views\Home\create_or_update.cshtml"
WriteAttributeValue("", 1210, ViewBag.visit.Date.ToString("yyyy-MM-dd --:--"), 1210, 48, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n\r\n            <tr>\r\n                <td>\r\n                    <p>Срециальность врача</p>\r\n                </td>\r\n                <td>\r\n                    <input type=\"text\" name=\"speciality\"");
                BeginWriteAttribute("value", " value=\"", 1497, "\"", 1530, 1);
#nullable restore
#line 57 "D:\Studies\3 course\ds02\lab03\project\WebApplication\WebApplication\Views\Home\create_or_update.cshtml"
WriteAttributeValue("", 1505, ViewBag.visit.Speciality, 1505, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </td>\r\n            </tr>\r\n\r\n\r\n            <tr>\r\n                <td><input type=\"submit\" value=\"Показать\" /> </td>\r\n                <td></td>\r\n            </tr>\r\n        </table>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n\r\n</div>");
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
