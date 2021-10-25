using System;
using System.Collections.Generic;

namespace AccountingSystem.Model.Accounting
{
	public class Asset
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal? OriginalValue { get; set; }
		public DateTime? AcquisitionDate { get; set; }
		public decimal? NotDepreciationValue { get; set; }
		public decimal? DepreciationValue { get; set; }
		public decimal? BookValue { get; set; }
		public string DepreciationMethod { get; set; }
		public string DepreciationDuration { get; set; }
		public DateTime? StartDepreciation { get; set; }
		public string AssetGlAccount { get; set; }
		public string DepreciationGlAccount { get; set; }
		public string ExpenseGlAccount { get; set; }
		public string Journal { get; set; }
		// This table is populated automatically based on depreciation Requirements
		public IEnumerable<DepreciationBoard> DepreciationBoards { get; set; }
		public bool? Closed { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
