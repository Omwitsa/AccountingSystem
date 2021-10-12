using System;

namespace AccountingSystem.Model.Configuration
{
	public class ReconciliationModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string Journal { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
