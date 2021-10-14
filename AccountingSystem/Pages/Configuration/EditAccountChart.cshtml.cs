using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystem.IProvider;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
    public class EditAccountChartModel : PageModel
    {
        private IConfigurationProvider _configurationProvider;
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public string[] AccountTypes { get; set; }
        public EditAccountChartModel(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        public void OnGet(Guid id)
        {
			var response = _configurationProvider.GetAccountChart(id);
			AccountTypes = new string[] { "Assets", "Liabilities", "Equity" };
			var va = "";
		}

        public IActionResult OnPost()
        {
			var account = new AccountChart
			{
				Code = Request.Form["code"],
				Name = Request.Form["name"],
				Type = Request.Form["type"],
				//AllowReconciliation = Request.Form["type"],
				DefaultTax = "",
				AllowJournal = "",
				Tag = "",
				//Closed = Request.Form["type"],
				Personnel = ""
			};

			var response = _configurationProvider.AddAccountChart(account, false);
			if (!response.Success)
			{
				Success = response.Success;
				Message = response.Message;
				return Page();
			}
			return RedirectToPage("./ListAccountCharts");
        }
    }
}
