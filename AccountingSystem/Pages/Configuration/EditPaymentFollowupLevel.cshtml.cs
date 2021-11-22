using System;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using AccountingSystem.Model.System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
	public class EditPaymentFollowupLevelModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public IPaymentFollowupLevel PaymentFollowupLevel { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }
		private readonly UserManager<ApplicationUser> _userManager;
		public EditPaymentFollowupLevelModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
			Success = true;
		}

		public void OnGet(Guid id)
		{
			try
			{
				PaymentFollowupLevel = _dbContext.IPaymentFollowupLevels.FirstOrDefault(a => a.Id == id);
				if (PaymentFollowupLevel != null)
					Id = PaymentFollowupLevel.Id;
			}
			catch (Exception ex)
			{
				Success = false;
				Message = "Sorry, An error occurred";
			}
		}

		public IActionResult OnPost()
		{
			try
			{
				PaymentFollowupLevel.Personnel = _userManager.GetUserName(User);
				if (string.IsNullOrEmpty(PaymentFollowupLevel.Level))
				{
					Success = false;
					Message = "Kindly provide level";
					return Page();
				}
				var savedLevel = _dbContext.IPaymentFollowupLevels.FirstOrDefault(l => l.Id == Id);
				if (savedLevel != null)
				{
					savedLevel.Level = PaymentFollowupLevel.Level;
					savedLevel.Personnel = PaymentFollowupLevel.Personnel;
					savedLevel.ModifiedDate = PaymentFollowupLevel.ModifiedDate;
				}
				else
				{
					if (_dbContext.IPaymentFollowupLevels.Any(l => l.Level.ToUpper().Equals(PaymentFollowupLevel.Level.ToUpper())))
					{
						Success = false;
						Message = "Sorry, Level already exist";
						return Page();
					}
						
					_dbContext.IPaymentFollowupLevels.Add(PaymentFollowupLevel);
				}
				_dbContext.SaveChanges();
				Success = true;
				Message = "Payment level saved successfully";
				return RedirectToPage("./ListPaymentFollowupLevel");
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
