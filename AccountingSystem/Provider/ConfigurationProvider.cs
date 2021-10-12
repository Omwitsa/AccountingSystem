using AccountingSystem.IProvider;
using AccountingSystem.Model;
using AccountingSystem.Model.Configuration;
using AccountingSystem.ViewModel;
using System;

namespace AccountingSystem.Provider
{
	public class ConfigurationProvider : IConfigurationProvider
	{
		private AccountingDbContext _dbContext;
		public ConfigurationProvider(AccountingDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public ReturnData<string> AddAccountChart(AccountChart account, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddAssetModel(AssetModel asset, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddBank(Bank bank, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddDefferredExpenseModel(DefferredExpenseModel expenseModel, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddDefferredRevenueModel(DefferredRevenueModel revenueModel, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddIncoTerm(IncoTerm term, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddIPaymentFollowupLevel(IPaymentFollowupLevel level, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddIPaymentTerm(IPaymentTerm term, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddJournal(Journal journal, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddProductCategory(ProductCategory category, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddReconciliationModel(ReconciliationModel model, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddSetting(Setting setting, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddTax(Tax tax, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> DeleteBank(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> DeleteDefferredExpenseModel(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> DeleteDefferredRevenueModel(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> DeleteIncoTerm(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> DeleteIPaymentFollowupLevel(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> DeleteIPaymentTerm(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> DeleteProductCategory(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> DeleteReconciliationModel(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> DeleteTax(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetAccountChart(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetAccountCharts(AccountChart account)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetAssetModel(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetAssetModels(AssetModel asset)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetBank(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetBanks(Bank bank)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetDefferredExpenseModel(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetDefferredExpenseModels(DefferredExpenseModel expenseModel)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetDefferredRevenueModel(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetDefferredRevenueModels(DefferredRevenueModel revenueModel)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetIncoTerm(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetIncoTerms(IncoTerm term)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetIPaymentFollowupLevel(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetIPaymentFollowupLevels(IPaymentFollowupLevel level)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetIPaymentTerm(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetIPaymentTerms(IPaymentTerm term)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetJournal(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetJournals(Journal journal)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetProductCategories(ProductCategory category)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetProductCategory(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetReconciliationModel(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetReconciliationModels(ReconciliationModel model)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetSetting(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetTax(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetTaxs(Tax tax)
		{
			throw new NotImplementedException();
		}
	}
}
