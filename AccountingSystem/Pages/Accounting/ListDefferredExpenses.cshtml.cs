using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Accounting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Accounting
{
	public class ListDefferredExpensesModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<DefferredExpense> DefferredExpenses { get; set; }
        [BindProperty]
        public DefferredExpense DefferredExpense { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListDefferredExpensesModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            DefferredExpense = new DefferredExpense();
        }
        public IActionResult OnGet()
        {
            try
            {
                DefferredExpenses = _dbContext.DefferredExpenses.ToList();
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
                DefferredExpenses = _dbContext.DefferredExpenses.Where(b =>
                (string.IsNullOrEmpty(DefferredExpense.Name) || b.Name.ToUpper().Equals(DefferredExpense.Name.ToUpper()))
                && (string.IsNullOrEmpty(DefferredExpense.ExpenseGlAccount) || b.ExpenseGlAccount.ToUpper().Equals(DefferredExpense.ExpenseGlAccount.ToUpper()))
                && (string.IsNullOrEmpty(DefferredExpense.DeferredGlAccount) || b.DeferredGlAccount.ToUpper().Equals(DefferredExpense.DeferredGlAccount.ToUpper()))
                && (string.IsNullOrEmpty(DefferredExpense.Journal) || b.Journal.ToUpper().Equals(DefferredExpense.Journal.ToUpper()))
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

            return RedirectToPage("./EditDefferredExpense", new { id = id });
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
