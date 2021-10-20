using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
	public class ListIPaymentTermModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<IPaymentTerm> PaymentTerms { get; set; }
        [BindProperty]
        public IPaymentTerm PaymentTerm { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListIPaymentTermModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            PaymentTerm = new IPaymentTerm();
        }
        public IActionResult OnGet()
        {
            try
            {
                PaymentTerms = _dbContext.IPaymentTerms.ToList();
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
                PaymentTerms = _dbContext.IPaymentTerms.Where(t =>
                (string.IsNullOrEmpty(PaymentTerm.Term) || t.Term.ToUpper().Equals(PaymentTerm.Term.ToUpper()))
                && (string.IsNullOrEmpty(PaymentTerm.Personnel) || t.Personnel.ToUpper().Equals(PaymentTerm.Personnel.ToUpper()))
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

            return RedirectToPage("./EditIPaymentTerm", new { id = id });
        }

        public IActionResult OnPostDelete(Guid id)
        {
            try
            {
                var term = _dbContext.IPaymentTerms.FirstOrDefault(t => t.Id == id);
                if (term == null)
				{
                    Success = false;
                    Message = "Sorry, Payment terms not found";
                    return Page();
                }
                    
                _dbContext.IPaymentTerms.Remove(term);
                _dbContext.SaveChanges();
                Success = true;
                Message = "Payment terms deleted successfully";
                return Page();
            }
            catch (Exception ex)
            {
                Success = false;
                Message = "Sorry, An error occurred";
                return Page();
            }
        }

        public void OnPostView(Guid id)
        {
        }
    }
}
