using System;
using System.Collections.Generic;

namespace AccountingSystem.Model.Accounting
{
	public class DefferredExpense
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public decimal? OriginalAmount { get; set; }
		public DateTime? AcquisitionDate { get; set; }
		public decimal? ResidualAmount { get; set; }
		public decimal? DefferredAmount { get; set; }
		public string RecognitionMonths { get; set; }
		public string RecognitionYears { get; set; }
		public DateTime? FirstRecognitionDate { get; set; }
		public string ExpenseGlAccount { get; set; }
		public string DeferredGlAccount { get; set; }
		public string Journal { get; set; }
		public IEnumerable<ExpenseBoard> ExpenseBoards { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
