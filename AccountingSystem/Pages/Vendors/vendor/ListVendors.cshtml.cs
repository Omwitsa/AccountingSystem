using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Venders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Vendors
{
	public class ListVendorsModel : PageModel
    {
       private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<Vender> Venders { get; set; }
        [BindProperty]
        public Vender Vender { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListVendorsModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            Vender = new Vender();
        }
        public IActionResult OnGet()
        {
            try
            {
                Venders = _dbContext.Venders.ToList();
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
                Venders = _dbContext.Venders.Where(v =>
               (string.IsNullOrEmpty(Vender.Name) || v.Name.ToUpper().Equals(Vender.Name.ToUpper()))
               && (string.IsNullOrEmpty(Vender.Country) || v.Country.ToUpper().Equals(Vender.Country.ToUpper()))
               && (string.IsNullOrEmpty(Vender.Industry) || v.Industry.ToUpper().Equals(Vender.Industry.ToUpper()))
               && (string.IsNullOrEmpty(Vender.Bank) || v.Bank.ToUpper().Equals(Vender.Bank.ToUpper()))
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

            return RedirectToPage("./EditVendor", new { id = id });
        }

        public IActionResult OnPostDelete(Guid id)
        {
            try
            {
                var vender = _dbContext.Venders.FirstOrDefault(v => v.Id == id);
                if (vender == null)
				{
                    Success = false;
                    Message = "Sorry, Vendor not found";
                    return Page();
                }
                    
                vender.Name = vender?.Name ?? "";
                if (_dbContext.Bills.Any(b => b.Vender.ToUpper().Equals(vender.Name.ToUpper())))
				{
                    Success = false;
                    Message = "Sorry, Vendor already billed. Can't be deleted";
                    return Page();
                }
                    
                _dbContext.Venders.Remove(vender);
                _dbContext.SaveChanges();
                Success = true;
                Message = "Vendor deleted successfully";
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
