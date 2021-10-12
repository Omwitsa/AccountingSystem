using System;

namespace AccountingSystem.Model.Configuration
{
	public class IPaymentFollowupLevel
	{
		public Guid Id { get; set; }
		public string Level { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
