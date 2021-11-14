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

    public class EditCustomer2Model : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public Customer Customer { get; set; }
		[BindProperty]
		public List<AccountChart> RAccounts { get; set; }
		[BindProperty]
		public List<AccountChart> PAccounts { get; set; }
		[BindProperty]
		public List<Bank> Banks { get; set; }
		[BindProperty]
		public List<IPaymentTerm> PaymentTerms { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }
		private readonly UserManager<ApplicationUser> _userManager;
		public EditCustomer2Model(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
			Success = true;
		}

		public void OnGet(Guid id)
		{
			try
			{
				RAccounts = _dbContext.AccountCharts.Where(a => !(bool)a.Closed && a.Type.ToLower().Equals("assets"))
					.Select(a => new AccountChart
					{
						Name = a.Name,
						Code = a.Code
					}).ToList();
				PAccounts = _dbContext.AccountCharts.Where(a => !(bool)a.Closed && a.Type.ToLower().Equals("liabilities"))
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
				PaymentTerms = _dbContext.IPaymentTerms.Select(p => new IPaymentTerm
				{
					Term = p.Term
				}).ToList();
				Customer = _dbContext.Customers.FirstOrDefault(v => v.Id == id);
				if (Customer != null)
					Id = Customer.Id;
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
				if (string.IsNullOrEmpty(Customer.Name))
				{
					Success = false;
					Message = "Sorry, Kindly provide customer";
					return Page();
				}

				if (string.IsNullOrEmpty(Customer.ARGlAccount))
				{
					Success = false;
					Message = "Sorry, Kindly provide account receivable";
					return Page();
				}
				Customer.Personnel = _userManager.GetUserName(User);
				Customer.CreatedDate = DateTime.UtcNow.AddHours(3);
				Customer.ModifiedDate = DateTime.UtcNow.AddHours(3);
				Customer.Closed = Customer?.Closed ?? false;
				var savedCustomer = _dbContext.Customers.FirstOrDefault(v => v.Id == Id);
				if (savedCustomer != null)
				{
					savedCustomer.Name = Customer.Name;
					savedCustomer.Street1 = Customer.Street1;
					savedCustomer.Street2 = Customer.Street2;
					savedCustomer.City = Customer.City;
					savedCustomer.Country = Customer.Country;
					savedCustomer.PhoneNo = Customer.PhoneNo;
					savedCustomer.Mobile = Customer.Mobile;
					savedCustomer.Email = Customer.Email;
					savedCustomer.WebSite = Customer.WebSite;
					savedCustomer.SalesPerson = Customer.SalesPerson;
					savedCustomer.PurchasePaymentTerms = Customer.PurchasePaymentTerms;
					savedCustomer.SalesPaymentTerms = Customer.SalesPaymentTerms;
					savedCustomer.FiscalPosition = Customer.FiscalPosition;
					savedCustomer.ARGlAccount = Customer.ARGlAccount;
					savedCustomer.Bank = Customer.Bank;
					savedCustomer.Notes = Customer.Notes;
					savedCustomer.Closed = Customer.Closed;
					savedCustomer.Personnel = Customer.Personnel;
					savedCustomer.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.Customers.Any(v => v.Name.ToUpper().Equals(Customer.Name.ToUpper())))
					{
						Success = false;
						Message = "Sorry, Customer already exist";
						return Page();
					}

					_dbContext.Customers.Add(Customer);
				}
				_dbContext.SaveChanges();
				Success = true;
				Message = "Customer saved successfully";
				return RedirectToPage("./ListCustomer");
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
