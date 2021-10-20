using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
	public class EditSettingModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public Setting Setting { get; set; }
		[BindProperty]
		public List<Journal> Journals { get; set; }
		[BindProperty]
		public List<Tax> Taxes { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[BindProperty]
		public string[] Periodicities { get; set; }
		[TempData]
		public Guid Id { get; set; }

		public EditSettingModel(AccountingSystemContext dbContext)
		{
			_dbContext = dbContext;
			Success = true;
		}

		public void OnGet(Guid id)
		{
			try
			{
				Journals = _dbContext.Journals.Where(j => !(bool)j.Closed)
					.Select(j => new Journal
					{
						Name = j.Name
					}).ToList();
				Taxes = _dbContext.Taxes.Where(t => !(bool)t.Closed)
					.Select(t => new Tax
					{
						Name = t.Name
					}).ToList();
				Periodicities = new string[] { "Monthly", "Quaterly", "Semi-Annually", "Annually" };
				Setting = _dbContext.Settings.FirstOrDefault(a => a.Id == id);
				if (Setting != null)
					Id = Setting.Id;
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
				var savesSetting = _dbContext.Settings.FirstOrDefault();
				savesSetting.SalesTax = Setting.SalesTax;
				savesSetting.PurchaseTax = Setting.PurchaseTax;
				savesSetting.Periodicity = Setting.Periodicity;
				savesSetting.Reminder = Setting.Reminder;
				savesSetting.Journal = Setting.Journal;
				savesSetting.RoundingMethod = Setting.RoundingMethod;
				savesSetting.FiscalCountry = Setting.FiscalCountry;
				savesSetting.MainCurrency = Setting.MainCurrency;
				savesSetting.MultiCurrency = Setting.MultiCurrency;
				savesSetting.FiscalPeriod = Setting.FiscalPeriod;
				savesSetting.ModifiedDate = DateTime.UtcNow.AddHours(3);
				
				_dbContext.SaveChanges();
				Success = true;
				Message = "Settings saved successfully";
				return Page();
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
