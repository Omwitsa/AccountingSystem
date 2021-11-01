using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystem.Data;
using AccountingSystem.Model.Accounting;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Reporting
{
    public class GeneralLedgerReportModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<AccountChart> AccountCharts { get; set; }
        [BindProperty]
        public AccountChart AccountChart { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public GeneralLedgerReportModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            AccountChart = new AccountChart();
        }
        public IActionResult OnGet()
        {
            try
            {
                AccountCharts = _dbContext.AccountCharts.ToList();
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
                AccountCharts = _dbContext.AccountCharts.Where(b =>
                (string.IsNullOrEmpty(AccountChart.Code) || b.Code.ToUpper().Equals(AccountChart.Code.ToUpper()))
                && (string.IsNullOrEmpty(AccountChart.Name) || b.Name.ToUpper().Equals(AccountChart.Name.ToUpper()))
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

            return RedirectToPage("./EditJournalEntry", new { id = id });
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
