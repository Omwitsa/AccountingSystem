﻿using System;

namespace AccountingSystem.Model.Configuration
{
	public class Tax
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public string Computation { get; set; }
		public string Scope { get; set; }
		public bool? Active { get; set; }
		public string Personnel { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
