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
    public class ListCustomerModel : PageModel
    {
        [BindProperty]
        public List<Customer> Customers { get; set; }
        private ICustomersProvider _customersProvider;
        public ListCustomerModel(ICustomersProvider customersProvider)
        {
            _customersProvider = customersProvider;
        }
        public void OnGet()
        {
            var customer = new Customer
            {
                Name = "",
                Country = "",
                Bank = ""
            };
            var vendorResp = _customersProvider.GetCustomers(customer);
            if(vendorResp.Success)
                Customers = vendorResp.Data;
            else
            {
               
            }
        }
    }
}
