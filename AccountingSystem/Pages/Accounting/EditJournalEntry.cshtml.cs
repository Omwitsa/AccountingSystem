using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Accounting;
using AccountingSystem.Model.Configuration;
using AccountingSystem.Model.Venders;
using AccountingSystem.Model.System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Accounting
{
	public class EditJournalEntryModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public JournalEntry JournalEntry { get; set; }
		[BindProperty]
		public List<AccountChart> Accounts { get; set; }
		[BindProperty]
		public List<Vender> Vendors { get; set; }
		[BindProperty]
		public List<Tax> Tax { get; set; }
		[BindProperty]
		public List<Journal> Journals { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }
		private readonly UserManager<ApplicationUser> _userManager;
		public EditJournalEntryModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
			Success = true;
		}

		public void OnGet(Guid id)
		{
			try
			{
				Vendors = _dbContext.Venders.Where(v => !(bool)v.Closed)
					.Select(v => new Vender
					{
						Name = v.Name,
					}).ToList();
				Tax = _dbContext.Taxes.Where(ta => !(bool)ta.Closed)
					.Select(ta => new Tax
					{ 
					  Name = ta.Name,
					  Rate= ta.Rate,
					}).ToList();
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
				JournalEntry = _dbContext.JournalEntries.FirstOrDefault(a => a.Id == id);
				if (JournalEntry != null)
					Id = JournalEntry.Id;
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
				if (string.IsNullOrEmpty(JournalEntry.Ref))
				{
					Success = false;
					Message = "Sorry, Kindly provide Reference No.";
					return Page();
				}

				if (string.IsNullOrEmpty(JournalEntry.Journal))
				{
					Success = false;
					Message = "Sorry, Kindly provide journal";
					return Page();
				}
				JournalEntry.Personnel = _userManager.GetUserName(User);
				var savedJournal = _dbContext.JournalEntries.FirstOrDefault(b => b.Id == Id);
				if (savedJournal != null)
				{
					savedJournal.Date = JournalEntry.Date;
					savedJournal.No = JournalEntry.No;
					savedJournal.Partner = JournalEntry.Partner;
					savedJournal.Ref = JournalEntry.Ref;
					savedJournal.Journal = JournalEntry.Journal;
					savedJournal.Total = JournalEntry.Total;
					savedJournal.Personnel = JournalEntry.Personnel;
					savedJournal.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					_dbContext.JournalEntries.Add(JournalEntry);
				}
				
				_dbContext.SaveChanges();
				Success = true;
				Message = "Emtry saved successfully";
				return RedirectToPage("./ListJournalEntries");
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
