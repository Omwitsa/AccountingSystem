using System;

namespace AccountingSystem.Model.Configuration
{
	public class AccountChart
	{
		public Guid Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public bool? AllowReconciliation { get; set; }
		public string DefaultTax { get; set; }
		public string AllowJournal { get; set; }
		public string Tag { get; set; }
		public bool? Closed { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
