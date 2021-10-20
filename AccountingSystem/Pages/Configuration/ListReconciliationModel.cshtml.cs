using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
	public class ListReconciliationModelModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<ReconciliationModel> ReconciliationModels { get; set; }
        [BindProperty]
        public ReconciliationModel ReconciliationModel { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListReconciliationModelModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            ReconciliationModel = new ReconciliationModel();
        }
        public IActionResult OnGet()
        {
            try
            {
                ReconciliationModels = _dbContext.ReconciliationModels.ToList();
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
                ReconciliationModels = _dbContext.ReconciliationModels.Where(r =>
                (string.IsNullOrEmpty(ReconciliationModel.Name) || r.Name.ToUpper().Equals(ReconciliationModel.Name.ToUpper()))
                && (string.IsNullOrEmpty(ReconciliationModel.Type) || r.Type.ToUpper().Equals(ReconciliationModel.Type.ToUpper()))
                && (string.IsNullOrEmpty(ReconciliationModel.Journal) || r.Journal.ToUpper().Equals(ReconciliationModel.Journal.ToUpper()))
                && (string.IsNullOrEmpty(ReconciliationModel.Personnel) || r.Personnel.ToUpper().Equals(ReconciliationModel.Personnel.ToUpper()))
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

            return RedirectToPage("./EditReconciliationModel", new { id = id });
        }

        public IActionResult OnPostDelete(Guid id)
        {
            try
            {
                var model = _dbContext.ReconciliationModels.FirstOrDefault(r => r.Id == id);
                if (model == null)
				{
                    Success = false;
                    Message = "Sorry, Reconciliation model not found";
                    return Page();
                }
                    
                _dbContext.ReconciliationModels.Remove(model);
                _dbContext.SaveChanges();
                Success = true;
                Message = "Reconciliation model deleted successfully";
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
