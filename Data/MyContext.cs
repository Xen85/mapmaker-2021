using System;
using System.Linq;
using Data.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Data
{
    public class MemoryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ForumUser> ForumUsers { get; set; }
        public DbSet<ForumModerator> ForumModerators { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, new[] {InMemoryEventId.ChangesSaved})
                .EnableSensitiveDataLogging()
                .UseInMemoryDatabase("UserContext");
        }
    }


}