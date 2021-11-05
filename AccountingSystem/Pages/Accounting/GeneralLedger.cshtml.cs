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
                var accounts = _dbContext.AccountCharts.Where(a => !(bool)a.Closed).ToList();
                accounts.ForEach(a =>
                {
                    var billJournals = _dbContext.BillJournals.Where(j => j.GlAccount.ToUpper().Equals(a.Code.ToUpper())).ToList();
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

                    var refundJournals = _dbContext.RefundJournals.Where(j => j.GlAccount.ToUpper().Equals(a.Code.ToUpper())).ToList();
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

                    var invoiceJournals = _dbContext.CInvoiceJournal.Where(j => j.GlAccount.ToUpper().Equals(a.Code.ToUpper())).ToList();
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

                    var notesJournals = _dbContext.CreditNoteJournals.Where(j => j.GlAccount.ToUpper().Equals(a.Code.ToUpper())).ToList();
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
                });

                var vPayments = _dbContext.VPayments.ToList();
                vPayments.ForEach(i =>
                {
                    details.Add(new JournalDetailsVm
                    {
                        GlAccount = "Outstanding Payments",
                        Label = "Outstanding Payments",
                        Debit = 0,
                        Credit = i.Amount
                    });
                    details.Add(new JournalDetailsVm
                    {
                        GlAccount = "Account Payable",
                        Label = "Account Payable",
                        Debit = i.Amount,
                        Credit = 0
                    });
                });

                var cPayments = _dbContext.CPayments.ToList();
                cPayments.ForEach(i =>
                {
                    details.Add(new JournalDetailsVm
                    {
                        GlAccount = "Outstanding Receipts",
                        Label = "Outstanding Receipts",
                        Debit = i.Amount,
                        Credit = 0
                    });
                    details.Add(new JournalDetailsVm
                    {
                        GlAccount = "Account Receivable",
                        Label = "Account Receivable",
                        Debit = 0,
                        Credit = i.Amount
                    });
                });

                var groupLedgers = details.OrderByDescending(d => d.Date)
                   .GroupBy(d => d.GlAccount).ToList();
                Ledgers = new List<JournalVm>();
                groupLedgers.ForEach(p =>
                {
                    Ledgers.Add(new JournalVm
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
