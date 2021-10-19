using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystem.Model;
using AccountingSystem.Model.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Customers
{
    public class ListCustomerInvoiceModel : PageModel
    {
        private AccountingDbContext _dbContext;
        [BindProperty]
        public List<CInvoice> invoices { get; set; }
        [BindProperty]
        public CInvoice cInvoice { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListCustomerInvoiceModel(AccountingDbContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            cInvoice = new CInvoice();
        }
        public PageResult OnGet()
        {
            try
            {
                invoices = _dbContext.CInvoices.ToList();
                return Page();
            }
            catch (Exception ex)
            {
                Success = false;
                Message = "Sorry, An error occurred";
                return Page();
            }
        }
    }
}
