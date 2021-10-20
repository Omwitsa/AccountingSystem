using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
	public class ListDefferredRevenueModelsModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<DefferredRevenueModel> DefferredRevenueModels { get; set; }
        [BindProperty]
        public DefferredRevenueModel DefferredRevenueModel { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListDefferredRevenueModelsModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            DefferredRevenueModel = new DefferredRevenueModel();
        }
        public IActionResult OnGet()
        {
            try
            {
                DefferredRevenueModels = _dbContext.DefferredRevenueModels.ToList();
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
                DefferredRevenueModels = _dbContext.DefferredRevenueModels.Where(r =>
                (string.IsNullOrEmpty(DefferredRevenueModel.Name) || r.Name.ToUpper().Equals(DefferredRevenueModel.Name.ToUpper()))
                && (string.IsNullOrEmpty(DefferredRevenueModel.Journal) || r.Journal.ToUpper().Equals(DefferredRevenueModel.Journal.ToUpper()))
                && (string.IsNullOrEmpty(DefferredRevenueModel.GlAccount) || r.GlAccount.ToUpper().Equals(DefferredRevenueModel.GlAccount.ToUpper()))
                && (string.IsNullOrEmpty(DefferredRevenueModel.Personnel) || r.Personnel.ToUpper().Equals(DefferredRevenueModel.Personnel.ToUpper()))
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

            return RedirectToPage("./EditDefferredRevenueModel", new { id = id });
        }

        public IActionResult OnPostDelete(Guid id)
        {
            try
            {
                var model = _dbContext.DefferredRevenueModels.FirstOrDefault(m => m.Id == id);
                if (model == null)
				{
                    Success = false;
                    Message = "Sorry, Revenue model not found";
                    return Page();
                }
                   
                _dbContext.DefferredRevenueModels.Remove(model);
                _dbContext.SaveChanges();
                Success = true;
                Message = "Revenue model deleted successfully";
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
