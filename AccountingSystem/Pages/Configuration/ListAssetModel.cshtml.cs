using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
	public class ListAssetModelModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<AssetModel> AssetModels { get; set; }
        [BindProperty]
        public AssetModel AssetModel { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListAssetModelModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            AssetModel = new AssetModel();
        }
        public IActionResult OnGet()
        {
            try
            {
                AssetModels = _dbContext.AssetModels.ToList();
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
                AssetModels = _dbContext.AssetModels.Where(a =>
                    (string.IsNullOrEmpty(AssetModel.Name) || a.Name.ToUpper().Equals(AssetModel.Name.ToUpper()))
                    && (string.IsNullOrEmpty(AssetModel.GlAccount) || a.GlAccount.ToUpper().Equals(AssetModel.GlAccount.ToUpper()))
                    && (string.IsNullOrEmpty(AssetModel.Journal) || a.Journal.ToUpper().Equals(AssetModel.Journal.ToUpper()))
                    && (string.IsNullOrEmpty(AssetModel.Personnel) || a.Personnel.ToUpper().Equals(AssetModel.Personnel.ToUpper()))
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

            return RedirectToPage("./EditAssetModel", new { id = id });
        }

        public void OnPostDelete(Guid id)
        {

        }

        public void OnPostView(Guid id)
        {
           
        }

    }
}
