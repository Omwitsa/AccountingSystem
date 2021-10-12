using System;

namespace AccountingSystem.Model.Accounting
{
	public class OriginalAccount
	{
		public Guid Id { get; set; }
		public Guid? AutoTransferId { get; set; }
		public string Code { get; set; }
		public string GlAccount { get; set; }
		public string GlAccountType { get; set; }
	}
}
