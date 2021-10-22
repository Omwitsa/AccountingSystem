using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using AccountingSystem.Model.Customers;
using AccountingSystem.Model.System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Customers
{
	public class EditCustomerInvoiceModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public CInvoice Invoice { get; set; }
		[BindProperty]
		public List<Customer> Customers { get; set; }
		[BindProperty]
		public List<Journal> Journals { get; set; }
		[BindProperty]
		public List<AccountChart> Accounts { get; set; }
		[BindProperty]
		public List<IncoTerm> IncoTerms { get; set; }
		[BindProperty]
		public List<CProduct> Products { get; set; }
		[BindProperty]
		public List<Bank> Banks { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }

		public EditCustomerInvoiceModel(AccountingSystemContext dbContext)
		{
			_dbContext = dbContext;
			Success = true;
		}

		public void OnGet(Guid id)
		{
			try
			{
				Customers = _dbContext.Customers.Where(v => !(bool)v.Closed)
					.Select(v => new Customer
					{
						Name = v.Name
					}).ToList();
				Journals = _dbContext.Journals.Where(j => !(bool)j.Closed)
					.Select(j => new Journal
					{
						Name = j.Name
					}).ToList();
				Banks = _dbContext.Banks.Where(b => !(bool)b.Closed)
					.Select(b => new Bank
					{
						Name = b.Name
					}).ToList();
				IncoTerms = _dbContext.IncoTerms
					.Select(t => new IncoTerm
					{
						Name = t.Name
					}).ToList();
				Products = _dbContext.CProducts.Where(p => !(bool)p.Closed)
					.Select(p => new CProduct
					{
						Name = p.Name
					}).ToList();
				Accounts = _dbContext.AccountCharts.Where(c => !(bool)c.Closed)
					.Select(c => new AccountChart
					{
						Name = c.Name,
						Code = c.Code
					}).ToList();
				Invoice = _dbContext.CInvoices.FirstOrDefault(b => b.Id == id);
				if (Invoice != null)
					Id = Invoice.Id;
			}
			catch (Exception)
			{
				Success = false;
				Message = "Sorry, An error occurred";
			}
		}

		public IActionResult OnPost()
		{
			try
			{
				Invoice.CreatedDate = DateTime.UtcNow.AddHours(3);
				Invoice.ModifiedDate = DateTime.UtcNow.AddHours(3);
				Invoice.Date = DateTime.UtcNow.AddHours(3);
				if (string.IsNullOrEmpty(Invoice.Customer))
                {
					Success = false;
					Message = "Sorry, Kindly provide customer";
					return Page();
				}


				if (string.IsNullOrEmpty(Invoice.Journal))
                {
					Success = false;
					Message = "Sorry, Kindly provide journal";
					return Page();
				}

				if (!Invoice.CInvoiceDetails.Any())
                {
					Success = false;
					Message = "Sorry, Kindly provide invoice items";
					return Page();
				}
					
				foreach (var detail in Invoice.CInvoiceDetails)
				{
					if (string.IsNullOrEmpty(detail.Product))
                    {
						Success = false;
						Message = "Sorry, There is a product missing in the invoice";
						return Page();
					}
						
					detail.Price = detail?.Price ?? 0;
					if (detail.Price < 1)
                    {
						Success = false;
						Message = $"Kindly enter the price for product {detail.Product}";
						return Page();
					}
						
					detail.Quantity = detail?.Quantity ?? 0;
					if (detail.Quantity < 1)
                    {
						Success = false;
						Message = $"Kindly enter the quantity for product {detail.Product}";
						return Page();
					}
						
				}
				var reference = "Add Invoice";
				var savedInvoice = _dbContext.CInvoices.FirstOrDefault(b => b.Id == Id);
				if (savedInvoice != null)
				{
					reference = "Edit invoice";
					Invoice.CreatedDate = savedInvoice.CreatedDate;
					if (savedInvoice != null)
					{
						var details = _dbContext.CInvoiceDetails.Where(b => b.CInvoiceId == savedInvoice.Id);
						if (details.Any())
							_dbContext.CInvoiceDetails.RemoveRange(details);
						var journals = _dbContext.CInvoiceJournal.Where(b => b.CInvoiceId == savedInvoice.Id);
						if (journals.Any())
							_dbContext.CInvoiceJournal.RemoveRange(journals);
						_dbContext.CInvoices.Remove(savedInvoice);
					}
				}
				_dbContext.Audits.Add(new Audit
				{
					UserName = Invoice.Personnel,
					Date = DateTime.UtcNow.AddHours(3),
					Reference = reference,
					ModuleId = "Customer"
				});

				_dbContext.CInvoices.Add(Invoice);
				_dbContext.SaveChanges();
				Success = true;
				Message = "Invoice saved successfully";
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
