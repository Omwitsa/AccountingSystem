using AccountingSystem.Data;
using AccountingSystem.IProvider;
using AccountingSystem.Model.System;
using AccountingSystem.ViewModel;

namespace AccountingSystem.Provider
{
	public class SystemProvider : ISystemProvider
	{
		private AccountingSystemContext _dbContext;
		public SystemProvider(AccountingSystemContext dbContext)
		{
			_dbContext = dbContext;
		}

		public ReturnData<string> AddAudit(Audit audit, bool isEdit)
		{
			throw new System.NotImplementedException();
		}

		public ReturnData<dynamic> GetAudits(Audit audit)
		{
			throw new System.NotImplementedException();
		}
	}
}
