using System;

namespace AccountingSystem.Model.Accounting
{
	public class LockDate
	{
		public Guid Id { get; set; }
		public DateTime? NonAdvisor { get; set; }
		public DateTime? AllUsers { get; set; }
		public DateTime? Tax { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
