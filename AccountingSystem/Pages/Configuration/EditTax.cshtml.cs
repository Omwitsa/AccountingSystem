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
	public class EditTaxModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public Tax Tax { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[BindProperty]
		public string[] Computations { get; set; }
		[BindProperty]
		public string[] Types { get; set; }
		[BindProperty]
		public string[] Scopes { get; set; }
		[BindProperty]
		public List<AccountChart> Accounts { get; set; }
		[TempData]
		public Guid Id { get; set; }
		private readonly UserManager<ApplicationUser> _userManager;

		public EditTaxModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
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
				Computations = new string[] { "Group of taxes", "Fixed", "Percentage of Price", "Percentage of Price Tax included" };
				Scopes = new string[] { "Services", "Goods" };
				Types = new string[] { "Sales", "Purchases", "None" };
				Tax = _dbContext.Taxes.FirstOrDefault(a => a.Id == id);
				if (Tax != null)
					Id = Tax.Id;
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
				if (string.IsNullOrEmpty(Tax.Name))
				{
					Success = false;
					Message = "Kindly provide tax";
					return Page();
				}
					
				Tax.Closed = Tax?.Closed ?? false;
				Tax.Personnel = _userManager.GetUserName(User);
				var savedTax = _dbContext.Taxes.FirstOrDefault(t => t.Id == Id);
				if (savedTax != null)
				{
					savedTax.Name = Tax.Name;
					savedTax.Type = Tax.Type;
					savedTax.Computation = Tax.Computation;
					savedTax.GlAccount = Tax.GlAccount;
					savedTax.Rate = Tax.Rate;
					savedTax.Scope = Tax.Scope;
					savedTax.Closed = Tax.Closed;
					savedTax.Personnel = Tax.Personnel;
					savedTax.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.Taxes.Any(t => t.Name.ToUpper().Equals(Tax.Name.ToUpper())))
					{
						Success = false;
						Message = "Sorry, tax already exist";
						return Page();
					}
						
					_dbContext.Taxes.Add(Tax);
				}
				_dbContext.SaveChanges();
				Success = true;
				Message = "Bank saved successfully";
				return RedirectToPage("./ListTaxes");
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
