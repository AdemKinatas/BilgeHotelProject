#pragma checksum "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "832f9243039141de511cfbe7200f29b7dff606b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\_ViewImports.cshtml"
using MvcWebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Entities.Concrete;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Entities.DTOs;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"832f9243039141de511cfbe7200f29b7dff606b9", @"/Areas/Admin/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"693138885798abf0334c4486a58ad19c9dca0ac1", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoomListDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("alert alert-danger alert-dismissible fade show"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("alert"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddRoom", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Room", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-outline-dark my-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateRoom", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteRoom", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
 if (Model.Rooms.Count != 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <main>\r\n        <div class=\"card mb-4\">\r\n            <div class=\"card-header\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "832f9243039141de511cfbe7200f29b7dff606b97353", async() => {
                WriteLiteral("\r\n                    <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n                        <span aria-hidden=\"true\">&times;</span>\r\n                    </button>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 13 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <i class=\"fas fa-table mr-1\"></i>\r\n                Odalar <br />\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "832f9243039141de511cfbe7200f29b7dff606b99453", async() => {
                WriteLiteral(" <i class=\"fas fa-plus-circle mr-2\"></i>Yeni Oda Ekle");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
            <div class=""card-body"">
                <div class=""table-responsive"">
                    <table class=""table table-bordered"" id=""dataTable"" width=""100%"" cellspacing=""0"">
                        <thead>
                            <tr>
                                <th>Oda No</th>
                                <th>Kat No</th>
                                <th>Kapasite</th>
                                <th>??zellikleri</th>
                                <th>Oda Tipi</th>
                                <th>Durumu</th>
                                <th>Rezervasyonlar</th>
                                <th>????lem</th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>Oda No</th>
                                <th>Kat No</th>
                                <th>Kapasite</th>
                                <th>??zellikleri</th>
 ");
            WriteLiteral(@"                               <th>Oda Tipi</th>
                                <th>Durumu</th>
                                <th>Rezervasyonlar</th>
                                <th>????lem</th>
                            </tr>
                        </tfoot>
                        <tbody>
");
#nullable restore
#line 50 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
                             foreach (var room in Model.Rooms)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 53 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
                                   Write(room.RoomNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 54 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
                                   Write(room.FloorNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 55 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
                                   Write(room.Capacity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 56 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
                                   Write(room.RoomFeatures);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n");
#nullable restore
#line 58 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
                                         if (Model.RoomTypes != null)
                                        {
                                            foreach (var roomType in Model.RoomTypes)
                                            {
                                                if (room.RoomTypeId == roomType.ID)
                                                {
                                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
                                               Write(roomType.RoomTypeName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
                                                                          
                                                }
                                            }
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td>\r\n");
#nullable restore
#line 70 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
                                         if (Model.RoomStatuses != null)
                                        {
                                            foreach (var roomStatus in Model.RoomStatuses)
                                            {
                                                if (room.RoomStatusId == roomStatus.ID)
                                                {
                                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
                                               Write(roomStatus.RoomStatusName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
                                                                              
                                                }
                                            }
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td>\r\n");
#nullable restore
#line 82 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
                                         if (ViewBag.Bookings != null)
                                        {
                                            foreach (var booking in ViewBag.Bookings as List<Booking>)
                                            {
                                                if (booking.RoomId == room.ID)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <h6>");
#nullable restore
#line 88 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
                                       Write(booking.BookingFrom.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 88 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
                                                                                  Write(booking.BookingTo.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n");
#nullable restore
#line 89 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
                                                }
                                            }
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "832f9243039141de511cfbe7200f29b7dff606b918908", async() => {
                WriteLiteral("<i class=\"far fa-edit mr-2\"></i>D??zenle");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 94 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
                                                                                           WriteLiteral(room.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "832f9243039141de511cfbe7200f29b7dff606b921515", async() => {
                WriteLiteral("<i class=\"far fa-edit mr-2\"></i>Sil");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 95 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
                                                                                           WriteLiteral(room.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 99 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </main>\r\n");
#nullable restore
#line 106 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"text-center mt-4\">\r\n        <p class=\"lead\">\r\n            Kay??tl?? Oda Bulunamad??!\r\n        </p>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "832f9243039141de511cfbe7200f29b7dff606b924960", async() => {
                WriteLiteral(" <i class=\"fas fa-plus-circle mr-2\"></i>Yeni Oda Ekle");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 115 "C:\Users\ademk\OneDrive\Belgeler\GitHub\BilgeHotelProject\BilgeHotelProject\MvcWebUI\Areas\Admin\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoomListDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
