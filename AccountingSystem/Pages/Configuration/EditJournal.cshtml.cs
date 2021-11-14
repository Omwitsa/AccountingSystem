using System;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using AccountingSystem.Model.System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
	public class EditJournalModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public Journal Journal { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[BindProperty]
		public string[] JournalTypes { get; set; }
		[TempData]
		public Guid Id { get; set; }
		private readonly UserManager<ApplicationUser> _userManager;
		public EditJournalModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
			Success = true;
		}

		public void OnGet(Guid id)
		{
			try
			{
				JournalTypes = new string[] { "Sales", "Purchases", "Cash", "Bank", "Miscellaneous" };
				Journal = _dbContext.Journals.FirstOrDefault(a => a.Id == id);
				if (Journal != null)
					Id = Journal.Id;
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
				if (string.IsNullOrEmpty(Journal.Name))
				{
					Success = false;
					Message = "Kindly provide journal";
					return Page();
				}
				if (string.IsNullOrEmpty(Journal.Type))
				{
					Success = false;
					Message = "Kindly provide type";
					return Page();
				}
				Journal.Personnel = _userManager.GetUserName(User);
				Journal.Closed = Journal?.Closed ?? false;
				var savedJournal = _dbContext.Journals.FirstOrDefault(j => j.Id == Id);
				if (savedJournal != null)
				{
					savedJournal.Name = Journal.Name;
					savedJournal.Type = Journal.Type;
					savedJournal.Closed = Journal.Closed;
					savedJournal.Personnel = Journal.Personnel;
					savedJournal.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.Journals.Any(j => j.Name.ToUpper().Equals(Journal.Name.ToUpper())))
					{
						Success = false;
						Message = "Sorry, Journal already exist";
						return Page();
					}
						
					_dbContext.Journals.Add(Journal);
				}
				_dbContext.SaveChanges();
				Success = true;
				Message = "Journal saved successfully";
				return RedirectToPage("./ListJournals");
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
