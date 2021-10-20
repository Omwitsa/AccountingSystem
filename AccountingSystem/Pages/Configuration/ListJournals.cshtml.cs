using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
	public class ListJournalsModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<Journal> Journals { get; set; }
        [BindProperty]
        public Journal Journal { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListJournalsModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            Journal = new Journal();
        }
        public IActionResult OnGet()
        {
            try
            {
                Journals = _dbContext.Journals.ToList();
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
                Journals = _dbContext.Journals.Where(j =>
                (string.IsNullOrEmpty(Journal.Name) || j.Name.ToUpper().Equals(Journal.Name.ToUpper()))
                && (string.IsNullOrEmpty(Journal.Type) || j.Type.ToUpper().Equals(Journal.Type.ToUpper()))
                && (string.IsNullOrEmpty(Journal.Personnel) || j.Personnel.ToUpper().Equals(Journal.Personnel.ToUpper()))
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

            return RedirectToPage("./EditJournal", new { id = id });
        }

        public IActionResult OnPostDelete(Guid id)
        {
            return Page();
        }

        public void OnPostView(Guid id)
        {
        }
    }
}
