using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystem.Model.Accounting
{
	public class JournalEntry
	{
		public Guid Id { get; set; }
		public DateTime? Date { get; set; }
		public string No { get; set; }
		public string Partner { get; set; }
		public string Ref { get; set; }
		public string Journal { get; set; }
		public decimal? Total { get; set; }
		public string Status { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
