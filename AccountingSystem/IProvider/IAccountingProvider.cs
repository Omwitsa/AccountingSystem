using AccountingSystem.Model.Accounting;
using AccountingSystem.ViewModel;
using System;
using System.Collections.Generic;

namespace AccountingSystem.IProvider
{
	public interface IAccountingProvider
	{
		ReturnData<string> AddAsset(Asset asset, bool isEdit);
		ReturnData<dynamic> GetAssets(Asset asset);
		ReturnData<dynamic> GetAsset(Guid id);
		ReturnData<string> AddAutoTransfer(AutoTransfer transfer, bool isEdit);
		ReturnData<dynamic> GetAutoTransfers(AutoTransfer transfer);
		ReturnData<dynamic> GetAutoTransfer(Guid id);
		ReturnData<string> AddAutoTransfer(DefferredExpense expense, bool isEdit);
		ReturnData<dynamic> GetDefferredExpenses(DefferredExpense expense);
		ReturnData<dynamic> GetDefferredExpense(Guid id);
		ReturnData<string> AddDefferredRevenue(DefferredRevenue revenue, bool isEdit);
		ReturnData<dynamic> GetDefferredRevenues(DefferredRevenue revenue);
		ReturnData<dynamic> GetDefferredRevenue(Guid id);
		ReturnData<string> AddJournalEntry(JournalEntry entry, bool isEdit);
		ReturnData<dynamic> GetJournalEntries(JournalEntry entry);
		ReturnData<dynamic> GetJournalEntry(Guid id);
		ReturnData<string> AddLockDate(LockDate date, bool isEdit);
		ReturnData<dynamic> GetLockDates(LockDate date);
		ReturnData<dynamic> GetLockDate(Guid id);
		ReturnData<string> DeleteLockDate(Guid id);
		ReturnData<IEnumerable<JournalVm>> GetSales(JournalVm journal);
		ReturnData<IEnumerable<JournalVm>> GetPurchases(JournalVm journal);
		ReturnData<IEnumerable<BackCashVm>> GetBackCash(BackCashVm backCash);
		ReturnData<IEnumerable<BackCashVm>> GetMiscellaneous(BackCashVm backCash);
		ReturnData<IEnumerable<GeneralLedgerVm>> GetGeneralLedger(GeneralLedgerVm ledgerVm);
		ReturnData<IEnumerable<PartnerLedgerVm>> GetPartnerLedger(PartnerLedgerVm ledgerVm);
	}
}
