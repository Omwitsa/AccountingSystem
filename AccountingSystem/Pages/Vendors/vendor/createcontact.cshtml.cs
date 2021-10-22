using System;
using AccountingSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Vendors
{
	public class createcontactModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public createcontactModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
        }
        public void OnGet()
        {
            try
            {
            }
            catch (Exception ex)
            {
                Success = false;
                Message = "Sorry, An error occurred";
            }
        }
    }
}
