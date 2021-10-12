
using System.Collections.Generic;

namespace AccountingSystem.ViewModel
{
	public class GeneralLedgerVm
	{
		public string GlAccount { get; set; }
		public decimal? Debit { get; set; }
		public decimal? Credit { get; set; }
		public decimal? Balance { get; set; }
		public IEnumerable<GeneralLedgerDetailVm> GeneralLedgerDetails { get; set; }
	}
}
