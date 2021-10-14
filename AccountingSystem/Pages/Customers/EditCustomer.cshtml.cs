using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystem.IProvider;
using AccountingSystem.Model.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Customers
{
    public class EditCustomerModel : PageModel
    {
        private ICustomersProvider _customersProvider;
        public EditCustomerModel(ICustomersProvider customersProvider)
        {
            _customersProvider = customersProvider;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var customer = new Customer
            {
                Name = "",
                Street1 = "",
                Street2 = "",
                City = "",
                Country = "",
                PhoneNo = "",
                Mobile = "",
                WebSite = "",
                SalesPerson = "",
                PurchasePaymentTerms = "",
                SalesPaymentTerms = "",
                FiscalPosition = "",
                ARGlAccount = "",
                APGlAccount = "",
                Bank = "",
                Notes = ""
            };

            var response = _customersProvider.AddCustomer(customer, false);
            if(response.Success)
                RedirectToPage("ListVendors");
            else
            {
                // Show message
            }
        }
    }
}
