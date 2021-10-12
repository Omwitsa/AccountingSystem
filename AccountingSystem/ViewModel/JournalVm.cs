using System;

namespace AccountingSystem.ViewModel
{
	public class JournalVm
	{
		public DateTime? Date { get; set; }
		public string Entry { get; set; }
		public string GlAccount { get; set; }
		public string Partner { get; set; }
		public string Ref { get; set; }
		public string Label { get; set; }
		public DateTime? DueDate { get; set; }
		public decimal? Debit { get; set; }
		public decimal? Credit { get; set; }
		public decimal? Balance { get; set; }
		public string Tax { get; set; }
	}
}
