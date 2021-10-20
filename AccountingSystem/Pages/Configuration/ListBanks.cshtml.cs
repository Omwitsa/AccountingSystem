using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
	public class ListBanksModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<Bank> Banks { get; set; }
        [BindProperty]
        public Bank Bank { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListBanksModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            Bank = new Bank();
        }
        public IActionResult OnGet()
        {
            try
            {
                Banks = _dbContext.Banks.ToList();
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
                Banks = _dbContext.Banks.Where(b =>
                (string.IsNullOrEmpty(Bank.AccNo) || b.AccNo.ToUpper().Equals(Bank.AccNo.ToUpper()))
                && (string.IsNullOrEmpty(Bank.Name) || b.Name.ToUpper().Equals(Bank.Name.ToUpper()))
                && (string.IsNullOrEmpty(Bank.Personnel) || b.Personnel.ToUpper().Equals(Bank.Personnel.ToUpper()))
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

            return RedirectToPage("./EditBank", new { id = id });
        }

        public IActionResult OnPostDelete(Guid id)
        {
            try
            {
                var bank = _dbContext.Banks.FirstOrDefault(b => b.Id == id);
                if (bank == null)
				{
                    Success = false;
                    Message = "Sorry, Bank not found";
                    return Page();
                }
                   
                _dbContext.Banks.Remove(bank);
                _dbContext.SaveChanges();
                Success = true;
                Message = "Bank deleted successfully";
                return Page();
            }
            catch (Exception ex)
            {
                Success = false;
                Message = "Sorry, An error occurred";
                return Page();
            }
        }

        public void OnPostView(Guid id)
        {
        }

    }
}
