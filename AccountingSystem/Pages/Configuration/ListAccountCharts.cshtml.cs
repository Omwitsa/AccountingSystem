using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystem.IProvider;
using AccountingSystem.Model.Configuration;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Configuration
{
    public class ListAccountChartsModel : PageModel
    {
        [BindProperty]
        public List<AccountChart> AccountCharts { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        private IConfigurationProvider _configurationProvider;
        public ListAccountChartsModel(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }
        public void OnGet()
        {
            var account = new AccountChart
            {
                Code = "",
                Name = "",
                Type = "",
                AllowReconciliation = false,
                DefaultTax = "",
                AllowJournal = "",
                Tag = "",
                Closed = false,
                Personnel = ""
            };

            var response = _configurationProvider.GetAccountCharts(account);
            if (response.Success)
                AccountCharts = response.Data;
            else
            {
                Success = response.Success;
                Message = response.Message;
            }
        }

        public void OnPost()
        {
            Message = "Form Posted";
        }

        public IActionResult OnPostEdit(Guid id)
        {

            return RedirectToPage("./EditAccountChart", new { id = id });
        }

        public void OnPostDelete(Guid id)
        {
            
        }

        public IActionResult OnPostView(Guid id)
        {
            return RedirectToPage("./Index");
        }
    }
}
