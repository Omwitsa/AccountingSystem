using System;

namespace AccountingSystem.Model.Accounting
{
	public class DepreciationBoard
	{
		public Guid Id { get; set; }
		public Guid? AssetId { get; set; }
		public string Ref { get; set; }
		public DateTime? DepreciationDate { get; set; }
		public decimal? Depreciation { get; set; }
		public decimal? CumulativeDepreciation { get; set; }
		public decimal? DepreciableValue { get; set; }
		public string journalEntry { get; set; }
	}
}
