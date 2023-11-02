using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InvoiceApplication.Models;

namespace InvoiceApplication.Data
{
    public class InvoiceApplicationContext : DbContext
    {
        public InvoiceApplicationContext (DbContextOptions<InvoiceApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<InvoiceApplication.Models.User> User { get; set; } = default!;

        public DbSet<InvoiceApplication.Models.Item>? Item { get; set; }

        public DbSet<InvoiceApplication.Models.Invoice>? Invoice { get; set; }

        public DbSet<InvoiceApplication.Models.InvoiceItem>? InvoiceItem { get; set; }

        public DbSet<InvoiceApplication.Models.DayData>? DayData { get; set; }

        public DbSet<InvoiceApplication.Models.Store>? Store { get; set; }
    }
}
