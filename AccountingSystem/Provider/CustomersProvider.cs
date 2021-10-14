using AccountingSystem.IProvider;
using AccountingSystem.Model;
using AccountingSystem.Model.Configuration;
using AccountingSystem.Model.Customers;
using AccountingSystem.Model.System;
using AccountingSystem.Model.Venders;
using AccountingSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

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
			try
			{
				note.CreatedDate = DateTime.UtcNow.AddHours(3);
				note.ModifiedDate = DateTime.UtcNow.AddHours(3);
				if (string.IsNullOrEmpty(note.Customer))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide customer"
					};

				if (string.IsNullOrEmpty(note.Journal))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide journal"
					};
				if (!note.CreditNoteDetails.Any())
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide invoice items"
					};
				foreach (var detail in note.CreditNoteDetails)
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
				var reference = "Add Credit note";
				if (isEdit)
				{
					reference = "Edit Credit note";
					var savedNote = _dbContext.CreditNotes.FirstOrDefault(b => b.Id == note.Id);
					note.CreatedDate = savedNote.CreatedDate;
					if (savedNote != null)
					{
						var details = _dbContext.CreditNoteDetails.Where(b => b.CreditNoteId == savedNote.Id);
						if (details.Any())
							_dbContext.CreditNoteDetails.RemoveRange(details);
						var journals = _dbContext.CreditNoteJournals.Where(b => b.CreditNoteId == savedNote.Id);
						if (journals.Any())
							_dbContext.CreditNoteJournals.RemoveRange(journals);
						_dbContext.CreditNotes.Remove(savedNote);
					}
				}
				_dbContext.Audits.Add(new Audit
				{
					UserName = note.Personnel,
					Date = DateTime.UtcNow.AddHours(3),
					Reference = reference,
					ModuleId = "Customer"
				});

				_dbContext.CreditNotes.Add(note);
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Credit note saved successfully"
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

		public ReturnData<string> AddCustomer(Customer customer, bool isEdit)
		{
			try
			{
				if (string.IsNullOrEmpty(customer.Name))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide customer"
					};
				if (string.IsNullOrEmpty(customer.APGlAccount))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide account payable"
					};
				if (string.IsNullOrEmpty(customer.ARGlAccount))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide account receivable"
					};
				customer.CreatedDate = DateTime.UtcNow.AddHours(3);
				customer.ModifiedDate = DateTime.UtcNow.AddHours(3);
				customer.Closed = customer?.Closed ?? false;
				if (isEdit)
				{
					var savedCustomer = _dbContext.Customers.FirstOrDefault(v => v.Id == customer.Id);
					savedCustomer.Name = customer.Name;
					savedCustomer.Street1 = customer.Street1;
					savedCustomer.Street2 = customer.Street2;
					savedCustomer.City = customer.City;
					savedCustomer.Country = customer.Country;
					savedCustomer.PhoneNo = customer.PhoneNo;
					savedCustomer.Mobile = customer.Mobile;
					savedCustomer.Email = customer.Email;
					savedCustomer.WebSite = customer.WebSite;
					savedCustomer.SalesPerson = customer.SalesPerson;
					savedCustomer.PurchasePaymentTerms = customer.PurchasePaymentTerms;
					savedCustomer.SalesPaymentTerms = customer.SalesPaymentTerms;
					savedCustomer.FiscalPosition = customer.FiscalPosition;
					savedCustomer.APGlAccount = customer.APGlAccount;
					savedCustomer.ARGlAccount = customer.ARGlAccount;
					savedCustomer.Bank = customer.Bank;
					savedCustomer.Notes = customer.Notes;
					savedCustomer.Closed = customer.Closed;
					savedCustomer.Personnel = customer.Personnel;
					savedCustomer.ModifiedDate = DateTime.UtcNow.AddHours(3);
				}
				else
				{
					if (_dbContext.Customers.Any(v => v.Name.ToUpper().Equals(customer.Name.ToUpper())))
						return new ReturnData<string>
						{
							Success = false,
							Message = "Sorry, Customer already exist"
						};
					_dbContext.Customers.Add(customer);
				}
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = false,
					Message = "Customer saved successfully"
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

		public ReturnData<string> AddInvoice(CInvoice invoice, bool isEdit)
		{
			try
			{
				invoice.CreatedDate = DateTime.UtcNow.AddHours(3);
				invoice.ModifiedDate = DateTime.UtcNow.AddHours(3);
				invoice.Date = DateTime.UtcNow.AddHours(3);
				if (string.IsNullOrEmpty(invoice.Customer))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide customer"
					};

				if (string.IsNullOrEmpty(invoice.Journal))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide journal"
					};
				if (!invoice.CInvoiceDetails.Any())
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Kindly provide invoice items"
					};
				foreach (var detail in invoice.CInvoiceDetails)
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
				var reference = "Add Invoice";
				if (isEdit)
				{
					reference = "Edit invoice";
					var savedInvoice = _dbContext.CInvoices.FirstOrDefault(b => b.Id == invoice.Id);
					invoice.CreatedDate = savedInvoice.CreatedDate;
					if (savedInvoice != null)
					{
						var details = _dbContext.CInvoiceDetails.Where(b => b.CInvoiceId == savedInvoice.Id);
						if (details.Any())
							_dbContext.CInvoiceDetails.RemoveRange(details);
						var journals = _dbContext.CInvoiceJournal.Where(b => b.CInvoiceId == savedInvoice.Id);
						if (journals.Any())
							_dbContext.CInvoiceJournal.RemoveRange(journals);
						_dbContext.CInvoices.Remove(savedInvoice);
					}
				}
				_dbContext.Audits.Add(new Audit
				{
					UserName = invoice.Personnel,
					Date = DateTime.UtcNow.AddHours(3),
					Reference = reference,
					ModuleId = "Customer"
				});

				_dbContext.CInvoices.Add(invoice);
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Invoice saved successfully"
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

		public ReturnData<string> AddPayment(CPayment payment, bool isEdit)
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
				if (string.IsNullOrEmpty(payment.Customer))
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
					var savedPayment = _dbContext.CPayments.FirstOrDefault(p => p.Id == payment.Id);
					savedPayment.ModifiedDate = DateTime.UtcNow.AddHours(3);
					savedPayment.IsPayable = payment.IsPayable;
					savedPayment.IsReceivable = payment.IsReceivable;
					savedPayment.PartnerType = payment.PartnerType;
					savedPayment.Customer = payment.Customer;
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
					_dbContext.CPayments.Add(payment);
				}

				_dbContext.Audits.Add(new Audit
				{
					UserName = payment.Personnel,
					Date = DateTime.UtcNow.AddHours(3),
					Reference = reference,
					ModuleId = "Customer"
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

		public ReturnData<string> AddProduct(CProduct product, bool isEdit)
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
					var savedProduct = _dbContext.CProducts.FirstOrDefault(p => p.Id == product.Id);
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
					_dbContext.CProducts.Add(product);
				}
				_dbContext.Audits.Add(new Audit
				{
					UserName = product.Personnel,
					Date = DateTime.UtcNow.AddHours(3),
					Reference = reference,
					ModuleId = "Customer"
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

		public ReturnData<string> DeleteCustomer(Guid id)
		{
			try
			{
				var customer = _dbContext.Customers.FirstOrDefault(v => v.Id == id);
				if (customer == null)
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Customer not found"
					};
				customer.Name = customer?.Name ?? "";
				if (_dbContext.CInvoices.Any(b => b.Customer.ToUpper().Equals(customer.Name.ToUpper())))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Customer already invoiced. Can't be deleted"
					};
				_dbContext.Customers.Remove(customer);
				_dbContext.SaveChanges();
				return new ReturnData<string>
				{
					Success = true,
					Message = "Customer deleted successfully"
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
				var product = _dbContext.CProducts.FirstOrDefault(p => p.Id == id);
				if (product == null)
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, Product not found"
					};
				product.Name = product?.Name ?? "";
				if (_dbContext.CInvoiceDetails.Any(b => b.Product.ToUpper().Equals(product.Name.ToUpper())))
					return new ReturnData<string>
					{
						Success = false,
						Message = "Sorry, the product has already been invoiced. It can't be deleted"
					};
				_dbContext.CProducts.Remove(product);
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

		public ReturnData<dynamic> GetCreditNote(Guid id)
		{
			try
			{
				var creditNote = _dbContext.CreditNotes.FirstOrDefault(r => r.Id == id);
				var customers = _dbContext.Customers.Where(v => !(bool)v.Closed)
					.Select(v => new Customer
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
				var products = _dbContext.CProducts.Where(p => !(bool)p.Closed)
					.Select(p => new CProduct
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
						creditNote,
						customers,
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

		public ReturnData<dynamic> GetCreditNotes(CreditNote note)
		{
			try
			{
				var creditNotes = _dbContext.CreditNotes.Where(r =>
				 (string.IsNullOrEmpty(note.Customer) || r.Customer.ToUpper().Equals(note.Customer.ToUpper()))
				 && (string.IsNullOrEmpty(note.Journal) || r.Journal.ToUpper().Equals(note.Journal.ToUpper()))
				 && (string.IsNullOrEmpty(note.ReceipientBank) || r.ReceipientBank.ToUpper().Equals(note.ReceipientBank.ToUpper()))
				 && (string.IsNullOrEmpty(note.Personnel) || r.Personnel.ToUpper().Equals(note.Personnel.ToUpper()))
					).ToList();

				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						creditNotes
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

		public ReturnData<dynamic> GetCustomer(Guid id)
		{
			try
			{
				var customer = _dbContext.Customers.FirstOrDefault(v => v.Id == id);
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
						customer,
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

		public ReturnData<List<Customer>> GetCustomers(Customer customer)
		{
			try
			{
				var customers = _dbContext.Customers.Where(v =>
				(string.IsNullOrEmpty(customer.Name) || v.Name.ToUpper().Equals(customer.Name.ToUpper()))
				&& (string.IsNullOrEmpty(customer.Country) || v.Country.ToUpper().Equals(customer.Country.ToUpper()))
				&& (string.IsNullOrEmpty(customer.Bank) || v.Bank.ToUpper().Equals(customer.Bank.ToUpper()))
				).ToList();

				return new ReturnData<List<Customer>>
				{
					Success = true,
					Data = customers
				};
			}
			catch (Exception ex)
			{
				return new ReturnData<List<Customer>>
				{
					Success = false,
					Message = "Sorry, An error occurred"
				};
			}
		}

		public ReturnData<dynamic> GetInvoice(Guid id)
		{
			try
			{
				var invoice = _dbContext.CInvoices.FirstOrDefault(b => b.Id == id);
				var customers = _dbContext.Customers.Where(v => !(bool)v.Closed)
					.Select(v => new Customer
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
				var products = _dbContext.CProducts.Where(p => !(bool)p.Closed)
					.Select(p => new CProduct
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
						invoice,
						customers,
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

		public ReturnData<dynamic> GetInvoices(CInvoice invoice)
		{
			try
			{
				var invoices = _dbContext.CInvoices
					.Where(b => (string.IsNullOrEmpty(invoice.Customer) || b.Customer.ToUpper().Equals(invoice.Customer.ToUpper()))
					&& (string.IsNullOrEmpty(invoice.Journal) || b.Journal.ToUpper().Equals(invoice.Journal.ToUpper()))
					&& (string.IsNullOrEmpty(invoice.RecipientBank) || b.RecipientBank.ToUpper().Equals(invoice.RecipientBank.ToUpper()))
					&& (string.IsNullOrEmpty(invoice.IncoTerm) || b.IncoTerm.ToUpper().Equals(invoice.IncoTerm.ToUpper()))
					&& (string.IsNullOrEmpty(invoice.FiscalPosition) || b.FiscalPosition.ToUpper().Equals(invoice.FiscalPosition.ToUpper()))
					&& (string.IsNullOrEmpty(invoice.Personnel) || b.Personnel.ToUpper().Equals(invoice.Personnel.ToUpper()))
					).ToList();

				return new ReturnData<dynamic>
				{
					Success = true,
					Data = new
					{
						invoices
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
				var payment = _dbContext.CPayments.FirstOrDefault(p => p.Id == id);
				var customers = _dbContext.Customers.Where(c => !(bool)c.Closed)
					.Select(c => new Customer
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
						customers,
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

		public ReturnData<dynamic> GetPayments(CPayment payment)
		{
			try
			{
				var payments = _dbContext.CPayments.Where(p =>
				(string.IsNullOrEmpty(payment.PartnerType) || p.PartnerType.ToUpper().Equals(payment.PartnerType.ToUpper()))
				&& (string.IsNullOrEmpty(payment.Customer) || p.Customer.ToUpper().Equals(payment.Customer.ToUpper()))
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
				var product = _dbContext.CProducts.FirstOrDefault(p => p.Id == id);
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

		public ReturnData<dynamic> GetProducts(CProduct product)
		{
			try
			{
				var products = _dbContext.CProducts.Where(p =>
				(string.IsNullOrEmpty(product.Name) || p.Name.ToUpper().Equals(product.Name.ToUpper()))
				&& (string.IsNullOrEmpty(product.Type) || p.Type.ToUpper().Equals(product.Type.ToUpper()))
				&& (string.IsNullOrEmpty(product.Category) || p.Category.ToUpper().Equals(product.Category.ToUpper()))
				&& (string.IsNullOrEmpty(product.Personnel) || p.Personnel.ToUpper().Equals(product.Personnel.ToUpper()))
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
	}
}
