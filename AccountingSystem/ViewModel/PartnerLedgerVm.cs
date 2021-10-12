using System.Collections.Generic;

namespace AccountingSystem.ViewModel
{
	public class PartnerLedgerVm
	{
		public string Partner { get; set; }
		public decimal? Debit { get; set; }
		public decimal? Credit { get; set; }
		public decimal? Balance { get; set; }
		public IEnumerable<PartnerLedgerDetailVm> PartnerLedgerDetails { get; set; }
	}
}
