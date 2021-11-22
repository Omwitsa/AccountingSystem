using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Accounting;
using AccountingSystem.Model.Configuration;
using AccountingSystem.Model.System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Accounting
{
	public class EditDefferredExpenseModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public DefferredExpense DefferredExpense { get; set; }
		[BindProperty]
		public List<AccountChart> Accounts { get; set; }
		[BindProperty]
		public List<Journal> Journals { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }
		private readonly UserManager<ApplicationUser> _userManager;
		public EditDefferredExpenseModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
			Success = true;
		}

		public void OnGet(Guid id)
		{
			try
			{
				Accounts = _dbContext.AccountCharts.Where(a => !(bool)a.Closed)
					.Select(a => new AccountChart
					{
						Name = a.Name,
						Code = a.Code
					}).ToList();
				Journals = _dbContext.Journals.Where(j => !(bool)j.Closed)
					.Select(j => new Journal
					{
						Name = j.Name
					}).ToList();
				DefferredExpense = _dbContext.DefferredExpenses.FirstOrDefault(a => a.Id == id);
				if (DefferredExpense != null)
					Id = DefferredExpense.Id;
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
				if (string.IsNullOrEmpty(DefferredExpense.Name))
				{
					Success = false;
					Message = "Sorry, Kindly provide name";
					return Page();
				}
				DefferredExpense.Personnel = _userManager.GetUserName(User);
				var savedExpense = _dbContext.DefferredExpenses.FirstOrDefault(b => b.Id == Id);
				if (savedExpense != null)
				{
					var expenseBoards = _dbContext.ExpenseBoards.Where(b => b.DefferredExpenseId == savedExpense.Id);
					if (expenseBoards.Any())
						_dbContext.ExpenseBoards.RemoveRange(expenseBoards);
					_dbContext.DefferredExpenses.Remove(savedExpense);
				}
				_dbContext.DefferredExpenses.Add(DefferredExpense);
				_dbContext.SaveChanges();
				Success = true;
				Message = "Expense successfully";
				return RedirectToPage("./ListDefferredExpenses");
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
