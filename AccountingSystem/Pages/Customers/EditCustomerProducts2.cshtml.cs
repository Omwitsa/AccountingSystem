using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using AccountingSystem.Model.Customers;
using AccountingSystem.Model.System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Customers
{
	public class EditCustomerProducts2Model : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public CProduct Product { get; set; }
		[BindProperty]
		public List<AccountChart> Accounts { get; set; }
		[BindProperty]
		public List<ProductCategory> ProductCategories { get; set; }
		[BindProperty]
		public string[] ProductTypes { get; set; }
		[BindProperty]
		public List<Tax> Taxes { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }
		private readonly UserManager<ApplicationUser> _userManager;
		public EditCustomerProducts2Model(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
			Success = true;
		}

		public void OnGet(Guid id)
		{
			try
			{
				ProductCategories = _dbContext.ProductCategories.Where(p => !(bool)p.Closed)
					.Select(c => new ProductCategory
					{
						Name = c.Name
					}).ToList();
				ProductTypes = new string[] { "Consumable", "Service" };
				Taxes = _dbContext.Taxes.Where(t => !(bool)t.Closed)
					.Select(t => new Tax
					{
						Name = t.Name
					}).ToList();
				Accounts = _dbContext.AccountCharts.Where(a => !(bool)a.Closed)
					.Select(a => new AccountChart
					{
						Name = a.Name,
						Code = a.Code
					}).ToList();
				Product = _dbContext.CProducts.FirstOrDefault(v => v.Id == id);
				if (Product != null)
					Id = Product.Id;
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
				Product.Personnel = _userManager.GetUserName(User);
				if (string.IsNullOrEmpty(Product.Name))
                {
					Success = false;
					Message = "Kindly provide the product";
					return Page();
				}

				if (string.IsNullOrEmpty(Product.Type))
                {
					Success = false;
					Message = "Sorry, Kindly provide product type";
					return Page();
				}

				if (string.IsNullOrEmpty(Product.Category))
                {
					Success = false;
					Message = "Sorry, Kindly provide product category";
					return Page();
				}

				if (string.IsNullOrEmpty(Product.ARGlAccount))
                {
					Success = false;
					Message = "Sorry, Kindly provide Account receivable";
					return Page();
				}
					
				Product.CreatedDate = DateTime.UtcNow.AddHours(3);
				Product.ModifiedDate = DateTime.UtcNow.AddHours(3);
				Product.Closed = Product?.Closed ?? false;
				var reference = "Add Product";
				var savedProduct = _dbContext.CProducts.FirstOrDefault(p => p.Id == Id);
				if (savedProduct != null)
				{
					reference = "Edit Product";
					savedProduct.ModifiedDate = DateTime.UtcNow.AddHours(3);
					savedProduct.Name = Product.Name;
					savedProduct.Type = Product.Type;
					savedProduct.Category = Product.Category;
					savedProduct.Ref = Product.Ref;
					savedProduct.BarCode = Product.BarCode;
					savedProduct.Price = Product.Price;
					savedProduct.CustomerTax = Product.CustomerTax;
					savedProduct.Cost = Product.Cost;
					savedProduct.Notes = Product.Notes;
					savedProduct.VenderTax = Product.VenderTax;
					savedProduct.ARGlAccount = Product.ARGlAccount;
					savedProduct.APGlAccount = Product.APGlAccount;
					savedProduct.Closed = Product.Closed;
					savedProduct.Personnel = Product.Personnel;
				}
				else
				{
					_dbContext.CProducts.Add(Product);
				}
				_dbContext.Audits.Add(new Audit
				{
					UserName = Product.Personnel,
					Date = DateTime.UtcNow.AddHours(3),
					Reference = reference,
					ModuleId = "Customer"
				});
				_dbContext.SaveChanges();
				Success = true;
				Message = "Product saved successfully";
				return RedirectToPage("./ListCustomerProducts");
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
