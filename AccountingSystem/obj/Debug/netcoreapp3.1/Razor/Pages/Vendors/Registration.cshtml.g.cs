#pragma checksum "F:\2021\evans\Accounting\Accounting\Accounts\AccountingSystem\AccountingSystem\Pages\Vendors\Registration.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "150de5bbee782eb962fdc1cf84c580ef8bc58ec0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AccountingSystem.Pages.Vendors.Pages_Vendors_Registration), @"mvc.1.0.razor-page", @"/Pages/Vendors/Registration.cshtml")]
namespace AccountingSystem.Pages.Vendors
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
#line 1 "F:\2021\evans\Accounting\Accounting\Accounts\AccountingSystem\AccountingSystem\Pages\_ViewImports.cshtml"
using AccountingSystem;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"150de5bbee782eb962fdc1cf84c580ef8bc58ec0", @"/Pages/Vendors/Registration.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a56f8c2dd73028c9204c690f3202789a632028e", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Vendors_Registration : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""modal-content hold-transition login-page"">
    <div class=""modal-header"" style=""background-color:#467fd0;color:white;text-align:center"">
        <h5 class=""modal-title w-100 text-center"">Vendors Registration Form</h5>
    </div>
    <div class=""modal-body"">
        <div class=""col-sm-4"">
            <div class=""col-md-10"">
                <input id=""Gender"" name=""Gender"" value=""Individual"" type=""radio"">
                Individual
                <input id=""Gender"" name=""Gender"" value=""Company"" type=""radio"">
                Company
            </div>
            <div class=""form-group"">
                <input type=""text"" class=""form-control"" id=""name"" placeholder=""Name"" style=""height:30px;"" autocomplete=""off"" />
            </div>
        </div>
        <div class=""row"" style=""border-radius:5px;border:1px solid #DDDDDD;padding:5px;"">
            <div class=""col-sm-1"">
                <div class=""form-group"">
                    <label");
            BeginWriteAttribute("for", " for=\"", 1049, "\"", 1055, 0);
            EndWriteAttribute();
            WriteLiteral(@">Adress</label>
                </div>
            </div>
            <div class=""col-sm-6"">
                <div class=""row"" style=""border-radius:5px;border:1px solid #DDDDDD;padding:5px;"">
                    <div class=""col-sm-12"">
                        <div class=""form-group"">

                            <input type=""text"" class=""form-control"" id=""idno"" placeholder=""Street..."" style=""height:30px;"" autocomplete=""off"" />
                        </div>
                    </div>
                    <div class=""col-sm-12"">
                        <div class=""form-group"">

                            <input type=""text"" class=""form-control"" id=""idno"" placeholder=""Street2..."" style=""height:30px;"" autocomplete=""off"" />
                        </div>
                    </div>
                    <div class=""col-sm-12"">
                        <div class=""col-sm-12"">
                            <div class=""row"" style=""border-radius:5px;border:1px solid #DDDDDD;padding:5px;"">
                ");
            WriteLiteral(@"                <div class=""col-sm-4"">
                                    <div class=""form-group"">
                                        <input type=""text"" class=""form-control"" id=""idno"" placeholder=""City..."" style=""height:30px;"" autocomplete=""off"" />
                                    </div>
                                </div>
                                <div class=""col-sm-4"">
                                    <div class=""form-group"">

                                        <input type=""text"" class=""form-control"" id=""idno"" placeholder=""State..."" style=""height:30px;"" autocomplete=""off"" />
                                    </div>
                                </div>
                                <div class=""col-sm-4"">
                                    <div class=""form-group"">
                                        <input type=""email"" class=""form-control"" id=""email"" placeholder=""Zip"" style=""height:30px;"" autocomplete=""off"" />
                                    </div>
     ");
            WriteLiteral(@"                           </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-sm-12"">
                        <div class=""form-group"">
                            <input type=""email"" class=""form-control"" id=""email"" placeholder=""Country"" style=""height:30px;"" autocomplete=""off"" />
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-sm-1"">
                <div class=""row"" style=""border-radius:5px;border:1px solid #DDDDDD;padding:5px;"">
                    <div class=""col-sm-8"">
                        <div class=""form-group"">
                            <label");
            BeginWriteAttribute("for", " for=\"", 3843, "\"", 3849, 0);
            EndWriteAttribute();
            WriteLiteral(">Phone</label>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"col-sm-8\">\r\n                        <div class=\"form-group\">\r\n                            <label");
            BeginWriteAttribute("for", " for=\"", 4054, "\"", 4060, 0);
            EndWriteAttribute();
            WriteLiteral(">Mobile</label>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"col-sm-8\">\r\n                        <div class=\"form-group\">\r\n                            <label");
            BeginWriteAttribute("for", " for=\"", 4266, "\"", 4272, 0);
            EndWriteAttribute();
            WriteLiteral(">Email</label>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"col-sm-8\">\r\n                        <div class=\"form-group\">\r\n                            <label");
            BeginWriteAttribute("for", " for=\"", 4477, "\"", 4483, 0);
            EndWriteAttribute();
            WriteLiteral(@">Website Link</label>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-sm-4"">
                <div class=""row"" style=""border-radius:5px;border:1px solid #DDDDDD;padding:5px;"">
                    <div class=""col-sm-12"">
                        <div class=""form-group"">

                            <input type=""text"" class=""form-control"" id=""idno"" placeholder=""Phone"" style=""height:30px;"" autocomplete=""off"" />
                        </div>
                    </div>
                    <div class=""col-sm-12"">
                        <div class=""form-group"">

                            <input type=""text"" class=""form-control"" id=""idno"" placeholder=""Mobile"" style=""height:30px;"" autocomplete=""off"" />
                        </div>
                    </div>
                    <div class=""col-sm-12"">
                        <div class=""form-group"">
                            <input type=""email"" class=""form-control""");
            WriteLiteral(@" id=""email"" placeholder=""Email"" style=""height:30px;"" autocomplete=""off"" />
                        </div>
                    </div>
                    <div class=""col-sm-12"">
                        <div class=""form-group"">
                            <input type=""email"" class=""form-control"" id=""email"" placeholder=""Website Link"" style=""height:30px;"" autocomplete=""off"" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class=""modal-body"">
            <div class=""row"" style=""border-radius:5px;border:1px solid #DDDDDD;padding:5px;"">
                <div class=""col-sm-3"">
                    <div class=""form-group"">
                        <label");
            BeginWriteAttribute("for", " for=\"", 6257, "\"", 6263, 0);
            EndWriteAttribute();
            WriteLiteral(@">Tax ID</label>
                    </div>
                </div>
                <div class=""col-sm-3"">
                    <div class=""form-group"">

                        <input type=""text"" class=""form-control"" id=""idno"" placeholder=""e.g BE0477472701"" style=""height:30px;"" autocomplete=""off"" />
                    </div>
                </div>
                <div class=""col-sm-3"">
                    <div class=""form-group"">
                        <label");
            BeginWriteAttribute("for", " for=\"", 6738, "\"", 6744, 0);
            EndWriteAttribute();
            WriteLiteral(@">Tags</label>
                    </div>
                </div>
                <div class=""col-sm-3"">
                    <div class=""form-group"">

                        <input type=""text"" class=""form-control"" id=""idno"" placeholder=""Tags"" style=""height:30px;"" autocomplete=""off"" />
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class=""modal-footer"" style=""background-color:#467fd0;color:white;text-align:center"">
        <button type=""submit"" id=""register"" class=""btn btn-success"">SAVE</button>
        <button type=""button"" class=""btn btn-danger"" data-dismiss=""modal"">DISCARD</button>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AccountingSystem.Pages.Vendors.RegistrationModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AccountingSystem.Pages.Vendors.RegistrationModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AccountingSystem.Pages.Vendors.RegistrationModel>)PageContext?.ViewData;
        public AccountingSystem.Pages.Vendors.RegistrationModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
