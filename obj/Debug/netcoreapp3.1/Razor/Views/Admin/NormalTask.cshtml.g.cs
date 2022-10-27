#pragma checksum "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Admin\NormalTask.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b5768f8125b9becc0618b3fc209327e9a554a07d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SI_Request.Pages.Admin.Views_Admin_NormalTask), @"mvc.1.0.view", @"/Views/Admin/NormalTask.cshtml")]
namespace SI_Request.Pages.Admin
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
#line 1 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\_ViewImports.cshtml"
using SI_Request;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\_ViewImports.cshtml"
using SI_Request.Models.DataBind;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\_ViewImports.cshtml"
using SI_Request.Models.DataModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5768f8125b9becc0618b3fc209327e9a554a07d", @"/Views/Admin/NormalTask.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bfea69bbe1aca1f34edb1586a80d6b63c06decd", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_NormalTask : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TaskViewModelData>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Admin\NormalTask.cshtml"
  
    ViewData["Title"] = "Assigned Task";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h4 class=""text-center"">Assigned Tasks</h4>
<hr />
<div class=""col-lg-8"">
    <div class=""card mb-4"">
        <div class=""card-body"">
            <div class=""row"">
                <div class=""col-sm-3"">
                    <p class=""mb-0"">Full Name</p>
                </div>
                <div class=""col-sm-9"">
                    <p class=""text-muted mb-0"">");
#nullable restore
#line 15 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Admin\NormalTask.cshtml"
                                          Write(ViewBag.FName);

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 15 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Admin\NormalTask.cshtml"
                                                          Write(ViewBag.LName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
            <hr>
            <div class=""row"">
                <div class=""col-sm-3"">
                    <p class=""mb-0"">Email</p>
                </div>
                <div class=""col-sm-9"">
                    <p class=""text-muted mb-0"">");
#nullable restore
#line 24 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Admin\NormalTask.cshtml"
                                          Write(ViewBag.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
            <hr>
            <div class=""row"">
                <div class=""col-sm-3"">
                    <p class=""mb-0"">Staff Number</p>
                </div>
                <div class=""col-sm-9"">
                    <p class=""text-muted mb-0"">");
#nullable restore
#line 33 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Admin\NormalTask.cshtml"
                                          Write(ViewBag.Staff);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n            <hr>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 41 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Admin\NormalTask.cshtml"
 if (Model.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table align-middle mb-0 bg-white"">
        <thead class=""bg-light"">
            <tr>
                <th>Category</th>
                <th>Date</th>
                <th>Start Time</th>
                <th>End Time</th>
                <th>Status</th>
                <th></th>

            </tr>
        </thead>
        <tbody>

");
#nullable restore
#line 57 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Admin\NormalTask.cshtml"
             foreach (var dat in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        <p class=\"fw-normal mb-1\">");
#nullable restore
#line 61 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Admin\NormalTask.cshtml"
                                             Write(dat.TaskCategoryModel.TaskCategory);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </td>\r\n                    <td>\r\n                        <p class=\"fw-normal mb-1\">");
#nullable restore
#line 64 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Admin\NormalTask.cshtml"
                                             Write(dat.TaskModel.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </td>\r\n                    <td>\r\n                        <p class=\"fw-normal mb-1\">");
#nullable restore
#line 67 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Admin\NormalTask.cshtml"
                                             Write(dat.TaskModel.StartTime.ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </td>\r\n                    <td>\r\n                        <p class=\"fw-normal mb-1\">");
#nullable restore
#line 70 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Admin\NormalTask.cshtml"
                                             Write(dat.TaskModel.EndTime.ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </td>\r\n");
#nullable restore
#line 72 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Admin\NormalTask.cshtml"
                     if (dat.TaskModel.Statuse == true)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>\r\n                            <span class=\"badge badge-success rounded-pill d-inline\">Active</span>\r\n                        </td>\r\n");
#nullable restore
#line 77 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Admin\NormalTask.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>\r\n                            <span class=\"badge badge-danger rounded-pill d-inline\">In Active</span>\r\n                        </td>\r\n");
#nullable restore
#line 83 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Admin\NormalTask.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n\r\n\r\n                </tr>\r\n");
#nullable restore
#line 88 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Admin\NormalTask.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n        </tbody>\r\n\r\n\r\n    </table>\r\n");
#nullable restore
#line 96 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Admin\NormalTask.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card\">\r\n        <div class=\"card-body\">The is no data to show</div>\r\n    </div>\r\n");
#nullable restore
#line 102 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Admin\NormalTask.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TaskViewModelData>> Html { get; private set; }
    }
}
#pragma warning restore 1591
