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
	public class EditAssetModelModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public AssetModel AssetModel { get; set; }
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
		public EditAssetModelModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
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
				AssetModel = _dbContext.AssetModels.FirstOrDefault(a => a.Id == id);
				if (AssetModel != null)
					Id = AssetModel.Id;
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
				if (string.IsNullOrEmpty(AssetModel.Name))
				{
					Success = false;
					Message = "Sorry, Kindly provide name";
					return Page();
				}
				AssetModel.Personnel = _userManager.GetUserName(User);
				var savedAsset = _dbContext.AssetModels.FirstOrDefault(a => a.Id == Id);
				if (savedAsset != null)
				{
					
					savedAsset.Name = AssetModel.Name;
					savedAsset.GlAccount = AssetModel.GlAccount;
					savedAsset.DepreciationMethod = AssetModel.DepreciationMethod;
					savedAsset.DepreciationDuration = AssetModel.DepreciationDuration;
					savedAsset.DepreciationGlAccount = AssetModel.DepreciationGlAccount;
					savedAsset.ExpenseGlAccount = AssetModel.ExpenseGlAccount;
					savedAsset.Journal = AssetModel.Journal;
					savedAsset.Personnel = AssetModel.Personnel;
					savedAsset.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.AssetModels.Any(a => a.Name.ToUpper().Equals(AssetModel.Name.ToUpper())))
					{
						Success = false;
						Message = "Sorry, Asset model already exist";
						return Page();
					}
						
					_dbContext.AssetModels.Add(AssetModel);
				}
				_dbContext.SaveChanges();
				Success = true;
				Message = "Model saved successfully";
				return RedirectToPage("./ListAssetModel");
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
