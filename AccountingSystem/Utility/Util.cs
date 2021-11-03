using AccountingSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingSystem.Utility
{
	public class Util
	{
		public string GetRef(string refNo, string suffix)
		{
			if (string.IsNullOrEmpty(refNo))
			{
				refNo = $"{suffix}1";
				return refNo;
			}
			var currentRef = Convert.ToInt32(refNo.Substring(suffix.Length)) + 1;
			refNo = $"{suffix}{currentRef}";
			return refNo;
		}
	}
}
