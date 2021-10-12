using System;

namespace AccountingSystem.Model.System
{
	public class Audit
	{
		public Guid Id { get; set; }
		public string UserName { get; set; }
		public DateTime? Date { get; set; }
		public string Reference { get; set; }
		public string ModuleId { get; set; }
	}
}
