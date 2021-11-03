using System;

namespace AccountingSystem.Model.Customers
{
	public class CPayment
	{
		public Guid Id { get; set; }
		public string Customer { get; set; }
		public string GlAccount { get; set; }
		public bool? IsInternalTransfer { get; set; }
		public decimal? Amount { get; set; }
		public DateTime? Date { get; set; }
		public string Memo { get; set; }
		public string Journal { get; set; }
		public string BankAccount { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
