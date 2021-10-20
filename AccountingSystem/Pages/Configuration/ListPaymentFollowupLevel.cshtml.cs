using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
	public class ListPaymentFollowupLevelModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<IPaymentFollowupLevel> PaymentFollowupLevels { get; set; }
        [BindProperty]
        public IPaymentFollowupLevel PaymentFollowupLevel { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListPaymentFollowupLevelModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            PaymentFollowupLevel = new IPaymentFollowupLevel();
        }
        public IActionResult OnGet()
        {
            try
            {
                PaymentFollowupLevels = _dbContext.IPaymentFollowupLevels.ToList();
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
                PaymentFollowupLevels = _dbContext.IPaymentFollowupLevels.Where(l =>
                (string.IsNullOrEmpty(PaymentFollowupLevel.Level) || l.Level.ToUpper().Equals(PaymentFollowupLevel.Level.ToUpper()))
                && (string.IsNullOrEmpty(PaymentFollowupLevel.Personnel) || l.Personnel.ToUpper().Equals(PaymentFollowupLevel.Personnel.ToUpper()))
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

            return RedirectToPage("./EditPaymentFollowupLevel", new { id = id });
        }

        public IActionResult OnPostDelete(Guid id)
        {
            try
            {
                var level = _dbContext.IPaymentFollowupLevels.FirstOrDefault(l => l.Id == id);
                if (level == null)
				{
                    Success = false;
                    Message = "Sorry, Follow up level not found";
                    return Page();
                }
                    
                _dbContext.IPaymentFollowupLevels.Remove(level);
                _dbContext.SaveChanges();
                Success = true;
                Message = "Follow up level deleted successfully";
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
