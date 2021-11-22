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
	public class EditDefferredRevenueModelModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public DefferredRevenueModel DefferredRevenueModel { get; set; }
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
		public EditDefferredRevenueModelModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
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
				DefferredRevenueModel = _dbContext.DefferredRevenueModels.FirstOrDefault(a => a.Id == id);
				if (DefferredRevenueModel != null)
					Id = DefferredRevenueModel.Id;
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
				DefferredRevenueModel.Personnel = _userManager.GetUserName(User);
				if (string.IsNullOrEmpty(DefferredRevenueModel.Name))
				{
					Success = false;
					Message = "Kindly provide model name";
					return Page();
				}

				if (string.IsNullOrEmpty(DefferredRevenueModel.GlAccount))
				{
					Success = false;
					Message = "Kindly provide GL account";
					return Page();
				}

				if (string.IsNullOrEmpty(DefferredRevenueModel.Journal))
				{
					Success = false;
					Message = "Kindly provide journal";
					return Page();
				}

				var savedModel = _dbContext.DefferredRevenueModels.FirstOrDefault(r => r.Id == Id);
				if (savedModel != null)
				{
					savedModel.Name = DefferredRevenueModel.Name;
					savedModel.GlAccount = DefferredRevenueModel.GlAccount;
					savedModel.DepreciationMethod = DefferredRevenueModel.DepreciationMethod;
					savedModel.DepreciationDuration = DefferredRevenueModel.DepreciationDuration;
					savedModel.DepreciationGlAccount = DefferredRevenueModel.DepreciationGlAccount;
					savedModel.RevenueGlAccount = DefferredRevenueModel.RevenueGlAccount;
					savedModel.Journal = DefferredRevenueModel.Journal;
					savedModel.Personnel = DefferredRevenueModel.Personnel;
					savedModel.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.DefferredRevenueModels.Any(r => r.Name.ToUpper().Equals(DefferredRevenueModel.Name.ToUpper())))
					{
						Success = false;
						Message = "Sorry, Model name already exist";
						return Page();
					}
						
					_dbContext.DefferredRevenueModels.Add(DefferredRevenueModel);
				}
				_dbContext.SaveChanges();
				Success = true;
				Message = "Model saved successfully";
				return RedirectToPage("./ListDefferredRevenueModels");
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
