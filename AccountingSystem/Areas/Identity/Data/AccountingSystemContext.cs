using AccountingSystem.Model.Accounting;
using AccountingSystem.Model.Configuration;
using AccountingSystem.Model.Customers;
using AccountingSystem.Model.System;
using AccountingSystem.Model.Venders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccountingSystem.Data
{
	public class AccountingSystemContext : IdentityDbContext<ApplicationUser>
    {
        public AccountingSystemContext(DbContextOptions<AccountingSystemContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

		public virtual DbSet<Setting> Settings { get; set; }
		public virtual DbSet<IPaymentTerm> IPaymentTerms { get; set; }
		public virtual DbSet<IPaymentFollowupLevel> IPaymentFollowupLevels { get; set; }
		public virtual DbSet<IncoTerm> IncoTerms { get; set; }
		public virtual DbSet<Bank> Banks { get; set; }
		public virtual DbSet<ReconciliationModel> ReconciliationModels { get; set; }
		public virtual DbSet<AccountChart> AccountCharts { get; set; }
		public virtual DbSet<Tax> Taxes { get; set; }
		public virtual DbSet<Journal> Journals { get; set; }
		public virtual DbSet<AssetModel> AssetModels { get; set; }
		public virtual DbSet<DefferredRevenueModel> DefferredRevenueModels { get; set; }
		public virtual DbSet<ProductCategory> ProductCategories { get; set; }
		public virtual DbSet<DefferredExpenseModel> DefferredExpenseModels { get; set; }
		public virtual DbSet<JournalEntry> JournalEntries { get; set; }
		public virtual DbSet<AutoTransfer> AutoTransfers { get; set; }
		public virtual DbSet<OriginalAccount> OriginalAccounts { get; set; }
		public virtual DbSet<TransferredToAccount> TransferredToAccounts { get; set; }
		public virtual DbSet<Asset> Assets { get; set; }
		public virtual DbSet<DepreciationBoard> DepreciationBoards { get; set; }
		public virtual DbSet<DefferredRevenue> DefferredRevenues { get; set; }
		public virtual DbSet<RevenueBoard> RevenueBoards { get; set; }
		public virtual DbSet<DefferredExpense> DefferredExpenses { get; set; }
		public virtual DbSet<ExpenseBoard> ExpenseBoards { get; set; }
		public virtual DbSet<LockDate> LockDates { get; set; }
		public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<CProduct> CProducts { get; set; }
		public virtual DbSet<CPayment> CPayments { get; set; }
		public virtual DbSet<CreditNote> CreditNotes { get; set; }
		public virtual DbSet<CreditNoteDetail> CreditNoteDetails { get; set; }
		public virtual DbSet<CreditNoteJournal> CreditNoteJournals { get; set; }
		public virtual DbSet<CInvoice> CInvoices { get; set; }
		public virtual DbSet<CInvoiceDetail> CInvoiceDetails { get; set; }
		public virtual DbSet<CInvoiceJournal> CInvoiceJournal { get; set; }
		public virtual DbSet<Vender> Venders { get; set; }
		public virtual DbSet<VProduct> VProducts { get; set; }
		public virtual DbSet<VPayment> VPayments { get; set; }
		public virtual DbSet<Refund> Refunds { get; set; }
		public virtual DbSet<RefundDetail> RefundDetails { get; set; }
		public virtual DbSet<RefundJournal> RefundJournals { get; set; }
		public virtual DbSet<Bill> Bills { get; set; }
		public virtual DbSet<BillDetail> BillDetails { get; set; }
		public virtual DbSet<BillJournal> BillJournals { get; set; }
		public virtual DbSet<Audit> Audits { get; set; }
	}
}
