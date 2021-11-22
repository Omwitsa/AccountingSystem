using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using AccountingSystem.Model.System;
using AccountingSystem.Model.Venders;
using AccountingSystem.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

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
		public RefundDetail RefundDetail { get; set; }
		//[TempData]
		//public List<RefundDetail> RefundDetails { get; set; }
		[BindProperty]
		public bool Success { get; set; }
		[BindProperty]
		public string Message { get; set; }
		[TempData]
		public Guid Id { get; set; }
		private Util util = new Util();
		private readonly UserManager<ApplicationUser> _userManager;
		public EditRefundsModel(AccountingSystemContext dbContext, UserManager<ApplicationUser> userManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
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
						Name = b.Name,
						AccNo=b.AccNo
					}).ToList();
				IncoTerms = _dbContext.IncoTerms
					.Select(t => new IncoTerm
					{
						Name = t.Name
					}).ToList();
				Products = _dbContext.VProducts.Where(p => !(bool)p.Closed)
					.Select(p => new VProduct
					{
						Name = p.Name,
						Cost = p.Cost
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
				RefundDetail = new RefundDetail();
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

		public IActionResult OnPost([FromBody] Refund refund)
		{
			try
			{
				refund.Personnel = _userManager.GetUserName(User);
				refund.CreatedDate = DateTime.UtcNow.AddHours(3);
				refund.ModifiedDate = DateTime.UtcNow.AddHours(3);
				if (string.IsNullOrEmpty(refund.Vendor))
				{
					Success = false;
					Message = "Sorry, Kindly provide vendor";
					return Page();
				}

				if (string.IsNullOrEmpty(refund.Journal))
				{
					Success = false;
					Message = "Sorry, Kindly provide journal";
					return Page();
				}
				if (!refund.RefundDetails.Any())
				{
					Success = false;
					Message = "Sorry, Kindly provide refund items";
					return Page();
				}

				refund.Status = "Posted";
				foreach (var detail in refund.RefundDetails)
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
					refund.Ref = savedRefund.Ref;
					refund.CreatedDate = savedRefund.CreatedDate;
					var details = _dbContext.RefundDetails.Where(b => b.RefundId == savedRefund.Id);
					if (details.Any())
						_dbContext.RefundDetails.RemoveRange(details);
					var journals = _dbContext.RefundJournals.Where(b => b.RefundId == savedRefund.Id);
					if (journals.Any())
						_dbContext.RefundJournals.RemoveRange(journals);
					_dbContext.Refunds.Remove(savedRefund);
				}
				else
				{
					var suffix = "RBILL";
					refund.Ref = $"{suffix}1";
					var refund1 = _dbContext.Refunds.ToList()
						.OrderByDescending(i => Convert.ToInt32(i.Ref.Substring(suffix.Length))).FirstOrDefault();
					if (refund1 != null)
						refund.Ref = util.GetRef(refund1.Ref, suffix);
				}
				_dbContext.Audits.Add(new Audit
				{
					UserName = refund.Personnel,
					Date = DateTime.UtcNow.AddHours(3),
					Reference = reference,
					ModuleId = "Venders"
				});

				_dbContext.Refunds.Add(refund);
				_dbContext.SaveChanges();
				Success = true;
				Message = "Refund saved successfully";
				return RedirectToPage("./ListRefunds");
			}
			catch (Exception ex)
			{
				Success = false;
				Message = "Sorry, An error occurred";
				return Page();
			}
		}

		public IActionResult OnPostPayment([FromBody] VPayment payment)
		{
			try
			{
				payment.Personnel = _userManager.GetUserName(User);
				if (string.IsNullOrEmpty(payment.Vender))
				{
					Success = false;
					Message = "Kindly provide vendor";
					return Page();
				}
				var vender = _dbContext.Venders.FirstOrDefault(c => c.Name.ToUpper().Equals(payment.Vender.ToUpper()));
				payment.GlAccount = vender.APGlAccount;
				_dbContext.VPayments.Add(payment);
				_dbContext.SaveChanges();
				return RedirectToPage("./ListRefunds");
			}
			catch (Exception ex)
			{
				return Page();
			}
		}

		public JsonResult OnPostRefund([FromBody] Refund vRefund)
		{
			try
			{
				var memo = vRefund?.Ref ?? "";
				var taxes = _dbContext.Taxes.Where(t => !(bool)t.Closed)
					.Select(t => new Tax
					{
						Name = t.Name,
						GlAccount = t.GlAccount,
						Rate = t.Rate
					}).ToList();
				var refund = _dbContext.Refunds.Include(i => i.RefundDetails)
					.FirstOrDefault(i => i.Ref.ToUpper().Equals(memo.ToUpper()));
				var isPaid = _dbContext.VPayments.Any(p => p.Memo.ToUpper().Equals(memo.ToUpper()));
				var accounts = _dbContext.AccountCharts.Where(a => !(bool)a.Closed)
					.Select(a => new AccountChart
					{
						Code = a.Code,
						Name = a.Name
					}).ToList();
				var results = new
				{
					refund,
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
