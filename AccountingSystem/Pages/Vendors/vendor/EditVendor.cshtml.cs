using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using AccountingSystem.Model.System;
using AccountingSystem.Model.Venders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Vendors
{
	public class EditVendorModel : PageModel
    {
		

		private AccountingSystemContext _dbContext;
		[BindProperty]
		public Vender Vender { get; set; }

		[BindProperty]
		public List<AccountChart> ARccounts { get; set; }
		
		[BindProperty]
		public List<AccountChart> APccounts { get; set; }
		[BindProperty]
		public List<IPaymentTerm> PaymentTerms { get; set; }
		[BindProperty]
		public List<Bank> Banks { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }
		private readonly UserManager<ApplicationUser> _userManager;
		public EditVendorModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
			Success = true;
		}

		public void OnGet(Guid id)
		{
			try
			{
				
				ARccounts = _dbContext.AccountCharts.Where(a => !(bool)a.Closed && a.Type.ToLower().Equals("assets"))
					.Select(a => new AccountChart
					{
						Name = a.Name,
						Code = a.Code
					}).ToList();
				APccounts = _dbContext.AccountCharts.Where(a => !(bool)a.Closed && a.Type.ToLower().Equals("liabilities"))
					.Select(a => new AccountChart
					{
						Name = a.Name,
						Code = a.Code
					}).ToList();
				Banks = _dbContext.Banks.Where(b => !(bool)b.Closed)
					.Select(b => new Bank
					{
						Name = b.Name
					}).ToList();
				PaymentTerms = _dbContext.IPaymentTerms
					.Select(t => new IPaymentTerm
					{
						Term = t.Term
					}).ToList();
				Vender = _dbContext.Venders.FirstOrDefault(v => v.Id == id);
				if (Vender != null)
					Id = Vender.Id;
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
				if (string.IsNullOrEmpty(Vender.Name))
				{
					Success = false;
					Message = "Sorry, Kindly provide vendor";
					return Page();
				}

				if (string.IsNullOrEmpty(Vender.APGlAccount))
				{
					Success = false;
					Message = "Sorry, Kindly provide account payable";
					return Page();
				}

				Vender.Personnel = _userManager.GetUserName(User);
				Vender.CreatedDate = DateTime.UtcNow.AddHours(3);
				Vender.ModifiedDate = DateTime.UtcNow.AddHours(3);
				Vender.Closed = Vender?.Closed ?? false;
				var savedVender = _dbContext.Venders.FirstOrDefault(v => v.Id == Id);
				if (savedVender != null)
				{
					savedVender.Name = Vender.Name;
					savedVender.Street1 = Vender.Street1;
					savedVender.Street2 = Vender.Street2;
					savedVender.City = Vender.City;
					savedVender.Country = Vender.Country;
					savedVender.PhoneNo = Vender.PhoneNo;
					savedVender.Mobile = Vender.Mobile;
					savedVender.Email = Vender.Email;
					savedVender.WebSite = Vender.WebSite;
					savedVender.PurchasePaymentTerms = Vender.PurchasePaymentTerms;
					savedVender.SalesPaymentTerms = Vender.SalesPaymentTerms;
					savedVender.Ref = Vender.Ref;
					savedVender.Industry = Vender.Industry;
					savedVender.Bank = Vender.Bank;
					savedVender.Bank = Vender.BankAccount;
					savedVender.APGlAccount = Vender.APGlAccount;
					savedVender.Notes = Vender.Notes;
					savedVender.Closed = Vender.Closed;
					savedVender.Personnel = Vender.Personnel;
					savedVender.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.Venders.Any(v => v.Name.ToUpper().Equals(Vender.Name.ToUpper())))
					{
						Success = false;
						Message = "Sorry, Vendor already exist";
						return Page();
					}
						
					_dbContext.Venders.Add(Vender);
				}
				_dbContext.SaveChanges();
				Success = true;
				Message = "Vendor saved successfully";
				return RedirectToPage("./ListVendors");
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
