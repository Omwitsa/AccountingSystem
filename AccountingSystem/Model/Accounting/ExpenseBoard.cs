using System;

namespace AccountingSystem.Model.Accounting
{
	public class ExpenseBoard
	{
		public Guid Id { get; set; }
		public Guid? DefferredExpenseId { get; set; }
		public string Ref { get; set; }
		public DateTime? ExpenseDate { get; set; }
		public decimal? Expense { get; set; }
		public decimal? CummulativeExpense { get; set; }
		public decimal? NextPeriodExpense { get; set; }
		public string JournalEntry { get; set; }
	}
}
