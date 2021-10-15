using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystem.Model;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
    public class EditTaxModel : PageModel
    {
		private AccountingDbContext _dbContext;
		[BindProperty]
		public Tax Tax { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }

		public EditTaxModel(AccountingDbContext dbContext)
		{
			_dbContext = dbContext;
			Success = true;
		}

		public void OnGet(Guid id)
		{
			try
			{
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
				var savedTax = _dbContext.Taxes.FirstOrDefault(t => t.Id == Tax.Id);
				if (savedTax != null)
				{
					savedTax.Name = Tax.Name;
					savedTax.Type = Tax.Type;
					savedTax.Computation = Tax.Computation;
					savedTax.Scope = Tax.Scope;
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
