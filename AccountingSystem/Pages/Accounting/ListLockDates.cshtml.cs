using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Accounting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Accounting
{
	public class ListLockDatesModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<LockDate> LockDates { get; set; }
        [BindProperty]
        public LockDate LockDate { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListLockDatesModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            LockDate = new LockDate();
        }
        public IActionResult OnGet()
        {
            try
            {
                LockDates = _dbContext.LockDates.ToList();
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
                LockDates = _dbContext.LockDates.Where(b =>
                string.IsNullOrEmpty(LockDate.Personnel) || b.Personnel.ToUpper().Equals(LockDate.Personnel.ToUpper())
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

            return RedirectToPage("./EditLockDate", new { id = id });
        }

        public IActionResult OnPostDelete(Guid id)
        {
            try
            {
                var lockDate = _dbContext.LockDates.FirstOrDefault(b => b.Id == id);
                if (lockDate == null)
                {
                    Success = false;
                    Message = "Sorry, Date not found";
                    return Page();
                }

                _dbContext.LockDates.Remove(lockDate);
                _dbContext.SaveChanges();
                Message = "Date deleted successfully";
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
