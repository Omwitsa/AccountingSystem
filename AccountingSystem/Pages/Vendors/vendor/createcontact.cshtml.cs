using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystem.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Vendors
{
    public class createcontactModel : PageModel
    {
        private AccountingDbContext _dbContext;
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public createcontactModel(AccountingDbContext dbContext)
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
