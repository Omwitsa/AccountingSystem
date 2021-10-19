using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystem.IProvider;
using AccountingSystem.Model;
using AccountingSystem.Model.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Customers
{
    public class ListCustomerProductsModel : PageModel
    {
        private AccountingDbContext _dbContext;
        [BindProperty]
        public List<CProduct> products { get; set; }
        [BindProperty]
        public CProduct product { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListCustomerProductsModel(AccountingDbContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            product = new CProduct();
        }
        public PageResult OnGet()
        {
            try
            {
                products = _dbContext.CProducts.ToList();
                return Page();
            }
            catch (Exception ex)
            {
                Success = false;
                Message = "Sorry, An error occurred";
                return Page();
            }
        }

    }
}
