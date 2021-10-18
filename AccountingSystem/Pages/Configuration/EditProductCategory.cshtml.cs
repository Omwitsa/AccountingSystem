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
    public class EditProductCategoryModel : PageModel
    {
		private AccountingDbContext _dbContext;
		[BindProperty]
		public ProductCategory ProductCategory { get; set; }
		[BindProperty]
		public List<AccountChart> Accounts { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }

		public EditProductCategoryModel(AccountingDbContext dbContext)
		{
			_dbContext = dbContext;
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
				ProductCategory = _dbContext.ProductCategories.FirstOrDefault(a => a.Id == id);
				if (ProductCategory != null)
					Id = ProductCategory.Id;
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
				if (string.IsNullOrEmpty(ProductCategory.Name))
				{
					Success = false;
					Message = "Kindly provide category";
					return Page();
				}
					
				ProductCategory.Closed = ProductCategory?.Closed ?? false;
				var savedCategory = _dbContext.ProductCategories.FirstOrDefault(c => c.Id == ProductCategory.Id);
				if (savedCategory != null)
				{
					savedCategory.Name = ProductCategory.Name;
					savedCategory.ParentCategory = ProductCategory.ParentCategory;
					savedCategory.IncomeGlAccount = ProductCategory.IncomeGlAccount;
					savedCategory.ExpenseGlAccount = ProductCategory.ExpenseGlAccount;
					savedCategory.Closed = ProductCategory.Closed;
					savedCategory.Personnel = ProductCategory.Personnel;
					savedCategory.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.ProductCategories.Any(c => c.Name.ToUpper().Equals(ProductCategory.Name.ToUpper())))
					{
						Success = false;
						Message = "Sorry, Category aleady exist";
						return Page();
					}
						
					_dbContext.ProductCategories.Add(ProductCategory);
				}
				_dbContext.SaveChanges();
				Success = true;
				Message = "Category saved successfully";
				return RedirectToPage("./ListProductCategory");
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