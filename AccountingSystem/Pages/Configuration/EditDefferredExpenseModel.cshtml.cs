using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using AccountingSystem.Model.System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
	public class EditDefferredExpenseModelModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public DefferredExpenseModel DefferredExpenseModel { get; set; }
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
		public EditDefferredExpenseModelModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
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
				DefferredExpenseModel = _dbContext.DefferredExpenseModels.FirstOrDefault(a => a.Id == id);
				if (DefferredExpenseModel != null)
					Id = DefferredExpenseModel.Id;
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
				if (string.IsNullOrEmpty(DefferredExpenseModel.Name))
				{
					Success = false;
					Message = "Kindly provide model name";
					return Page();
				}

				if (string.IsNullOrEmpty(DefferredExpenseModel.GlAccount))
				{
					Success = false;
					Message = "Kindly provide GL account";
					return Page();
				}

				if (string.IsNullOrEmpty(DefferredExpenseModel.Journal))
				{
					Success = false;
					Message = "Kindly provide journal";
					return Page();
				}
				DefferredExpenseModel.Personnel = _userManager.GetUserName(User);
				var savedModel = _dbContext.DefferredExpenseModels.FirstOrDefault(e => e.Id == Id);
				if (savedModel != null)
				{
					savedModel.Name = DefferredExpenseModel.Name;
					savedModel.GlAccount = DefferredExpenseModel.GlAccount;
					savedModel.DepreciationMethod = DefferredExpenseModel.DepreciationMethod;
					savedModel.DepreciationDuration = DefferredExpenseModel.DepreciationDuration;
					savedModel.DepreciationGlAccount = DefferredExpenseModel.DepreciationGlAccount;
					savedModel.RevenueGlAccount = DefferredExpenseModel.RevenueGlAccount;
					savedModel.Journal = DefferredExpenseModel.Journal;
					savedModel.Personnel = DefferredExpenseModel.Personnel;
					savedModel.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.DefferredExpenseModels.Any(e => e.Name.ToUpper().Equals(DefferredExpenseModel.Name.ToUpper())))
					{
						Success = false;
						Message = "Sorry, expense model already exist";
						return Page();
					}
						
					_dbContext.DefferredExpenseModels.Add(DefferredExpenseModel);
				}
				_dbContext.SaveChanges();
				Success = true;
				Message = "Expense model saved successfully";
				return RedirectToPage("./ListDefferredExpenseModel");
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
