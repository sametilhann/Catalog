using Catalog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data
{
    public class EGMCatalogDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public EGMCatalogDbContext(DbContextOptions<EGMCatalogDbContext> options) : base(options)
        {

        }
        //Güvenlik nedeniyle connection string kod içerisinde verilmemeli.
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=EGMSampleDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Name)
                                          .IsRequired()
                                          .HasMaxLength(250);

            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Elektronik" },
                new Category { Id = 2, Name = "Kırtasiye" }
            );

            var sampleDate = new DateTime(2025, 10, 15);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id=1,Name="Dell",CategoryId=1,Description="Dell XPS 15",CreatedDate=sampleDate,Price=10,Rating=4.6,StockCount=100},
                new Product { Id = 2, Name = "A4 Defter", CategoryId = 2, Description = "Harita Metod", CreatedDate = sampleDate, Price = 15, Rating = 4.9, StockCount = 100 }
                );
        }
    }
}
