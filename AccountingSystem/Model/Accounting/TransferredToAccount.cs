using System;

namespace AccountingSystem.Model.Accounting
{
	public class TransferredToAccount
	{
		public Guid Id { get; set; }
		public Guid? AutoTransferId { get; set; }
		public string Percentage { get; set; }
		public string Partner { get; set; }
		public string GlAccount { get; set; }
	}
}
