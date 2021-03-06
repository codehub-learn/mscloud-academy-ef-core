﻿using CrmAzure.Model;
using Microsoft.EntityFrameworkCore;

namespace CrmAzure.Data
{
    public class CrmAzureDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    "Server=tcp:<server-name>.database.windows.net,1433;Initial Catalog=CrmAzure;Persist Security Info=False;" +
                    "User ID=<your-username>;Password=<pass>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>();

            modelBuilder.Entity<Customer>()
                .Property(c => c.FirstName)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.LastName)
                .IsRequired();

            modelBuilder.Entity<Order>();

            modelBuilder.Entity<Product>();

            // works on EF Core 5.0
            //modelBuilder.Entity<Order>().HasMany(o => o.Products).WitMany()

            // Many-to-many: works on EF Core 3.x
            modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.OrderId, op.ProductId });
        }
    }
}
