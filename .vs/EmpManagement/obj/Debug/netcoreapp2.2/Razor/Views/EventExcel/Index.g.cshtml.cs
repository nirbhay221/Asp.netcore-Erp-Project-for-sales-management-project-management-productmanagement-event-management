#pragma checksum "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\EventExcel\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90b00ccde6c89a0d6589d156f383dafc92bf148f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EventExcel_Index), @"mvc.1.0.view", @"/Views/EventExcel/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/EventExcel/Index.cshtml", typeof(AspNetCore.Views_EventExcel_Index))]
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
#line 1 "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\_ViewImports.cshtml"
using EmpManagement.Models;

#line default
#line hidden
#line 2 "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\_ViewImports.cshtml"
using EmpManagement.ViewModels;

#line default
#line hidden
#line 3 "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90b00ccde6c89a0d6589d156f383dafc92bf148f", @"/Views/EventExcel/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67d6ec5c308294d61a3bbb40d8c9044fb01a3987", @"/Views/_ViewImports.cshtml")]
    public class Views_EventExcel_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "mainhome", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "newindex", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "eventexcel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "importXML", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Event", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("return confirm(\'Are you sure ?\')"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 8, true);
            WriteLiteral("<html>\r\n");
            EndContext();
            BeginContext(8, 100, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "90b00ccde6c89a0d6589d156f383dafc92bf148f7339", async() => {
                BeginContext(14, 87, true);
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Index</title>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(108, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(110, 1390, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "90b00ccde6c89a0d6589d156f383dafc92bf148f8614", async() => {
                BeginContext(116, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(123, 14, false);
#line 7 "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\EventExcel\Index.cshtml"
Write(ViewBag.result);

#line default
#line hidden
                EndContext();
                BeginContext(137, 18, true);
                WriteLiteral("\r\n    <br />\r\n    ");
                EndContext();
                BeginContext(155, 281, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "90b00ccde6c89a0d6589d156f383dafc92bf148f9419", async() => {
                    BeginContext(256, 107, true);
                    WriteLiteral("\r\n        <input type=\"file\" name=\"xmlFile\" />\r\n        <input type=\"submit\" name=\"Import\" />\r\n\r\n\r\n        ");
                    EndContext();
                    BeginContext(363, 60, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "90b00ccde6c89a0d6589d156f383dafc92bf148f9943", async() => {
                        BeginContext(414, 5, true);
                        WriteLiteral("Index");
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(423, 6, true);
                    WriteLiteral("\r\n    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(436, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 16 "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\EventExcel\Index.cshtml"
     if (ViewBag.Event != null)
    {


#line default
#line hidden
                BeginContext(480, 275, true);
                WriteLiteral(@"<table border=""1"">
    <tr>
        <th>Id</th>
        <th>Title</th>
        <th>Description</th>
        <th>StartDate</th>
        <th>EndDate</th>
        <th>Budget</th>
        <th>Profit</th>
        <th>Location</th>

        <th>Options</th>
    </tr>
");
                EndContext();
#line 32 "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\EventExcel\Index.cshtml"
     foreach (var Event in ViewBag.Event)
    {

#line default
#line hidden
                BeginContext(805, 30, true);
                WriteLiteral("        <tr>\r\n            <td>");
                EndContext();
                BeginContext(836, 8, false);
#line 35 "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\EventExcel\Index.cshtml"
           Write(Event.Id);

#line default
#line hidden
                EndContext();
                BeginContext(844, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(868, 11, false);
#line 36 "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\EventExcel\Index.cshtml"
           Write(Event.Title);

#line default
#line hidden
                EndContext();
                BeginContext(879, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(903, 17, false);
#line 37 "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\EventExcel\Index.cshtml"
           Write(Event.Description);

#line default
#line hidden
                EndContext();
                BeginContext(920, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(944, 15, false);
#line 38 "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\EventExcel\Index.cshtml"
           Write(Event.StartDate);

#line default
#line hidden
                EndContext();
                BeginContext(959, 25, true);
                WriteLiteral("</td>\r\n\r\n            <td>");
                EndContext();
                BeginContext(985, 13, false);
#line 40 "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\EventExcel\Index.cshtml"
           Write(Event.EndDate);

#line default
#line hidden
                EndContext();
                BeginContext(998, 25, true);
                WriteLiteral("</td>\r\n\r\n            <td>");
                EndContext();
                BeginContext(1024, 12, false);
#line 42 "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\EventExcel\Index.cshtml"
           Write(Event.Budget);

#line default
#line hidden
                EndContext();
                BeginContext(1036, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1060, 12, false);
#line 43 "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\EventExcel\Index.cshtml"
           Write(Event.Profit);

#line default
#line hidden
                EndContext();
                BeginContext(1072, 25, true);
                WriteLiteral("</td>\r\n\r\n            <td>");
                EndContext();
                BeginContext(1098, 14, false);
#line 45 "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\EventExcel\Index.cshtml"
           Write(Event.Location);

#line default
#line hidden
                EndContext();
                BeginContext(1112, 43, true);
                WriteLiteral("</td>\r\n\r\n            <td>\r\n                ");
                EndContext();
                BeginContext(1155, 77, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "90b00ccde6c89a0d6589d156f383dafc92bf148f18059", async() => {
                    BeginContext(1224, 4, true);
                    WriteLiteral("Edit");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 48 "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\EventExcel\Index.cshtml"
                                                              WriteLiteral(Event.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1232, 37, true);
                WriteLiteral("\r\n                |\r\n                ");
                EndContext();
                BeginContext(1269, 124, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "90b00ccde6c89a0d6589d156f383dafc92bf148f20844", async() => {
                    BeginContext(1383, 6, true);
                    WriteLiteral("Delete");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 50 "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\EventExcel\Index.cshtml"
                                                                WriteLiteral(Event.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1393, 40, true);
                WriteLiteral("\r\n            </td>\r\n\r\n\r\n        </tr>\r\n");
                EndContext();
#line 55 "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\EventExcel\Index.cshtml"
    }

#line default
#line hidden
                BeginContext(1440, 10, true);
                WriteLiteral("</table>\r\n");
                EndContext();
#line 57 "C:\Users\Nirbhay Malhotra\Downloads\Security (7)\Security (6)\Security (5)\Security (2)\Security\EmpManagement\Views\EventExcel\Index.cshtml"

    }

#line default
#line hidden
                BeginContext(1459, 34, true);
                WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1500, 11, true);
            WriteLiteral("\r\n</html>\r\n");
            EndContext();
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
