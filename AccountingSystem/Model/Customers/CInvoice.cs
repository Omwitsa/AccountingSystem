using System;
using System.Collections.Generic;

namespace AccountingSystem.Model.Customers
{
	public class CInvoice
	{
		public Guid Id { get; set; }
		public string Customer { get; set; }
		public string Ref { get; set; }
		public DateTime? Date { get; set; }
		public DateTime? DueDate { get; set; }
		public string Journal { get; set; }
		public IEnumerable<CInvoiceDetail> CInvoiceDetails { get; set; }
		public IEnumerable<CInvoiceJournal> CInvoiceJournals { get; set; }
		public string SalesPerson { get; set; }
		public string RecipientBank { get; set; }
		public string IncoTerm { get; set; }
		public string FiscalPosition { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
