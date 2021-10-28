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
                var invoices = _dbContext.CInvoices.Include(i => i.CInvoiceJournals)
                    .OrderByDescending(i => i.CreatedDate).ToList();
                var groupedInvoices = invoices.GroupBy(i => i.Ref).ToList();
                groupedInvoices.ForEach(i =>
                {
                    var details = new List<JournalDetailsVm>();
                    i.ToList().ForEach(d => {
                        foreach (var journal in d.CInvoiceJournals)
                        {
                            details.Add(new JournalDetailsVm
                            {
                                Date = d.CreatedDate,
                                Ref = d.Ref,
                                GlAccount = journal.GlAccount,
                                Partner = d.Customer,
                                Label = journal.Label,
                                DueDate = d.DueDate,
                                Debit = journal.Debit,
                                Credit = journal.Credit
                            });
                        }
                    });

                    Sales.Add(new JournalVm
                    {
                        Ref = i.Key,
                        Debit = details.Sum(d => d.Debit),
                        Credit = details.Sum(d => d.Credit),
                        Details = details
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
