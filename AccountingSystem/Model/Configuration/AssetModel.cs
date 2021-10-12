using System;

namespace AccountingSystem.Model.Configuration
{
	public class AssetModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string GlAccount { get; set; }
		public string DepreciationMethod { get; set; }
		public string DepreciationDuration { get; set; }
		public string DepreciationGlAccount { get; set; }
		public string ExpenseGlAccount { get; set; }
		public string Journal { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
