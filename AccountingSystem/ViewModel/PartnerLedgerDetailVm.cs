using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystem.ViewModel
{
	public class PartnerLedgerDetailVm
	{
		public DateTime? Date { get; set; }
		public string Entry { get; set; }
		public string Account { get; set; }
		public string Label { get; set; }
		public DateTime? DueDate { get; set; }
		public decimal? Debit { get; set; }
		public decimal? Credit { get; set; }
		public decimal? Balance { get; set; }
		public decimal? CummulatedBalance { get; set; }
	}
}
