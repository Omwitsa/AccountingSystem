using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using AccountingSystem.Model.System;
using AccountingSystem.Model.Venders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Vendors
{
	public class EditRefundsModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public Refund Refund { get; set; }
		[BindProperty]
		public List<Vender> Venders { get; set; }
		[BindProperty]
		public List<Journal> Journals { get; set; }
		[BindProperty]
		public List<AccountChart> Accounts { get; set; }
		[BindProperty]
		public List<Bank> Banks { get; set; }
		[BindProperty]
		public List<IncoTerm> IncoTerms { get; set; }
		[BindProperty]
		public List<VProduct> Products { get; set; }
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

		public EditRefundsModel(AccountingSystemContext dbContext)
		{
			_dbContext = dbContext;
			Success = true;
		}

		public void OnGet(Guid id)
		{
			try
			{
				Venders = _dbContext.Venders.Where(v => !(bool)v.Closed)
					.Select(v => new Vender
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
					.Select(p => new VProduct
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
				Refund = _dbContext.Refunds.FirstOrDefault(r => r.Id == id);
				if (Refund != null)
					Id = Refund.Id;
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
				Refund.CreatedDate = DateTime.UtcNow.AddHours(3);
				Refund.ModifiedDate = DateTime.UtcNow.AddHours(3);
				if (string.IsNullOrEmpty(Refund.Vendor))
				{
					Success = false;
					Message = "Sorry, Kindly provide vendor";
					return Page();
				}


				if (string.IsNullOrEmpty(Refund.Journal))
				{
					Success = false;
					Message = "Sorry, Kindly provide journal";
					return Page();
				}

				if (!Refund.RefundDetails.Any())
				{
					Success = false;
					Message = "Sorry, Kindly provide refund items";
					return Page();
				}
					
				foreach (var detail in Refund.RefundDetails)
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
				var reference = "Add Refund";
				var savedRefund = _dbContext.Refunds.FirstOrDefault(b => b.Id == Id);
				if (savedRefund != null)
				{
					reference = "Edit Refund";
					Refund.CreatedDate = savedRefund.CreatedDate;
					if (savedRefund != null)
					{
						var details = _dbContext.RefundDetails.Where(b => b.RefundId == savedRefund.Id);
						if (details.Any())
							_dbContext.RefundDetails.RemoveRange(details);
						var journals = _dbContext.RefundJournals.Where(b => b.RefundId == savedRefund.Id);
						if (journals.Any())
							_dbContext.RefundJournals.RemoveRange(journals);
						_dbContext.Refunds.Remove(savedRefund);
					}
				}
				_dbContext.Audits.Add(new Audit
				{
					UserName = Refund.Personnel,
					Date = DateTime.UtcNow.AddHours(3),
					Reference = reference,
					ModuleId = "Venders"
				});

				_dbContext.Refunds.Add(Refund);
				_dbContext.SaveChanges();
				Success = true;
				Message = "Refund saved successfully";
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
