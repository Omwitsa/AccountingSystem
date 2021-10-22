using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Customers
{
	public class ListCustomerProductsModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<CProduct> Products { get; set; }
        [BindProperty]
        public CProduct Product { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListCustomerProductsModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            Product = new CProduct();
        }
        public IActionResult OnGet()
        {
            try
            {
                Products = _dbContext.CProducts.ToList();
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
                Products = _dbContext.CProducts.Where(p =>
                (string.IsNullOrEmpty(Product.Name) || p.Name.ToUpper().Equals(Product.Name.ToUpper()))
                && (string.IsNullOrEmpty(Product.Type) || p.Type.ToUpper().Equals(Product.Type.ToUpper()))
                && (string.IsNullOrEmpty(Product.Category) || p.Category.ToUpper().Equals(Product.Category.ToUpper()))
                && (string.IsNullOrEmpty(Product.Personnel) || p.Personnel.ToUpper().Equals(Product.Personnel.ToUpper()))
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

            return RedirectToPage("./EditCustomerProducts2", new { id = id });
        }

        public IActionResult OnPostDelete(Guid id)
        {
            try
            {
                var product = _dbContext.CProducts.FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    Success = false;
                    Message = "Sorry, Product not found";
                    return Page();
                }
                   
                product.Name = product?.Name ?? "";
                if (_dbContext.CInvoiceDetails.Any(b => b.Product.ToUpper().Equals(product.Name.ToUpper())))
                {
                    Success = false;
                    Message = "Sorry, the product has already been invoiced. It can't be deleted";
                    return Page();
                }
                   
                _dbContext.CProducts.Remove(product);
                _dbContext.SaveChanges();
                Success = true;
                Message = "Product deleted successfully";
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
