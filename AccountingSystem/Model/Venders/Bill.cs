using System;

using System.Collections.Generic;

namespace AccountingSystem.Model.Venders
{
	public class Bill
	{
		public Guid Id { get; set; }
		public string No { get; set; }
		public string Vender { get; set; }
		public string Ref { get; set; }
		public string Quantity { get; set; }
		public string remarks { get; set; }
		public DateTime? Date { get; set; }
		public DateTime? DueDate { get; set; }
		public string Journal { get; set; }
		public IEnumerable<BillDetail> BillDetails { get; set; }
		public IEnumerable<BillJournal> BillJournals { get; set; }
		public string RecipientBank { get; set; }
		public string IncoTerm { get; set; }
		public string FiscalPosition { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
