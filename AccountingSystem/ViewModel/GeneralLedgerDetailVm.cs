using System;

namespace AccountingSystem.ViewModel
{
	public class GeneralLedgerDetailVm
	{
		public DateTime? Date { get; set; }
		public string Entry { get; set; }
		public string Partner { get; set; }
		public string Label { get; set; }
		public decimal? Debit { get; set; }
		public decimal? Credit { get; set; }
		public decimal? Balance { get; set; }
		public decimal? CumulatedBalance { get; set; }
	}
}
