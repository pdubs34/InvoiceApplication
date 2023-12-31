﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
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

        public DbSet<Item>? Item { get; set; }

        public DbSet<Invoice>? Invoice { get; set; }

        public DbSet<InvoiceItem>? InvoiceItem { get; set; }

        public DbSet<Store>? Store { get; set; }


        public DbSet<DayData>? DayData { get; set; }
    }
}
