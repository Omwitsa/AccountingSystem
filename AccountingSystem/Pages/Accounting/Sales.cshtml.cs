using AccountingSystem.Data;
using AccountingSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountingSystem.Pages.Accounting
{
	public class SalesModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<JournalVm> Sales { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public SalesModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
        }
        public void OnGet()
        {
			try
			{
                Success = true;
                Sales = new List<JournalVm>();
                var details = new List<JournalDetailsVm>();
                var invoices = _dbContext.CInvoices.Include(i => i.CInvoiceJournals).ToList();
                invoices.ForEach(i =>
                {
                    foreach (var journal in i.CInvoiceJournals)
                    {
                        details.Add(new JournalDetailsVm
                        {
                            Date = i.CreatedDate,
                            Ref = i.Ref,
                            GlAccount = journal.GlAccount,
                            Partner = i.Customer,
                            Label = journal.Label,
                            DueDate = i.DueDate,
                            Debit = journal.Debit,
                            Credit = journal.Credit
                        });
                    }
                });

                var notes = _dbContext.CreditNotes.Include(i => i.CreditNoteJournals).ToList();
                notes.ForEach(i =>
                {
                    foreach (var journal in i.CreditNoteJournals)
                    {
                        details.Add(new JournalDetailsVm
                        {
                            Date = i.CreatedDate,
                            Ref = i.Ref,
                            GlAccount = journal.GlAccount,
                            Partner = i.Customer,
                            Label = journal.Label,
                            DueDate = i.DueDate,
                            Debit = journal.Debit,
                            Credit = journal.Credit
                        });
                    }
                });

                var groupSales = details.OrderByDescending(d => d.Date)
                   .GroupBy(d => d.Ref).ToList();
                groupSales.ForEach(p =>
                {
                    Sales.Add(new JournalVm
                    {
                        Ref = p.Key,
                        Debit = details.Sum(d => d.Debit),
                        Credit = details.Sum(d => d.Credit),
                        Details = p.ToList()
                    });
                });
            }
			catch (Exception ex)
			{

				throw;
			}
        }
    }
}
