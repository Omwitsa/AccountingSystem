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
	public class EditCustomerCreditNotesModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public CreditNote CreditNote { get; set; }
		[BindProperty]
		public List<Customer> Customers { get; set; }
		[BindProperty]
		public List<Journal> Journals { get; set; }
		[BindProperty]
		public List<AccountChart> Accounts { get; set; }
		[BindProperty]
		public List<Bank> Banks { get; set; }
		[BindProperty]
		public List<IncoTerm> IncoTerms { get; set; }
		[BindProperty]
		public List<CProduct> Products { get; set; }
		[BindProperty]
		public List<Tax> Taxes { get; set; }
		[BindProperty]
		public List<IPaymentTerm> PaymentTerms { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }
		private Util util = new Util();
		private readonly UserManager<ApplicationUser> _userManager;
		public EditCustomerCreditNotesModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
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
						Name = v.Name,
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
				Accounts = _dbContext.AccountCharts.Where(a => !(bool)a.Closed)
					.Select(a => new AccountChart
					{
						Name = a.Name,
						Code = a.Code
					}).ToList();
				Taxes = _dbContext.Taxes.Where(t => !(bool)t.Closed)
					.Select(t => new Tax
					{
						Name = t.Name
					}).ToList();
				PaymentTerms = _dbContext.IPaymentTerms
					.Select(t => new IPaymentTerm
					{
						Term = t.Term
					}).ToList();
				CreditNote = _dbContext.CreditNotes.FirstOrDefault(r => r.Id == id);
				if (CreditNote != null)
					Id = CreditNote.Id;
			}
			catch (Exception ex)
			{
				Success = false;
				Message = "Sorry, An error occurred";
			}
		}

		public IActionResult OnPost([FromBody] CreditNote note)
		{
			try
			{
				note.CreatedDate = DateTime.UtcNow.AddHours(3);
				note.ModifiedDate = DateTime.UtcNow.AddHours(3);
				note.Personnel = _userManager.GetUserName(User);
				if (string.IsNullOrEmpty(note.Customer))
                {
					Success = false;
					Message = "Sorry, Kindly provide customer";
					return Page();
				}


				if (string.IsNullOrEmpty(note.Journal))
                {
					Success = false;
					Message = "Sorry, Kindly provide journal";
					return Page();
				}

				if (!note.CreditNoteDetails.Any())
                {
					Success = false;
					Message = "Sorry, Kindly provide invoice items";
					return Page();
				}

				note.Status = "Posted";
				foreach (var detail in note.CreditNoteDetails)
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
				var reference = "Add Credit note";
				var savedNote = _dbContext.CreditNotes.FirstOrDefault(b => b.Id == Id);
				if (savedNote != null)
				{
					reference = "Edit Credit note";
					note.CreatedDate = savedNote.CreatedDate;
					note.Ref = savedNote.Ref;
					var details = _dbContext.CreditNoteDetails.Where(b => b.CreditNoteId == savedNote.Id);
					if (details.Any())
						_dbContext.CreditNoteDetails.RemoveRange(details);
					var journals = _dbContext.CreditNoteJournals.Where(b => b.CreditNoteId == savedNote.Id);
					if (journals.Any())
						_dbContext.CreditNoteJournals.RemoveRange(journals);
					_dbContext.CreditNotes.Remove(savedNote);
				}
				else
				{
					var suffix = "RINV";
					note.Ref = $"{suffix}1";
					var creditNote = _dbContext.CreditNotes.ToList()
						.OrderByDescending(i => Convert.ToInt32(i.Ref.Substring(suffix.Length))).FirstOrDefault();
					if (creditNote != null)
						note.Ref = util.GetRef(creditNote.Ref, suffix);
				}
				_dbContext.Audits.Add(new Audit
				{
					UserName = note.Personnel,
					Date = DateTime.UtcNow.AddHours(3),
					Reference = reference,
					ModuleId = "Customer"
				});

				_dbContext.CreditNotes.Add(note);
				_dbContext.SaveChanges();
				Success = true;
				Message = "Credit note saved successfully";
				return RedirectToPage("./ListCustomerCreditNotes");
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
				return RedirectToPage("./ListCustomerCreditNotes");
			}
			catch (Exception ex)
			{
				return Page();
			}
		}

		public JsonResult OnPostCreditNote([FromBody] CreditNote note)
		{
			try
			{
				var memo = note?.Ref ?? "";
				var taxes = _dbContext.Taxes.Where(t => !(bool)t.Closed)
					.Select(t => new Tax
					{
						Name = t.Name,
						GlAccount = t.GlAccount,
						Rate = t.Rate
					}).ToList();
				var creditNote = _dbContext.CreditNotes.Include(i => i.CreditNoteDetails)
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
					creditNote,
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
