using AccountingSystem.Model.Accounting;
using AccountingSystem.ViewModel;
using System;
using System.Collections.Generic;

namespace AccountingSystem.IProvider
{
	public interface IAccountingProvider
	{
		ReturnData<IEnumerable<JournalVm>> GetPurchases(JournalVm journal);
		ReturnData<IEnumerable<GeneralLedgerVm>> GetGeneralLedger(GeneralLedgerVm ledgerVm);
		ReturnData<IEnumerable<PartnerLedgerVm>> GetPartnerLedger(PartnerLedgerVm ledgerVm);
	}
}
