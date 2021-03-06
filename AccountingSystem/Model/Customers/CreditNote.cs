using System;
using System.Collections.Generic;

namespace AccountingSystem.Model.Customers
{
	public class CreditNote
	{
		public Guid Id { get; set; }
		public string Customer { get; set; }
		public string Ref { get; set; }
		public DateTime? InvoiceDate { get; set; }
		public DateTime? DueDate { get; set; }
		public string Journal { get; set; }
		public string PaymentReference { get; set; }
		public decimal? NetAmount { get; set; }
		public decimal? Tax { get; set; }
		public decimal? TotalAmount { get; set; }
		public decimal? Arrears { get; set; }
		public string Status { get; set; }
		public IEnumerable<CreditNoteDetail> CreditNoteDetails { get; set; }
		public IEnumerable<CreditNoteJournal> CreditNoteJournals { get; set; }
		public string SalesPerson { get; set; }
		public string ReceipientBank { get; set; }
		public string IncoTerm { get; set; }
		public string FiscalPosition { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
