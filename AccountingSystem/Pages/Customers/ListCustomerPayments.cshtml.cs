using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Customers
{
	public class ListCustomerPaymentsModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<CPayment> Payments { get; set; }
        [BindProperty]
        public CPayment Payment { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListCustomerPaymentsModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            Payment = new CPayment();
        }
        public IActionResult OnGet()
        {
            try
            {
                Payments = _dbContext.CPayments.ToList();
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
                Payments = _dbContext.CPayments.Where(p =>
                (string.IsNullOrEmpty(Payment.Customer) || p.Customer.ToUpper().Equals(Payment.Customer.ToUpper()))
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

            return RedirectToPage("./EditCustomerPayments", new { id = id });
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
