#pragma checksum "C:\Users\golla\source\repos\MovieMVC\MovieMVC\Areas\Customer\Views\Home\MoviesByDirector.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44b85a33a4e1637eb2b0aba9cffc941491bd9532"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Home_MoviesByDirector), @"mvc.1.0.view", @"/Areas/Customer/Views/Home/MoviesByDirector.cshtml")]
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
#line 1 "C:\Users\golla\source\repos\MovieMVC\MovieMVC\Areas\Customer\Views\_ViewImports.cshtml"
using MovieMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\golla\source\repos\MovieMVC\MovieMVC\Areas\Customer\Views\_ViewImports.cshtml"
using MovieMVC.Model.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44b85a33a4e1637eb2b0aba9cffc941491bd9532", @"/Areas/Customer/Views/Home/MoviesByDirector.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e42737255f1a260c16423a1f111d697896f49d8", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    public class Areas_Customer_Views_Home_MoviesByDirector : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MovieMVC.Model.Movie>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "moviesByDirector", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\golla\source\repos\MovieMVC\MovieMVC\Areas\Customer\Views\Home\MoviesByDirector.cshtml"
  
    ViewData["Title"] = "Movies by Director: "+ @Model.FirstOrDefault().Director;

#line default
#line hidden
#nullable disable
            WriteLiteral("<h3>Movies by Director: ");
#nullable restore
#line 7 "C:\Users\golla\source\repos\MovieMVC\MovieMVC\Areas\Customer\Views\Home\MoviesByDirector.cshtml"
                   Write(Model.FirstOrDefault().Director);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n<div class=\"row pb-3\">\r\n\r\n\r\n\r\n");
#nullable restore
#line 13 "C:\Users\golla\source\repos\MovieMVC\MovieMVC\Areas\Customer\Views\Home\MoviesByDirector.cshtml"
     foreach (var movie in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""col-lg-3 col-md-6"">
            <div class=""row p-2"">
                <div class=""col-12  p-1"" style=""border:1px solid #008cba; border-radius: 5px;"">
                    <div class=""card"" style=""border:0px;"">
                        <img");
            BeginWriteAttribute("src", " src=\"", 534, "\"", 555, 1);
#nullable restore
#line 19 "C:\Users\golla\source\repos\MovieMVC\MovieMVC\Areas\Customer\Views\Home\MoviesByDirector.cshtml"
WriteAttributeValue("", 540, movie.ImageUrl, 540, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"height:200px\" class=\"card-img-top rounded\" />\r\n                        <div class=\"pl-1\">\r\n                            <p class=\"card-title h5\"><b style=\"color:#2c3e50\">");
#nullable restore
#line 21 "C:\Users\golla\source\repos\MovieMVC\MovieMVC\Areas\Customer\Views\Home\MoviesByDirector.cshtml"
                                                                         Write(movie.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "44b85a33a4e1637eb2b0aba9cffc941491bd95326331", async() => {
                WriteLiteral("<p class=\"card-title text-primary\">by <b>");
#nullable restore
#line 22 "C:\Users\golla\source\repos\MovieMVC\MovieMVC\Areas\Customer\Views\Home\MoviesByDirector.cshtml"
                                                                                                                                          Write(movie.Director);

#line default
#line hidden
#nullable disable
                WriteLiteral("</b></p>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-directorName", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 22 "C:\Users\golla\source\repos\MovieMVC\MovieMVC\Areas\Customer\Views\Home\MoviesByDirector.cshtml"
                                                                         WriteLiteral(movie.Director);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["directorName"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-directorName", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["directorName"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div style=\"padding-left:5px;\">\r\n                            <p>List Price: <strike><b");
            BeginWriteAttribute("class", " class=\"", 1069, "\"", 1077, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 25 "C:\Users\golla\source\repos\MovieMVC\MovieMVC\Areas\Customer\Views\Home\MoviesByDirector.cshtml"
                                                          Write(movie.ListPrice.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></strike></p>\r\n                        </div>\r\n                        <div style=\"padding-left:5px;\">\r\n                            <p style=\"color:maroon\">As low as: <b");
            BeginWriteAttribute("class", " class=\"", 1285, "\"", 1293, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 28 "C:\Users\golla\source\repos\MovieMVC\MovieMVC\Areas\Customer\Views\Home\MoviesByDirector.cshtml"
                                                                      Write(movie.Price100.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n                        </div>\r\n                    </div>\r\n                    <div>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "44b85a33a4e1637eb2b0aba9cffc941491bd953210369", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "C:\Users\golla\source\repos\MovieMVC\MovieMVC\Areas\Customer\Views\Home\MoviesByDirector.cshtml"
                                                                                       WriteLiteral(movie.Id);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 37 "C:\Users\golla\source\repos\MovieMVC\MovieMVC\Areas\Customer\Views\Home\MoviesByDirector.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MovieMVC.Model.Movie>> Html { get; private set; }
    }
}
#pragma warning restore 1591