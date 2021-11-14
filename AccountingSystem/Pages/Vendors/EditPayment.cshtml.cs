using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using AccountingSystem.Model.Customers;
using AccountingSystem.Model.System;
using AccountingSystem.Model.Venders;
using Microsoft.AspNetCore.Identity;
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
		private readonly UserManager<ApplicationUser> _userManager;
		public EditPaymentModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
			Success = true;
			Payment = new VPayment();
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
				Accounts = _dbContext.AccountCharts.Where(c => !(bool)c.Closed && c.Type.ToLower().Equals("assets"))
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
				Payment.Personnel = _userManager.GetUserName(User);
				Payment.Date = DateTime.UtcNow.AddHours(3);
				if (string.IsNullOrEmpty(Payment.Vender))
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
				Payment.IsInternalTransfer = Payment.IsInternalTransfer == null ? false : Payment.IsInternalTransfer;
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
				Payment.Status = "Pending";
				var reference = "Add Payment";
				var savedPayment = _dbContext.VPayments.FirstOrDefault(p => p.Id == Id);
				if (savedPayment != null)
				{
					reference = "Edit Payment";
					savedPayment.ModifiedDate = DateTime.UtcNow.AddHours(3);
					savedPayment.Vender = Payment.Vender;
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
				return RedirectToPage("./ListPayment");
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
