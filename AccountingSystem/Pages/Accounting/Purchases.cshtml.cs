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
                var details = new List<JournalDetailsVm>();
                var bills = _dbContext.Bills.Include(i => i.BillJournals).ToList();
                bills.ForEach(i =>
                {
                    foreach (var journal in i.BillJournals)
                    {
                        details.Add(new JournalDetailsVm
                        {
                            Date = i.CreatedDate,
                            Ref = i.Ref,
                            GlAccount = journal.GlAccount,
                            Partner = i.Vender,
                            Label = journal.Label,
                            DueDate = i.DueDate,
                            Debit = journal.Debit,
                            Credit = journal.Credit
                        });
                    }
                });

                var refunds = _dbContext.Refunds.Include(i => i.RefundJournals).ToList();
                refunds.ForEach(i =>
                {
                    foreach (var journal in i.RefundJournals)
                    {
                        details.Add(new JournalDetailsVm
                        {
                            Date = i.CreatedDate,
                            Ref = i.Ref,
                            GlAccount = journal.GlAccount,
                            Partner = i.Vendor,
                            Label = journal.Label,
                            DueDate = i.DueDate,
                            Debit = journal.Debit,
                            Credit = journal.Credit
                        });
                    }
                });

                var groupPurchases = details.OrderByDescending(d => d.Date)
                   .GroupBy(d => d.Ref).ToList();
                groupPurchases.ForEach(p =>
                {
                    Purchases.Add(new JournalVm
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
