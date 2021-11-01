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
	public class EditbillModel : PageModel
    {
		private AccountingSystemContext _dbContext;
        private Guid id;

        [BindProperty]
		public Bill Bill { get; set; }
		[BindProperty]
		public BillDetail BillDetail { get; set; }
		[BindProperty]
		public List<Vender> Venders { get; set; }
		[BindProperty]
		public List<Journal> Journals { get; set; }

		[BindProperty]
		public List<AccountChart> Accounts { get; set; }
		[BindProperty]
		public List<Tax> Taxes { get; set; }
		[BindProperty]
		public List<IncoTerm> IncoTerms { get; set; }
		[BindProperty]
		public List<VProduct> Products { get; set; }
		[BindProperty]
		public List<Bank> Banks { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }

		public EditbillModel(AccountingSystemContext dbContext)
		{
			_dbContext = dbContext;
			Success = true;
			BillDetail = new BillDetail();
		}
		public void OnGet()
		{
			try
			{
				Taxes = _dbContext.Taxes.Where(ta => !(bool)ta.Closed)
					.Select(ta => new Tax
					{
						Type = ta.Type,
						Name = ta.Name
					}).ToList();
				Venders = _dbContext.Venders.Where(v => !(bool)v.Closed)
					.Select(v => new Vender
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
				Products = _dbContext.VProducts.Where(p => !(bool)p.Closed)
					.Select(p => new VProduct
					{
						Name = p.Name
					}).ToList();
				Accounts = _dbContext.AccountCharts.Where(c => !(bool)c.Closed)
					.Select(c => new AccountChart
					{
						Name = c.Name,
						Code = c.Code
					}).ToList();
				Bill = _dbContext.Bills.FirstOrDefault(b => b.Id == id);
				if (Bill != null)
					Id = Bill.Id;
			}
			catch (Exception)
			{
				Success = false;
				Message = "Sorry, An error occurred";
			}
		}
		public IActionResult OnPost([FromBody] Bill bill)
		{
			try
			{
				bill.CreatedDate = DateTime.UtcNow.AddHours(3);
				bill.ModifiedDate = DateTime.UtcNow.AddHours(3);
				bill.Date = DateTime.UtcNow.AddHours(3);
				if (string.IsNullOrEmpty(bill.Vender))
				{
					Success = false;
					Message = "Sorry, Kindly provide vendor";
					return Page();
				}


				if (string.IsNullOrEmpty(bill.Journal))
				{
					Success = false;
					Message = "Sorry, Kindly provide journal";
					return Page();
				}
				
				if (!bill.BillDetails.Any())
				{
					Success = false;
					Message = "Sorry, Kindly provide invoice items";
					return Page();
				}

				foreach (var detail in bill.BillDetails)
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
				var reference = "Add Bill";
				var savedBill = _dbContext.Bills.FirstOrDefault(b => b.Id == Id);
				if (savedBill != null)
				{
					reference = "Edit Bill";
					bill.CreatedDate = savedBill.CreatedDate;
					if (savedBill != null)
					{
						var details = _dbContext.BillDetails.Where(b => b.BillId == savedBill.Id);
						if (details.Any())
							_dbContext.BillDetails.RemoveRange(details);
						var journals = _dbContext.BillJournals.Where(b => b.BillId == savedBill.Id);
						if (journals.Any())
							_dbContext.BillJournals.RemoveRange(journals);
						_dbContext.Bills.Remove(savedBill);
					}
				}
				_dbContext.Audits.Add(new Audit
				{
					UserName = bill.Personnel,
					Date = DateTime.UtcNow.AddHours(3),
					Reference = reference,
					ModuleId = "Venders"
				});

				_dbContext.Bills.Add(bill);
				_dbContext.SaveChanges();
				Success = true;
				Message = "Bill saved successfully";
				return RedirectToPage("./Listbill");
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
