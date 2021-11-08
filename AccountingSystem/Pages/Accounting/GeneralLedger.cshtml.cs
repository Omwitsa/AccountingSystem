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
	public class GeneralLedgerModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<JournalVm> Ledgers { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public GeneralLedgerModel(AccountingSystemContext dbContext)
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
                var billJournals = _dbContext.BillJournals.ToList();
                billJournals.ForEach(i =>
                {
                    details.Add(new JournalDetailsVm
                    {
                        GlAccount = i.GlAccount,
                        Label = i.Label,
                        Debit = i.Debit,
                        Credit = i.Credit
                    });
                });

                var refundJournals = _dbContext.RefundJournals.ToList();
                refundJournals.ForEach(i =>
                {
                    details.Add(new JournalDetailsVm
                    {
                        GlAccount = i.GlAccount,
                        Label = i.Label,
                        Debit = i.Debit,
                        Credit = i.Credit
                    });
                });

                var invoiceJournals = _dbContext.CInvoiceJournal.ToList();
                invoiceJournals.ForEach(i =>
                {
                    details.Add(new JournalDetailsVm
                    {
                        GlAccount = i.GlAccount,
                        Label = i.Label,
                        Debit = i.Debit,
                        Credit = i.Credit
                    });
                });

                var notesJournals = _dbContext.CreditNoteJournals.ToList();
                notesJournals.ForEach(i =>
                {
                    details.Add(new JournalDetailsVm
                    {
                        GlAccount = i.GlAccount,
                        Label = i.Label,
                        Debit = i.Debit,
                        Credit = i.Credit
                    });
                });

                var vPayments = _dbContext.VPayments.ToList();
                vPayments.ForEach(i =>
                {
                    var label = "Outstanding Payments";
                    var account = _dbContext.AccountCharts.FirstOrDefault(a => a.Name.ToUpper().Equals(label.ToUpper()));
                    details.Add(new JournalDetailsVm
                    {
                        GlAccount = account.Code,
                        Label = label,
                        Debit = 0,
                        Credit = i.Amount
                    });
                    label = "Account Payable";
                    account = _dbContext.AccountCharts.FirstOrDefault(a => a.Name.ToUpper().Equals(label.ToUpper()));
                    details.Add(new JournalDetailsVm
                    {
                        GlAccount = account.Code,
                        Label = label,
                        Debit = i.Amount,
                        Credit = 0
                    });
                });

                var cPayments = _dbContext.CPayments.ToList();
                cPayments.ForEach(i =>
                {
                    var label = "Outstanding Receipts";
                    var account = _dbContext.AccountCharts.FirstOrDefault(a => a.Name.ToUpper().Equals(label.ToUpper()));
                    details.Add(new JournalDetailsVm
                    {
                        GlAccount = account.Code,
                        Label = label,
                        Debit = i.Amount,
                        Credit = 0
                    });
                    label = "Account Receivable";
                    account = _dbContext.AccountCharts.FirstOrDefault(a => a.Name.ToUpper().Equals(label.ToUpper()));
                    details.Add(new JournalDetailsVm
                    {
                        GlAccount = account.Code,
                        Label = label,
                        Debit = 0,
                        Credit = i.Amount
                    });
                });

				var groupLedgers = details.OrderByDescending(d => d.Date)
                    .GroupBy(d => d.GlAccount).ToList();
                Ledgers = new List<JournalVm>();
                groupLedgers.ForEach(p =>
                {
                    var key = p.Key.ToString();
                    var account = _dbContext.AccountCharts.FirstOrDefault(a => a.Code.ToUpper().Equals(key.ToUpper()));
                    Ledgers.Add(new JournalVm
                    {
                        Key = $"A-{key}",
                        Ref = $"{key} {account.Name}",
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
