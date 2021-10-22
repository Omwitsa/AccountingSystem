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

		public EditCustomerCreditNotesModel(AccountingSystemContext dbContext)
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
				Products = _dbContext.VProducts.Where(p => !(bool)p.Closed)
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

		public IActionResult OnPost()
		{
			try
			{
				CreditNote.CreatedDate = DateTime.UtcNow.AddHours(3);
				CreditNote.ModifiedDate = DateTime.UtcNow.AddHours(3);
				if (string.IsNullOrEmpty(CreditNote.Customer))
                {
					Success = false;
					Message = "Sorry, Kindly provide customer";
					return Page();
				}


				if (string.IsNullOrEmpty(CreditNote.Journal))
                {
					Success = false;
					Message = "Sorry, Kindly provide journal";
					return Page();
				}

				if (!CreditNote.CreditNoteDetails.Any())
                {
					Success = false;
					Message = "Sorry, Kindly provide invoice items";
					return Page();
				}
					
				foreach (var detail in CreditNote.CreditNoteDetails)
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
					CreditNote.CreatedDate = savedNote.CreatedDate;
					if (savedNote != null)
					{
						var details = _dbContext.CreditNoteDetails.Where(b => b.CreditNoteId == savedNote.Id);
						if (details.Any())
							_dbContext.CreditNoteDetails.RemoveRange(details);
						var journals = _dbContext.CreditNoteJournals.Where(b => b.CreditNoteId == savedNote.Id);
						if (journals.Any())
							_dbContext.CreditNoteJournals.RemoveRange(journals);
						_dbContext.CreditNotes.Remove(savedNote);
					}
				}
				_dbContext.Audits.Add(new Audit
				{
					UserName = CreditNote.Personnel,
					Date = DateTime.UtcNow.AddHours(3),
					Reference = reference,
					ModuleId = "Customer"
				});

				_dbContext.CreditNotes.Add(CreditNote);
				_dbContext.SaveChanges();
				Success = true;
				Message = "Credit note saved successfully";
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
