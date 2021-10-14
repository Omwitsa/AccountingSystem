using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystem.IProvider;
using AccountingSystem.Model.Venders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Vendors
{
    public class EditVendorModel : PageModel
    {
        private IVendersProvider _vendersProvider;
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public EditVendorModel(IVendersProvider vendersProvider)
        {
            _vendersProvider = vendersProvider;
        }
        public void OnGet()
        {
            //var id = new Guid();
            //var response = _vendersProvider.GetVender(id);
            //var va = "";
        }

        public void OnPost()
        {
            var vender = new Vender
            {
                Name = Request.Form["name"],
                Street1 = Request.Form["Street"],
                Street2 = Request.Form["Street2"],
                City = Request.Form["City"],
                Country = Request.Form["Country"],
                PhoneNo = Request.Form["Phone"],
                Mobile = Request.Form["name"],
                Email = Request.Form["name"],
                WebSite = Request.Form["name"],
                SalesPerson = Request.Form["name"],
                PurchasePaymentTerms = Request.Form["name"],
                SalesPaymentTerms = Request.Form["name"],
                FiscalPosition = Request.Form["name"],
                Ref = Request.Form["name"],
                Industry = Request.Form["name"],
                ARGlAccount = "Recivable",
                APGlAccount = "Creditor",
                Bank = "KCB",
                Notes = "Sijui"
            };

            var response = _vendersProvider.AddVender(vender, false);
            if(response.Success)
                RedirectToPage("ListVendors");
            else
            {
                Success = response.Success;
                Message = response.Message;
                // Show error message
            }
        }
    }
}
