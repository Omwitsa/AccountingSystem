using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Venders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Vendors
{
	public class ListPaymentModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<VPayment> Payments { get; set; }
        [BindProperty]
        public VPayment Payment { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListPaymentModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            Payment = new VPayment();
        }
        public IActionResult OnGet()
        {
            try
            {
                Payments = _dbContext.VPayments.ToList();
                return Page();
            }
            catch (Exception ex)
            {
                Success = false;
                Message = "Sorry, An error occurred";
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                Payments = _dbContext.VPayments.Where(p =>
                (string.IsNullOrEmpty(Payment.PartnerType) || p.PartnerType.ToUpper().Equals(Payment.PartnerType.ToUpper()))
                && (string.IsNullOrEmpty(Payment.Vendor) || p.Vendor.ToUpper().Equals(Payment.Vendor.ToUpper()))
                && (string.IsNullOrEmpty(Payment.GlAccount) || p.GlAccount.ToUpper().Equals(Payment.GlAccount.ToUpper()))
                && (string.IsNullOrEmpty(Payment.Journal) || p.Journal.ToUpper().Equals(Payment.Journal.ToUpper()))
                && (string.IsNullOrEmpty(Payment.BankAccount) || p.BankAccount.ToUpper().Equals(Payment.BankAccount.ToUpper()))
                && (string.IsNullOrEmpty(Payment.Personnel) || p.Personnel.ToUpper().Equals(Payment.Personnel.ToUpper()))
                ).ToList();
                return Page();
            }
            catch (Exception ex)
            {
                Success = false;
                Message = "Sorry, An error occurred";
                return Page();
            }
        }

        public IActionResult OnPostEdit(Guid id)
        {

            return RedirectToPage("./EditPayment", new { id = id });
        }

        public IActionResult OnPostDelete(Guid id)
        {
            return Page();
        }

        public void OnPostView(Guid id)
        {
        }
    }
}
