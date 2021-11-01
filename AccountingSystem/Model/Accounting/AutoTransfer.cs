using System;
using System.Collections.Generic;

namespace AccountingSystem.Model.Accounting
{
	public class AutoTransfer
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public DateTime? From { get; set; }
		public DateTime? To { get; set; }
		public string Journal { get; set; }
		public string Frequency { get; set; }
		public IEnumerable<OriginalAccount> OriginalAccounts { get; set; }
		public IEnumerable<TransferredToAccount> TransferredToAccounts { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
