using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystem.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Vendors.Refund
{
    public class ListRefundsModel : PageModel
    {
        //[BindProperty]
        //public List<Refund> Refunds { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        private AccountingDbContext _dbContext;
        public ListRefundsModel(AccountingDbContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            //Vender = new Vender();
        }
        public void OnGet()
        {
        }
    }
}
