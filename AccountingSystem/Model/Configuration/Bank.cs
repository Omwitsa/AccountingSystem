using System;

namespace AccountingSystem.Model.Configuration
{
	public class Bank
	{
		public Guid Id { get; set; }
		public string AccNo { get; set; }
		public string Name { get; set; }
		public string IdentifierCode { get; set; }
		public bool? Closed { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
