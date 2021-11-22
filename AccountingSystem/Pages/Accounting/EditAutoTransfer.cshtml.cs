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
	public class EditAutoTransferModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public AutoTransfer AutoTransfer { get; set; }
		[BindProperty]
		public List<AccountChart> Accounts { get; set; }
		[BindProperty]
		public List<Journal> Journals { get; set; }
		[BindProperty]
		public string[] Frequencies { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }
		private readonly UserManager<ApplicationUser> _userManager;
		public EditAutoTransferModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
			Success = true;
		}

		public void OnGet(Guid id)
		{
			try
			{
				Frequencies = new string[] { "Monthly", "Quarterly", "Yearly" };
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
				AutoTransfer = _dbContext.AutoTransfers.FirstOrDefault(a => a.Id == id);
				if (AutoTransfer != null)
					Id = AutoTransfer.Id;
			}
			catch (Exception ex)
			{
				Success = false;
				Message = "Sorry, An error occurred";
			}
		}

		public IActionResult OnPost([FromBody] AutoTransfer transfer)
		{
			try
			{
				if (string.IsNullOrEmpty(transfer.Name))
				{
					Success = false;
					Message = "Sorry, Kindly provide name";
					return Page();
				}
				AutoTransfer.Personnel = _userManager.GetUserName(User);
				var savedTransfer = _dbContext.AutoTransfers.FirstOrDefault(b => b.Id == Id);
				if (savedTransfer != null)
				{
					var originalAccounts = _dbContext.OriginalAccounts.Where(b => b.AutoTransferId == savedTransfer.Id);
					if (originalAccounts.Any())
						_dbContext.OriginalAccounts.RemoveRange(originalAccounts);
					var transferredToAccounts = _dbContext.TransferredToAccounts.Where(b => b.AutoTransferId == savedTransfer.Id);
					if (transferredToAccounts.Any())
						_dbContext.TransferredToAccounts.RemoveRange(transferredToAccounts);
					_dbContext.AutoTransfers.Remove(savedTransfer);
				}
				_dbContext.AutoTransfers.Add(transfer);
				_dbContext.SaveChanges();
				Success = true;
				Message = "Transferred successfully";
				return RedirectToPage("./ListAutoTransfers");
			}
			catch (Exception ex)
			{
				Success = false;
				Message = "Sorry, An error occurred";
				return Page();
			}
		}

		public JsonResult OnPostLoad()
		{
			try
			{
				var accounts = _dbContext.AccountCharts.Where(a => !(bool)a.Closed).ToList();
				var results = new
				{
					accounts
				};
				return new JsonResult(results);
			}
			catch (Exception ex)
			{
				return new JsonResult("");
			}
		}
	}
}
