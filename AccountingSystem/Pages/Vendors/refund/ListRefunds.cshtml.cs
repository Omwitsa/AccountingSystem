using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Venders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Vendors
{
	public class ListRefundsModel : PageModel
    {
         private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<Refund> Refunds { get; set; }
        [BindProperty]
        public Refund Refund { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListRefundsModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            Refund = new Refund();
        }
        public IActionResult OnGet()
        {
            try
            {
                Refunds = _dbContext.Refunds.ToList();
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
                Refunds = _dbContext.Refunds.Where(r =>
                 (string.IsNullOrEmpty(Refund.Vendor) || r.Vendor.ToUpper().Equals(Refund.Vendor.ToUpper()))
                 && (string.IsNullOrEmpty(Refund.Journal) || r.Journal.ToUpper().Equals(Refund.Journal.ToUpper()))
                 && (string.IsNullOrEmpty(Refund.ReceipientBank) || r.ReceipientBank.ToUpper().Equals(Refund.ReceipientBank.ToUpper()))
                 && (string.IsNullOrEmpty(Refund.Personnel) || r.Personnel.ToUpper().Equals(Refund.Personnel.ToUpper()))
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

            return RedirectToPage("./EditRefunds", new { id = id });
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
