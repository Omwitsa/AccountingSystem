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
	public class EditIPaymentTermModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public IPaymentTerm PaymentTerm { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }
		private readonly UserManager<ApplicationUser> _userManager;
		public EditIPaymentTermModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
			Success = true;
		}

		public void OnGet(Guid id)
		{
			try
			{
				PaymentTerm = _dbContext.IPaymentTerms.FirstOrDefault(a => a.Id == id);
				if (PaymentTerm != null)
					Id = PaymentTerm.Id;
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
				PaymentTerm.Personnel = _userManager.GetUserName(User);
				if (string.IsNullOrEmpty(PaymentTerm.Term))
				{
					Success = false;
					Message = "Kindly provide terms";
					return Page();
				}

				var savedTerm = _dbContext.IPaymentTerms.FirstOrDefault(t => t.Id == Id);
				if (savedTerm != null)
				{
					savedTerm.Term = PaymentTerm.Term;
					savedTerm.Personnel = PaymentTerm.Personnel;
					savedTerm.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.IPaymentTerms.Any(t => t.Term.ToUpper().Equals(PaymentTerm.Term.ToUpper())))
					{
						Success = false;
						Message = "Sorry, terms already exist";
						return Page();
					}
						
					_dbContext.IPaymentTerms.Add(PaymentTerm);
				}
				_dbContext.SaveChanges();
				Success = true;
				Message = "Terms saved successfully";
				return RedirectToPage("./ListIPaymentTerm");
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
