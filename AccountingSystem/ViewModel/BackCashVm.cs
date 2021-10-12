using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystem.ViewModel
{
	public class BackCashVm
	{
		public string GlAccount { get; set; }
		public string Partner { get; set; }
		public string Ref { get; set; }
		public string Label { get; set; }
		public decimal? Debit { get; set; }
		public decimal? Credit { get; set; }
	}
}
