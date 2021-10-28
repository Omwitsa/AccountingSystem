using AccountingSystem.Model.Accounting;
using AccountingSystem.ViewModel;
using System;
using System.Collections.Generic;

namespace AccountingSystem.IProvider
{
	public interface IAccountingProvider
	{
		ReturnData<IEnumerable<JournalVm>> GetSales(JournalVm journal);
		ReturnData<IEnumerable<JournalVm>> GetPurchases(JournalVm journal);
		ReturnData<IEnumerable<BackCashVm>> GetBackCash(BackCashVm backCash);
		ReturnData<IEnumerable<BackCashVm>> GetMiscellaneous(BackCashVm backCash);
		ReturnData<IEnumerable<GeneralLedgerVm>> GetGeneralLedger(GeneralLedgerVm ledgerVm);
		ReturnData<IEnumerable<PartnerLedgerVm>> GetPartnerLedger(PartnerLedgerVm ledgerVm);
	}
}
