using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystem.IProvider;
using AccountingSystem.Model.Venders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Vendors
{
    public class ListVendorsModel : PageModel
    {
        [BindProperty]
        public List<Vender> Venders { get; set; }
        private IVendersProvider _vendersProvider;
        public ListVendorsModel(IVendersProvider vendersProvider)
        {
            _vendersProvider = vendersProvider;
        }
        public void OnGet()
        {
            var vender = new Vender
            {
                Name = "",
                Industry = "",
                Country = "",
                Bank = ""
            };
            var vendorResp = _vendersProvider.GetVenders(vender);
            Venders = vendorResp.Data;
        }


    }
}
