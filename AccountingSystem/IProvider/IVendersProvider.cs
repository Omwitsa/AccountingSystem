using AccountingSystem.Model.Venders;
using AccountingSystem.ViewModel;
using System;
using System.Collections.Generic;

namespace AccountingSystem.IProvider
{
	public interface IVendersProvider
	{
		ReturnData<string> AddBill(Bill bill, bool isEdit);
		ReturnData<dynamic> GetBills(Bill bill);
		ReturnData<dynamic> GetBill(Guid id);
		ReturnData<string> AddRefund(Refund refund, bool isEdit);
		ReturnData<dynamic> GetRefunds(Refund refund);
		ReturnData<dynamic> GetRefund(Guid id);
		ReturnData<string> AddVender(Vender vender, bool isEdit);
		ReturnData<List<Vender>> GetVenders(Vender vender);
		ReturnData<dynamic> GetVender(Guid id);
		ReturnData<string> DeleteVender(Guid id);
		ReturnData<string> AddPayment(VPayment payment, bool isEdit);
		ReturnData<dynamic> GetPayments(VPayment payment);
		ReturnData<dynamic> GetPayment(Guid id);
		ReturnData<string> AddProduct(VProduct product, bool isEdit);
		ReturnData<dynamic> GetProducts(VProduct vender);
		ReturnData<dynamic> GetProduct(Guid id);
		ReturnData<string> DeleteProduct(Guid id);
	}
}
