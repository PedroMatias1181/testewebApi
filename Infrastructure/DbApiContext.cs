using FirstExercice.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstExercice.Infrastructure
{
    public class DbApiContext : DbContext
    {
        public DbApiContext(DbContextOptions<DbApiContext> options) : base(options)
        {
            if (Customers.Count() == 0)
            {
                AddTestData(this);
            }
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        private static void AddTestData(DbApiContext context)
        {
            List<Customer> customers = new List<Customer>();
            List<Invoice> invoices = new List<Invoice>();
            List<InvoiceItem> InvoiceItens = new List<InvoiceItem>();
            customers.Add(new Customer
            {
                CustomerId = 1,
                FirstName = "Kyran ",
                LastName = "McIntosh",
                Address = "16 Foregate Street HOLTON",
                Contact = "+4407863090208"
            });
            invoices.Add(new Invoice
            {
                Id = 1,
                CustomerId = 1,
                Date = DateTime.UtcNow.AddDays(-5),
                InvoiceCode = "201910001"
            });
            InvoiceItens.Add(new InvoiceItem
            {
                InvoiceItemId = 1,
                InvoiceId = 1,
                Code = "N9TT-9G0A-B7FQ-RANC",
                Price = 3,
                Quantity = 4
            });
            invoices.Add(new Invoice
            {
                Id = 2,
                CustomerId = 1,
                Date = DateTime.UtcNow.AddDays(-10),
                InvoiceCode = "201909001"
            });
            InvoiceItens.Add(new InvoiceItem
            {
                InvoiceItemId = 2,
                InvoiceId = 2,
                Code = "7EIQ-72IU-2YNV-3L4Y",
                Price = 5,
                Quantity = 2
            });
            customers.Add(new Customer
            {
                CustomerId = 2,
                FirstName = "Guy",
                LastName = "Cunningham",
                Address = "22 Consett Rd HILLEND",
                Contact = "+4407762495196"
            });
            invoices.Add(new Invoice
            {
                Id = 3,
                CustomerId = 2,
                Date = DateTime.UtcNow.AddDays(-10),
                InvoiceCode = "201909002"
            });
            InvoiceItens.Add(new InvoiceItem
            {
                InvoiceItemId = 3,
                InvoiceId = 3,
                Code = "N9TT-9G0A-B7FQ-RANC",
                Price = 10,
                Quantity = 1
            });
            customers.Add(new Customer
            {
                CustomerId = 3,
                FirstName = "Jared",
                LastName = "Hay",
                Address = "25 Brynglas Road GLENEAGLES",
                Contact = "+4407818499336"
            });
            invoices.Add(new Invoice
            {
                Id = 4,
                CustomerId = 3,
                Date = DateTime.UtcNow.AddDays(-2),
                InvoiceCode = "201910002"
            });
            InvoiceItens.Add(new InvoiceItem
            {
                InvoiceItemId = 4,
                InvoiceId = 4,
                Code = "6ETI-UIL2-9WAX-XHYO",
                Price = 15,
                Quantity = 2
            });

            context.Customers.AddRange(customers);
            context.Invoices.AddRange(invoices);
            context.InvoiceItems.AddRange(InvoiceItens);
            context.SaveChanges();
        }
    }

}
