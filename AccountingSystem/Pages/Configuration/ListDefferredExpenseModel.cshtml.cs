using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
	public class ListDefferredExpenseModelModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<DefferredExpenseModel> DefferredExpenseModels { get; set; }
        [BindProperty]
        public DefferredExpenseModel DefferredExpenseModel { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListDefferredExpenseModelModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            DefferredExpenseModel = new DefferredExpenseModel();
        }
        public IActionResult OnGet()
        {
            try
            {
                DefferredExpenseModels = _dbContext.DefferredExpenseModels.ToList();
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
                DefferredExpenseModels = _dbContext.DefferredExpenseModels.Where(e =>
               (string.IsNullOrEmpty(DefferredExpenseModel.Name) || e.Name.ToUpper().Equals(DefferredExpenseModel.Name.ToUpper()))
               && (string.IsNullOrEmpty(DefferredExpenseModel.GlAccount) || e.GlAccount.ToUpper().Equals(DefferredExpenseModel.GlAccount.ToUpper()))
               && (string.IsNullOrEmpty(DefferredExpenseModel.Journal) || e.Journal.ToUpper().Equals(DefferredExpenseModel.Journal.ToUpper()))
               && (string.IsNullOrEmpty(DefferredExpenseModel.Personnel) || e.Personnel.ToUpper().Equals(DefferredExpenseModel.Personnel.ToUpper()))
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

            return RedirectToPage("./EditDefferredExpenseModel", new { id = id });
        }

        public IActionResult OnPostDelete(Guid id)
        {
            try
            {
                var model = _dbContext.DefferredExpenseModels.FirstOrDefault(d => d.Id == id);
                if (model == null)
				{
                    Success = false;
                    Message = "Sorry, Expense model not found";
                    return Page();
                }
                   
                _dbContext.DefferredExpenseModels.Remove(model);
                _dbContext.SaveChanges();
                Success = true;
                Message = "Expense model deleted successfully";
                return Page();
            }
            catch (Exception)
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
