using System;
using System.Collections.Generic;

namespace AccountingSystem.ViewModel
{
	public class JournalVm
	{
		public string Key { get; set; }
		public string Ref { get; set; }
		public DateTime? Date { get; set; }
		public decimal? Debit { get; set; }
		public decimal? Credit { get; set; }
		public List<JournalDetailsVm> Details { get; set; }
	}

	public class JournalDetailsVm
	{
		public DateTime? Date { get; set; }
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
