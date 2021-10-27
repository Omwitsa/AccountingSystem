using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Accounting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Accounting
{
	public class ListAutoTransfersModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<AutoTransfer> AutoTransfers { get; set; }
        [BindProperty]
        public AutoTransfer AutoTransfer { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListAutoTransfersModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            AutoTransfer = new AutoTransfer();
        }
        public IActionResult OnGet()
        {
            try
            {
                AutoTransfers = _dbContext.AutoTransfers.ToList();
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
                AutoTransfers = _dbContext.AutoTransfers.Where(b =>
                (string.IsNullOrEmpty(AutoTransfer.Name) || b.Name.ToUpper().Equals(AutoTransfer.Name.ToUpper()))
                && (string.IsNullOrEmpty(AutoTransfer.Journal) || b.Journal.ToUpper().Equals(AutoTransfer.Journal.ToUpper()))
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

            return RedirectToPage("./EditAutoTransfer", new { id = id });
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
