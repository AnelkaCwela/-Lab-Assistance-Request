#pragma checksum "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Account\AccessDenied.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df9589d1dac9af1ba9a309450b4a04d7ff05db92"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SI_Request.Pages.Account.Views_Account_AccessDenied), @"mvc.1.0.view", @"/Views/Account/AccessDenied.cshtml")]
namespace SI_Request.Pages.Account
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df9589d1dac9af1ba9a309450b4a04d7ff05db92", @"/Views/Account/AccessDenied.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bfea69bbe1aca1f34edb1586a80d6b63c06decd", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_AccessDenied : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Account\AccessDenied.cshtml"
  
    ViewData["Title"] = "Access Denied";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h4 class=\"text-center alert alert-danger alert-heading\">Acces Denied!</h4>\r\n<hr />\r\n<div class=\"alert alert-danger alert-dismissible fade show\">\r\n    <strong>Please login !</strong> you dont have permssion to view this page.\r\n    <p>\r\n");
#nullable restore
#line 9 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Account\AccessDenied.cshtml"
          
            if (ViewBag.Error != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Account\AccessDenied.cshtml"
           Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\s220006415\OneDrive - Nelson Mandela University\Project\SI-Request\Views\Account\AccessDenied.cshtml"
                              
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </p>\r\n\r\n</div>");
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