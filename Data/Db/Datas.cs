// **********
// MapMaker2021 - Datas.cs
// **********

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Db
{
    [EntityTypeConfiguration(typeof(BookConfiguration))]
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
    }

    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual List<Invoice> Invoices { get; set; }
    }

    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")] public virtual Customer Customer { get; set; }

        public virtual List<InvoiceItem> Items { get; set; }
    }
   [EntityTypeConfiguration(typeof(UserConfiguration))]
    public class User
    {
        [Key] public int Id { get; set; }

        [Required] public string Username { get; set; }
    }

    public class ForumUser
    {
        [Key] public int Id { get; set; }

        public string Username { get; set; }
    }

    public class ForumModerator : ForumUser
    {
        public string ForumName { get; set; }
    }

    public class InvoiceItem
    {
        [Key] public int InvoiceItemId { get; set; }

        public int InvoiceId { get; set; }
        public string Code { get; set; }

        [ForeignKey("InvoiceId")] public virtual Invoice Invoice { get; set; }
    }
}