using AccountingSystem.IProvider;
using AccountingSystem.Model;
using AccountingSystem.Model.System;
using AccountingSystem.ViewModel;

namespace AccountingSystem.Provider
{
	public class SystemProvider : ISystemProvider
	{
		private AccountingDbContext _dbContext;
		public SystemProvider(AccountingDbContext dbContext)
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
