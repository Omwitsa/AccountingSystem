using System;

namespace AccountingSystem.Model.Configuration
{
	public class Setting
	{
		public Guid Id { get; set; }
		public string SalesTax { get; set; }
		public string PurchaseTax { get; set; }
		public string Periodicity { get; set; }
		public int Reminder { get; set; }
		public string Journal { get; set; }
		public RoundingMethod RoundingMethod { get; set; }
		public string FiscalCountry { get; set; }
		public string MainCurrency { get; set; }
		public string MultiCurrency { get; set; }
		public string FiscalPeriod { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}

	public enum RoundingMethod
	{
		PerLine = 1,
		Globally = 2
	}
}
