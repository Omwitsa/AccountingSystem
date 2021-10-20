using System;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
	public class EditIncoTermModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public IncoTerm IncoTerm { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }

		public EditIncoTermModel(AccountingSystemContext dbContext)
		{
			_dbContext = dbContext;
			Success = true;
		}

		public void OnGet(Guid id)
		{
			try
			{
				IncoTerm = _dbContext.IncoTerms.FirstOrDefault(a => a.Id == id);
				if (IncoTerm != null)
					Id = IncoTerm.Id;
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
				if (string.IsNullOrEmpty(IncoTerm.Code))
				{
					Success = false;
					Message = "Kindly provide code";
					return Page();
				}
				if (string.IsNullOrEmpty(IncoTerm.Name))
				{
					Success = false;
					Message = "Kindly provide name";
					return Page();
				}

				var savedTerm = _dbContext.IncoTerms.FirstOrDefault(t => t.Id == IncoTerm.Id);
				if (savedTerm != null)
				{
					savedTerm.Code = IncoTerm.Code;
					savedTerm.Name = IncoTerm.Name;
					savedTerm.Personnel = IncoTerm.Personnel;
					savedTerm.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.IncoTerms.Any(t => t.Code.ToUpper().Equals(IncoTerm.Code.ToUpper())))
					{
						Success = false;
						Message = "Sorry, Term already exist";
						return Page();
					}
						
					_dbContext.IncoTerms.Add(IncoTerm);
				}
				_dbContext.SaveChanges();
				Success = true;
				Message = "Terms saved successfully";
				return RedirectToPage("./ListIncoTerm");
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
