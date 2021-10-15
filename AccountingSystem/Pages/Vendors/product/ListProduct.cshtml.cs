using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSystem.IProvider;
using AccountingSystem.Model.Venders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Vendors.product
{
    public class ListProductModel : PageModel
    {
        [BindProperty]
        public List<VProduct> Products { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        private IVendersProvider _vendersProvider;
        public ListProductModel(IVendersProvider vendersProvider)
        {
            _vendersProvider = vendersProvider;
        }
        public void OnGet()
        {
            var product = new VProduct
            {
                Ref = "",
                Name = "",
                Price=0,
                CustomerTax = "",
                VenderTax="",
            };
            var productresps = _vendersProvider.GetProducts(product);
            if (productresps.Success)
                Products = productresps.Data;
            else
            {
                Success = productresps.Success;
                Message = productresps.Message;
            }

        }
    }
}
