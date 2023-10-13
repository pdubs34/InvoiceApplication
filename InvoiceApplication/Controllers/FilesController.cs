using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;

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
                    // Process the uploaded PDF file here
                    string fileName = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    // Additional processing if needed

                    // Parse the PDF file
                    string text = ParsePdfFile(path);

                    return RedirectToAction("ShowString", new { givenText = text });
                }
                else
                {
                    // Invalid file type
                    ModelState.AddModelError("file", "The uploaded file must be a PDF.");
                }
            }

            return View();
        }

        private string ParsePdfFile(string filePath)
        {
            using (var reader = new PdfReader(filePath))
            {
                var text = new StringBuilder();
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    var strategy = new SimpleTextExtractionStrategy();
                    var currentText = PdfTextExtractor.GetTextFromPage(reader, page, strategy);
                    text.Append(currentText);
                }
                return text.ToString();
            }
        }
        public IActionResult ShowString(string givenText)
        {
            ViewBag.GivenText = givenText;
            return View();
        }
    }
}

