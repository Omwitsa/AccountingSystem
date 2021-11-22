using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystem.Data;
using AccountingSystem.Model.Accounting;
using AccountingSystem.Model.Configuration;
using AccountingSystem.Model.System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Accounting
{
    public class EditAssetModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public Asset Asset { get; set; }
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
		public EditAssetModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
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
				Asset = _dbContext.Assets.FirstOrDefault(a => a.Id == id);
				if (Asset != null)
					Id = Asset.Id;
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
				if (string.IsNullOrEmpty(Asset.Name))
				{
					Success = false;
					Message = "Sorry, Kindly provide asset name";
					return Page();
				}

				if (string.IsNullOrEmpty(Asset.AssetGlAccount))
				{
					Success = false;
					Message = "Sorry, Kindly provide asset GL account";
					return Page();
				}

				Asset.Closed = Asset?.Closed ?? false;
				Asset.Personnel = _userManager.GetUserName(User);
				var savedAsset = _dbContext.Assets.FirstOrDefault(b => b.Id == Id);
				if (savedAsset != null)
				{
					var boards = _dbContext.DepreciationBoards.Where(b => b.AssetId == savedAsset.Id);
					if (boards.Any())
						_dbContext.DepreciationBoards.RemoveRange(boards);
					_dbContext.Assets.Remove(savedAsset);
				}
				_dbContext.Assets.Add(Asset);
				_dbContext.SaveChanges();
				Success = true;
				Message = "Asset saved successfully";
				return RedirectToPage("./ListAssets");
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
