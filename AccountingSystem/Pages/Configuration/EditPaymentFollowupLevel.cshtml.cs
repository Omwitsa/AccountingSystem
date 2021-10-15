using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystem.Model;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
    public class EditPaymentFollowupLevelModel : PageModel
    {
		private AccountingDbContext _dbContext;
		[BindProperty]
		public IPaymentFollowupLevel PaymentFollowupLevel { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }

		public EditPaymentFollowupLevelModel(AccountingDbContext dbContext)
		{
			_dbContext = dbContext;
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
				if (string.IsNullOrEmpty(PaymentFollowupLevel.Level))
				{
					Success = false;
					Message = "Kindly provide level";
					return Page();
				}
				var savedLevel = _dbContext.IPaymentFollowupLevels.FirstOrDefault(l => l.Id == PaymentFollowupLevel.Id);
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
