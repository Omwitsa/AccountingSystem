using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
	public class ListIncoTermModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<IncoTerm> IncoTerms { get; set; }
        [BindProperty]
        public IncoTerm IncoTerm { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListIncoTermModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            IncoTerm = new IncoTerm();
        }
        public IActionResult OnGet()
        {
            try
            {
                IncoTerms = _dbContext.IncoTerms.ToList();
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
                IncoTerms = _dbContext.IncoTerms.Where(t =>
                (string.IsNullOrEmpty(IncoTerm.Code) || t.Code.ToUpper().Equals(IncoTerm.Code.ToUpper()))
                && (string.IsNullOrEmpty(IncoTerm.Name) || t.Name.ToUpper().Equals(IncoTerm.Name.ToUpper()))
                && (string.IsNullOrEmpty(IncoTerm.Personnel) || t.Personnel.ToUpper().Equals(IncoTerm.Personnel.ToUpper()))
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

            return RedirectToPage("./EditIncoTerm", new { id = id });
        }

        public IActionResult OnPostDelete(Guid id)
        {
            try
            {
                var term = _dbContext.IncoTerms.FirstOrDefault(t => t.Id == id);
                if (term == null)
				{
                    Success = false;
                    Message = "Sorry, Terms not found";
                    return Page();
                }
                   
                _dbContext.IncoTerms.Remove(term);
                _dbContext.SaveChanges();
                Success = true;
                Message = "Terms deleted successfully";
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
