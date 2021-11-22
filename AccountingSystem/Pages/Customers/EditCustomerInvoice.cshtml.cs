using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using AccountingSystem.Model.Customers;
using AccountingSystem.Model.System;
using AccountingSystem.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
		public List<Tax> Taxes { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }
		private Util util = new Util();
		private readonly UserManager<ApplicationUser> _userManager;
		public EditCustomerInvoiceModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
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
				Taxes = _dbContext.Taxes.Where(t => !(bool)t.Closed)
					.Select(t => new Tax { 
						Name = t.Name,
						GlAccount = t.GlAccount,
						Rate = t.Rate
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

		public IActionResult OnPost([FromBody] CInvoice invoice)
		{
			try
			{
				invoice.CreatedDate = DateTime.UtcNow.AddHours(3);
				invoice.ModifiedDate = DateTime.UtcNow.AddHours(3);
				invoice.Date = DateTime.UtcNow.AddHours(3);
				invoice.Personnel = _userManager.GetUserName(User);
				if (string.IsNullOrEmpty(invoice.Customer))
                {
					Success = false;
					Message = "Sorry, Kindly provide customer";
					return Page();
				}

				if (string.IsNullOrEmpty(invoice.Journal))
                {
					Success = false;
					Message = "Sorry, Kindly provide journal";
					return Page();
				}

				if (!invoice.CInvoiceDetails.Any())
                {
					Success = false;
					Message = "Sorry, Kindly provide invoice items";
					return Page();
				}

				invoice.Status = "Posted";
				foreach (var detail in invoice.CInvoiceDetails)
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
					invoice.CreatedDate = savedInvoice.CreatedDate;
					invoice.Ref = savedInvoice.Ref;
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
				else
				{
					var suffix = "INV";
					invoice.Ref = $"{suffix}1";
					var invoice1 = _dbContext.CInvoices.ToList()
						.OrderByDescending(i => Convert.ToInt32(i.Ref.Substring(suffix.Length))).FirstOrDefault();
					if (invoice1 != null)
						invoice.Ref = util.GetRef(invoice1.Ref, suffix);
				}
				_dbContext.Audits.Add(new Audit
				{
					UserName = invoice.Personnel,
					Date = DateTime.UtcNow.AddHours(3),
					Reference = reference,
					ModuleId = "Customer"
				});

				_dbContext.CInvoices.Add(invoice);
				_dbContext.SaveChanges();
				Success = true;
				Message = "Invoice saved successfully";
				return RedirectToPage("./ListCustomerInvoice");
			}
			catch (Exception ex)
			{
				Success = false;
				Message = "Sorry, An error occurred";
				return Page();
			}
		}
	
		public IActionResult OnPostPayment([FromBody] CPayment payment)
		{
			try
			{
				payment.Personnel = _userManager.GetUserName(User);
				if (string.IsNullOrEmpty(payment.Customer))
				{
					Success = false;
					Message = "Kindly provide customer";
					return Page();
				}
				var customer = _dbContext.Customers.FirstOrDefault(c => c.Name.ToUpper().Equals(payment.Customer.ToUpper()));
				payment.GlAccount = customer.ARGlAccount;
				_dbContext.CPayments.Add(payment);
				_dbContext.SaveChanges();
				return RedirectToPage("./ListCustomerInvoice");
			}
			catch (Exception ex)
			{
				return Page();
			}
		}

		public JsonResult OnPostInvoice([FromBody] CInvoice cInvoice)
		{
			try
			{
				var memo = cInvoice?.Ref ?? "";
				var taxes = _dbContext.Taxes.Where(t => !(bool)t.Closed)
					.Select(t => new Tax
					{
						Name = t.Name,
						GlAccount = t.GlAccount,
						Rate = t.Rate
					}).ToList();
				var invoice = _dbContext.CInvoices.Include(i => i.CInvoiceDetails)
					.FirstOrDefault(i => i.Ref.ToUpper().Equals(memo.ToUpper()));
				var isPaid = _dbContext.CPayments.Any(p => p.Memo.ToUpper().Equals(memo.ToUpper()));
				var accounts = _dbContext.AccountCharts.Where(a => !(bool)a.Closed)
					.Select(a => new AccountChart
					{
						Code = a.Code,
						Name = a.Name
					}).ToList();
				var results = new
				{
					invoice,
					isPaid,
					taxes,
					accounts
				};
				return new JsonResult(results);
			}
			catch (Exception)
			{
				return new JsonResult("");
			}
		}
	}
}
