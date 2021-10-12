using System;

namespace AccountingSystem.Model.Configuration
{
	public class IPaymentTerm
	{
		public Guid Id { get; set; }
		public string Term { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
