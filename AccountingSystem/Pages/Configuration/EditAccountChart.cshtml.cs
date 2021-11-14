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
	public class EditAccountChartModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
        public AccountChart Account { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }
		[BindProperty]
        public string[] AccountTypes { get; set; }
		private readonly UserManager<ApplicationUser> _userManager;
		public EditAccountChartModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
        {
			_dbContext = dbContext;
			_userManager = userManager;
			Success = true;
		}

        public void OnGet(Guid id)
        {
			try
			{
				AccountTypes = new string[] { "Assets", "Liabilities", "Equity",  "Income", "Expense"};
				Account = _dbContext.AccountCharts.FirstOrDefault(a => a.Id == id);
				if (Account != null)
					Id = Account.Id;
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
				if (string.IsNullOrEmpty(Account.Code))
				{
					Success = false;
					Message = "Sorry, Kindly provide account code";
					return Page();
				}
				if (string.IsNullOrEmpty(Account.Name))
				{
					Success = false;
					Message = "Sorry, Kindly provide account name";
					return Page();
				}
				if (string.IsNullOrEmpty(Account.Type))
				{
					Success = false;
					Message = "Sorry, Kindly provide account type";
					return Page();
				}
				Account.Personnel = _userManager.GetUserName(User);
				Account.Closed = Account?.Closed ?? false;
				Account.AllowReconciliation = Account?.AllowReconciliation ?? false;
				var savedAccount = _dbContext.AccountCharts.FirstOrDefault(a => a.Id == Id);
				if (savedAccount != null)
				{
					savedAccount.Code = Account.Code;
					savedAccount.Name = Account.Name;
					savedAccount.Type = Account.Type;
					savedAccount.AllowReconciliation = Account.AllowReconciliation;
					savedAccount.DefaultTax = Account.DefaultTax;
					savedAccount.AllowJournal = Account.AllowJournal;
					savedAccount.Tag = Account.Tag;
					savedAccount.Closed = Account.Closed;
					savedAccount.Personnel = Account.Personnel;
					savedAccount.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.AccountCharts.Any(a => a.Code.ToUpper().Equals(Account.Code.ToUpper())))
					{
						Success = false;
						Message = "Sorry, Code already exist";
						return Page();
					}

					if (_dbContext.AccountCharts.Any(a => a.Name.ToUpper().Equals(Account.Name.ToUpper())))
					{
						Success = false;
						Message = "Sorry, Name already exist";
						return Page();
					}
						
					_dbContext.AccountCharts.Add(Account);
				}
				_dbContext.SaveChanges();
				Success = true;
				Message = "Account saved successfully";
				return RedirectToPage("./ListAccountCharts");
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
