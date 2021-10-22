using System;
using System.Collections.Generic;

namespace AccountingSystem.Model.Venders
{
	public class Refund
	{
		public Guid Id { get; set; }
		public string BillRef { get; set; }
		public string Vendor { get; set; }
		public string Ref { get; set; }
		public DateTime? BillDate { get; set; }
		public DateTime? DueDate { get; set; }
		public string Journal { get; set; }
		public IEnumerable<RefundDetail> RefundDetails { get; set; }
		public IEnumerable<RefundJournal> RefundJournals { get; set; }
		public string ReceipientBank { get; set; }
		public string IncoTerm { get; set; }
		public string FiscalPosition { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
