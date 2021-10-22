using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Customers
{
	public class ListCustomerCreditNotesModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<CreditNote> CreditNotes { get; set; }
        [BindProperty]
        public CreditNote CreditNote { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListCustomerCreditNotesModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            CreditNote = new CreditNote();
        }
        public IActionResult OnGet()
        {
            try
            {
                CreditNotes = _dbContext.CreditNotes.ToList();
                return Page();
            }
            catch (Exception ex)
            {
                Success = false;
                Message = "Sorry, An error occurred";
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                CreditNotes = _dbContext.CreditNotes.Where(r =>
                 (string.IsNullOrEmpty(CreditNote.Customer) || r.Customer.ToUpper().Equals(CreditNote.Customer.ToUpper()))
                 && (string.IsNullOrEmpty(CreditNote.Journal) || r.Journal.ToUpper().Equals(CreditNote.Journal.ToUpper()))
                 && (string.IsNullOrEmpty(CreditNote.ReceipientBank) || r.ReceipientBank.ToUpper().Equals(CreditNote.ReceipientBank.ToUpper()))
                 && (string.IsNullOrEmpty(CreditNote.Personnel) || r.Personnel.ToUpper().Equals(CreditNote.Personnel.ToUpper()))
                    ).ToList();
                return Page();
            }
            catch (Exception ex)
            {
                Success = false;
                Message = "Sorry, An error occurred";
                return Page();
            }
        }

        public IActionResult OnPostEdit(Guid id)
        {

            return RedirectToPage("./EditCustomerCreditNotes", new { id = id });
        }

        public IActionResult OnPostDelete(Guid id)
        {
            return Page();
        }

        public void OnPostView(Guid id)
        {
        }
    }
}
