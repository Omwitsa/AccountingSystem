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
	public class BackCashModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<JournalVm> Banks { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public BackCashModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
        }
        public void OnGet()
        {
            try
            {
                Success = true;
                Banks = new List<JournalVm>();
                var vPayments = _dbContext.VPayments.ToList();
                var details = new List<JournalDetailsVm>();
                vPayments.ForEach(p =>
                {
                    details.Add(new JournalDetailsVm
                    {
                        Date = p.CreatedDate,
                        Ref = p.Memo,
                        GlAccount = "Outstanding Payments",
                        Partner = p.Vender,
                        Debit = 0,
                        Credit = p.Amount
                    });

                    details.Add(new JournalDetailsVm
                    {
                        Date = p.CreatedDate,
                        Ref = p.Memo,
                        GlAccount = "Account Payable",
                        Partner = p.Vender,
                        Debit = p.Amount,
                        Credit = 0
                    });
                });

                var cPayments = _dbContext.CPayments.ToList();
                cPayments.ForEach(p =>
                {
                    details.Add(new JournalDetailsVm
                    {
                        Date = p.CreatedDate,
                        Ref = p.Memo,
                        GlAccount = "Outstanding Receipts",
                        Partner = p.Customer,
                        Debit = p.Amount,
                        Credit = 0
                    });

                    details.Add(new JournalDetailsVm
                    {
                        Date = p.CreatedDate,
                        Ref = p.Memo,
                        GlAccount = "Account Receivable",
                        Partner = p.Customer,
                        Debit = 0,
                        Credit = p.Amount
                    });
                });

                var groupPayments = details.OrderByDescending(d => d.Date)
                    .GroupBy(d => d.Ref).ToList();
                groupPayments.ForEach(p =>
                {
                    Banks.Add(new JournalVm
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
