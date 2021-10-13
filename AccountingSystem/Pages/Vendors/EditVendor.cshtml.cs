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
        public EditVendorModel(IVendersProvider vendersProvider)
        {
            _vendersProvider = vendersProvider;
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            var vender = new Vender
            {
                Name = "Wilson Omwitsa",
                Street1 = "Matasia",
                Street2 = "",
                City = "Ngong",
                Country = "Kenya",
                PhoneNo = "075635237125",
                Mobile = "",
                WebSite = "",
                SalesPerson = "",
                PurchasePaymentTerms = "",
                SalesPaymentTerms = "",
                FiscalPosition = "",
                Ref = "",
                Industry = "Software",
                ARGlAccount = "Recivable",
                APGlAccount = "Creditor",
                Bank = "KCB",
                Notes = "Sijui"
            };

            var response = _vendersProvider.AddVender(vender, false);
            //RedirectToPage("ListVendors");
        }
    }
}
