using System;

namespace AccountingSystem.Model.Configuration
{
	public class ProductCategory
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string ParentCategory { get; set; }
		public string IncomeGlAccount { get; set; }
		public string ExpenseGlAccount { get; set; }
		public bool? Closed { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
