using AccountingSystem.IProvider;
using AccountingSystem.Model;
using AccountingSystem.Model.Configuration;
using AccountingSystem.ViewModel;
using System;
using System.Collections.Generic;
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
			try
			{
				if (string.IsNullOrEmpty(journal.Name))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide journal"
					};
				if (string.IsNullOrEmpty(journal.Type))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide type"
					};
				journal.Closed = journal?.Closed ?? false;
				if (isEdit)
				{
					var savedJournal = _dbContext.Journals.FirstOrDefault(j => j.Id == journal.Id);
					savedJournal.Name = journal.Name;
					savedJournal.Type = journal.Type;
					savedJournal.Closed = journal.Closed;
					savedJournal.Personnel = journal.Personnel;
					savedJournal.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.Journals.Any(j => j.Name.ToUpper().Equals(journal.Name.ToUpper())))
						return new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, Journal already exist"
						};
					_dbContext.Journals.Add(journal);
				}
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Journal saved successfully"
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

		public ReturnData<string> AddProductCategory(ProductCategory category, bool isEdit)
		{
			try
			{
				if (string.IsNullOrEmpty(category.Name))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide category"
					};
				category.Closed = category?.Closed ?? false;
				if (isEdit)
				{
					var savedCategory = _dbContext.ProductCategories.FirstOrDefault(c => c.Id == category.Id);
					savedCategory.Name = category.Name;
					savedCategory.ParentCategory = category.ParentCategory;
					savedCategory.IncomeGlAccount = category.IncomeGlAccount;
					savedCategory.ExpenseGlAccount = category.ExpenseGlAccount;
					savedCategory.Closed = category.Closed;
					savedCategory.Personnel = category.Personnel;
					savedCategory.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.ProductCategories.Any(c => c.Name.ToUpper().Equals(category.Name.ToUpper())))
						return new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, Category aleady exist"
						};
					_dbContext.ProductCategories.Add(category);
				}
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Category saved successfully"
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

		public ReturnData<string> AddReconciliationModel(ReconciliationModel model, bool isEdit)
		{
			try
			{
				if (string.IsNullOrEmpty(model.Name))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide model name"
					};
				if (string.IsNullOrEmpty(model.Type))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide type"
					};
				if (string.IsNullOrEmpty(model.Journal))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide journal"
					};
				if (isEdit)
				{
					var savedModel = _dbContext.ReconciliationModels.FirstOrDefault(r => r.Id == model.Id);
					savedModel.Name = model.Name;
					savedModel.Type = model.Type;
					savedModel.Journal = model.Journal;
					savedModel.Personnel = model.Personnel;
					savedModel.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.ReconciliationModels.Any(r => r.Name.ToUpper().Equals(model.Name.ToUpper())))
						return new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, Reconsiliation already exist"
						};
					_dbContext.ReconciliationModels.Add(model);
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

		public ReturnData<string> AddSetting(Setting setting, bool isEdit)
		{
			try
			{
				var savesSetting = _dbContext.Settings.FirstOrDefault();
				savesSetting.SalesTax = setting.SalesTax;
				savesSetting.PurchaseTax = setting.PurchaseTax;
				savesSetting.Periodicity = setting.Periodicity;
				savesSetting.Reminder = setting.Reminder;
				savesSetting.Journal = setting.Journal;
				savesSetting.RoundingMethod = setting.RoundingMethod;
				savesSetting.FiscalCountry = setting.FiscalCountry;
				savesSetting.MainCurrency = setting.MainCurrency;
				savesSetting.MultiCurrency = setting.MultiCurrency;
				savesSetting.FiscalPeriod = setting.FiscalPeriod;
				setting.ModifiedDate = DateTime.UtcNow.AddHours(3);

				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Setting saved successfully"
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

		public ReturnData<string> AddTax(Tax tax, bool isEdit)
		{
			try
			{
				if (string.IsNullOrEmpty(tax.Name))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide tax"
					};
				tax.Closed = tax?.Closed ?? false;
				if (isEdit)
				{
					var savedTax = _dbContext.Taxes.FirstOrDefault(t => t.Id == tax.Id);
					savedTax.Name = tax.Name;
					savedTax.Type = tax.Type;
					savedTax.Computation = tax.Computation;
					savedTax.Scope = tax.Scope;
					savedTax.Personnel = tax.Personnel;
					savedTax.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.Taxes.Any(t => t.Name.ToUpper().Equals(tax.Name.ToUpper())))
						return new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, tax already exist"
						};
					_dbContext.Taxes.Add(tax);
				}
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Tax saved successfully"
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

		public ReturnData<string> DeleteBank(Guid id)
		{
			try
			{
				var bank = _dbContext.Banks.FirstOrDefault(b => b.Id == id);
				if (bank == null)
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Bank not found"
					};
				_dbContext.Banks.Remove(bank);
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Bank deleted successfully"
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

		public ReturnData<string> DeleteDefferredExpenseModel(Guid id)
		{
			try
			{
				var model = _dbContext.DefferredExpenseModels.FirstOrDefault(d => d.Id == id);
				if (model == null)
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Expense model not found"
					};
				_dbContext.DefferredExpenseModels.Remove(model);
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Expense model deleted successfully"
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

		public ReturnData<string> DeleteDefferredRevenueModel(Guid id)
		{
			try
			{
				var model = _dbContext.DefferredRevenueModels.FirstOrDefault(m => m.Id == id);
				if (model == null)
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Revenue model not found"
					};
				_dbContext.DefferredRevenueModels.Remove(model);
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Revenue model deleted successfully"
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

		public ReturnData<string> DeleteIncoTerm(Guid id)
		{
			try
			{
				var term = _dbContext.IncoTerms.FirstOrDefault(t => t.Id == id);
				if (term == null)
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Terms not found"
					};
				_dbContext.IncoTerms.Remove(term);
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Terms deleted successfully"
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

		public ReturnData<string> DeleteIPaymentFollowupLevel(Guid id)
		{
			try
			{
				var level = _dbContext.IPaymentFollowupLevels.FirstOrDefault(l => l.Id == id);
				if (level == null)
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Follow up level not found"
					};
				_dbContext.IPaymentFollowupLevels.Remove(level);
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Follow up level deleted successfully"
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

		public ReturnData<string> DeleteIPaymentTerm(Guid id)
		{
			try
			{
				var term = _dbContext.IPaymentTerms.FirstOrDefault(t => t.Id == id);
				if (term == null)
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Payment terms not found"
					};
				_dbContext.IPaymentTerms.Remove(term);
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Payment terms deleted successfully"
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

		public ReturnData<string> DeleteProductCategory(Guid id)
		{
			try
			{
				var category = _dbContext.ProductCategories.FirstOrDefault(c => c.Id == id);
				if (category == null)
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Category not found"
					};
				_dbContext.ProductCategories.Remove(category);
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Product category deleted successfully"
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

		public ReturnData<string> DeleteReconciliationModel(Guid id)
		{
			try
			{
				var model = _dbContext.ReconciliationModels.FirstOrDefault(r => r.Id == id);
				if (model == null)
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Reconciliation model not found"
					};
				_dbContext.ReconciliationModels.Remove(model);
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Reconciliation model deleted successfully"
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

		public ReturnData<string> DeleteTax(Guid id)
		{
			try
			{
				var tax = _dbContext.Taxes.FirstOrDefault(t => t.Id == id);
				if (tax == null)
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, tax not found"
					};
				_dbContext.Taxes.Remove(tax);
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Tax deleted successfully"
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

		public ReturnData<dynamic> GetAccountChart(Guid id)
		{
			try
			{
				var account = _dbContext.AccountCharts.FirstOrDefault(a => a.Id == id);
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						account
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<List<AccountChart>> GetAccountCharts(AccountChart account)
		{
			try
			{
				var charts = _dbContext.AccountCharts.Where(a =>
				(string.IsNullOrEmpty(account.Code) || a.Code.ToUpper().Equals(account.Code.ToUpper()))
				&& (string.IsNullOrEmpty(account.Name) || a.Name.ToUpper().Equals(account.Name.ToUpper()))
				&& (string.IsNullOrEmpty(account.Type) || a.Type.ToUpper().Equals(account.Type.ToUpper()))
				&& (string.IsNullOrEmpty(account.Personnel) || a.Personnel.ToUpper().Equals(account.Personnel.ToUpper()))
				).ToList();

				return new ReturnData<List<AccountChart>>
				{
					Success = true,
					Data = charts
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<List<AccountChart>>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetAssetModel(Guid id)
		{
			try
			{
				var asset = _dbContext.AssetModels.FirstOrDefault(a => a.Id == id);
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						asset
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetAssetModels(AssetModel asset)
		{
			try
			{
				var models = _dbContext.AssetModels.Where(a =>
					(string.IsNullOrEmpty(asset.Name) || a.Name.ToUpper().Equals(asset.Name.ToUpper()))
					&& (string.IsNullOrEmpty(asset.GlAccount) || a.GlAccount.ToUpper().Equals(asset.GlAccount.ToUpper()))
					&& (string.IsNullOrEmpty(asset.Journal) || a.Journal.ToUpper().Equals(asset.Journal.ToUpper()))
					&& (string.IsNullOrEmpty(asset.Personnel) || a.Personnel.ToUpper().Equals(asset.Personnel.ToUpper()))
					).ToList();
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						models
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetBank(Guid id)
		{
			try
			{
				var bank = _dbContext.Banks.FirstOrDefault(b => b.Id == id);
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						bank
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetBanks(Bank bank)
		{
			try
			{
				var banks = _dbContext.Banks.Where(b =>
				(string.IsNullOrEmpty(bank.AccNo) || b.AccNo.ToUpper().Equals(bank.AccNo.ToUpper()))
				&& (string.IsNullOrEmpty(bank.Name) || b.Name.ToUpper().Equals(bank.Name.ToUpper()))
				&& (string.IsNullOrEmpty(bank.Personnel) || b.Personnel.ToUpper().Equals(bank.Personnel.ToUpper()))
				).ToList();
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						banks
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetDefferredExpenseModel(Guid id)
		{
			try
			{
				var expenseModel = _dbContext.DefferredExpenseModels.FirstOrDefault(e => e.Id == id);
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						expenseModel
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetDefferredExpenseModels(DefferredExpenseModel expenseModel)
		{
			try
			{
				var expenseModels = _dbContext.DefferredExpenseModels.Where(e =>
				(string.IsNullOrEmpty(expenseModel.Name) || e.Name.ToUpper().Equals(expenseModel.Name.ToUpper()))
				&& (string.IsNullOrEmpty(expenseModel.GlAccount) || e.GlAccount.ToUpper().Equals(expenseModel.GlAccount.ToUpper()))
				&& (string.IsNullOrEmpty(expenseModel.Journal) || e.Journal.ToUpper().Equals(expenseModel.Journal.ToUpper()))
				&& (string.IsNullOrEmpty(expenseModel.Personnel) || e.Personnel.ToUpper().Equals(expenseModel.Personnel.ToUpper()))
				).ToList();
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						expenseModels
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetDefferredRevenueModel(Guid id)
		{
			try
			{
				var expenseModel = _dbContext.DefferredExpenseModels.FirstOrDefault(m => m.Id == id);
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						expenseModel
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetDefferredRevenueModels(DefferredRevenueModel revenueModel)
		{
			try
			{
				var revenueModels = _dbContext.DefferredRevenueModels.Where(r =>
				(string.IsNullOrEmpty(revenueModel.Name) || r.Name.ToUpper().Equals(revenueModel.Name.ToUpper()))
				&& (string.IsNullOrEmpty(revenueModel.Journal) || r.Journal.ToUpper().Equals(revenueModel.Journal.ToUpper()))
				&& (string.IsNullOrEmpty(revenueModel.GlAccount) || r.GlAccount.ToUpper().Equals(revenueModel.GlAccount.ToUpper()))
				&& (string.IsNullOrEmpty(revenueModel.Personnel) || r.Personnel.ToUpper().Equals(revenueModel.Personnel.ToUpper()))
				).ToList();
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						revenueModels
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetIncoTerm(Guid id)
		{
			try
			{
				var term = _dbContext.IncoTerms.FirstOrDefault(t => t.Id == id);
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						term
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetIncoTerms(IncoTerm term)
		{
			try
			{
				var terms = _dbContext.IncoTerms.Where(t =>
				(string.IsNullOrEmpty(term.Code) || t.Code.ToUpper().Equals(term.Code.ToUpper()))
				&& (string.IsNullOrEmpty(term.Name) || t.Name.ToUpper().Equals(term.Name.ToUpper()))
				&& (string.IsNullOrEmpty(term.Personnel) || t.Personnel.ToUpper().Equals(term.Personnel.ToUpper()))
				).ToList();
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						terms
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetIPaymentFollowupLevel(Guid id)
		{
			try
			{
				var followupLevel = _dbContext.IPaymentFollowupLevels.FirstOrDefault(l => l.Id == id);
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						followupLevel
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetIPaymentFollowupLevels(IPaymentFollowupLevel level)
		{
			try
			{
				var followupLevels = _dbContext.IPaymentFollowupLevels.Where(l =>
				(string.IsNullOrEmpty(level.Level) || l.Level.ToUpper().Equals(level.Level.ToUpper()))
				&& (string.IsNullOrEmpty(level.Personnel) || l.Personnel.ToUpper().Equals(level.Personnel.ToUpper()))
				).ToList();

				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						followupLevels
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetIPaymentTerm(Guid id)
		{
			try
			{
				var term = _dbContext.IPaymentTerms.FirstOrDefault(t => t.Id == id);
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						term
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetIPaymentTerms(IPaymentTerm term)
		{
			try
			{
				var terms = _dbContext.IPaymentTerms.Where(t =>
				(string.IsNullOrEmpty(term.Term) || t.Term.ToUpper().Equals(term.Term.ToUpper()))
				&& (string.IsNullOrEmpty(term.Personnel) || t.Personnel.ToUpper().Equals(term.Personnel.ToUpper()))
				).ToList();
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						terms
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetJournal(Guid id)
		{
			try
			{
				var journal = _dbContext.Journals.FirstOrDefault(j => j.Id == id);
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						journal
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetJournals(Journal journal)
		{
			try
			{
				var journals = _dbContext.Journals.Where(j =>
				(string.IsNullOrEmpty(journal.Name) || j.Name.ToUpper().Equals(journal.Name.ToUpper()))
				&& (string.IsNullOrEmpty(journal.Type) || j.Type.ToUpper().Equals(journal.Type.ToUpper()))
				&& (string.IsNullOrEmpty(journal.Personnel) || j.Personnel.ToUpper().Equals(journal.Personnel.ToUpper()))
				).ToList();
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						journals
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetProductCategories(ProductCategory category)
		{
			try
			{
				var categories = _dbContext.ProductCategories.Where(c =>
				(string.IsNullOrEmpty(category.Name) || c.Name.ToUpper().Equals(category.Name.ToUpper()))
				&& (string.IsNullOrEmpty(category.Personnel) || c.Personnel.ToUpper().Equals(category.Personnel.ToUpper()))
				).ToList();
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						categories
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetProductCategory(Guid id)
		{
			try
			{
				var category = _dbContext.ProductCategories.FirstOrDefault(c => c.Id == id);
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						category
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetReconciliationModel(Guid id)
		{
			try
			{
				var reconciliation = _dbContext.ReconciliationModels.FirstOrDefault(r => r.Id == id);
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						reconciliation
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetReconciliationModels(ReconciliationModel model)
		{
			try
			{
				var reconciliationModels = _dbContext.ReconciliationModels.Where(r =>
				(string.IsNullOrEmpty(model.Name) || r.Name.ToUpper().Equals(model.Name.ToUpper()))
				&& (string.IsNullOrEmpty(model.Type) || r.Type.ToUpper().Equals(model.Type.ToUpper()))
				&& (string.IsNullOrEmpty(model.Journal) || r.Journal.ToUpper().Equals(model.Journal.ToUpper()))
				&& (string.IsNullOrEmpty(model.Personnel) || r.Personnel.ToUpper().Equals(model.Personnel.ToUpper()))
				).ToList();

				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						reconciliationModels
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetSetting(Guid id)
		{
			try
			{
				var setting = _dbContext.Settings.FirstOrDefault(s => s.Id == id);
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						setting
					}
				};
			}
			catch (Exception)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetTax(Guid id)
		{
			try
			{
				var tax = _dbContext.Taxes.FirstOrDefault(t => t.Id == id);
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						tax
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetTaxs(Tax tax)
		{
			try
			{
				var taxes = _dbContext.Taxes.Where(t =>
				(string.IsNullOrEmpty(tax.Name) || t.Name.ToUpper().Equals(tax.Name.ToUpper()))
				&& (string.IsNullOrEmpty(tax.Type) || t.Type.ToUpper().Equals(tax.Type.ToUpper()))
				&& (string.IsNullOrEmpty(tax.Personnel) || t.Personnel.ToUpper().Equals(tax.Personnel.ToUpper()))
				).ToList();
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						taxes
					}
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<dynamic>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}
	}
}
