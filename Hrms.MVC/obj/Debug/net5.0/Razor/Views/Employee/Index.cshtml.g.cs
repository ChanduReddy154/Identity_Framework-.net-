#pragma checksum "D:\Projects\.Net\HrmsWeb_Solution\Hrms.MVC\Views\Employee\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "330fbb4f68472fe32355f210a2a2863306212799"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Index), @"mvc.1.0.view", @"/Views/Employee/Index.cshtml")]
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
#line 1 "D:\Projects\.Net\HrmsWeb_Solution\Hrms.MVC\Views\_ViewImports.cshtml"
using Hrms.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projects\.Net\HrmsWeb_Solution\Hrms.MVC\Views\_ViewImports.cshtml"
using Hrms.MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"330fbb4f68472fe32355f210a2a2863306212799", @"/Views/Employee/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c1e8f46f62c6c80c4d147b23437b512cf34aef6", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ViewModels.EmployeeViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Projects\.Net\HrmsWeb_Solution\Hrms.MVC\Views\Employee\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Employees List</h1>\r\n\r\n<h3 style=\"color:green\"> ");
#nullable restore
#line 10 "D:\Projects\.Net\HrmsWeb_Solution\Hrms.MVC\Views\Employee\Index.cshtml"
                    Write(TempData["status"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>Employee Id</th>\r\n            <th>Employee Name</th>\r\n            <th>Employee Salary</th>\r\n            <th>Department Id</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 22 "D:\Projects\.Net\HrmsWeb_Solution\Hrms.MVC\Views\Employee\Index.cshtml"
          
            foreach (var emp in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 26 "D:\Projects\.Net\HrmsWeb_Solution\Hrms.MVC\Views\Employee\Index.cshtml"
                   Write(emp.EmpId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 27 "D:\Projects\.Net\HrmsWeb_Solution\Hrms.MVC\Views\Employee\Index.cshtml"
                   Write(emp.EmpName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 28 "D:\Projects\.Net\HrmsWeb_Solution\Hrms.MVC\Views\Employee\Index.cshtml"
                   Write(emp.EmpSalary);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 29 "D:\Projects\.Net\HrmsWeb_Solution\Hrms.MVC\Views\Employee\Index.cshtml"
                   Write(emp.DeptId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 32 "D:\Projects\.Net\HrmsWeb_Solution\Hrms.MVC\Views\Employee\Index.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ViewModels.EmployeeViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
