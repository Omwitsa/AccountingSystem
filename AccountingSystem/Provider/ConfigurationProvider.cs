using AccountingSystem.IProvider;
using AccountingSystem.Model;
using AccountingSystem.Model.Configuration;
using AccountingSystem.ViewModel;
using System;
using System.Linq;

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
			try
			{
				if (string.IsNullOrEmpty(account.Code))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide account code"
					};
				if (string.IsNullOrEmpty(account.Name))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide account name"
					};
				if (string.IsNullOrEmpty(account.Type))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide account type"
					};

				account.Closed = account?.Closed ?? false;
				if (isEdit)
				{
					var savedAccount = _dbContext.AccountCharts.FirstOrDefault(a => a.Id == account.Id);
					savedAccount.Code = account.Code;
					savedAccount.Name = account.Name;
					savedAccount.Type = account.Type;
					savedAccount.AllowReconciliation = account.AllowReconciliation;
					savedAccount.DefaultTax = account.DefaultTax;
					savedAccount.AllowJournal = account.AllowJournal;
					savedAccount.Tag = account.Tag;
					savedAccount.Closed = account.Closed;
					savedAccount.Personnel = account.Personnel;
					savedAccount.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.AccountCharts.Any(a => a.Code.ToUpper().Equals(account.Code.ToUpper())))
						return new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, Code already exist"
						};
					if (_dbContext.AccountCharts.Any(a => a.Name.ToUpper().Equals(account.Name.ToUpper())))
						return new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, Name already exist"
						};
					_dbContext.AccountCharts.Add(account);
				}
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Account saved successfully"
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<string> AddAssetModel(AssetModel asset, bool isEdit)
		{
			try
			{
				if (string.IsNullOrEmpty(asset.Name))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide name"
					};
				if (isEdit)
				{
					var savedAsset = _dbContext.AssetModels.FirstOrDefault(a => a.Id == asset.Id);
					savedAsset.Name = asset.Name;
					savedAsset.GlAccount = asset.GlAccount;
					savedAsset.DepreciationMethod = asset.DepreciationMethod;
					savedAsset.DepreciationDuration = asset.DepreciationDuration;
					savedAsset.DepreciationGlAccount = asset.DepreciationGlAccount;
					savedAsset.ExpenseGlAccount = asset.ExpenseGlAccount;
					savedAsset.Journal = asset.Journal;
					savedAsset.Personnel = asset.Personnel;
					savedAsset.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.AssetModels.Any(a => a.Name.ToUpper().Equals(asset.Name.ToUpper())))
						return new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, Asset model already exist"
						};
					_dbContext.AssetModels.Add(asset);
				}
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Model saved successfully"
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<string> AddBank(Bank bank, bool isEdit)
		{
			try
			{
				if (string.IsNullOrEmpty(bank.AccNo))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide bank account"
					};
				if (string.IsNullOrEmpty(bank.Name))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, kindly provide bank name"
					};

				bank.Closed = bank?.Closed ?? false;
				if (isEdit)
				{
					var savedBank = _dbContext.Banks.FirstOrDefault(b => b.Id == bank.Id);
					savedBank.AccNo = bank.AccNo;
					savedBank.Name = bank.Name;
					savedBank.IdentifierCode = bank.IdentifierCode;
					savedBank.Closed = bank.Closed;
					savedBank.Personnel = bank.Personnel;
					savedBank.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.Banks.Any(b => b.AccNo.ToUpper().Equals(bank.AccNo.ToUpper())))
						return new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, Bank account already exist"
						};
					if (_dbContext.Banks.Any(b => b.Name.ToUpper().Equals(bank.Name.ToUpper())))
						return new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, Bank name already exist"
						};
					_dbContext.Banks.Add(bank);
				}
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Bank saved successfully"
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<string> AddDefferredExpenseModel(DefferredExpenseModel expenseModel, bool isEdit)
		{
			try
			{
				if (string.IsNullOrEmpty(expenseModel.Name))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide model name"
					};
				if (string.IsNullOrEmpty(expenseModel.GlAccount))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide GL account"
					};
				if (string.IsNullOrEmpty(expenseModel.Journal))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide journal"
					};
				if (isEdit)
				{
					var savedModel = _dbContext.DefferredExpenseModels.FirstOrDefault(e => e.Id == expenseModel.Id);
					savedModel.Name = expenseModel.Name;
					savedModel.GlAccount = expenseModel.GlAccount;
					savedModel.DepreciationMethod = expenseModel.DepreciationMethod;
					savedModel.DepreciationDuration = expenseModel.DepreciationDuration;
					savedModel.DepreciationGlAccount = expenseModel.DepreciationGlAccount;
					savedModel.RevenueGlAccount = expenseModel.RevenueGlAccount;
					savedModel.Journal = expenseModel.Journal;
					savedModel.Personnel = expenseModel.Personnel;
					savedModel.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.DefferredExpenseModels.Any(e => e.Name.ToUpper().Equals(expenseModel.Name.ToUpper())))
						return new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, expense model already exist"
						};
					_dbContext.DefferredExpenseModels.Add(expenseModel);
				}
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Expense model saved successfully"
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<string> AddDefferredRevenueModel(DefferredRevenueModel revenueModel, bool isEdit)
		{
			try
			{
				if (string.IsNullOrEmpty(revenueModel.Name))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide model name"
					};
				if (string.IsNullOrEmpty(revenueModel.GlAccount))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide GL account"
					};
				if (string.IsNullOrEmpty(revenueModel.Journal))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide journal"
					};
				if (isEdit)
				{
					var savedModel = _dbContext.DefferredRevenueModels.FirstOrDefault(r => r.Id == revenueModel.Id);
					savedModel.Name = revenueModel.Name;
					savedModel.GlAccount = revenueModel.GlAccount;
					savedModel.DepreciationMethod = revenueModel.DepreciationMethod;
					savedModel.DepreciationDuration = revenueModel.DepreciationDuration;
					savedModel.DepreciationGlAccount = revenueModel.DepreciationGlAccount;
					savedModel.RevenueGlAccount = revenueModel.RevenueGlAccount;
					savedModel.Journal = revenueModel.Journal;
					savedModel.Personnel = revenueModel.Personnel;
					savedModel.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.DefferredRevenueModels.Any(r => r.Name.ToUpper().Equals(revenueModel.Name.ToUpper())))
						return new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, Model name already exist"
						};
					_dbContext.DefferredRevenueModels.Add(revenueModel);
				}
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Model saved succsessfully"
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<string> AddIncoTerm(IncoTerm term, bool isEdit)
		{
			try
			{
				if (string.IsNullOrEmpty(term.Code))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide code"
					};
				if (string.IsNullOrEmpty(term.Name))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide name"
					};
				if (isEdit)
				{
					var savedTerm = _dbContext.IncoTerms.FirstOrDefault(t => t.Id == term.Id);
					savedTerm.Code = term.Code;
					savedTerm.Name = term.Name;
					savedTerm.Personnel = term.Personnel;
					savedTerm.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.IncoTerms.Any(t => t.Code.ToUpper().Equals(term.Code.ToUpper())))
						return new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, Term already exist"
						};
					_dbContext.IncoTerms.Add(term);
				}
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Terms saved successfully"
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<string> AddIPaymentFollowupLevel(IPaymentFollowupLevel level, bool isEdit)
		{
			try
			{
				if (string.IsNullOrEmpty(level.Level))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide level"
					};
				if (isEdit)
				{
					var savedLevel = _dbContext.IPaymentFollowupLevels.FirstOrDefault(l => l.Id == level.Id);
					savedLevel.Level = level.Level;
					savedLevel.Personnel = level.Personnel;
					savedLevel.ModifiedDate = level.ModifiedDate;
				}
				else
				{
					if (_dbContext.IPaymentFollowupLevels.Any(l => l.Level.ToUpper().Equals(level.Level.ToUpper())))
						return new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, Level already exist"
						};
					_dbContext.IPaymentFollowupLevels.Add(level);
				}
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Payment level saved successfully"
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<string> AddIPaymentTerm(IPaymentTerm term, bool isEdit)
		{
			try
			{
				if (string.IsNullOrEmpty(term.Term))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide terms"
					};
				if (isEdit)
				{
					var savedTerm = _dbContext.IPaymentTerms.FirstOrDefault(t => t.Id == term.Id);
					savedTerm.Term = term.Term;
					savedTerm.Personnel = term.Personnel;
					savedTerm.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.IPaymentTerms.Any(t => t.Term.ToUpper().Equals(term.Term.ToUpper())))
						return new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, terms already exist"
						};
					_dbContext.IPaymentTerms.Add(term);
				}
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Terms saved successfully"
				};
			}
			catch (Exception)
			{
				return new ReturnData<string>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
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
