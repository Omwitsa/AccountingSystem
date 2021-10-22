using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Customers
{
	public class ListCustomerInvoiceModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<CInvoice> Invoices { get; set; }
        [BindProperty]
        public CInvoice Invoice { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListCustomerInvoiceModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            Invoice = new CInvoice();
        }
        public IActionResult OnGet()
        {
            try
            {
                Invoices = _dbContext.CInvoices.ToList();
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
                Invoices = _dbContext.CInvoices
                    .Where(b => (string.IsNullOrEmpty(Invoice.Customer) || b.Customer.ToUpper().Equals(Invoice.Customer.ToUpper()))
                    && (string.IsNullOrEmpty(Invoice.Journal) || b.Journal.ToUpper().Equals(Invoice.Journal.ToUpper()))
                    && (string.IsNullOrEmpty(Invoice.RecipientBank) || b.RecipientBank.ToUpper().Equals(Invoice.RecipientBank.ToUpper()))
                    && (string.IsNullOrEmpty(Invoice.IncoTerm) || b.IncoTerm.ToUpper().Equals(Invoice.IncoTerm.ToUpper()))
                    && (string.IsNullOrEmpty(Invoice.FiscalPosition) || b.FiscalPosition.ToUpper().Equals(Invoice.FiscalPosition.ToUpper()))
                    && (string.IsNullOrEmpty(Invoice.Personnel) || b.Personnel.ToUpper().Equals(Invoice.Personnel.ToUpper()))
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

            return RedirectToPage("./EditCustomerInvoice", new { id = id });
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
