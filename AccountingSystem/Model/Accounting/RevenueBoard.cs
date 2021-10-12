using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystem.Model.Accounting
{
	public class RevenueBoard
	{
		public Guid Id { get; set; }
		public Guid? DefferredRevenueId { get; set; }
		public string Ref { get; set; }
		public DateTime? RevenueDate { get; set; }
		public decimal? Revenue { get; set; }
		public decimal? CummulativeRevenue { get; set; }
		public decimal? NextPeriodRevenue { get; set; }
		public string JournalEntry { get; set; }
	}
}
