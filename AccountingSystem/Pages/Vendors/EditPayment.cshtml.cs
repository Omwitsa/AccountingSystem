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
	public class EditPaymentModel : PageModel
    {
		private AccountingSystemContext _dbContext;
		[BindProperty]
		public VPayment Payment { get; set; }
		[BindProperty]
		public List<Vender> Venders { get; set; }
		[BindProperty]
		public List<AccountChart> Accounts { get; set; }
		[BindProperty]
		public List<Bank> Banks { get; set; }
		[BindProperty]
		public List<Journal> Journals { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }

		public EditPaymentModel(AccountingSystemContext dbContext)
		{
			_dbContext = dbContext;
			Success = true;
		}

		public void OnGet(Guid id)
		{
			try
			{
				Venders = _dbContext.Venders.Where(c => !(bool)c.Closed)
					.Select(c => new Vender
					{
						Name = c.Name
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
				Accounts = _dbContext.AccountCharts.Where(c => !(bool)c.Closed)
					.Select(c => new AccountChart
					{
						Name = c.Name,
						Code = c.Code
					}).ToList();
				Payment = _dbContext.VPayments.FirstOrDefault(p => p.Id == id);
				if (Payment != null)
					Id = Payment.Id;
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
				Payment.Date = DateTime.UtcNow.AddHours(3);
				Payment.IsPayable = Payment?.IsPayable ?? false;
				Payment.IsReceivable = Payment?.IsReceivable ?? false;
				if (!(bool)Payment.IsPayable || !(bool)Payment.IsReceivable)
				{
					Success = false;
					Message = "Sorry, Kindly select payment type";
					return Page();
				}

				if (string.IsNullOrEmpty(Payment.PartnerType))
				{
					Success = false;
					Message = "Sorry, Kindly provide partner type";
					return Page();
				}

				if (string.IsNullOrEmpty(Payment.Vendor))
				{
					Success = false;
					Message = "Sorry, Kindly provide customer";
					return Page();
				}

				if (string.IsNullOrEmpty(Payment.GlAccount))
				{
					Success = false;
					Message = "Sorry, Kindly provide GL Account";
					return Page();
				}
					
				Payment.Amount = Payment?.Amount ?? 0;
				if (Payment.Amount < 1)
				{
					Success = false;
					Message = "Kindly provide amount";
					return Page();
				}

				if (string.IsNullOrEmpty(Payment.Journal))
				{
					Success = false;
					Message = "Sorry, Kindly provide journal";
					return Page();
				}

				if (string.IsNullOrEmpty(Payment.BankAccount))
				{
					Success = false;
					Message = "Sorry, Kindly provide bank account";
					return Page();
				}
					

				Payment.CreatedDate = DateTime.UtcNow.AddHours(3);
				Payment.ModifiedDate = DateTime.UtcNow.AddHours(3);
				var reference = "Add Payment";
				var savedPayment = _dbContext.VPayments.FirstOrDefault(p => p.Id == Id);
				if (savedPayment != null)
				{
					reference = "Edit Payment";
					savedPayment.ModifiedDate = DateTime.UtcNow.AddHours(3);
					savedPayment.IsPayable = Payment.IsPayable;
					savedPayment.IsReceivable = Payment.IsReceivable;
					savedPayment.PartnerType = Payment.PartnerType;
					savedPayment.Vendor = Payment.Vendor;
					savedPayment.GlAccount = Payment.GlAccount;
					savedPayment.IsInternalTransfer = Payment.IsInternalTransfer;
					savedPayment.Amount = Payment.Amount;
					savedPayment.Date = Payment.Date;
					savedPayment.Memo = Payment.Memo;
					savedPayment.Journal = Payment.Journal;
					savedPayment.BankAccount = Payment.BankAccount;
					savedPayment.Personnel = Payment.Personnel;
				}
				else
				{
					_dbContext.VPayments.Add(Payment);
				}

				_dbContext.Audits.Add(new Audit
				{
					UserName = Payment.Personnel,
					Date = DateTime.UtcNow.AddHours(3),
					Reference = reference,
					ModuleId = "Venders"
				});

				_dbContext.SaveChanges();
				Success = true;
				Message = "Payment saved successfully";
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
