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
    public class EditDefferredRevenueModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public DefferredRevenue DefferredRevenue { get; set; }
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
		public EditDefferredRevenueModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
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
				DefferredRevenue = _dbContext.DefferredRevenues.FirstOrDefault(a => a.Id == id);
				if (DefferredRevenue != null)
					Id = DefferredRevenue.Id;
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
				if (string.IsNullOrEmpty(DefferredRevenue.Name))
				{
					Success = false;
					Message = "Sorry, Kindly provide name";
					return Page();
				}
				DefferredRevenue.Personnel = _userManager.GetUserName(User);
				var savedRevenue = _dbContext.DefferredRevenues.FirstOrDefault(b => b.Id == Id);
				if (savedRevenue != null)
				{
					var revenueBoards = _dbContext.RevenueBoards.Where(b => b.DefferredRevenueId == savedRevenue.Id);
					if (revenueBoards.Any())
						_dbContext.RevenueBoards.RemoveRange(revenueBoards);
					_dbContext.DefferredRevenues.Remove(savedRevenue);
				}
				_dbContext.DefferredRevenues.Add(DefferredRevenue);
				_dbContext.SaveChanges();
				Success = true;
				Message = "Revenue successfully";
				return RedirectToPage("./ListDefferredRevenues");
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
