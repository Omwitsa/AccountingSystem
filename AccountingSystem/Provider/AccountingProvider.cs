using AccountingSystem.Data;
using AccountingSystem.IProvider;
using AccountingSystem.Model.Accounting;
using AccountingSystem.ViewModel;
using System;
using System.Collections.Generic;

namespace AccountingSystem.Provider
{
	public class AccountingProvider : IAccountingProvider
	{
		private AccountingSystemContext _dbContext;
		public AccountingProvider(AccountingSystemContext dbContext)
		{
			_dbContext = dbContext;
		}

		public ReturnData<string> AddAsset(Asset asset, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddAutoTransfer(AutoTransfer transfer, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddAutoTransfer(DefferredExpense expense, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddDefferredRevenue(DefferredRevenue revenue, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddJournalEntry(JournalEntry entry, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddLockDate(LockDate date, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> DeleteLockDate(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetAsset(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetAssets(Asset asset)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetAutoTransfer(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetAutoTransfers(AutoTransfer transfer)
		{
			throw new NotImplementedException();
		}

		public ReturnData<IEnumerable<BackCashVm>> GetBackCash(BackCashVm backCash)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetDefferredExpense(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetDefferredExpenses(DefferredExpense expense)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetDefferredRevenue(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetDefferredRevenues(DefferredRevenue revenue)
		{
			throw new NotImplementedException();
		}

		public ReturnData<IEnumerable<GeneralLedgerVm>> GetGeneralLedger(GeneralLedgerVm ledgerVm)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetJournalEntries(JournalEntry entry)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetJournalEntry(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetLockDate(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetLockDates(LockDate date)
		{
			throw new NotImplementedException();
		}

		public ReturnData<IEnumerable<BackCashVm>> GetMiscellaneous(BackCashVm backCash)
		{
			throw new NotImplementedException();
		}

		public ReturnData<IEnumerable<PartnerLedgerVm>> GetPartnerLedger(PartnerLedgerVm ledgerVm)
		{
			throw new NotImplementedException();
		}

		public ReturnData<IEnumerable<JournalVm>> GetPurchases(JournalVm journal)
		{
			throw new NotImplementedException();
		}

		public ReturnData<IEnumerable<JournalVm>> GetSales(JournalVm journal)
		{
			throw new NotImplementedException();
		}
	}
}
