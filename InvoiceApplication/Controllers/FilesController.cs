using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;
using InvoiceApplication.ViewModels;
using InvoiceApplication.Models;
using InvoiceApplication.Services;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace InvoiceApplication.Controllers
{
    public class FilesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                if (System.IO.Path.GetExtension(file.FileName).ToLower() == ".pdf" && file.ContentType == "application/pdf")
                {
                    using var stream = file.OpenReadStream();

                    // Create a StringBuilder to store the extracted text
                    var output = new StringBuilder();

                    // Create a PdfReader
                    using (var reader = new PdfReader(stream))
                    {
                        for (int page = 1; page <= reader.NumberOfPages; page++)
                        {
                            var strategy = new SimpleTextExtractionStrategy();
                            var currentText = PdfTextExtractor.GetTextFromPage(reader, page, strategy);
                            output.Append(currentText);
                        }
                    }

                    // Process the extracted text as needed

                    string givenText = output.ToString();
                    DataProcessor handleData = new DataProcessor(givenText);
                    string tempText = handleData.ProcessData();

                    return RedirectToAction("ShowString", new { givenText = tempText });
                }
                else
                {
                    // Invalid file type
                    ModelState.AddModelError("file", "The uploaded file must be a PDF.");
                }
            }

            return View();
        }
        public IActionResult ShowString(string givenText)
        {
            PDFViewModel model = new PDFViewModel(givenText);
            return View(model);
        }

    }
}

