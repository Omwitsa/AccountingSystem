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
	public class EditBankModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public Bank Bank { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }
		private readonly UserManager<ApplicationUser> _userManager;
		public EditBankModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
			Success = true;
		}

		public void OnGet(Guid id)
		{
			try
			{
				Bank = _dbContext.Banks.FirstOrDefault(a => a.Id == id);
				if (Bank != null)
					Id = Bank.Id;
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
				if (string.IsNullOrEmpty(Bank.AccNo))
				{
					Success = false;
					Message = "Sorry, Kindly provide bank account";
					return Page();
				}

				if (string.IsNullOrEmpty(Bank.Name))
				{
					Success = false;
					Message = "Sorry, kindly provide bank name";
					return Page();
				}

				Bank.Personnel = _userManager.GetUserName(User);
				Bank.Closed = Bank?.Closed ?? false;
				var savedBank = _dbContext.Banks.FirstOrDefault(b => b.Id == Id);
				if (savedBank != null)
				{
					savedBank.AccNo = Bank.AccNo;
					savedBank.Name = Bank.Name;
					savedBank.IdentifierCode = Bank.IdentifierCode;
					savedBank.Closed = Bank.Closed;
					savedBank.Personnel = Bank.Personnel;
					savedBank.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.Banks.Any(b => b.AccNo.ToUpper().Equals(Bank.AccNo.ToUpper())))
					{
						Success = false;
						Message = "Sorry, Bank account already exist";
						return Page();
					}

					if (_dbContext.Banks.Any(b => b.Name.ToUpper().Equals(Bank.Name.ToUpper())))
					{
						Success = false;
						Message = "Sorry, Bank name already exist";
						return Page();
					}
						
					_dbContext.Banks.Add(Bank);
				}
				_dbContext.SaveChanges();
				Success = true;
				Message = "Bank saved successfully";
				return RedirectToPage("./ListBanks");
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
