using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Venders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Vendors
{
	public class ListBillModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<Bill> Bills { get; set; }
        [BindProperty]
        public Bill Bill { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListBillModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            Bill = new Bill();
        }
        public IActionResult OnGet()
        {
            try
            {
                Bills = _dbContext.Bills.ToList();
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
                Bills = _dbContext.Bills
                    .Where(b => (string.IsNullOrEmpty(Bill.Vender) || b.Vender.ToUpper().Equals(Bill.Vender.ToUpper()))
                    && (string.IsNullOrEmpty(Bill.Journal) || b.Journal.ToUpper().Equals(Bill.Journal.ToUpper()))
                    && (string.IsNullOrEmpty(Bill.RecipientBank) || b.RecipientBank.ToUpper().Equals(Bill.RecipientBank.ToUpper()))
                    && (string.IsNullOrEmpty(Bill.IncoTerm) || b.IncoTerm.ToUpper().Equals(Bill.IncoTerm.ToUpper()))
                    && (string.IsNullOrEmpty(Bill.FiscalPosition) || b.FiscalPosition.ToUpper().Equals(Bill.FiscalPosition.ToUpper()))
                    && (string.IsNullOrEmpty(Bill.Personnel) || b.Personnel.ToUpper().Equals(Bill.Personnel.ToUpper()))
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

            return RedirectToPage("./EditBill", new { id = id });
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
