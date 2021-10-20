using System;
using System.Collections.Generic;
using System.Linq;
using AccountingSystem.Data;
using AccountingSystem.Model.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccountingSystem.Pages.Customers
{
	public class ListCustomerModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<Customer> Customers { get; set; }
        [BindProperty]
        public Customer Customer { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public ListCustomerModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            Customer = new Customer();
        }
        public IActionResult OnGet()
        {
            try
            {
                Customers = _dbContext.Customers.ToList();
                return Page();
            }
            catch (Exception ex)
            {
                Success = false;
                Message = "Sorry, An error occurred";
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                Customers = _dbContext.Customers.Where(v =>
                (string.IsNullOrEmpty(Customer.Name) || v.Name.ToUpper().Equals(Customer.Name.ToUpper()))
                && (string.IsNullOrEmpty(Customer.Country) || v.Country.ToUpper().Equals(Customer.Country.ToUpper()))
                && (string.IsNullOrEmpty(Customer.Bank) || v.Bank.ToUpper().Equals(Customer.Bank.ToUpper()))
                ).ToList();
                return Page();
            }
            catch (Exception ex)
            {
                Success = false;
                Message = "Sorry, An error occurred";
                return Page();
            }
        }

        public IActionResult OnPostEdit(Guid id)
        {

            return RedirectToPage("./EditCustomer", new { id = id });
        }

        public IActionResult OnPostDelete(Guid id)
        {
            try
            {
                var customer = _dbContext.Customers.FirstOrDefault(v => v.Id == id);
                if (customer == null)
				{
                    Success = false;
                    Message = "Sorry, Customer not found";
                    return Page();
                }
                    
                customer.Name = customer?.Name ?? "";
                if (_dbContext.CInvoices.Any(b => b.Customer.ToUpper().Equals(customer.Name.ToUpper())))
				{
                    Success = false;
                    Message = "Sorry, Customer already invoiced. Can't be deleted";
                    return Page();
                }
                   
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges();
                Success = true;
                Message = "Customer deleted successfully";
                return Page();
            }
            catch (Exception ex)
            {
                Success = false;
                Message = "Sorry, An error occurred";
                return Page();
            }
        }

        public void OnPostView(Guid id)
        {
        }
    }
}
