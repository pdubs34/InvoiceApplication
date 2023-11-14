using InvoiceApplication.Data;
using InvoiceApplication.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApplication.Services
{
    public class DataProcessor
    {
        private readonly InvoiceApplicationContext _context;
        private string Data;
        public DataProcessor(InvoiceApplicationContext context)
        {
            _context = context;
            Data = string.Empty;
        }

        public DataProcessor() {
            Data = string.Empty;
        }
        public DataProcessor(string data)
        {
            Data = data;
        }
        public async Task ProcessData(string pdfData)
        {
            Store insertedStore = new Store("hello", "dog");
            await AddStoreToDB(insertedStore);
        }

        public async Task AddStoreToDB(Store store)
        {
            if (store != null)
            {
                _context.Store.Add(store);
            }
            
            await _context.SaveChangesAsync();
        }
    }
}
