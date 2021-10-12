using System;

namespace AccountingSystem.Model.Venders
{
	public class VPayment
	{
		public Guid Id { get; set; }
		public bool? IsPayable { get; set; }
		public bool? IsReceivable { get; set; }
		public string PartnerType { get; set; }
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
