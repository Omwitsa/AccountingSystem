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
                var patners = _dbContext.Customers.Select(c => c.Name).ToList();
                var vendors = _dbContext.Venders.Select(v => v.Name).ToList();
                patners.AddRange(vendors);
                patners.ForEach(p =>
                {
                    var bills = _dbContext.Bills.Include(b => b.BillJournals).Where(b => b.Vender.ToUpper().Equals(p.ToUpper())).ToList();
                    bills.ForEach(b =>
                    {
                        foreach(var journal in b.BillJournals)
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

                    var refunds = _dbContext.Refunds.Include(b => b.RefundJournals).Where(b => b.Vendor.ToUpper().Equals(p.ToUpper())).ToList();
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

                    var invoices = _dbContext.CInvoices.Include(b => b.CInvoiceDetails).Where(b => b.Customer.ToUpper().Equals(p.ToUpper())).ToList();
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

                    var notes = _dbContext.CreditNotes.Include(b => b.CreditNoteDetails).Where(b => b.Customer.ToUpper().Equals(p.ToUpper())).ToList();
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

                    var vPayments = _dbContext.VPayments.Where(v => v.Vender.ToUpper().Equals(p.ToUpper())).ToList();
                    vPayments.ForEach(i =>
                    {
                        details.Add(new JournalDetailsVm
                        {
                            Partner = i.Vender,
                            GlAccount = "Account Payable",
                            Label = "Account Payable",
                            Debit = i.Amount,
                            Credit = 0
                        });
                    });

                    var cPayments = _dbContext.CPayments.Where(v => v.Customer.ToUpper().Equals(p.ToUpper())).ToList();
                    cPayments.ForEach(i =>
                    {
                        details.Add(new JournalDetailsVm
                        {
                            Partner = i.Customer,
                            GlAccount = "Account Receivable",
                            Label = "Account Receivable",
                            Debit = 0,
                            Credit = i.Amount
                        });
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
                   .GroupBy(d => d.Partner).ToList();
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
