using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using AccountingSystem.Data;
using AccountingSystem.Model.Customers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using iTextSharp.tool.xml;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Document = iTextSharp.text.Document;

namespace AccountingSystem.Pages.Reporting
{
    public class InvoiceReportModel : PageModel
    {
        private AccountingSystemContext _dbContext;
        [BindProperty]
        public List<CInvoice> Invoices { get; set; }
        [BindProperty]
        public CInvoice Invoice { get; set; }
        [BindProperty]
        public bool Success { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public InvoiceReportModel(AccountingSystemContext dbContext)
        {
            _dbContext = dbContext;
            Success = true;
            Invoice = new CInvoice();
        }
        public IActionResult OnGet()
        {
            try
            {
                Invoices = _dbContext.CInvoices.ToList();
                return Page();
            }
            catch (Exception ex)
            {
                Success = false;
                Message = "Sorry, An error occurred";
                return Page();
            }
        }
        //public FileResult Export(string GridHtml)
        //{
        //    using (MemoryStream stream = new System.IO.MemoryStream())
        //    {
        //        StringReader sr = new StringReader(GridHtml);
        //        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
        //        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
        //        pdfDoc.Open();
        //        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
        //        pdfDoc.Close();
        //        return File(stream.ToArray(), "application/pdf", "StudentDetails.pdf");
        //    }
        //}
        public IActionResult OnPost()
        {
            try
            {
                Invoices = _dbContext.CInvoices
                    .Where(b => (string.IsNullOrEmpty(Invoice.Customer) || b.Customer.ToUpper().Equals(Invoice.Customer.ToUpper()))
                    && (string.IsNullOrEmpty(Invoice.Journal) || b.Journal.ToUpper().Equals(Invoice.Journal.ToUpper()))
                    && (string.IsNullOrEmpty(Invoice.RecipientBank) || b.RecipientBank.ToUpper().Equals(Invoice.RecipientBank.ToUpper()))
                    && (string.IsNullOrEmpty(Invoice.IncoTerm) || b.IncoTerm.ToUpper().Equals(Invoice.IncoTerm.ToUpper()))
                    && (string.IsNullOrEmpty(Invoice.FiscalPosition) || b.FiscalPosition.ToUpper().Equals(Invoice.FiscalPosition.ToUpper()))
                    && (string.IsNullOrEmpty(Invoice.Personnel) || b.Personnel.ToUpper().Equals(Invoice.Personnel.ToUpper()))
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

            return RedirectToPage("./EditCustomerInvoice", new { id = id });
        }

        public IActionResult OnPostDelete(Guid id)
        {
            return Page();
        }

        public void OnPostView(Guid id)
        {
        }
    }
}
