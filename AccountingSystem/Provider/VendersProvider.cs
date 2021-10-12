using AccountingSystem.IProvider;
using AccountingSystem.Model;
using AccountingSystem.Model.Configuration;
using AccountingSystem.Model.Customers;
using AccountingSystem.Model.System;
using AccountingSystem.Model.Venders;
using AccountingSystem.ViewModel;
using System;
using System.Linq;

namespace AccountingSystem.Provider
{
	public class VendersProvider : IVendersProvider
	{
		private AccountingDbContext _dbContext;
		public VendersProvider(AccountingDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public ReturnData<string> AddBill(Bill bill, bool isEdit)
		{
			try
			{
				bill.CreatedDate = DateTime.UtcNow.AddHours(3);
				bill.ModifiedDate = DateTime.UtcNow.AddHours(3);
				bill.Date = DateTime.UtcNow.AddHours(3);
				if (string.IsNullOrEmpty(bill.Vender))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide vendor"
					};
				
				if (string.IsNullOrEmpty(bill.Journal))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide journal"
					};
				if (!bill.BillDetails.Any())
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide invoice items"
					};
				foreach(var detail in bill.BillDetails)
				{
					if (string.IsNullOrEmpty(detail.Product))
						return new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, There is a product missing in the invoice"
						};
					detail.Price = detail?.Price ?? 0;
					if (detail.Price < 1)
						return new ReturnData<string>
						{
							Success = false,
							Message = $"Kindly enter the price for product {detail.Product}"
						};
					detail.Quantity = detail?.Quantity ?? 0;
					if (detail.Quantity < 1)
						return new ReturnData<string>
						{
							Success = false,
							Message = $"Kindly enter the quantity for product {detail.Product}"
						};
				}
				var reference = "Add Bill";
				if (isEdit)
				{
					reference = "Edit Bill";
					var savedBill = _dbContext.Bills.FirstOrDefault(b => b.Id == bill.Id);
					bill.CreatedDate = savedBill.CreatedDate;
					if (savedBill != null)
					{
						var details = _dbContext.BillDetails.Where(b => b.BillId == savedBill.Id);
						if (details.Any())
							_dbContext.BillDetails.RemoveRange(details);
						var journals = _dbContext.BillJournals.Where(b => b.BillId == savedBill.Id);
						if (journals.Any())
							_dbContext.BillJournals.RemoveRange(journals);
						_dbContext.Bills.Remove(savedBill);
					}
				}
				_dbContext.Audits.Add(new Audit
				{
					UserName = bill.Personnel,
					Date = DateTime.UtcNow.AddHours(3),
					Reference = reference,
					ModuleId = "Venders"
				});
				
				_dbContext.Bills.Add(bill);
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Bill saved successfully"
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

		public ReturnData<string> AddPayment(VPayment payment, bool isEdit)
		{
			try
			{
				payment.Date = DateTime.UtcNow.AddHours(3);
				payment.IsPayable = payment?.IsPayable ?? false;
				payment.IsReceivable = payment?.IsReceivable ?? false;
				if (!(bool)payment.IsPayable || !(bool)payment.IsReceivable)
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly select payment type"
					};
				if (string.IsNullOrEmpty(payment.PartnerType))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide partner type"
					};
				if (string.IsNullOrEmpty(payment.Vendor))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide customer"
					};
				if (string.IsNullOrEmpty(payment.GlAccount))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide GL Account"
					};
				payment.Amount = payment?.Amount ?? 0;
				if (payment.Amount < 1)
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide amount"
					};
				if (string.IsNullOrEmpty(payment.Journal))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide journal"
					};
				if (string.IsNullOrEmpty(payment.BankAccount))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide bank account"
					};

				payment.CreatedDate = DateTime.UtcNow.AddHours(3);
				payment.ModifiedDate = DateTime.UtcNow.AddHours(3);
				var reference = "Add Payment";
				if (isEdit)
				{
					reference = "Edit Payment";
					var savedPayment = _dbContext.VPayments.FirstOrDefault(p => p.Id == payment.Id);
					savedPayment.ModifiedDate = DateTime.UtcNow.AddHours(3);
					savedPayment.IsPayable = payment.IsPayable;
					savedPayment.IsReceivable = payment.IsReceivable;
					savedPayment.PartnerType = payment.PartnerType;
					savedPayment.Vendor = payment.Vendor;
					savedPayment.GlAccount = payment.GlAccount;
					savedPayment.IsInternalTransfer = payment.IsInternalTransfer;
					savedPayment.Amount = payment.Amount;
					savedPayment.Date = payment.Date;
					savedPayment.Memo = payment.Memo;
					savedPayment.Journal = payment.Journal;
					savedPayment.BankAccount = payment.BankAccount;
					savedPayment.Personnel = payment.Personnel;
				}
				else
				{
					_dbContext.VPayments.Add(payment);
				}
				
				_dbContext.Audits.Add(new Audit
				{
					UserName = payment.Personnel,
					Date = DateTime.UtcNow.AddHours(3),
					Reference = reference,
					ModuleId = "Venders"
				});
				
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Payment saved successfully"
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

		public ReturnData<string> AddProduct(VProduct product, bool isEdit)
		{
			try
			{
				if (string.IsNullOrEmpty(product.Name))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Kindly provide the product"
					};
				if (string.IsNullOrEmpty(product.Type))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide product type"
					};
				if (string.IsNullOrEmpty(product.Category))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide product category"
					};
				if (string.IsNullOrEmpty(product.APGlAccount))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide Account payable"
					};
				if (string.IsNullOrEmpty(product.ARGlAccount))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide Account receivable"
					};
				product.CreatedDate = DateTime.UtcNow.AddHours(3);
				product.ModifiedDate = DateTime.UtcNow.AddHours(3);
				product.Closed = product?.Closed ?? false;
				var reference = "Add Product";
				if (isEdit)
				{
					reference = "Edit Product";
					var savedProduct = _dbContext.VProducts.FirstOrDefault(p => p.Id == product.Id);
					savedProduct.ModifiedDate = DateTime.UtcNow.AddHours(3);
					savedProduct.Name = product.Name;
					savedProduct.Type = product.Type;
					savedProduct.Category = product.Category;
					savedProduct.Ref = product.Ref;
					savedProduct.BarCode = product.BarCode;
					savedProduct.Price = product.Price;
					savedProduct.CustomerTax = product.CustomerTax;
					savedProduct.Cost = product.Cost;
					savedProduct.Notes = product.Notes;
					savedProduct.VenderTax = product.VenderTax;
					savedProduct.ARGlAccount = product.ARGlAccount;
					savedProduct.APGlAccount = product.APGlAccount;
					savedProduct.Closed = product.Closed;
					savedProduct.Personnel = product.Personnel;
				}
				else
				{
					_dbContext.VProducts.Add(product);
				}
				_dbContext.Audits.Add(new Audit
				{
					UserName = product.Personnel,
					Date = DateTime.UtcNow.AddHours(3),
					Reference = reference,
					ModuleId = "Venders"
				});
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Product saved successfully"
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

		public ReturnData<string> AddRefund(Refund refund, bool isEdit)
		{
			try
			{
				refund.CreatedDate = DateTime.UtcNow.AddHours(3);
				refund.ModifiedDate = DateTime.UtcNow.AddHours(3);
				if (string.IsNullOrEmpty(refund.Vendor))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide vendor"
					};

				if (string.IsNullOrEmpty(refund.Journal))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide journal"
					};
				if (!refund.RefundDetails.Any())
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide refund items"
					};
				foreach (var detail in refund.RefundDetails)
				{
					if (string.IsNullOrEmpty(detail.Product))
						return new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, There is a product missing in the invoice"
						};
					detail.Price = detail?.Price ?? 0;
					if (detail.Price < 1)
						return new ReturnData<string>
						{
							Success = false,
							Message = $"Kindly enter the price for product {detail.Product}"
						};
					detail.Quantity = detail?.Quantity ?? 0;
					if (detail.Quantity < 1)
						return new ReturnData<string>
						{
							Success = false,
							Message = $"Kindly enter the quantity for product {detail.Product}"
						};
				}
				var reference = "Add Refund";
				if (isEdit)
				{
					reference = "Edit Refund";
					var savedRefund = _dbContext.Refunds.FirstOrDefault(b => b.Id == refund.Id);
					refund.CreatedDate = savedRefund.CreatedDate;
					if (savedRefund != null)
					{
						var details = _dbContext.RefundDetails.Where(b => b.RefundId == savedRefund.Id);
						if (details.Any())
							_dbContext.RefundDetails.RemoveRange(details);
						var journals = _dbContext.RefundJournals.Where(b => b.RefundId == savedRefund.Id);
						if (journals.Any())
							_dbContext.RefundJournals.RemoveRange(journals);
						_dbContext.Refunds.Remove(savedRefund);
					}
				}
				_dbContext.Audits.Add(new Audit
				{
					UserName = refund.Personnel,
					Date = DateTime.UtcNow.AddHours(3),
					Reference = reference,
					ModuleId = "Venders"
				});

				_dbContext.Refunds.Add(refund);
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Refund saved successfully"
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

		public ReturnData<string> AddVender(Vender vender, bool isEdit)
		{
			try
			{
				if (string.IsNullOrEmpty(vender.Name))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide vendor"
					};
				if(string.IsNullOrEmpty(vender.APGlAccount))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide account payable"
					};
				if (string.IsNullOrEmpty(vender.ARGlAccount))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide account receivable"
					};
				vender.CreatedDate = DateTime.UtcNow.AddHours(3);
				vender.ModifiedDate = DateTime.UtcNow.AddHours(3);
				vender.Closed = vender?.Closed ?? false;
				if (isEdit)
				{
					var savedVender = _dbContext.Venders.FirstOrDefault(v => v.Id == vender.Id);
					savedVender.Name = vender.Name;
					savedVender.Street1 = vender.Street1;
					savedVender.Street2 = vender.Street2;
					savedVender.City = vender.City;
					savedVender.Country = vender.Country;
					savedVender.PhoneNo = vender.PhoneNo;
					savedVender.Mobile = vender.Mobile;
					savedVender.Email = vender.Email;
					savedVender.WebSite = vender.WebSite;
					savedVender.SalesPerson = vender.SalesPerson;
					savedVender.PurchasePaymentTerms = vender.PurchasePaymentTerms;
					savedVender.SalesPaymentTerms = vender.SalesPaymentTerms;
					savedVender.FiscalPosition = vender.FiscalPosition;
					savedVender.Ref = vender.Ref;
					savedVender.Industry = vender.Industry;
					savedVender.APGlAccount = vender.APGlAccount;
					savedVender.ARGlAccount = vender.ARGlAccount;
					savedVender.Bank = vender.Bank;
					savedVender.Notes = vender.Notes;
					savedVender.Closed = vender.Closed;
					savedVender.Personnel = vender.Personnel;
					savedVender.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.Venders.Any(v => v.Name.ToUpper().Equals(vender.Name.ToUpper())))
						return new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, Vendor already exist"
						};
					_dbContext.Venders.Add(vender);
				}
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = false,
					Message = "Vendor saved successfully"
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

		public ReturnData<string> DeleteProduct(Guid id)
		{
			try
			{
				var product = _dbContext.VProducts.FirstOrDefault(p => p.Id == id);
				if (product == null)
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Product not found"
					};
				product.Name = product?.Name ?? "";
				if (_dbContext.BillDetails.Any(b => b.Product.ToUpper().Equals(product.Name.ToUpper())))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, the product has already been billed. It can't be deleted"
					};
				_dbContext.VProducts.Remove(product);
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Product deleted successfully"
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

		public ReturnData<string> DeleteVender(Guid id)
		{
			try
			{
				var vender = _dbContext.Venders.FirstOrDefault(v => v.Id == id);
				if (vender == null)
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Vendor not found"
					};
				vender.Name = vender?.Name ?? "";
				if (_dbContext.Bills.Any(b => b.Vender.ToUpper().Equals(vender.Name.ToUpper())))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Vendor already billed. Can't be deleted"
					};
				_dbContext.Venders.Remove(vender);
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Vendor deleted successfully"
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

		public ReturnData<dynamic> GetBill(Guid id)
		{
			try
			{
				var bill = _dbContext.Bills.FirstOrDefault(b => b.Id == id);
				var venders = _dbContext.Venders.Where(v => !(bool)v.Closed)
					.Select(v => new Vender
					{
						Name = v.Name
					}).ToList();
				var journals = _dbContext.Journals.Where(j => !(bool)j.Closed)
					.Select(j => new Journal
					{
						Name = j.Name
					}).ToList();
				var banks = _dbContext.Banks.Where(b => !(bool)b.Closed)
					.Select(b => new Bank
					{
						Name = b.Name
					}).ToList();
				var terms = _dbContext.IncoTerms
					.Select(t => new IncoTerm
					{
						Name = t.Name
					}).ToList();
				var products = _dbContext.VProducts.Where(p => !(bool)p.Closed)
					.Select(p => new VProduct
					{
						Name = p.Name
					}).ToList();
				var accounts = _dbContext.AccountCharts.Where(c => !(bool)c.Closed)
					.Select(c => new AccountChart
					{
						Name = c.Name,
						Code = c.Code
					}).ToList();
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						bill,
						venders,
						journals,
						banks,
						terms,
						products,
						accounts
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

		public ReturnData<dynamic> GetBills(Bill bill)
		{
			try
			{
				var bills = _dbContext.Bills
					.Where(b => (string.IsNullOrEmpty(bill.Vender) || b.Vender.ToUpper().Equals(bill.Vender.ToUpper()))
					&& (string.IsNullOrEmpty(bill.Journal) || b.Journal.ToUpper().Equals(bill.Journal.ToUpper()))
					&& (string.IsNullOrEmpty(bill.RecipientBank) || b.RecipientBank.ToUpper().Equals(bill.RecipientBank.ToUpper()))
					&& (string.IsNullOrEmpty(bill.IncoTerm) || b.IncoTerm.ToUpper().Equals(bill.IncoTerm.ToUpper()))
					&& (string.IsNullOrEmpty(bill.FiscalPosition) || b.FiscalPosition.ToUpper().Equals(bill.FiscalPosition.ToUpper()))
					&& (string.IsNullOrEmpty(bill.Personnel) || b.Personnel.ToUpper().Equals(bill.Personnel.ToUpper()))
					).ToList();

				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						bills
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

		public ReturnData<dynamic> GetPayment(Guid id)
		{
			try
			{
				var payment = _dbContext.VPayments.FirstOrDefault(p => p.Id == id);
				var venders = _dbContext.Venders.Where(c => !(bool)c.Closed)
					.Select(c => new Vender
					{
						Name = c.Name
					}).ToList();
				var journals = _dbContext.Journals.Where(j => !(bool)j.Closed)
					.Select(j => new Journal
					{
						Name = j.Name
					}).ToList();
				var banks = _dbContext.Banks.Where(b => !(bool)b.Closed)
					.Select(b => new Bank
					{
						Name = b.Name
					}).ToList();
				var accounts = _dbContext.AccountCharts.Where(c => !(bool)c.Closed)
					.Select(c => new AccountChart
					{
						Name = c.Name,
						Code = c.Code
					}).ToList();
				
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						payment,
						venders,
						accounts,
						journals,
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

		public ReturnData<dynamic> GetPayments(VPayment payment)
		{
			try
			{
				var payments = _dbContext.VPayments.Where(p =>
				(string.IsNullOrEmpty(payment.PartnerType) || p.PartnerType.ToUpper().Equals(payment.PartnerType.ToUpper()))
				&& (string.IsNullOrEmpty(payment.Vendor) || p.Vendor.ToUpper().Equals(payment.Vendor.ToUpper()))
				&& (string.IsNullOrEmpty(payment.GlAccount) || p.GlAccount.ToUpper().Equals(payment.GlAccount.ToUpper()))
				&& (string.IsNullOrEmpty(payment.Journal) || p.Journal.ToUpper().Equals(payment.Journal.ToUpper()))
				&& (string.IsNullOrEmpty(payment.BankAccount) || p.BankAccount.ToUpper().Equals(payment.BankAccount.ToUpper()))
				&& (string.IsNullOrEmpty(payment.Personnel) || p.Personnel.ToUpper().Equals(payment.Personnel.ToUpper()))
				).ToList();
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						payments
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

		public ReturnData<dynamic> GetProduct(Guid id)
		{
			try
			{
				var product = _dbContext.VProducts.FirstOrDefault(p => p.Id == id);
				var categories = _dbContext.ProductCategories.Where(p => !(bool)p.Closed)
					.Select(c => new ProductCategory
					{
						Name = c.Name
					}).ToList();
				var types = new string[] { "Consumable", "Service" };
				var taxes = _dbContext.Taxes.Where(t => !(bool)t.Closed)
					.Select(t => new Tax
					{
						Name = t.Name
					}).ToList();
				var accounts = _dbContext.AccountCharts.Where(a => !(bool)a.Closed)
					.Select(a => new AccountChart
					{
						Name = a.Name,
						Code = a.Code
					}).ToList();

				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						product,
						types,
						categories,
						taxes,
						accounts
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

		public ReturnData<dynamic> GetProducts(VProduct vender)
		{
			try
			{
				var products = _dbContext.VProducts.Where(p =>
				(string.IsNullOrEmpty(vender.Name) || p.Name.ToUpper().Equals(vender.Name.ToUpper()))
				&& (string.IsNullOrEmpty(vender.Type) || p.Type.ToUpper().Equals(vender.Type.ToUpper()))
				&& (string.IsNullOrEmpty(vender.Category) || p.Category.ToUpper().Equals(vender.Category.ToUpper()))
				&& (string.IsNullOrEmpty(vender.Personnel) || p.Personnel.ToUpper().Equals(vender.Personnel.ToUpper()))
				).ToList();

				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						products
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

		public ReturnData<dynamic> GetRefund(Guid id)
		{
			try
			{
				var refund = _dbContext.Refunds.FirstOrDefault(r => r.Id == id);
				var venders = _dbContext.Venders.Where(v => !(bool)v.Closed)
					.Select(v => new Vender
					{
						Name = v.Name,
					}).ToList();
				var journals = _dbContext.Journals.Where(j => !(bool)j.Closed)
					.Select(j => new Journal
					{
						Name = j.Name
					}).ToList();
				var banks = _dbContext.Banks.Where(b => !(bool)b.Closed)
					.Select(b => new Bank
					{
						Name = b.Name
					}).ToList();
				var incoTerms = _dbContext.IncoTerms
					.Select(t => new IncoTerm
					{
						Name = t.Name
					}).ToList();
				var products = _dbContext.VProducts.Where(p => !(bool)p.Closed)
					.Select(p => new VProduct
					{
						Name = p.Name
					}).ToList();
				var accounts = _dbContext.AccountCharts.Where(a => !(bool)a.Closed)
					.Select(a => new AccountChart
					{
						Name = a.Name,
						Code = a.Code
					}).ToList();
				var taxes = _dbContext.Taxes.Where(t => !(bool)t.Closed)
					.Select(t => new Tax
					{
						Name = t.Name
					}).ToList();
				var paymentTerms = _dbContext.IPaymentTerms
					.Select(t => new IPaymentTerm
					{
						Term = t.Term
					}).ToList();

				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						refund,
						venders,
						journals,
						banks,
						incoTerms,
						products,
						accounts,
						taxes,
						paymentTerms
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

		public ReturnData<dynamic> GetRefunds(Refund refund)
		{
			try
			{
				var refunds = _dbContext.Refunds.Where(r =>
				 (string.IsNullOrEmpty(refund.Vendor) || r.Vendor.ToUpper().Equals(refund.Vendor.ToUpper()))
				 && (string.IsNullOrEmpty(refund.Journal) || r.Journal.ToUpper().Equals(refund.Journal.ToUpper()))
				 && (string.IsNullOrEmpty(refund.ReceipientBank) || r.ReceipientBank.ToUpper().Equals(refund.ReceipientBank.ToUpper()))
				 && (string.IsNullOrEmpty(refund.Personnel) || r.Personnel.ToUpper().Equals(refund.Personnel.ToUpper()))
					).ToList();

				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						refunds
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

		public ReturnData<dynamic> GetVender(Guid id)
		{
			try
			{
				var vender = _dbContext.Venders.FirstOrDefault(v => v.Id == id);
				var accounts = _dbContext.AccountCharts.Where(a => !(bool)a.Closed)
					.Select(a => new AccountChart
					{
						Name = a.Name,
						Code = a.Code
					}).ToList();
				var banks = _dbContext.Banks.Where(b => !(bool)b.Closed)
					.Select(b => new Bank
					{
						Name = b.Name
					}).ToList();
				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						vender,
						accounts,
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

		public ReturnData<dynamic> GetVenders(Vender vender)
		{
			try
			{
				var venders = _dbContext.Venders.Where(v =>
				(string.IsNullOrEmpty(vender.Name) || v.Name.ToUpper().Equals(vender.Name.ToUpper()))
				&& (string.IsNullOrEmpty(vender.Country) || v.Country.ToUpper().Equals(vender.Country.ToUpper()))
				&& (string.IsNullOrEmpty(vender.Industry) || v.Industry.ToUpper().Equals(vender.Industry.ToUpper()))
				&& (string.IsNullOrEmpty(vender.Bank) || v.Bank.ToUpper().Equals(vender.Bank.ToUpper()))
				).ToList();

				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						venders
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
