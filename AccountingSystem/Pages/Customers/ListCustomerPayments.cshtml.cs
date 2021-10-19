using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystem.IProvider;
using AccountingSystem.Model;
using AccountingSystem.Model.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Customers
{
    public class ListCustomerPaymentsModel : PageModel
    {
        private AccountingDbContext _dbContext;
        [BindProperty]
        public List<CPayment> payments { get; set; }
        [BindProperty]
        public CPayment payment { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListCustomerPaymentsModel(AccountingDbContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            payment = new CPayment();
        }
        public PageResult OnGet()
        {
            try
            {
                payments = _dbContext.CPayments.ToList();
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
