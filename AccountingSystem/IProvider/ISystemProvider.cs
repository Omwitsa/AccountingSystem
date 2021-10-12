using AccountingSystem.Model.System;
using AccountingSystem.ViewModel;

namespace AccountingSystem.IProvider
{
	public interface ISystemProvider
	{
		ReturnData<string> AddAudit(Audit audit, bool isEdit);
		ReturnData<dynamic> GetAudits(Audit audit);
	}
}
