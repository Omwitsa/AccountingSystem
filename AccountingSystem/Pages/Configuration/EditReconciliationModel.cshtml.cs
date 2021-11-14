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
	public class EditReconciliationModelModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public ReconciliationModel ReconciliationModel { get; set; }
		[BindProperty]
		public List<Journal> Journals { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }
		private readonly UserManager<ApplicationUser> _userManager;
		public EditReconciliationModelModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
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
				ReconciliationModel = _dbContext.ReconciliationModels.FirstOrDefault(a => a.Id == id);
				if (ReconciliationModel != null)
					Id = ReconciliationModel.Id;
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
				ReconciliationModel.Personnel = _userManager.GetUserName(User);
				if (string.IsNullOrEmpty(ReconciliationModel.Name))
				{
					Success = false;
					Message = "Kindly provide model name";
					return Page();
				}

				if (string.IsNullOrEmpty(ReconciliationModel.Type))
				{
					Success = false;
					Message = "Kindly provide type";
					return Page();
				}

				if (string.IsNullOrEmpty(ReconciliationModel.Journal))
				{
					Success = false;
					Message = "Kindly provide journal";
					return Page();
				}
				var savedModel = _dbContext.ReconciliationModels.FirstOrDefault(r => r.Id == Id);
				if (savedModel != null)
				{
					savedModel.Name = ReconciliationModel.Name;
					savedModel.Type = ReconciliationModel.Type;
					savedModel.Journal = ReconciliationModel.Journal;
					savedModel.Personnel = ReconciliationModel.Personnel;
					savedModel.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.ReconciliationModels.Any(r => r.Name.ToUpper().Equals(ReconciliationModel.Name.ToUpper())))
					{
						Success = false;
						Message = "Sorry, Reconsiliation already exist";
						return Page();
					}
						
					_dbContext.ReconciliationModels.Add(ReconciliationModel);
				}
				_dbContext.SaveChanges();
				Success = true;
				Message = "Model saved successfully";
				return RedirectToPage("./ListReconciliationModel");
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
