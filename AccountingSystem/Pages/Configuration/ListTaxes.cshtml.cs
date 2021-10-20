using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
	public class ListTaxesModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<Tax> Taxes { get; set; }
        [BindProperty]
        public Tax Tax { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListTaxesModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            Tax = new Tax();
        }
        public IActionResult OnGet()
        {
            try
            {
                Taxes = _dbContext.Taxes.ToList();
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
                Taxes = _dbContext.Taxes.Where(t =>
                (string.IsNullOrEmpty(Tax.Name) || t.Name.ToUpper().Equals(Tax.Name.ToUpper()))
                && (string.IsNullOrEmpty(Tax.Type) || t.Type.ToUpper().Equals(Tax.Type.ToUpper()))
                && (string.IsNullOrEmpty(Tax.Personnel) || t.Personnel.ToUpper().Equals(Tax.Personnel.ToUpper()))
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

            return RedirectToPage("./EditTax", new { id = id });
        }

        public IActionResult OnPostDelete(Guid id)
        {
            try
            {
                var tax = _dbContext.Taxes.FirstOrDefault(t => t.Id == id);
                if (tax == null)
				{
                    Success = false;
                    Message = "Sorry, tax not found";
                    return Page();
                }
                    
                _dbContext.Taxes.Remove(tax);
                _dbContext.SaveChanges();
                Success = true;
                Message = "Tax deleted successfully";
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
