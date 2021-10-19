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
    public class ListCustomerCreditNotesModel : PageModel
    {
        private AccountingDbContext _dbContext;
        [BindProperty]
        public List<CreditNote> creditNotes { get; set; }
        [BindProperty]
        public CreditNote creditNote { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListCustomerCreditNotesModel(AccountingDbContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            creditNote = new CreditNote();
        }
        public PageResult OnGet()
        {
            try
            {
                creditNotes = _dbContext.CreditNotes.ToList();
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
