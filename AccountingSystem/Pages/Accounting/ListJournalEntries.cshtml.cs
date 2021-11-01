using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Accounting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Accounting
{
	public class ListJournalEntriesModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<JournalEntry> JournalEntries { get; set; }
        [BindProperty]
        public JournalEntry JournalEntry { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListJournalEntriesModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            JournalEntry = new JournalEntry();
        }
        public IActionResult OnGet()
        {
            try
            {
                JournalEntries = _dbContext.JournalEntries.ToList();
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
                JournalEntries = _dbContext.JournalEntries.Where(b =>
                (string.IsNullOrEmpty(JournalEntry.No) || b.No.ToUpper().Equals(JournalEntry.No.ToUpper()))
                && (string.IsNullOrEmpty(JournalEntry.Journal) || b.Journal.ToUpper().Equals(JournalEntry.Journal.ToUpper()))
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

            return RedirectToPage("./EditJournalEntry", new { id = id });
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
