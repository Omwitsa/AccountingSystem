using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AccountingSystem.Pages.Accounting
{
	public class PurchasesModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<JournalVm> Purchases { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public PurchasesModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
        }
        public void OnGet()
        {
            try
            {
                Success = true;
                Purchases = new List<JournalVm>();
                var bills = _dbContext.Bills.Include(i => i.BillJournals)
                    .OrderByDescending(i => i.CreatedDate).ToList();
                var groupedBills = bills.GroupBy(i => i.Ref).ToList();
                groupedBills.ForEach(i =>
                {
                    var details = new List<JournalDetailsVm>();
                    i.ToList().ForEach(d => {
                        foreach (var journal in d.BillJournals)
                        {
                            details.Add(new JournalDetailsVm
                            {
                                Date = d.CreatedDate,
                                Ref = d.Ref,
                                GlAccount = journal.GlAccount,
                                Partner = d.Vender,
                                Label = journal.Label,
                                DueDate = d.DueDate,
                                Debit = journal.Debit,
                                Credit = journal.Credit
                            });
                        }
                    });

                    Purchases.Add(new JournalVm
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
