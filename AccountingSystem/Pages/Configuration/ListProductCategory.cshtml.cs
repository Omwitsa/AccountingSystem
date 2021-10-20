using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
	public class ListProductCategoryModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<ProductCategory> ProductCategories { get; set; }
        [BindProperty]
        public ProductCategory ProductCategory { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListProductCategoryModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            ProductCategory = new ProductCategory();
        }
        public IActionResult OnGet()
        {
            try
            {
                ProductCategories = _dbContext.ProductCategories.ToList();
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
                ProductCategories = _dbContext.ProductCategories.Where(c =>
                (string.IsNullOrEmpty(ProductCategory.Name) || c.Name.ToUpper().Equals(ProductCategory.Name.ToUpper()))
                && (string.IsNullOrEmpty(ProductCategory.Personnel) || c.Personnel.ToUpper().Equals(ProductCategory.Personnel.ToUpper()))
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

            return RedirectToPage("./EditProductCategory", new { id = id });
        }

        public IActionResult OnPostDelete(Guid id)
        {
            try
            {
                var category = _dbContext.ProductCategories.FirstOrDefault(c => c.Id == id);
                if (category == null)
				{
                    Success = false;
                    Message = "Sorry, Category not found";
                    return Page();
                }
                    
                _dbContext.ProductCategories.Remove(category);
                _dbContext.SaveChanges();
                Success = true;
                Message = "Product category deleted successfully";
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
