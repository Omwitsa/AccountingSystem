using AccountingSystem.IProvider;
using AccountingSystem.Model;
using AccountingSystem.Model.Customers;
using AccountingSystem.ViewModel;
using System;

namespace AccountingSystem.Provider
{
	public class CustomersProvider : ICustomersProvider
	{
		private AccountingDbContext _dbContext;
		public CustomersProvider(AccountingDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public ReturnData<string> AddCreditNote(CreditNote note, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddCustomer(Customer customer, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddInvoice(CInvoice invoice, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddPayment(CPayment payment, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> AddProduct(CProduct product, bool isEdit)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> DeleteCustomer(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<string> DeleteProduct(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetCreditNote(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetCreditNotes(CreditNote note)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetCustomer(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetCustomers(Customer customer)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetInvoice(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetInvoices(CInvoice invoice)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetPayment(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetPayments(CPayment payment)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetProduct(Guid id)
		{
			throw new NotImplementedException();
		}

		public ReturnData<dynamic> GetProducts(CProduct product)
		{
			throw new NotImplementedException();
		}
	}
}
