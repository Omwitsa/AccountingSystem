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
	public class PartnerLedgerModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<JournalVm> Ledgers { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public PartnerLedgerModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
        }
        public void OnGet()
        {
            try
            {
                Success = true;
                var details = new List<JournalDetailsVm>();
                var bills = _dbContext.Bills.Include(b => b.BillJournals).ToList();
                bills.ForEach(b =>
                {
                    foreach (var journal in b.BillJournals)
                    {
                        details.Add(new JournalDetailsVm
                        {
                            Partner = b.Vender,
                            GlAccount = journal.GlAccount,
                            Label = journal.Label,
                            Debit = journal.Debit,
                            Credit = journal.Credit
                        });
                    }
                });

                var refunds = _dbContext.Refunds.Include(b => b.RefundJournals).ToList();
                refunds.ForEach(b =>
                {
                    foreach (var journal in b.RefundJournals)
                    {
                        details.Add(new JournalDetailsVm
                        {
                            Partner = b.Vendor,
                            GlAccount = journal.GlAccount,
                            Label = journal.Label,
                            Debit = journal.Debit,
                            Credit = journal.Credit
                        });
                    }
                });

                var invoices = _dbContext.CInvoices.Include(b => b.CInvoiceJournals).ToList();
                invoices.ForEach(b =>
                {
                    foreach (var journal in b.CInvoiceJournals)
                    {
                        details.Add(new JournalDetailsVm
                        {
                            Partner = b.Customer,
                            GlAccount = journal.GlAccount,
                            Label = journal.Label,
                            Debit = journal.Debit,
                            Credit = journal.Credit
                        });
                    }
                });

                var notes = _dbContext.CreditNotes.Include(b => b.CreditNoteJournals).ToList();
                notes.ForEach(b =>
                {
                    foreach (var journal in b.CreditNoteJournals)
                    {
                        details.Add(new JournalDetailsVm
                        {
                            Partner = b.Customer,
                            GlAccount = journal.GlAccount,
                            Label = journal.Label,
                            Debit = journal.Debit,
                            Credit = journal.Credit
                        });
                    }
                });

                var vPayments = _dbContext.VPayments.ToList();
                vPayments.ForEach(i =>
                {
                    var label = "Account Payable";
                    var account = _dbContext.AccountCharts.FirstOrDefault(a => a.Name.ToUpper().Equals(label.ToUpper()));
                    details.Add(new JournalDetailsVm
                    {
                        Partner = i.Vender,
                        GlAccount = account.Code,
                        Label = label,
                        Debit = i.Amount,
                        Credit = 0
                    });
                });

                var cPayments = _dbContext.CPayments.ToList();
                cPayments.ForEach(i =>
                {
                    var label = "Account Receivable";
                    var account = _dbContext.AccountCharts.FirstOrDefault(a => a.Name.ToUpper().Equals(label.ToUpper()));
                    details.Add(new JournalDetailsVm
                    {
                        Partner = i.Customer,
                        GlAccount = account.Code,
                        Label = label,
                        Debit = 0,
                        Credit = i.Amount
                    });
                });

                var groupLedgers = details.OrderByDescending(d => d.Date)
                   .GroupBy(d => d.Partner).ToList();
                Ledgers = new List<JournalVm>();
                groupLedgers.ForEach(p =>
                {
                    var key = p.Key.ToString();
                    Ledgers.Add(new JournalVm
                    {
                        Key = $"{key.Replace(" ", "")}",
                        Ref = key,
                        Debit = p.Sum(d => d.Debit),
                        Credit = p.Sum(d => d.Credit),
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
