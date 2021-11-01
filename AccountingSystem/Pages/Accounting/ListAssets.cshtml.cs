using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Accounting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Accounting
{
	public class ListAssetsModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<Asset> Assets { get; set; }
        [BindProperty]
        public Asset Asset { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListAssetsModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            Asset = new Asset();
        }
        public IActionResult OnGet()
        {
            try
            {
                Assets = _dbContext.Assets.ToList();
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
                Assets = _dbContext.Assets.Where(b =>
                (string.IsNullOrEmpty(Asset.Name) || b.Name.ToUpper().Equals(Asset.Name.ToUpper()))
                && (string.IsNullOrEmpty(Asset.DepreciationMethod) || b.DepreciationMethod.ToUpper().Equals(Asset.DepreciationMethod.ToUpper()))
                && (string.IsNullOrEmpty(Asset.AssetGlAccount) || b.AssetGlAccount.ToUpper().Equals(Asset.AssetGlAccount.ToUpper()))
                && (string.IsNullOrEmpty(Asset.DepreciationGlAccount) || b.DepreciationGlAccount.ToUpper().Equals(Asset.DepreciationGlAccount.ToUpper()))
                && (string.IsNullOrEmpty(Asset.Journal) || b.Journal.ToUpper().Equals(Asset.Journal.ToUpper()))
                && (string.IsNullOrEmpty(Asset.Personnel) || b.Personnel.ToUpper().Equals(Asset.Personnel.ToUpper()))
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

            return RedirectToPage("./EditAsset", new { id = id });
        }

        public IActionResult OnPostDelete(Guid id)
        {
            try
            {
                var asset = _dbContext.Assets.FirstOrDefault(b => b.Id == id);
                if (asset == null)
                {
                    Success = false;
                    Message = "Sorry, Asset not found";
                    return Page();
                }

                _dbContext.Assets.Remove(asset);
                _dbContext.SaveChanges();
                Success = true;
                Message = "Asset deleted successfully";
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
