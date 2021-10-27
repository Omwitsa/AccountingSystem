using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Accounting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Accounting
{
	public class ListDefferredRevenuesModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<DefferredRevenue> DefferredRevenues { get; set; }
        [BindProperty]
        public DefferredRevenue DefferredRevenue { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListDefferredRevenuesModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            DefferredRevenue = new DefferredRevenue();
        }
        public IActionResult OnGet()
        {
            try
            {
                DefferredRevenues = _dbContext.DefferredRevenues.ToList();
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
                DefferredRevenues = _dbContext.DefferredRevenues.Where(b =>
                (string.IsNullOrEmpty(DefferredRevenue.Name) || b.Name.ToUpper().Equals(DefferredRevenue.Name.ToUpper()))
                && (string.IsNullOrEmpty(DefferredRevenue.RevenueGlAccount) || b.RevenueGlAccount.ToUpper().Equals(DefferredRevenue.RevenueGlAccount.ToUpper()))
                && (string.IsNullOrEmpty(DefferredRevenue.DeferredGlAccount) || b.DeferredGlAccount.ToUpper().Equals(DefferredRevenue.DeferredGlAccount.ToUpper()))
                && (string.IsNullOrEmpty(DefferredRevenue.Journal) || b.Journal.ToUpper().Equals(DefferredRevenue.Journal.ToUpper()))
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

            return RedirectToPage("./EditDefferredRevenue", new { id = id });
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
