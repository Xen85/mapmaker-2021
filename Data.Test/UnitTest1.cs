using System;
using System.Collections.Generic;
using System.Linq;
using Data.Db;
using NUnit.Framework;

namespace Data.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void Test2()
        {
            using var context = new MemoryContext();

            context.Add(new Book());

            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType().FullName}: {e.Message}");
            }

            Console.WriteLine();

            Assert.Pass();
        }

        [Test]
        public void Test4()
        {
            using var context = new MemoryContext();

            context.Add(new Customer
            {
                Address = "address", CustomerId = 1, FirstName = "ciccio", LastName = "caio",
                Invoices = new List<Invoice>
                {
                    new()
                    {
                        Date = new DateTime(), Id = 1, CustomerId = 1,
                        Items = new List<InvoiceItem> {new() {Code = "0", InvoiceId = 1, InvoiceItemId = 1}}
                    }
                }
            });

            context.SaveChanges();
            var s = context.Customers.Find(1);

            Assert.True(s != null);

            var customer =
                context
                    .Customers
                    .AsQueryable()
                    .First(c => c.Address == "address");
            Assert.AreEqual(s, customer);
            
            customer =
                context
                    .Customers
                    .AsQueryable()
                    .First(c => c.Invoices.First().Id == 1);
            Assert.AreEqual(s, customer);

            var invoice = context.Invoices.Find(1);
            
            Assert.AreEqual(s.Invoices.First(), invoice);
            
            
            
            Console.WriteLine();
            Assert.Pass();
        }
    }
}