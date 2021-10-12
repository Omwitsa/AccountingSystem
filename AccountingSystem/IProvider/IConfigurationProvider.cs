using AccountingSystem.Model.Configuration;
using AccountingSystem.ViewModel;
using System;

namespace AccountingSystem.IProvider
{
	public interface IConfigurationProvider
	{
		ReturnData<string> AddAccountChart(AccountChart account, bool isEdit);
		ReturnData<dynamic> GetAccountCharts(AccountChart account);
		ReturnData<dynamic> GetAccountChart(Guid id);
		ReturnData<string> AddAssetModel(AssetModel asset, bool isEdit);
		ReturnData<dynamic> GetAssetModels(AssetModel asset);
		ReturnData<dynamic> GetAssetModel(Guid id);
		ReturnData<string> AddBank(Bank bank, bool isEdit);
		ReturnData<dynamic> GetBanks(Bank bank);
		ReturnData<dynamic> GetBank(Guid id);
		ReturnData<string> DeleteBank(Guid id);
		ReturnData<string> AddDefferredExpenseModel(DefferredExpenseModel expenseModel, bool isEdit);
		ReturnData<dynamic> GetDefferredExpenseModels(DefferredExpenseModel expenseModel);
		ReturnData<dynamic> GetDefferredExpenseModel(Guid id);
		ReturnData<string> DeleteDefferredExpenseModel(Guid id);
		ReturnData<string> AddDefferredRevenueModel(DefferredRevenueModel revenueModel, bool isEdit);
		ReturnData<dynamic> GetDefferredRevenueModels(DefferredRevenueModel revenueModel);
		ReturnData<dynamic> GetDefferredRevenueModel(Guid id);
		ReturnData<string> DeleteDefferredRevenueModel(Guid id);
		ReturnData<string> AddIncoTerm(IncoTerm term, bool isEdit);
		ReturnData<dynamic> GetIncoTerms(IncoTerm term);
		ReturnData<dynamic> GetIncoTerm(Guid id);
		ReturnData<string> DeleteIncoTerm(Guid id);
		ReturnData<string> AddIPaymentFollowupLevel(IPaymentFollowupLevel level, bool isEdit);
		ReturnData<dynamic> GetIPaymentFollowupLevels(IPaymentFollowupLevel level);
		ReturnData<dynamic> GetIPaymentFollowupLevel(Guid id);
		ReturnData<string> DeleteIPaymentFollowupLevel(Guid id);
		ReturnData<string> AddIPaymentTerm(IPaymentTerm term, bool isEdit);
		ReturnData<dynamic> GetIPaymentTerms(IPaymentTerm term);
		ReturnData<dynamic> GetIPaymentTerm(Guid id);
		ReturnData<string> DeleteIPaymentTerm(Guid id);
		ReturnData<string> AddJournal(Journal journal, bool isEdit);
		ReturnData<dynamic> GetJournals(Journal journal);
		ReturnData<dynamic> GetJournal(Guid id);
		ReturnData<string> AddProductCategory(ProductCategory category, bool isEdit);
		ReturnData<dynamic> GetProductCategories(ProductCategory category);
		ReturnData<dynamic> GetProductCategory(Guid id);
		ReturnData<string> DeleteProductCategory(Guid id);
		ReturnData<string> AddReconciliationModel(ReconciliationModel model, bool isEdit);
		ReturnData<dynamic> GetReconciliationModels(ReconciliationModel model);
		ReturnData<dynamic> GetReconciliationModel(Guid id);
		ReturnData<string> DeleteReconciliationModel(Guid id);
		ReturnData<string> AddSetting(Setting setting, bool isEdit);
		ReturnData<dynamic> GetSetting(Guid id);
		ReturnData<string> AddTax(Tax tax, bool isEdit);
		ReturnData<dynamic> GetTaxs(Tax tax);
		ReturnData<dynamic> GetTax(Guid id);
		ReturnData<string> DeleteTax(Guid id);
	}
}
