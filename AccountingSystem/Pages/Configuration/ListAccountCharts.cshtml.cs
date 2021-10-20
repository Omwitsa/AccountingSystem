using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
	public class ListAccountChartsModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<AccountChart> AccountCharts { get; set; }
        [BindProperty]
        public AccountChart Account { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListAccountChartsModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            Account = new AccountChart();
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
                AccountCharts = _dbContext.AccountCharts.Where(a =>
                (string.IsNullOrEmpty(Account.Code) || a.Code.ToUpper().Equals(Account.Code.ToUpper()))
                && (string.IsNullOrEmpty(Account.Name) || a.Name.ToUpper().Equals(Account.Name.ToUpper()))
                && (string.IsNullOrEmpty(Account.Type) || a.Type.ToUpper().Equals(Account.Type.ToUpper()))
                && (string.IsNullOrEmpty(Account.Personnel) || a.Personnel.ToUpper().Equals(Account.Personnel.ToUpper()))
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

            return RedirectToPage("./EditAccountChart", new { id = id });
        }

        public void OnPostDelete(Guid id)
        {
            
        }

        public void OnPostView(Guid id)
        {
        }

    }
}
