using AccountingSystem.Model.Customers;
using AccountingSystem.ViewModel;
using System;

namespace AccountingSystem.IProvider
{
	public interface ICustomersProvider
	{
		ReturnData<string> AddInvoice(CInvoice invoice, bool isEdit);
		ReturnData<dynamic> GetInvoices(CInvoice invoice);
		ReturnData<dynamic> GetInvoice(Guid id);
		ReturnData<string> AddPayment(CPayment payment, bool isEdit);
		ReturnData<dynamic> GetPayments(CPayment payment);
		ReturnData<dynamic> GetPayment(Guid id);
		ReturnData<string> AddProduct(CProduct product, bool isEdit);
		ReturnData<dynamic> GetProducts(CProduct product);
		ReturnData<dynamic> GetProduct(Guid id);
		ReturnData<string> DeleteProduct(Guid id);
		ReturnData<string> AddCreditNote(CreditNote note, bool isEdit);
		ReturnData<dynamic> GetCreditNotes(CreditNote note);
		ReturnData<dynamic> GetCreditNote(Guid id);
		ReturnData<string> AddCustomer(Customer customer, bool isEdit);
		ReturnData<dynamic> GetCustomers(Customer customer);
		ReturnData<dynamic> GetCustomer(Guid id);
		ReturnData<string> DeleteCustomer(Guid id);
	}
}
